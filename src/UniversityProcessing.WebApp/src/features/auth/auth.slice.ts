import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AuthState, AuthTokens } from './auth.contracts';
import { ClearAuthTokens, GetAuthTokens, SetAuthTokens } from 'src/core/localStorageToken';
import { AuthInfoResponse } from 'src/api/backendApi';

const initialState: AuthState = {
  authorized: !!GetAuthTokens()?.accessToken,
  user: null,
  tokens: GetAuthTokens()
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state: AuthState) => {
      ClearAuthTokens();
      state.authorized = false;
      state.user = null;
    },
    login: (state: AuthState, action: PayloadAction<AuthTokens>) => {
      SetAuthTokens(action.payload);
      state.authorized = true;
    },
    setUser: (state: AuthState, action: PayloadAction<AuthInfoResponse>) => {
      state.user = action.payload;
    }
  }
});

export const { logout, login, setUser } = authSlice.actions;

export default authSlice.reducer;