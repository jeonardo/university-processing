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
    postApiAuthRefresh: build.mutation<
      PostApiAuthRefreshApiResponse,
      PostApiAuthRefreshApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Refresh`,
        method: "POST",
        body: queryArg.authRefreshRequest,
      }),
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
    patchApiDepartmentsSetDepartmentHead: build.mutation<
      PatchApiDepartmentsSetDepartmentHeadApiResponse,
      PatchApiDepartmentsSetDepartmentHeadApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Departments/SetDepartmentHead`,
        method: "PATCH",
        params: {
          DepartmentId: queryArg.departmentId,
          UserId: queryArg.userId,
        },
      }),
    }),
    getApiDepartmentsGet: build.query<
      GetApiDepartmentsGetApiResponse,
      GetApiDepartmentsGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Departments/Get`,
        params: {
          FacultyId: queryArg.facultyId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    getApiDepartmentsGetFullDescription: build.query<
      GetApiDepartmentsGetFullDescriptionApiResponse,
      GetApiDepartmentsGetFullDescriptionApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Departments/GetFullDescription`,
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    deleteApiDepartmentsDelete: build.mutation<
      DeleteApiDepartmentsDeleteApiResponse,
      DeleteApiDepartmentsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Departments/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiDepartmentsCreate: build.mutation<
      PostApiDepartmentsCreateApiResponse,
      PostApiDepartmentsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Departments/Create`,
        method: "POST",
        body: queryArg.departmentsCreateRequest,
      }),
    }),
    deleteApiDiplomaProcessesUsersRemove: build.mutation<
      DeleteApiDiplomaProcessesUsersRemoveApiResponse,
      DeleteApiDiplomaProcessesUsersRemoveApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Users/Remove`,
        method: "DELETE",
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          UserIds: queryArg.userIds,
        },
      }),
    }),
    getApiDiplomaProcessesUsersGet: build.query<
      GetApiDiplomaProcessesUsersGetApiResponse,
      GetApiDiplomaProcessesUsersGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Users/Get`,
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          RoleType: queryArg.roleType,
        },
      }),
    }),
    postApiDiplomaProcessesUsersAdd: build.mutation<
      PostApiDiplomaProcessesUsersAddApiResponse,
      PostApiDiplomaProcessesUsersAddApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Users/Add`,
        method: "POST",
        body: queryArg.diplomaProcessesUsersAddRequest,
      }),
    }),
    getApiDiplomaProcessesGet: build.query<
      GetApiDiplomaProcessesGetApiResponse,
      GetApiDiplomaProcessesGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Get`,
        params: {
          PeriodId: queryArg.periodId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    deleteApiDiplomaProcessesDelete: build.mutation<
      DeleteApiDiplomaProcessesDeleteApiResponse,
      DeleteApiDiplomaProcessesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiDiplomaProcessesCreate: build.mutation<
      PostApiDiplomaProcessesCreateApiResponse,
      PostApiDiplomaProcessesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Create`,
        method: "POST",
        body: queryArg.diplomaProcessesCreateRequest,
      }),
    }),
    patchApiFacultiesSetFacultyHead: build.mutation<
      PatchApiFacultiesSetFacultyHeadApiResponse,
      PatchApiFacultiesSetFacultyHeadApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Faculties/SetFacultyHead`,
        method: "PATCH",
        params: {
          FacultyId: queryArg.facultyId,
          UserId: queryArg.userId,
        },
      }),
    }),
    getApiFacultiesGet: build.query<
      GetApiFacultiesGetApiResponse,
      GetApiFacultiesGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Faculties/Get`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    getApiFacultiesGetFullDescription: build.query<
      GetApiFacultiesGetFullDescriptionApiResponse,
      GetApiFacultiesGetFullDescriptionApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Faculties/GetFullDescription`,
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    deleteApiFacultiesDelete: build.mutation<
      DeleteApiFacultiesDeleteApiResponse,
      DeleteApiFacultiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Faculties/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiFacultiesCreate: build.mutation<
      PostApiFacultiesCreateApiResponse,
      PostApiFacultiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Faculties/Create`,
        method: "POST",
        body: queryArg.facultiesCreateRequest,
      }),
    }),
    getApiGroupsGet: build.query<
      GetApiGroupsGetApiResponse,
      GetApiGroupsGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Groups/Get`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    deleteApiGroupsDelete: build.mutation<
      DeleteApiGroupsDeleteApiResponse,
      DeleteApiGroupsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Groups/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiGroupsCreate: build.mutation<
      PostApiGroupsCreateApiResponse,
      PostApiGroupsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Groups/Create`,
        method: "POST",
        body: queryArg.groupsCreateRequest,
      }),
    }),
    getApiPeriodsGet: build.query<
      GetApiPeriodsGetApiResponse,
      GetApiPeriodsGetApiArg
    >({
      query: () => ({ url: `/api/Periods/Get` }),
    }),
    deleteApiPeriodsDelete: build.mutation<
      DeleteApiPeriodsDeleteApiResponse,
      DeleteApiPeriodsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Periods/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiPeriodsCreate: build.mutation<
      PostApiPeriodsCreateApiResponse,
      PostApiPeriodsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Periods/Create`,
        method: "POST",
        body: queryArg.periodsCreateRequest,
      }),
    }),
    getApiSpecialtiesGet: build.query<
      GetApiSpecialtiesGetApiResponse,
      GetApiSpecialtiesGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Specialties/Get`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    deleteApiSpecialtiesDelete: build.mutation<
      DeleteApiSpecialtiesDeleteApiResponse,
      DeleteApiSpecialtiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Specialties/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiSpecialtiesCreate: build.mutation<
      PostApiSpecialtiesCreateApiResponse,
      PostApiSpecialtiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Specialties/Create`,
        method: "POST",
        body: queryArg.specialtiesCreateRequest,
      }),
    }),
    putApiUsersUpdateVerification: build.mutation<
      PutApiUsersUpdateVerificationApiResponse,
      PutApiUsersUpdateVerificationApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/UpdateVerification`,
        method: "PUT",
        body: queryArg.usersUpdateVerificationRequest,
      }),
    }),
    putApiUsersUpdateBlocking: build.mutation<
      PutApiUsersUpdateBlockingApiResponse,
      PutApiUsersUpdateBlockingApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/UpdateBlocking`,
        method: "PUT",
        body: queryArg.usersUpdateBlockingRequest,
      }),
    }),
    getApiUsersGetTeachers: build.query<
      GetApiUsersGetTeachersApiResponse,
      GetApiUsersGetTeachersApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/GetTeachers`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    getApiUsersGetStudents: build.query<
      GetApiUsersGetStudentsApiResponse,
      GetApiUsersGetStudentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/GetStudents`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    getApiUsersGetDeaneries: build.query<
      GetApiUsersGetDeaneriesApiResponse,
      GetApiUsersGetDeaneriesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/GetDeaneries`,
        params: {
          FacultyId: queryArg.facultyId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    getApiUsersGetAdmins: build.query<
      GetApiUsersGetAdminsApiResponse,
      GetApiUsersGetAdminsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/GetAdmins`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
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
export type PostApiAuthRefreshApiResponse =
  /** status 200 OK */ AuthRefreshResponse;
export type PostApiAuthRefreshApiArg = {
  authRefreshRequest: AuthRefreshRequest;
};
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
export type PatchApiDepartmentsSetDepartmentHeadApiResponse = unknown;
export type PatchApiDepartmentsSetDepartmentHeadApiArg = {
  departmentId: string;
  userId: string;
};
export type GetApiDepartmentsGetApiResponse =
  /** status 200 OK */ DepartmentsGetResponseRead;
export type GetApiDepartmentsGetApiArg = {
  facultyId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiDepartmentsGetFullDescriptionApiResponse =
  /** status 200 OK */ DepartmentsGetFullDescriptionResponse;
export type GetApiDepartmentsGetFullDescriptionApiArg = {
  id: string;
};
export type DeleteApiDepartmentsDeleteApiResponse = unknown;
export type DeleteApiDepartmentsDeleteApiArg = {
  id: string;
};
export type PostApiDepartmentsCreateApiResponse =
  /** status 200 OK */ DepartmentsCreateResponse;
export type PostApiDepartmentsCreateApiArg = {
  departmentsCreateRequest: DepartmentsCreateRequest;
};
export type DeleteApiDiplomaProcessesUsersRemoveApiResponse = unknown;
export type DeleteApiDiplomaProcessesUsersRemoveApiArg = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type GetApiDiplomaProcessesUsersGetApiResponse =
  /** status 200 OK */ DiplomaProcessesUsersGetResponse;
export type GetApiDiplomaProcessesUsersGetApiArg = {
  diplomaPeriodId: string;
  roleType: ContractsUserRoleType;
};
export type PostApiDiplomaProcessesUsersAddApiResponse = unknown;
export type PostApiDiplomaProcessesUsersAddApiArg = {
  diplomaProcessesUsersAddRequest: DiplomaProcessesUsersAddRequest;
};
export type GetApiDiplomaProcessesGetApiResponse =
  /** status 200 OK */ DiplomaProcessesGetResponseRead;
export type GetApiDiplomaProcessesGetApiArg = {
  periodId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type DeleteApiDiplomaProcessesDeleteApiResponse = unknown;
export type DeleteApiDiplomaProcessesDeleteApiArg = {
  id: string;
};
export type PostApiDiplomaProcessesCreateApiResponse =
  /** status 200 OK */ DiplomaProcessesCreateResponse;
export type PostApiDiplomaProcessesCreateApiArg = {
  diplomaProcessesCreateRequest: DiplomaProcessesCreateRequest;
};
export type PatchApiFacultiesSetFacultyHeadApiResponse = unknown;
export type PatchApiFacultiesSetFacultyHeadApiArg = {
  facultyId: string;
  userId: string;
};
export type GetApiFacultiesGetApiResponse =
  /** status 200 OK */ FacultiesGetResponseRead;
export type GetApiFacultiesGetApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiFacultiesGetFullDescriptionApiResponse =
  /** status 200 OK */ FacultiesGetFullDescriptionResponse;
export type GetApiFacultiesGetFullDescriptionApiArg = {
  id: string;
};
export type DeleteApiFacultiesDeleteApiResponse = unknown;
export type DeleteApiFacultiesDeleteApiArg = {
  id: string;
};
export type PostApiFacultiesCreateApiResponse =
  /** status 200 OK */ FacultiesCreateResponse;
export type PostApiFacultiesCreateApiArg = {
  facultiesCreateRequest: FacultiesCreateRequest;
};
export type GetApiGroupsGetApiResponse =
  /** status 200 OK */ GroupsGetResponseRead;
export type GetApiGroupsGetApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type DeleteApiGroupsDeleteApiResponse = unknown;
export type DeleteApiGroupsDeleteApiArg = {
  id: string;
};
export type PostApiGroupsCreateApiResponse =
  /** status 200 OK */ GroupsCreateResponse;
export type PostApiGroupsCreateApiArg = {
  groupsCreateRequest: GroupsCreateRequest;
};
export type GetApiPeriodsGetApiResponse =
  /** status 200 OK */ PeriodsGetResponse;
export type GetApiPeriodsGetApiArg = void;
export type DeleteApiPeriodsDeleteApiResponse = unknown;
export type DeleteApiPeriodsDeleteApiArg = {
  id: string;
};
export type PostApiPeriodsCreateApiResponse =
  /** status 200 OK */ PeriodsCreateResponse;
export type PostApiPeriodsCreateApiArg = {
  periodsCreateRequest: PeriodsCreateRequest;
};
export type GetApiSpecialtiesGetApiResponse =
  /** status 200 OK */ SpecialtiesGetResponseRead;
export type GetApiSpecialtiesGetApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type DeleteApiSpecialtiesDeleteApiResponse = unknown;
export type DeleteApiSpecialtiesDeleteApiArg = {
  id: string;
};
export type PostApiSpecialtiesCreateApiResponse =
  /** status 200 OK */ SpecialtiesCreateResponse;
export type PostApiSpecialtiesCreateApiArg = {
  specialtiesCreateRequest: SpecialtiesCreateRequest;
};
export type PutApiUsersUpdateVerificationApiResponse = unknown;
export type PutApiUsersUpdateVerificationApiArg = {
  usersUpdateVerificationRequest: UsersUpdateVerificationRequest;
};
export type PutApiUsersUpdateBlockingApiResponse = unknown;
export type PutApiUsersUpdateBlockingApiArg = {
  usersUpdateBlockingRequest: UsersUpdateBlockingRequest;
};
export type GetApiUsersGetTeachersApiResponse =
  /** status 200 OK */ UsersGetTeachersResponseRead;
export type GetApiUsersGetTeachersApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiUsersGetStudentsApiResponse =
  /** status 200 OK */ UsersGetStudentsResponseRead;
export type GetApiUsersGetStudentsApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiUsersGetDeaneriesApiResponse =
  /** status 200 OK */ UsersGetDeaneriesResponseRead;
export type GetApiUsersGetDeaneriesApiArg = {
  facultyId?: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiUsersGetAdminsApiResponse =
  /** status 200 OK */ UsersGetAdminsResponseRead;
export type GetApiUsersGetAdminsApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
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
export type AuthRefreshResponse = {
  accessToken?: string | null;
  refreshToken?: string | null;
};
export type AuthRefreshRequest = {
  accessToken: string;
  refreshToken: string;
};
export type AuthLoginResponse = {
  accessToken?: string | null;
  refreshToken?: string | null;
};
export type AuthLoginRequest = {
  userName: string;
  password: string;
};
export type AuthInfoResponse = {
  userId?: string;
  role?: ContractsUserRoleType;
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
  facultyId?: string | null;
  departmentId?: string | null;
};
export type AuthChangePasswordRequest = {
  password: string;
  newPassword: string;
};
export type DepartmentsGetDepartment = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type DepartmentsGetResponse = {
  items?: DepartmentsGetDepartment[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type DepartmentsGetResponseRead = {
  items?: DepartmentsGetDepartment[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type DepartmentsGetFullDescriptionDepartmentFullDescriptionUser = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  position?: string | null;
  blocked?: boolean;
  approved?: boolean;
};
export type DepartmentsGetFullDescriptionResponse = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  head?: DepartmentsGetFullDescriptionDepartmentFullDescriptionUser;
  teachers?:
    | DepartmentsGetFullDescriptionDepartmentFullDescriptionUser[]
    | null;
};
export type DepartmentsCreateResponse = {
  id: string;
};
export type DepartmentsCreateRequest = {
  name: string;
  shortName: string;
  facultyId: string;
};
export type DiplomaProcessesUsersGetDiplomaPeriodUser = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  universityPosition?: string | null;
  added?: boolean;
};
export type DiplomaProcessesUsersGetResponse = {
  list?: DiplomaProcessesUsersGetDiplomaPeriodUser[] | null;
};
export type DiplomaProcessesUsersAddRequest = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type DiplomaProcessesGetDiplomaProcess = {
  id?: string;
  name?: string | null;
};
export type DiplomaProcessesGetResponse = {
  items?: DiplomaProcessesGetDiplomaProcess[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type DiplomaProcessesGetResponseRead = {
  items?: DiplomaProcessesGetDiplomaProcess[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type DiplomaProcessesCreateResponse = {
  id?: string;
};
export type DiplomaProcessesCreateRequest = {
  periodId: string;
  name: string;
};
export type FacultiesGetFaculty = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type FacultiesGetResponse = {
  items?: FacultiesGetFaculty[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type FacultiesGetResponseRead = {
  items?: FacultiesGetFaculty[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type FacultiesGetFullDescriptionFacultyFullDescriptionUser = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  position?: string | null;
  blocked?: boolean;
  approved?: boolean;
};
export type FacultiesGetFullDescriptionResponse = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  head?: FacultiesGetFullDescriptionFacultyFullDescriptionUser;
  deaneries?: FacultiesGetFullDescriptionFacultyFullDescriptionUser[] | null;
};
export type FacultiesCreateResponse = {
  id?: string;
};
export type FacultiesCreateRequest = {
  name: string;
  shortName: string;
};
export type GroupsGetGroup = {
  id?: string;
  number?: string | null;
};
export type GroupsGetResponse = {
  items?: GroupsGetGroup[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type GroupsGetResponseRead = {
  items?: GroupsGetGroup[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GroupsCreateResponse = {
  id: string;
};
export type GroupsCreateRequest = {
  groupNumber: string;
  startDate: string;
  endDate: string;
  specialtyId: string;
  periodId: string;
};
export type PeriodsGetPeriod = {
  id: string;
  name: string;
  from: string;
  to: string;
  comments?: string | null;
};
export type PeriodsGetResponse = {
  list?: PeriodsGetPeriod[] | null;
};
export type PeriodsCreateResponse = {
  id: string;
};
export type PeriodsCreateRequest = {
  name: string;
  from: string;
  to: string;
  comments?: string | null;
};
export type SpecialtiesGetSpecialty = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type SpecialtiesGetResponse = {
  items?: SpecialtiesGetSpecialty[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type SpecialtiesGetResponseRead = {
  items?: SpecialtiesGetSpecialty[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type SpecialtiesCreateResponse = {
  id?: string;
};
export type SpecialtiesCreateRequest = {
  name: string;
  shortName: string;
  code: string;
  departmentId: string;
};
export type UsersUpdateVerificationRequest = {
  userId: string;
  isApproved: boolean;
};
export type UsersUpdateBlockingRequest = {
  userId: string;
  isBlocked: boolean;
};
export type UsersGetTeachersTeacher = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
  position?: string | null;
};
export type UsersGetTeachersTeacherPagedList = {
  items?: UsersGetTeachersTeacher[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type UsersGetTeachersTeacherPagedListRead = {
  items?: UsersGetTeachersTeacher[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type UsersGetTeachersResponse = {
  list?: UsersGetTeachersTeacherPagedList;
};
export type UsersGetTeachersResponseRead = {
  list?: UsersGetTeachersTeacherPagedListRead;
};
export type UsersGetStudentsStudent = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
};
export type UsersGetStudentsStudentPagedList = {
  items?: UsersGetStudentsStudent[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type UsersGetStudentsStudentPagedListRead = {
  items?: UsersGetStudentsStudent[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type UsersGetStudentsResponse = {
  list?: UsersGetStudentsStudentPagedList;
};
export type UsersGetStudentsResponseRead = {
  list?: UsersGetStudentsStudentPagedListRead;
};
export type UsersGetDeaneriesDeanery = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
  position?: string | null;
};
export type UsersGetDeaneriesDeaneryPagedList = {
  items?: UsersGetDeaneriesDeanery[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type UsersGetDeaneriesDeaneryPagedListRead = {
  items?: UsersGetDeaneriesDeanery[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type UsersGetDeaneriesResponse = {
  list?: UsersGetDeaneriesDeaneryPagedList;
};
export type UsersGetDeaneriesResponseRead = {
  list?: UsersGetDeaneriesDeaneryPagedListRead;
};
export type UsersGetAdminsAdmin = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
};
export type UsersGetAdminsAdminPagedList = {
  items?: UsersGetAdminsAdmin[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type UsersGetAdminsAdminPagedListRead = {
  items?: UsersGetAdminsAdmin[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type UsersGetAdminsResponse = {
  list?: UsersGetAdminsAdminPagedList;
};
export type UsersGetAdminsResponseRead = {
  list?: UsersGetAdminsAdminPagedListRead;
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
  usePostApiAuthRefreshMutation,
  usePostApiAuthLogoutMutation,
  usePostApiAuthLoginMutation,
  useGetApiAuthInfoQuery,
  useLazyGetApiAuthInfoQuery,
  usePostApiAuthChangePasswordMutation,
  usePatchApiDepartmentsSetDepartmentHeadMutation,
  useGetApiDepartmentsGetQuery,
  useLazyGetApiDepartmentsGetQuery,
  useGetApiDepartmentsGetFullDescriptionQuery,
  useLazyGetApiDepartmentsGetFullDescriptionQuery,
  useDeleteApiDepartmentsDeleteMutation,
  usePostApiDepartmentsCreateMutation,
  useDeleteApiDiplomaProcessesUsersRemoveMutation,
  useGetApiDiplomaProcessesUsersGetQuery,
  useLazyGetApiDiplomaProcessesUsersGetQuery,
  usePostApiDiplomaProcessesUsersAddMutation,
  useGetApiDiplomaProcessesGetQuery,
  useLazyGetApiDiplomaProcessesGetQuery,
  useDeleteApiDiplomaProcessesDeleteMutation,
  usePostApiDiplomaProcessesCreateMutation,
  usePatchApiFacultiesSetFacultyHeadMutation,
  useGetApiFacultiesGetQuery,
  useLazyGetApiFacultiesGetQuery,
  useGetApiFacultiesGetFullDescriptionQuery,
  useLazyGetApiFacultiesGetFullDescriptionQuery,
  useDeleteApiFacultiesDeleteMutation,
  usePostApiFacultiesCreateMutation,
  useGetApiGroupsGetQuery,
  useLazyGetApiGroupsGetQuery,
  useDeleteApiGroupsDeleteMutation,
  usePostApiGroupsCreateMutation,
  useGetApiPeriodsGetQuery,
  useLazyGetApiPeriodsGetQuery,
  useDeleteApiPeriodsDeleteMutation,
  usePostApiPeriodsCreateMutation,
  useGetApiSpecialtiesGetQuery,
  useLazyGetApiSpecialtiesGetQuery,
  useDeleteApiSpecialtiesDeleteMutation,
  usePostApiSpecialtiesCreateMutation,
  usePutApiUsersUpdateVerificationMutation,
  usePutApiUsersUpdateBlockingMutation,
  useGetApiUsersGetTeachersQuery,
  useLazyGetApiUsersGetTeachersQuery,
  useGetApiUsersGetStudentsQuery,
  useLazyGetApiUsersGetStudentsQuery,
  useGetApiUsersGetDeaneriesQuery,
  useLazyGetApiUsersGetDeaneriesQuery,
  useGetApiUsersGetAdminsQuery,
  useLazyGetApiUsersGetAdminsQuery,
} = injectedRtkApi;
