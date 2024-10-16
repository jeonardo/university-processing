import { BaseQueryFn, createApi, FetchArgs, fetchBaseQuery, FetchBaseQueryError } from '@reduxjs/toolkit/query/react'
import { Mutex } from 'async-mutex';
import { RootState } from '../core/store';
import { login, logout } from 'src/features/authentication/auth.slice';
import { ENV } from '../core/env';
import { RefreshResponseDto } from './backendApi';

const mutex = new Mutex()

const baseQuery = fetchBaseQuery({
    baseUrl: ENV.VITE_BACKEND_BASEURL,
    prepareHeaders: (headers, { getState }) => {

        const token = (getState() as RootState).auth.tokens

        if (token?.accessToken) {
            headers.set('authorization', `Bearer ${token.accessToken.value}`)
        }

        return headers
    }
})

const baseQueryWithReauth: BaseQueryFn<
    string | FetchArgs,
    unknown,
    FetchBaseQueryError
> = async (args, api, extraOptions) => {

    await mutex.waitForUnlock()

    let result = await baseQuery(args, api, extraOptions)

    if (!result.error || result.error.status != 401)
        return result

    if (mutex.isLocked()) {
        await mutex.waitForUnlock()
        result = await baseQuery(args, api, extraOptions)
        return result
    }

    const release = await mutex.acquire()

    try {
        const refreshResult = await baseQuery('/api/v1/Identity/Refresh', api, extraOptions)

        if (refreshResult.error || !refreshResult.data) {
            api.dispatch(logout())
        }
        else {
            const refreshContent: RefreshResponseDto = refreshResult.data
            api.dispatch(login({ accessToken: refreshContent.accessToken, refreshToken: refreshContent.refreshToken }))
            result = await baseQuery(args, api, extraOptions)
        }
    }
    finally {
        release()
    }

    return result
}

export const emptySplitApi = createApi({
    baseQuery: baseQueryWithReauth,
    endpoints: () => ({}),
})