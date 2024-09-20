import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {AuthState, AuthTokens, AuthUser} from "./auth.contracts";
import {localStorageGetObject, localStorageSetData} from "src/core/localStorage";

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
            state.authorized = false
            state.user = null
            state.tokens = null
        },
        login: (state, action: PayloadAction<AuthTokens>) => {
            console.log(action.payload)
            localStorageSetData(TOKEN_KEY, action.payload)
            state.authorized = true
        },
        setUser: (state, action: PayloadAction<AuthUser>) => {
            state.user = action.payload
        }
    }
})

export const {logout, login, setUser} = authSlice.actions

export default authSlice.reducer