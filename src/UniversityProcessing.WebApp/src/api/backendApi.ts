import { emptySplitApi as api } from "./emptyApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    postApiAuthRegistrationRegisterTeacher: build.mutation<
      PostApiAuthRegistrationRegisterTeacherApiResponse,
      PostApiAuthRegistrationRegisterTeacherApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Register/Teacher`,
        method: "POST",
        body: queryArg.authRegistrationRegisterTeacherRequest,
      }),
    }),
    postApiAuthRegistrationRegisterStudent: build.mutation<
      PostApiAuthRegistrationRegisterStudentApiResponse,
      PostApiAuthRegistrationRegisterStudentApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Register/Student`,
        method: "POST",
        body: queryArg.authRegistrationRegisterStudentRequest,
      }),
    }),
    postApiAuthRegistrationRegisterDeanery: build.mutation<
      PostApiAuthRegistrationRegisterDeaneryApiResponse,
      PostApiAuthRegistrationRegisterDeaneryApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Register/Deanery`,
        method: "POST",
        body: queryArg.authRegistrationRegisterDeaneryRequest,
      }),
    }),
    postApiAuthRegistrationRegisterAdmin: build.mutation<
      PostApiAuthRegistrationRegisterAdminApiResponse,
      PostApiAuthRegistrationRegisterAdminApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Register/Admin`,
        method: "POST",
        body: queryArg.authRegistrationRegisterAdminRequest,
      }),
    }),
    getApiAuthRegistrationGetAvailableUniversityPositions: build.query<
      GetApiAuthRegistrationGetAvailableUniversityPositionsApiResponse,
      GetApiAuthRegistrationGetAvailableUniversityPositionsApiArg
    >({
      query: () => ({
        url: `/api/Auth/Registration/GetAvailableUniversityPositions`,
      }),
    }),
    getApiAuthRegistrationGetAvailableGroups: build.query<
      GetApiAuthRegistrationGetAvailableGroupsApiResponse,
      GetApiAuthRegistrationGetAvailableGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/GetAvailableGroups`,
        params: {
          Number: queryArg["number"],
        },
      }),
    }),
    getApiAuthRegistrationGetAvailableFaculties: build.query<
      GetApiAuthRegistrationGetAvailableFacultiesApiResponse,
      GetApiAuthRegistrationGetAvailableFacultiesApiArg
    >({
      query: () => ({ url: `/api/Auth/Registration/GetAvailableFaculties` }),
    }),
    getApiAuthRegistrationGetAvailableDepartments: build.query<
      GetApiAuthRegistrationGetAvailableDepartmentsApiResponse,
      GetApiAuthRegistrationGetAvailableDepartmentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/GetAvailableDepartments`,
        params: {
          FacultyId: queryArg.facultyId,
        },
      }),
    }),
    getApiAuthRefresh: build.query<
      GetApiAuthRefreshApiResponse,
      GetApiAuthRefreshApiArg
    >({
      query: () => ({ url: `/api/Auth/Refresh` }),
    }),
    postApiAuthLogout: build.mutation<
      PostApiAuthLogoutApiResponse,
      PostApiAuthLogoutApiArg
    >({
      query: () => ({ url: `/api/Auth/Logout`, method: "POST" }),
    }),
    postApiAuthLogin: build.mutation<
      PostApiAuthLoginApiResponse,
      PostApiAuthLoginApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Login`,
        method: "POST",
        body: queryArg.authLoginRequest,
      }),
    }),
    getApiAuthInfo: build.query<
      GetApiAuthInfoApiResponse,
      GetApiAuthInfoApiArg
    >({
      query: () => ({ url: `/api/Auth/Info` }),
    }),
    postApiAuthChangePassword: build.mutation<
      PostApiAuthChangePasswordApiResponse,
      PostApiAuthChangePasswordApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/ChangePassword`,
        method: "POST",
        body: queryArg.authChangePasswordRequest,
      }),
    }),
    putApiIdentityUpdateVerification: build.mutation<
      PutApiIdentityUpdateVerificationApiResponse,
      PutApiIdentityUpdateVerificationApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Identity/UpdateVerification`,
        method: "PUT",
        body: queryArg.identityUpdateVerificationRequest,
      }),
    }),
    putApiIdentityUpdateBlocking: build.mutation<
      PutApiIdentityUpdateBlockingApiResponse,
      PutApiIdentityUpdateBlockingApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Identity/UpdateBlocking`,
        method: "PUT",
        body: queryArg.identityUpdateBlockingRequest,
      }),
    }),
  }),
  overrideExisting: false,
});
export { injectedRtkApi as backendApi };
export type PostApiAuthRegistrationRegisterTeacherApiResponse =
  /** status 200 OK */ AuthRegistrationRegisterResponse;
