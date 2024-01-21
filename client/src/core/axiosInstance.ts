import axios from "axios";
import { ENV } from "../env";
import { getTokenLocalStorage } from "../features/authentication/auth.slice";

export const axiosInstance = axios.create({
  withCredentials: true,
  baseURL: ENV.VITE_BACKEND_BASEURL,
});

axiosInstance.interceptors.request.use(
  (config) => {
    const token = getTokenLocalStorage()
    config.headers.Authorization = `Bearer ${token == null ? "" : token.Value}`
    return config
  }
)
// TODO
// axiosInstance.interceptors.response.use(
//   (config) => {
//     return config;
//   },
//   async (error) => {
//    const originalRequest = {...error.config};
//    originalRequest._isRetry = true; 
//     if (
//       error.response.status === 401 
//       && error.config 
//       && !error.config._isRetry
//     ) {
//       try {
//         const resp = await axiosInstance.get("/api/refresh");
//         localStorage.setItem("token", resp.data.accessToken);
//         return axiosInstance.request(originalRequest);
//       } catch (error) {
//         console.log("AUTH ERROR");
//       }
//     }
//     throw error;
//   }
// );