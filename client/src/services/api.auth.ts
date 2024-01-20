import { instance } from "../api/api.config"

export interface ILogin {
    password: string;
    email: string;
}

const login = ({ email, password }: ILogin) => {
    return instance.post("/api/login", { email, password })
}

const refreshToken = () => {
    return instance.get("/api/refresh");
}

const logout = () => {
    return instance.post("/api/logout")
}

const AuthService = {
    refreshToken,
    login,
    logout
};

export default AuthService;