export type PostApiAuthRegistrationRegisterTeacherApiArg = {
  authRegistrationRegisterTeacherRequest: AuthRegistrationRegisterTeacherRequest;
};
export type PostApiAuthRegistrationRegisterStudentApiResponse =
  /** status 200 OK */ AuthRegistrationRegisterResponse;
export type PostApiAuthRegistrationRegisterStudentApiArg = {
  authRegistrationRegisterStudentRequest: AuthRegistrationRegisterStudentRequest;
};
export type PostApiAuthRegistrationRegisterDeaneryApiResponse =
  /** status 200 OK */ AuthRegistrationRegisterResponse;
export type PostApiAuthRegistrationRegisterDeaneryApiArg = {
  authRegistrationRegisterDeaneryRequest: AuthRegistrationRegisterDeaneryRequest;
};
export type PostApiAuthRegistrationRegisterAdminApiResponse =
  /** status 200 OK */ AuthRegistrationRegisterResponse;
export type PostApiAuthRegistrationRegisterAdminApiArg = {
  authRegistrationRegisterAdminRequest: AuthRegistrationRegisterAdminRequest;
};
export type GetApiAuthRegistrationGetAvailableUniversityPositionsApiResponse =
  /** status 200 OK */ AuthRegistrationGetAvailableUniversityPositionsResponse;
export type GetApiAuthRegistrationGetAvailableUniversityPositionsApiArg = void;
export type GetApiAuthRegistrationGetAvailableGroupsApiResponse =
  /** status 200 OK */ AuthRegistrationGetAvailableGroupsResponse;
export type GetApiAuthRegistrationGetAvailableGroupsApiArg = {
  number: string;
};
export type GetApiAuthRegistrationGetAvailableFacultiesApiResponse =
  /** status 200 OK */ AuthRegistrationGetAvailableFacultiesResponse;
export type GetApiAuthRegistrationGetAvailableFacultiesApiArg = void;
export type GetApiAuthRegistrationGetAvailableDepartmentsApiResponse =
  /** status 200 OK */ AuthRegistrationGetAvailableDepartmentsResponse;
export type GetApiAuthRegistrationGetAvailableDepartmentsApiArg = {
  facultyId: string;
};
export type GetApiAuthRefreshApiResponse =
  /** status 200 OK */ AuthRefreshResponse;
export type GetApiAuthRefreshApiArg = void;
export type PostApiAuthLogoutApiResponse = unknown;
export type PostApiAuthLogoutApiArg = void;
export type PostApiAuthLoginApiResponse =
  /** status 200 OK */ AuthLoginResponse;
