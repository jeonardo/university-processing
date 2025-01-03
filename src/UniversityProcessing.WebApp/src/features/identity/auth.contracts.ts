import { UniversityProcessingApiEndpointsContractsTokenDto, UniversityProcessingAPIEndpointsContractsUserRoleTypeDto } from '../../api/backendApi';

export type AuthTokens = {
  accessToken?: UniversityProcessingApiEndpointsContractsTokenDto;
  refreshToken?: UniversityProcessingApiEndpointsContractsTokenDto;
}

export type AuthUser = {
  userId?: string;
  roleId?: UniversityProcessingAPIEndpointsContractsUserRoleTypeDto;
  approved?: boolean;
  email?: string;
  userName?: string;
}

export type AuthState = {
  authorized: boolean,
  user: AuthUser | null,
  tokens: AuthTokens | null
}