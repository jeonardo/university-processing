import { ContractsUserRoleType } from 'src/api/backendApi';

export type AuthTokens = {
  accessToken?: string;
  refreshToken?: string;
}

export type AuthState = {
  authorized: boolean,
  user: AuthUser | null,
  tokens?: AuthTokens | null,
}

export type AuthUser = {
  userId?: string;
  role?: ContractsUserRoleType | null;
  approved?: boolean;
  blocked?: boolean;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  userName?: string | null;
  faculty?: string | null;
  department?: string | null;
  email?: string | null;
  position?: string | null;
  phoneNumber?: string | null;
  speciality?: string | null;
  groupNumber?: string | null;
};