export type PostApiAuthLoginApiArg = {
  authLoginRequest: AuthLoginRequest;
};
export type GetApiAuthInfoApiResponse = /** status 200 OK */ AuthInfoResponse;
export type GetApiAuthInfoApiArg = void;
export type PostApiAuthChangePasswordApiResponse = unknown;
export type PostApiAuthChangePasswordApiArg = {
  authChangePasswordRequest: AuthChangePasswordRequest;
};
export type PutApiIdentityUpdateVerificationApiResponse = unknown;
export type PutApiIdentityUpdateVerificationApiArg = {
  identityUpdateVerificationRequest: IdentityUpdateVerificationRequest;
};
export type PutApiIdentityUpdateBlockingApiResponse = unknown;
export type PutApiIdentityUpdateBlockingApiArg = {
  identityUpdateBlockingRequest: IdentityUpdateBlockingRequest;
};
export type AuthRegistrationRegisterResponse = {
  userId: string;
};
export type AuthRegistrationRegisterTeacherRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  birthday?: string | null;
  universityPositionId: string;
  departmentId: string;
};
export type AuthRegistrationRegisterStudentRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  birthday?: string | null;
  groupNumber: string;
};
export type AuthRegistrationRegisterDeaneryRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  birthday?: string | null;
  universityPositionId: string;
  facultyId: string;
};
export type AuthRegistrationRegisterAdminRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  birthday?: string | null;
};
export type AuthRegistrationGetAvailableUniversityPositionsUniversityPosition =
  {
    id?: string;
    name?: string | null;
  };
export type AuthRegistrationGetAvailableUniversityPositionsResponse = {
  list?:
    | AuthRegistrationGetAvailableUniversityPositionsUniversityPosition[]
    | null;
};
export type AuthRegistrationGetAvailableGroupsResponse = {
  groupNumbers?: string[] | null;
};
export type AuthRegistrationGetAvailableFacultiesFaculty = {
  id?: string;
  name?: string | null;
};
export type AuthRegistrationGetAvailableFacultiesResponse = {
  faculties?: AuthRegistrationGetAvailableFacultiesFaculty[] | null;
};
export type AuthRegistrationGetAvailableDepartmentsDepartment = {
  id?: string;
  name?: string | null;
};
export type AuthRegistrationGetAvailableDepartmentsResponse = {
  departments?: AuthRegistrationGetAvailableDepartmentsDepartment[] | null;
};
export type ContractsToken = {
  value?: string | null;
  expiration?: string;
};
export type AuthRefreshResponse = {
  accessToken?: ContractsToken;
  refreshToken?: ContractsToken;
};
export type AuthLoginResponse = {
  accessToken?: ContractsToken;
  refreshToken?: ContractsToken;
};
export type AuthLoginRequest = {
  userName: string;
  password: string;
};
export type AuthInfoResponse = {
  userId?: string;
  roleTypes?: ContractsUserRoleType[] | null;
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
export type AuthChangePasswordRequest = {
  password: string;
  newPassword: string;
};
export type IdentityUpdateVerificationRequest = {
  userId: string;
  isApproved: boolean;
};
export type IdentityUpdateBlockingRequest = {
  userId: string;
  isBlocked: boolean;
};
export enum ContractsUserRoleType {
  None = "None",
  Admin = "Admin",
  Deanery = "Deanery",
  Teacher = "Teacher",
  Student = "Student",
}
export const {
  usePostApiAuthRegistrationRegisterTeacherMutation,
  usePostApiAuthRegistrationRegisterStudentMutation,
  usePostApiAuthRegistrationRegisterDeaneryMutation,
  usePostApiAuthRegistrationRegisterAdminMutation,
  useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery,
  useLazyGetApiAuthRegistrationGetAvailableUniversityPositionsQuery,
  useGetApiAuthRegistrationGetAvailableGroupsQuery,
  useLazyGetApiAuthRegistrationGetAvailableGroupsQuery,
  useGetApiAuthRegistrationGetAvailableFacultiesQuery,
  useLazyGetApiAuthRegistrationGetAvailableFacultiesQuery,
  useGetApiAuthRegistrationGetAvailableDepartmentsQuery,
  useLazyGetApiAuthRegistrationGetAvailableDepartmentsQuery,
  useGetApiAuthRefreshQuery,
  useLazyGetApiAuthRefreshQuery,
  usePostApiAuthLogoutMutation,
  usePostApiAuthLoginMutation,
  useGetApiAuthInfoQuery,
  useLazyGetApiAuthInfoQuery,
  usePostApiAuthChangePasswordMutation,
  usePutApiIdentityUpdateVerificationMutation,
  usePutApiIdentityUpdateBlockingMutation,
} = injectedRtkApi;
