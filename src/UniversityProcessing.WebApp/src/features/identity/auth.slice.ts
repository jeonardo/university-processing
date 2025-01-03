import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AuthState, AuthTokens, AuthUser } from './auth.contracts';
import { ClearAuthTokens, GetAuthTokens, SetAuthTokens } from 'src/core/localStorageToken';

const initialState: AuthState = {
  authorized: GetAuthTokens() != null,
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
      state.tokens = null;
    },
    login: (state: AuthState, action: PayloadAction<AuthTokens>) => {
      SetAuthTokens(action.payload);
      state.authorized = true;
      state.tokens = action.payload;
    },
    setUser: (state: AuthState, action: PayloadAction<AuthUser>) => {
      state.user = action.payload;
    }
  }
});

export const { logout, login, setUser } = authSlice.actions;

export default authSlice.reducer;