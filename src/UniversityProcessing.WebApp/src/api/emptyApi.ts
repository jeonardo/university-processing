import { BaseQueryFn, createApi, FetchArgs, fetchBaseQuery, FetchBaseQueryError } from '@reduxjs/toolkit/query/react';
import { Mutex } from 'async-mutex';
import { RootState } from '../core/store';
import { login, logout } from 'src/features/auth/auth.slice';
import { appEnv } from '../core/appEnv';
import { AuthRefreshResponse } from './backendApi';
import { GetAuthTokens } from 'src/core/localStorageToken';

const mutex = new Mutex();

const baseQuery = fetchBaseQuery({
  baseUrl: appEnv.VITE_BACKEND_BASEURL,
  prepareHeaders: (headers, { getState }) => {
    const stateToken = (getState() as RootState).auth.tokens?.accessToken;
    const localToken = GetAuthTokens()?.accessToken;
    const token = stateToken || localToken;

    if (token) {
      headers.set('authorization', `Bearer ${token}`);
    }

    return headers;
  }
});

const baseQueryWithReauth: BaseQueryFn<
  string | FetchArgs,
  unknown,
  FetchBaseQueryError
> = async (args, api, extraOptions) => {
  // Wait for any pending mutex lock to be released
  await mutex.waitForUnlock();

  let result = await baseQuery(args, api, extraOptions);

  // If the request succeeded or the error is not 401, return the result
  if (!result.error || result.error.status !== 401) {
    return result;
  }

  // If we're already waiting for a token refresh, wait for it to complete
  if (mutex.isLocked()) {
    await mutex.waitForUnlock();
    return await baseQuery(args, api, extraOptions);
  }

  // Acquire mutex lock to prevent multiple simultaneous token refresh attempts
  const release = await mutex.acquire();

  try {
    const state = api.getState() as RootState;
    const stateTokens = state.auth.tokens || undefined;
    const localTokens = GetAuthTokens() || undefined;
    const accessToken = stateTokens?.accessToken || localTokens?.accessToken || '';
    const refreshToken = stateTokens?.refreshToken || localTokens?.refreshToken || '';

    // Attempt to refresh the token
    const refreshResult = await baseQuery({
      url: '/api/Auth/Refresh',
      method: 'POST',
      body: {
        accessToken,
        refreshToken
      }
    }, api, extraOptions);

    if (refreshResult.error || !refreshResult.data) {
      // Refresh failed - logout user
      api.dispatch(logout());
    } else {
      // Refresh succeeded - update tokens and retry original request
      const refreshData = refreshResult.data as AuthRefreshResponse;
      api.dispatch(login({
        accessToken: refreshData.accessToken ?? '',
        refreshToken: refreshData.refreshToken ?? ''
      }));

      // Retry the original request with the new token.
      // Remove any old headers from args so that prepareHeaders can set fresh Authorization.
      const retryArgs: string | FetchArgs = typeof args === 'string'
        ? args
        : (() => {
          const { headers: _oldHeaders, ...rest } = args as FetchArgs;
          return { ...rest } as FetchArgs;
        })();
      result = await baseQuery(retryArgs, api, extraOptions);
    }
  } finally {
    // Always release the mutex lock
    release();
  }

  return result;
};

export const emptySplitApi = createApi({
  baseQuery: baseQueryWithReauth,
  endpoints: () => ({}),
  tagTypes: [] // Add any tag types used for caching if applicable
});