import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import { axiosInstance } from "../../core/axiosInstance";
import { LoginRequest } from "./types/LoginRequest";
import { Result } from "../../core/common/Result";
import { Token } from "./types/Token";
import { AxiosResponse } from "axios";
import { RegisterRequest } from "./types/RegisterRequest";
import { AuthState } from "./types/AuthState";
import { localStorageGetObject, localStorageSetData } from "../../core/utilities/localstorage";
import { UserTokenData } from "./types/UserTokenData";
import { ENV } from "../../env";
import { Status } from "../../core/common/Status";

const getUserTokenData = (): UserTokenData | null => {
  const token = getTokenLocalStorage()

  if (token == null)
    return null

  try {
    const decodedToken = {  } //decode(token.Value)
    const userTokenData: UserTokenData = JSON.parse(decodedToken as string);
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
  basicUserInfo: getUserTokenData(),
  status: Status.NONE,
  error: null,
};

export const refresh = createAsyncThunk("refresh", async (): Promise<Result> => {
  const token = getTokenLocalStorage()

  if (token == null)
    return Result.Fail();

  const result = await axiosInstance
    .post('refresh', token)
    .then((res: AxiosResponse<Token>) => {
      setTokenLocalStorage(res.data)
      return Result.Success();
    })
    .catch((res: AxiosResponse) => {
      return Result.Fail()
    })

  return result;
});

export const login = createAsyncThunk("login", async (req: LoginRequest): Promise<Result> =>
  await axiosInstance
    .post("/login", req)
    .then((res: AxiosResponse<Token>) => {
      setTokenLocalStorage(res.data)
      return Result.Success()
    })
    .catch((res: AxiosResponse) => {
      return Result.Fail()
    })
);

export const register = createAsyncThunk("register", async (req: RegisterRequest): Promise<Result> =>
  await axiosInstance
    .post("/register", req)
    .then((res: AxiosResponse) => {
      return Result.Success()
    })
    .catch((res: AxiosResponse) => {
      return Result.Fail()
    })
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