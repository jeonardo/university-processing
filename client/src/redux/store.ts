import { Action, ThunkAction, configureStore } from '@reduxjs/toolkit'
import counterReducer from './slices/counter/counterSlice'
import authReducer from './slices/auth.slice'
import userReducer from './slices/user.slice'
import initialReducer from './slices/initial.slice'

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    auth: authReducer,
    user: userReducer,
    initialSlice: initialReducer
  }
})

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;