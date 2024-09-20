import {TokenDto, UserRoleIdDto} from "../../api/backendApi";

export type AuthTokens = {
    accessToken?: TokenDto;
    refreshToken?: TokenDto;
}

export type AuthUser = {
    userId?: string;
    roleId?: UserRoleIdDto;
    approved?: boolean;
}

export type AuthState = {
    authorized: boolean,
    user: AuthUser | null,
    tokens: AuthTokens | null
}