import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { AuthState, AuthTokens, AuthUser } from "./auth.contracts";
import { localStorageGetObject, localStorageSetData } from "../../core/utilities/localstorage";

const TOKEN_KEY: string = "bntu_token";

const initialState: AuthState = {
    authorized: localStorageGetObject<AuthTokens>(TOKEN_KEY) != null,
    user: null,
    tokens: localStorageGetObject<AuthTokens>(TOKEN_KEY)
}

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        logout: (state) => {
            localStorageSetData(TOKEN_KEY, "")
            state = initialState
        },
        login: (state, action: PayloadAction<AuthTokens>) => {
            localStorageSetData(TOKEN_KEY, action.payload)
            state.authorized = true
        },
        setUser: (state, action: PayloadAction<AuthUser>) => {
            state.user = action.payload
        }
    },
    extraReducers: {}
})

export const { logout, login, setUser } = authSlice.actions

export default authSlice.reducer