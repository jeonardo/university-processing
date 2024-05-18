import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import {axiosInstance} from "../../core/axiosInstance";
import {LoginRequestDto} from "./types/LoginRequestDto";
import {TokenDto} from "./types/TokenDto";
import {AxiosResponse} from "axios";
import {RegisterRequestDto} from "./types/RegisterRequestDto";
import {AuthState} from "./AuthState";
import {localStorageGetObject, localStorageSetData} from "../../core/utilities/localstorage";
import {TokenData} from "./types/TokenData";
import {ENV} from "../../env";
import {Status} from "../../core/common/Status";
import {jwtDecode, JwtPayload} from "jwt-decode";

const getUserTokenData = (): TokenData | null => {
    const token = getTokenLocalStorage()

    if (token == null)
        return null

    try {
        const decodedToken = jwtDecode<JwtPayload>(token.Value, {header: true});
        console.log(decodedToken)
        const userTokenData: TokenData = {email_: "", id_: "", userName_: ""} // JSON.parse(decodedToken as string);
        return userTokenData
    } catch (error) {
        if (ENV.VITE_IS_DEVELOPMENT)
            console.log("Token decoding exception", error)
        return null
    }
}

export const getTokenLocalStorage = (): TokenDto | null => localStorageGetObject<TokenDto>("bntu_token")
export const setTokenLocalStorage = (req: TokenDto): boolean => localStorageSetData("bntu_token", req)
export const resetTokenLocalStorage = (): boolean => localStorageSetData("bntu_token", "")

const initialState: AuthState = {
    isAuthenticated: getTokenLocalStorage() ? true : false,
    tokenData: getUserTokenData(),
    status: Status.NONE,
    error: null,
};

export const refresh = createAsyncThunk(
    "refresh",
    async ({}, {rejectWithValue}) => {
        const token = getTokenLocalStorage()

        if (token == null)
            return false

        return await axiosInstance
            .post('api/v1/Identity/Refresh', token)
            .then((res: AxiosResponse<TokenDto>) => {
                setTokenLocalStorage(res.data)
                return true
            })
            .catch((err) => rejectWithValue(err.response.data))
    });

export const login = createAsyncThunk(
    "login",
    async (req: LoginRequestDto, {rejectWithValue}) =>
        await axiosInstance
            .post("api/v1/Identity/Login", req)
            .then((res: AxiosResponse<TokenDto>) => {
                setTokenLocalStorage(res.data)
                return true
            })
            .catch((err) => rejectWithValue(err.response.data))
);

export const register = createAsyncThunk(
    "register",
    async (req: RegisterRequestDto, {rejectWithValue}) =>
        await axiosInstance
            .post("api/v1/Identity/Register", req)
            .then(() => true)
            .catch((err) => rejectWithValue(err.response.data))
);

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {},
    extraReducers: {},
    // (builder) => {
    //   builder
    //     .addCase(login.pending, (state) => {
    //       state.status = "loading";
    //       state.error = null;
    //     });
    // },
});

export default authSlice.reducer;