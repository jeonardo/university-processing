import axios from "axios";
import { ENV } from "../env";
import AuthActions, { getTokens } from "../features/authentication/auth.actions";

export const httpClient = axios.create({
    baseURL: ENV.VITE_BACKEND_BASEURL
});

httpClient.interceptors.request.use(
    (config) => {
        const token = getTokens()
        config.headers.Authorization = `Bearer ${token == null ? "" : token.accessToken.Value}`
        return config
    }
)

httpClient.interceptors.response.use(
    (config) => {
        return config;
    },
    async (error) => {
        const originalRequest = { ...error.config };
        originalRequest._isRetry = true;

        if (
            error.response.status === 401
            && error.config
            && !error.config._isRetry
        ) {
            try {
                AuthActions.refresh();
                return httpClient.request(originalRequest);
            } catch (error) {
                console.log("AUTH ERROR");
            }
        }

        throw error;
    }
);