import axios from "axios";
import { ENV } from "../env";

// Create an Axios instance with default options
const axiosInstance = axios.create({
  baseURL: ENV.VITE_BACKEND_BASEURL,
  withCredentials: true,
});

export default axiosInstance;