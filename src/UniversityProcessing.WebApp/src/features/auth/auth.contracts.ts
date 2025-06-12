import { AuthInfoResponse, ContractsToken, ContractsUserRoleType } from 'src/api/backendApi';

export type AuthTokens = {
  accessToken?: ContractsToken;
  refreshToken?: ContractsToken;
}

export type AuthState = {
  authorized: boolean,
  user: AuthInfoResponse | null,
  tokens: AuthTokens | null
}