import { ContractsToken, ContractsUserRoleType } from 'src/api/backendApi';

export type AuthTokens = {
  accessToken?: ContractsToken;
  refreshToken?: ContractsToken;
}

export type AuthUser = {
  userId?: string;
  role?: ContractsUserRoleType;
  approved?: boolean;
  email?: string;
  userName?: string;
}

export type AuthState = {
  authorized: boolean,
  user: AuthUser | null,
  tokens: AuthTokens | null
}