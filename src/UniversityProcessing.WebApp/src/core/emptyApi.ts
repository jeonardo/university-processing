import {BaseQueryFn, createApi, FetchArgs, fetchBaseQuery, FetchBaseQueryError} from '@reduxjs/toolkit/query/react'
import {Mutex} from 'async-mutex';
import {useAppDispatch} from './hooks';
import {RootState} from './store';
import {useGetApiV1IdentityRefreshQuery} from 'src/api/backendApi';
import {login, logout} from 'src/features/authentication/auth.slice';
import {ENV} from './env';

// create a new mutex
const mutex = new Mutex()

const baseQuery = fetchBaseQuery({
    baseUrl: ENV.VITE_BACKEND_BASEURL,
    prepareHeaders: (headers, {getState}) => {
        const token = (getState() as RootState).auth.tokens
        if (token) {
            headers.set('authorization', `Bearer ${token?.accessToken?.value}`)
        }

        return headers
    }
})

const baseQueryWithReauth: BaseQueryFn<
    string | FetchArgs,
    unknown,
    FetchBaseQueryError
> = async (args, api, extraOptions) => {

    // wait until the mutex is available without locking it
    await mutex.waitForUnlock()
    let result = await baseQuery(args, api, extraOptions)

    if (result.error && result.error.status === 401) {
        // checking whether the mutex is locked
        if (!mutex.isLocked()) {
            const release = await mutex.acquire()
            try {
                const dispatch = useAppDispatch()
                const {data, isError} = useGetApiV1IdentityRefreshQuery()

                if (isError || data == undefined || data.accessToken || data.refreshToken) {
                    dispatch(logout())
                } else {
                    dispatch(login({accessToken: data.accessToken, refreshToken: data.refreshToken}))
                    result = await baseQuery(args, api, extraOptions)
                }
            } finally {
                // release must be called once the mutex should be released again.
                release()
            }
        } else {
            // wait until the mutex is available without locking it
            await mutex.waitForUnlock()
            result = await baseQuery(args, api, extraOptions)
        }
    }

    return result
}

// initialize an empty api service that we'll inject endpoints into later as needed
export const emptySplitApi = createApi({
    baseQuery: baseQueryWithReauth,
    endpoints: () => ({}),
})