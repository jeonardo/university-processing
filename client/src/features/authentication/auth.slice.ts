import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { axiosInstance } from "../../core/axiosInstance";
import { LoginRequest } from "./signin/LoginRequest";
import { Token } from "./types/Token";
import axios, { AxiosResponse } from "axios";
import { RegisterRequest } from "./signup/RegisterRequest";
import { AuthState } from "./AuthState";
import { localStorageGetObject, localStorageSetData } from "../../core/utilities/localstorage";
import { TokenData } from "./types/TokenData";
import { ENV } from "../../env";
import { Status } from "../../core/common/Status";
import { JwtPayload, jwtDecode } from "jwt-decode";

const getUserTokenData = (): TokenData | null => {
  const token = getTokenLocalStorage()

  if (token == null)
    return null

  try {
    const decodedToken = jwtDecode<JwtPayload>(token.Value, { header: true });
    console.log(decodedToken)
    const userTokenData: TokenData = { email_: "", id_: "", userName_: "" } // JSON.parse(decodedToken as string);
    return userTokenData
  } catch (error) {
    if (ENV.VITE_IS_DEVELOPMENT)
      console.log("Token decoding exception", error)
    return null
  }
}

export const getTokenLocalStorage = (): Token | null => localStorageGetObject<Token>("bntu_token")
export const setTokenLocalStorage = (req: Token): boolean => localStorageSetData("bntu_token", req)
export const resetTokenLocalStorage = (): boolean => localStorageSetData("bntu_token", "")

const initialState: AuthState = {
  isAuthenticated: getTokenLocalStorage() ? true : false,
  tokenData: getUserTokenData(),
  status: Status.NONE,
  error: null,
};

export const refresh = createAsyncThunk(
  "refresh", 
  async ({}, { rejectWithValue }) => {
  const token = getTokenLocalStorage()

  if (token == null)
    return false

    return await axiosInstance
    .post('api/Identity/refresh', token)
    .then((res: AxiosResponse<Token>) => {
      setTokenLocalStorage(res.data)
      return true
    })
    .catch((err) => rejectWithValue(err.response.data))
});

export const login = createAsyncThunk(
  "login", 
  async (req: LoginRequest, { rejectWithValue }) =>
  await axiosInstance
    .post("api/Identity/login", req)
    .then((res: AxiosResponse<Token>) => {
      setTokenLocalStorage(res.data)
      return true
    })
    .catch((err) => rejectWithValue(err.response.data))
);

export const register = createAsyncThunk(
  "register",
  async (req: RegisterRequest, { rejectWithValue }) =>
    await axiosInstance
      .post("api/Identity/register", req)
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