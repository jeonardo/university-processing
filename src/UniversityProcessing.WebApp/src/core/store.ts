import { Action, configureStore, ThunkAction } from '@reduxjs/toolkit'
import authReducer from '../features/authentication/auth.slice'
import messageReducer from '../features/message/message.slice'
import { backendApi } from '../apis/backendApi'
import { setupListeners } from '@reduxjs/toolkit/query'

export const store = configureStore({
    reducer: {
        auth: authReducer,
        [backendApi.reducerPath]: backendApi.reducer,
        message: messageReducer
    },
    // Adding the api middleware enables caching, invalidation, polling,
    // and other useful features of `rtk-query`.
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(backendApi.middleware),
    devTools: process.env.NODE_ENV === 'development'
})

// optional, but required for refetchOnFocus/refetchOnReconnect behaviors
// see `setupListeners` docs - takes an optional callback as the 2nd arg for customization
setupListeners(store.dispatch)

export default store

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
    ReturnType,
    RootState,
    unknown,
    Action<string>
>;