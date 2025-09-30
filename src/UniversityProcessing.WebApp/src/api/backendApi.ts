import { emptySplitApi as api } from "./emptyApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    postApiAuthRefresh: build.mutation<
      PostApiAuthRefreshApiResponse,
      PostApiAuthRefreshApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Refresh`,
        method: "POST",
        body: queryArg.apiAuthRefreshRequestDto,
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
        body: queryArg.apiAuthLoginRequestDto,
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
        body: queryArg.apiAuthChangePasswordRequestDto,
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
        body: queryArg.apiDepartmentsCreateRequestDto,
      }),
    }),
    getApiDiplomaProcessesGetInfo: build.query<
      GetApiDiplomaProcessesGetInfoApiResponse,
      GetApiDiplomaProcessesGetInfoApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/GetInfo`,
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    putApiDiplomaProcessesTeachersAdd: build.mutation<
      PutApiDiplomaProcessesTeachersAddApiResponse,
      PutApiDiplomaProcessesTeachersAddApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Teachers/Add`,
        method: "PUT",
        body: queryArg.apiDiplomaProcessesTeachersAddRequestDto,
      }),
    }),
    getApiDiplomaProcessesTeachersGet: build.query<
      GetApiDiplomaProcessesTeachersGetApiResponse,
      GetApiDiplomaProcessesTeachersGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Teachers/Get`,
        params: {
          DiplomaProcessId: queryArg.diplomaProcessId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    putApiDiplomaProcessesTeachersRemove: build.mutation<
      PutApiDiplomaProcessesTeachersRemoveApiResponse,
      PutApiDiplomaProcessesTeachersRemoveApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Teachers/Remove`,
        method: "PUT",
        body: queryArg.apiDiplomaProcessesTeachersRemoveRequestDto,
      }),
    }),
    putApiDiplomaProcessesGroupsAdd: build.mutation<
      PutApiDiplomaProcessesGroupsAddApiResponse,
      PutApiDiplomaProcessesGroupsAddApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Groups/Add`,
        method: "PUT",
        body: queryArg.apiDiplomaProcessesGroupsAddRequestDto,
      }),
    }),
    getApiDiplomaProcessesGroupsGetFullDescription: build.query<
      GetApiDiplomaProcessesGroupsGetFullDescriptionApiResponse,
      GetApiDiplomaProcessesGroupsGetFullDescriptionApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Groups/GetFullDescription`,
        params: {
          DiplomaProcessId: queryArg.diplomaProcessId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    putApiDiplomaProcessesGroupsRemove: build.mutation<
      PutApiDiplomaProcessesGroupsRemoveApiResponse,
      PutApiDiplomaProcessesGroupsRemoveApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Groups/Remove`,
        method: "PUT",
        body: queryArg.apiDiplomaProcessesGroupsRemoveRequestDto,
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
    getApiDiplomaProcessesDiplomasGet: build.query<
      GetApiDiplomaProcessesDiplomasGetApiResponse,
      GetApiDiplomaProcessesDiplomasGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Diplomas/Get`,
        params: {
          DiplomaProcessId: queryArg.diplomaProcessId,
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
    postApiDiplomaProcessesDefenseSessionsCreate: build.mutation<
      PostApiDiplomaProcessesDefenseSessionsCreateApiResponse,
      PostApiDiplomaProcessesDefenseSessionsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/DefenseSessions/Create`,
        method: "POST",
        body: queryArg.apiDiplomaProcessesDefenseSessionsCreateRequestDto,
      }),
    }),
    deleteApiDiplomaProcessesDefenseSessionsDelete: build.mutation<
      DeleteApiDiplomaProcessesDefenseSessionsDeleteApiResponse,
      DeleteApiDiplomaProcessesDefenseSessionsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/DefenseSessions/Delete`,
        method: "DELETE",
        body: queryArg.apiDiplomaProcessesDefenseSessionsDeleteRequestDto,
      }),
    }),
    getApiDiplomaProcessesDefenseSessionsGetFreeStudents: build.query<
      GetApiDiplomaProcessesDefenseSessionsGetFreeStudentsApiResponse,
      GetApiDiplomaProcessesDefenseSessionsGetFreeStudentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/DefenseSessions/GetFreeStudents`,
        params: {
          DiplomaProcessId: queryArg.diplomaProcessId,
        },
      }),
    }),
    getApiDiplomaProcessesDefenseSessionsGetPage: build.query<
      GetApiDiplomaProcessesDefenseSessionsGetPageApiResponse,
      GetApiDiplomaProcessesDefenseSessionsGetPageApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/DefenseSessions/GetPage`,
        params: {
          DiplomaProcessId: queryArg.diplomaProcessId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
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
        body: queryArg.apiDiplomaProcessesCreateRequestDto,
      }),
    }),
    putApiDiplomaProcessesCommitteesAddTeacher: build.mutation<
      PutApiDiplomaProcessesCommitteesAddTeacherApiResponse,
      PutApiDiplomaProcessesCommitteesAddTeacherApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Committees/AddTeacher`,
        method: "PUT",
        body: queryArg.apiDiplomaProcessesCommitteesAddTeacherRequestDto,
      }),
    }),
    postApiDiplomaProcessesCommitteesCreate: build.mutation<
      PostApiDiplomaProcessesCommitteesCreateApiResponse,
      PostApiDiplomaProcessesCommitteesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Committees/Create`,
        method: "POST",
        body: queryArg.apiDiplomaProcessesCommitteesCreateRequestDto,
      }),
    }),
    deleteApiDiplomaProcessesCommitteesDelete: build.mutation<
      DeleteApiDiplomaProcessesCommitteesDeleteApiResponse,
      DeleteApiDiplomaProcessesCommitteesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Committees/Delete`,
        method: "DELETE",
        body: queryArg.apiDiplomaProcessesCommitteesDeleteRequestDto,
      }),
    }),
    getApiDiplomaProcessesCommitteesGet: build.query<
      GetApiDiplomaProcessesCommitteesGetApiResponse,
      GetApiDiplomaProcessesCommitteesGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Committees/Get`,
        params: {
          DiplomaProcessId: queryArg.diplomaProcessId,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
        },
      }),
    }),
    putApiDiplomaProcessesCommitteesRemoveTeacher: build.mutation<
      PutApiDiplomaProcessesCommitteesRemoveTeacherApiResponse,
      PutApiDiplomaProcessesCommitteesRemoveTeacherApiArg
    >({
      query: (queryArg) => ({
        url: `/api/DiplomaProcesses/Committees/RemoveTeacher`,
        method: "PUT",
        body: queryArg.apiDiplomaProcessesCommitteesRemoveTeacherRequestDto,
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
        body: queryArg.apiFacultiesCreateRequestDto,
      }),
    }),
    getApiGroupsGet: build.query<
      GetApiGroupsGetApiResponse,
      GetApiGroupsGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Groups/Get`,
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
        body: queryArg.apiGroupsCreateRequestDto,
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
        body: queryArg.apiPeriodsCreateRequestDto,
      }),
    }),
    postApiRegistrationRegisterTeacher: build.mutation<
      PostApiRegistrationRegisterTeacherApiResponse,
      PostApiRegistrationRegisterTeacherApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Register/Teacher`,
        method: "POST",
        body: queryArg.apiRegistrationRegisterTeacherRequestDto,
      }),
    }),
    postApiRegistrationRegisterStudent: build.mutation<
      PostApiRegistrationRegisterStudentApiResponse,
      PostApiRegistrationRegisterStudentApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Register/Student`,
        method: "POST",
        body: queryArg.apiRegistrationRegisterStudentRequestDto,
      }),
    }),
    postApiRegistrationRegisterDeanery: build.mutation<
      PostApiRegistrationRegisterDeaneryApiResponse,
      PostApiRegistrationRegisterDeaneryApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Register/Deanery`,
        method: "POST",
        body: queryArg.apiRegistrationRegisterDeaneryRequestDto,
      }),
    }),
    postApiRegistrationRegisterAdmin: build.mutation<
      PostApiRegistrationRegisterAdminApiResponse,
      PostApiRegistrationRegisterAdminApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Register/Admin`,
        method: "POST",
        body: queryArg.apiRegistrationRegisterAdminRequestDto,
      }),
    }),
    getApiRegistrationGetAvailableUniversityPositions: build.query<
      GetApiRegistrationGetAvailableUniversityPositionsApiResponse,
      GetApiRegistrationGetAvailableUniversityPositionsApiArg
    >({
      query: () => ({
        url: `/api/Registration/GetAvailableUniversityPositions`,
      }),
    }),
    getApiRegistrationGetAvailableGroups: build.query<
      GetApiRegistrationGetAvailableGroupsApiResponse,
      GetApiRegistrationGetAvailableGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/GetAvailableGroups`,
        params: {
          Number: queryArg["number"],
        },
      }),
    }),
    getApiRegistrationGetAvailableFaculties: build.query<
      GetApiRegistrationGetAvailableFacultiesApiResponse,
      GetApiRegistrationGetAvailableFacultiesApiArg
    >({
      query: () => ({ url: `/api/Registration/GetAvailableFaculties` }),
    }),
    getApiRegistrationGetAvailableDepartments: build.query<
      GetApiRegistrationGetAvailableDepartmentsApiResponse,
      GetApiRegistrationGetAvailableDepartmentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/GetAvailableDepartments`,
        params: {
          FacultyId: queryArg.facultyId,
        },
      }),
    }),
    getApiSpecialtiesGet: build.query<
      GetApiSpecialtiesGetApiResponse,
      GetApiSpecialtiesGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Specialties/Get`,
        params: {
          DepartmentId: queryArg.departmentId,
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
        body: queryArg.apiSpecialtiesCreateRequestDto,
      }),
    }),
    putApiUsersUpdateVerification: build.mutation<
      PutApiUsersUpdateVerificationApiResponse,
      PutApiUsersUpdateVerificationApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/UpdateVerification`,
        method: "PUT",
        body: queryArg.apiUsersUpdateVerificationRequestDto,
      }),
    }),
    putApiUsersUpdateBlocking: build.mutation<
      PutApiUsersUpdateBlockingApiResponse,
      PutApiUsersUpdateBlockingApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Users/UpdateBlocking`,
        method: "PUT",
        body: queryArg.apiUsersUpdateBlockingRequestDto,
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
          PeriodId: queryArg.periodId,
          GroupId: queryArg.groupId,
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
export type PostApiAuthRefreshApiResponse =
  /** status 200 OK */ ApiAuthRefreshResponseDto;
export type PostApiAuthRefreshApiArg = {
  apiAuthRefreshRequestDto: ApiAuthRefreshRequestDto;
};
export type PostApiAuthLogoutApiResponse = unknown;
export type PostApiAuthLogoutApiArg = void;
export type PostApiAuthLoginApiResponse =
  /** status 200 OK */ ApiAuthLoginResponseDto;
export type PostApiAuthLoginApiArg = {
  apiAuthLoginRequestDto: ApiAuthLoginRequestDto;
};
export type GetApiAuthInfoApiResponse =
  /** status 200 OK */ ApiAuthInfoResponseDto;
export type GetApiAuthInfoApiArg = void;
export type PostApiAuthChangePasswordApiResponse = unknown;
export type PostApiAuthChangePasswordApiArg = {
  apiAuthChangePasswordRequestDto: ApiAuthChangePasswordRequestDto;
};
export type PatchApiDepartmentsSetDepartmentHeadApiResponse = unknown;
export type PatchApiDepartmentsSetDepartmentHeadApiArg = {
  departmentId: string;
  userId: string;
};
export type GetApiDepartmentsGetApiResponse =
  /** status 200 OK */ ApiDepartmentsGetResponseDtoRead;
export type GetApiDepartmentsGetApiArg = {
  facultyId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiDepartmentsGetFullDescriptionApiResponse =
  /** status 200 OK */ ApiDepartmentsGetFullDescriptionResponseDto;
export type GetApiDepartmentsGetFullDescriptionApiArg = {
  id: string;
};
export type DeleteApiDepartmentsDeleteApiResponse = unknown;
export type DeleteApiDepartmentsDeleteApiArg = {
  id: string;
};
export type PostApiDepartmentsCreateApiResponse =
  /** status 200 OK */ ApiDepartmentsCreateResponseDto;
export type PostApiDepartmentsCreateApiArg = {
  apiDepartmentsCreateRequestDto: ApiDepartmentsCreateRequestDto;
};
export type GetApiDiplomaProcessesGetInfoApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesGetInfoResponseDto;
export type GetApiDiplomaProcessesGetInfoApiArg = {
  id: string;
};
export type PutApiDiplomaProcessesTeachersAddApiResponse = unknown;
export type PutApiDiplomaProcessesTeachersAddApiArg = {
  apiDiplomaProcessesTeachersAddRequestDto: ApiDiplomaProcessesTeachersAddRequestDto;
};
export type GetApiDiplomaProcessesTeachersGetApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesTeachersGetResponseDtoRead;
export type GetApiDiplomaProcessesTeachersGetApiArg = {
  diplomaProcessId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type PutApiDiplomaProcessesTeachersRemoveApiResponse = unknown;
export type PutApiDiplomaProcessesTeachersRemoveApiArg = {
  apiDiplomaProcessesTeachersRemoveRequestDto: ApiDiplomaProcessesTeachersRemoveRequestDto;
};
export type PutApiDiplomaProcessesGroupsAddApiResponse = unknown;
export type PutApiDiplomaProcessesGroupsAddApiArg = {
  apiDiplomaProcessesGroupsAddRequestDto: ApiDiplomaProcessesGroupsAddRequestDto;
};
export type GetApiDiplomaProcessesGroupsGetFullDescriptionApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesGroupsGetFullDescriptionResponseDtoRead;
export type GetApiDiplomaProcessesGroupsGetFullDescriptionApiArg = {
  diplomaProcessId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type PutApiDiplomaProcessesGroupsRemoveApiResponse = unknown;
export type PutApiDiplomaProcessesGroupsRemoveApiArg = {
  apiDiplomaProcessesGroupsRemoveRequestDto: ApiDiplomaProcessesGroupsRemoveRequestDto;
};
export type GetApiDiplomaProcessesGetApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesGetResponseDtoRead;
export type GetApiDiplomaProcessesGetApiArg = {
  periodId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiDiplomaProcessesDiplomasGetApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesDiplomasGetResponseDtoRead;
export type GetApiDiplomaProcessesDiplomasGetApiArg = {
  diplomaProcessId: string;
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
export type PostApiDiplomaProcessesDefenseSessionsCreateApiResponse = unknown;
export type PostApiDiplomaProcessesDefenseSessionsCreateApiArg = {
  apiDiplomaProcessesDefenseSessionsCreateRequestDto: ApiDiplomaProcessesDefenseSessionsCreateRequestDto;
};
export type DeleteApiDiplomaProcessesDefenseSessionsDeleteApiResponse = unknown;
export type DeleteApiDiplomaProcessesDefenseSessionsDeleteApiArg = {
  apiDiplomaProcessesDefenseSessionsDeleteRequestDto: ApiDiplomaProcessesDefenseSessionsDeleteRequestDto;
};
export type GetApiDiplomaProcessesDefenseSessionsGetFreeStudentsApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesDefenseSessionsGetFreeStudentsResponseDto;
export type GetApiDiplomaProcessesDefenseSessionsGetFreeStudentsApiArg = {
  diplomaProcessId: string;
};
export type GetApiDiplomaProcessesDefenseSessionsGetPageApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesDefenseSessionsGetPageResponseDtoRead;
export type GetApiDiplomaProcessesDefenseSessionsGetPageApiArg = {
  diplomaProcessId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type PostApiDiplomaProcessesCreateApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesCreateResponseDto;
export type PostApiDiplomaProcessesCreateApiArg = {
  apiDiplomaProcessesCreateRequestDto: ApiDiplomaProcessesCreateRequestDto;
};
export type PutApiDiplomaProcessesCommitteesAddTeacherApiResponse = unknown;
export type PutApiDiplomaProcessesCommitteesAddTeacherApiArg = {
  apiDiplomaProcessesCommitteesAddTeacherRequestDto: ApiDiplomaProcessesCommitteesAddTeacherRequestDto;
};
export type PostApiDiplomaProcessesCommitteesCreateApiResponse = unknown;
export type PostApiDiplomaProcessesCommitteesCreateApiArg = {
  apiDiplomaProcessesCommitteesCreateRequestDto: ApiDiplomaProcessesCommitteesCreateRequestDto;
};
export type DeleteApiDiplomaProcessesCommitteesDeleteApiResponse = unknown;
export type DeleteApiDiplomaProcessesCommitteesDeleteApiArg = {
  apiDiplomaProcessesCommitteesDeleteRequestDto: ApiDiplomaProcessesCommitteesDeleteRequestDto;
};
export type GetApiDiplomaProcessesCommitteesGetApiResponse =
  /** status 200 OK */ ApiDiplomaProcessesCommitteesGetResponseDtoRead;
export type GetApiDiplomaProcessesCommitteesGetApiArg = {
  diplomaProcessId: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type PutApiDiplomaProcessesCommitteesRemoveTeacherApiResponse = unknown;
export type PutApiDiplomaProcessesCommitteesRemoveTeacherApiArg = {
  apiDiplomaProcessesCommitteesRemoveTeacherRequestDto: ApiDiplomaProcessesCommitteesRemoveTeacherRequestDto;
};
export type PatchApiFacultiesSetFacultyHeadApiResponse = unknown;
export type PatchApiFacultiesSetFacultyHeadApiArg = {
  facultyId: string;
  userId: string;
};
export type GetApiFacultiesGetApiResponse =
  /** status 200 OK */ ApiFacultiesGetResponseDtoRead;
export type GetApiFacultiesGetApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiFacultiesGetFullDescriptionApiResponse =
  /** status 200 OK */ ApiFacultiesGetFullDescriptionResponseDto;
export type GetApiFacultiesGetFullDescriptionApiArg = {
  id: string;
};
export type DeleteApiFacultiesDeleteApiResponse = unknown;
export type DeleteApiFacultiesDeleteApiArg = {
  id: string;
};
export type PostApiFacultiesCreateApiResponse =
  /** status 200 OK */ ApiFacultiesCreateResponseDto;
export type PostApiFacultiesCreateApiArg = {
  apiFacultiesCreateRequestDto: ApiFacultiesCreateRequestDto;
};
export type GetApiGroupsGetApiResponse =
  /** status 200 OK */ ApiGroupsGetResponseDtoRead;
export type GetApiGroupsGetApiArg = {
  periodId: string;
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
  /** status 200 OK */ ApiGroupsCreateResponseDto;
export type PostApiGroupsCreateApiArg = {
  apiGroupsCreateRequestDto: ApiGroupsCreateRequestDto;
};
export type GetApiPeriodsGetApiResponse =
  /** status 200 OK */ ApiPeriodsGetResponseDto;
export type GetApiPeriodsGetApiArg = void;
export type DeleteApiPeriodsDeleteApiResponse = unknown;
export type DeleteApiPeriodsDeleteApiArg = {
  id: string;
};
export type PostApiPeriodsCreateApiResponse =
  /** status 200 OK */ ApiPeriodsCreateResponseDto;
export type PostApiPeriodsCreateApiArg = {
  apiPeriodsCreateRequestDto: ApiPeriodsCreateRequestDto;
};
export type PostApiRegistrationRegisterTeacherApiResponse =
  /** status 200 OK */ ApiRegistrationRegisterBaseResponseDto;
export type PostApiRegistrationRegisterTeacherApiArg = {
  apiRegistrationRegisterTeacherRequestDto: ApiRegistrationRegisterTeacherRequestDto;
};
export type PostApiRegistrationRegisterStudentApiResponse =
  /** status 200 OK */ ApiRegistrationRegisterBaseResponseDto;
export type PostApiRegistrationRegisterStudentApiArg = {
  apiRegistrationRegisterStudentRequestDto: ApiRegistrationRegisterStudentRequestDto;
};
export type PostApiRegistrationRegisterDeaneryApiResponse =
  /** status 200 OK */ ApiRegistrationRegisterBaseResponseDto;
export type PostApiRegistrationRegisterDeaneryApiArg = {
  apiRegistrationRegisterDeaneryRequestDto: ApiRegistrationRegisterDeaneryRequestDto;
};
export type PostApiRegistrationRegisterAdminApiResponse =
  /** status 200 OK */ ApiRegistrationRegisterBaseResponseDto;
export type PostApiRegistrationRegisterAdminApiArg = {
  apiRegistrationRegisterAdminRequestDto: ApiRegistrationRegisterAdminRequestDto;
};
export type GetApiRegistrationGetAvailableUniversityPositionsApiResponse =
  /** status 200 OK */ ApiRegistrationGetAvailableUniversityPositionsResponseDto;
export type GetApiRegistrationGetAvailableUniversityPositionsApiArg = void;
export type GetApiRegistrationGetAvailableGroupsApiResponse =
  /** status 200 OK */ ApiRegistrationGetAvailableGroupsResponseDto;
export type GetApiRegistrationGetAvailableGroupsApiArg = {
  number: string;
};
export type GetApiRegistrationGetAvailableFacultiesApiResponse =
  /** status 200 OK */ ApiRegistrationGetAvailableFacultiesResponseDto;
export type GetApiRegistrationGetAvailableFacultiesApiArg = void;
export type GetApiRegistrationGetAvailableDepartmentsApiResponse =
  /** status 200 OK */ ApiRegistrationGetAvailableDepartmentsResponseDto;
export type GetApiRegistrationGetAvailableDepartmentsApiArg = {
  facultyId: string;
};
export type GetApiSpecialtiesGetApiResponse =
  /** status 200 OK */ ApiSpecialtiesGetResponseDtoRead;
export type GetApiSpecialtiesGetApiArg = {
  departmentId: string;
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
  /** status 200 OK */ ApiSpecialtiesCreateResponseDto;
export type PostApiSpecialtiesCreateApiArg = {
  apiSpecialtiesCreateRequestDto: ApiSpecialtiesCreateRequestDto;
};
export type PutApiUsersUpdateVerificationApiResponse = unknown;
export type PutApiUsersUpdateVerificationApiArg = {
  apiUsersUpdateVerificationRequestDto: ApiUsersUpdateVerificationRequestDto;
};
export type PutApiUsersUpdateBlockingApiResponse = unknown;
export type PutApiUsersUpdateBlockingApiArg = {
  apiUsersUpdateBlockingRequestDto: ApiUsersUpdateBlockingRequestDto;
};
export type GetApiUsersGetTeachersApiResponse =
  /** status 200 OK */ ApiUsersGetTeachersResponseDtoRead;
export type GetApiUsersGetTeachersApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiUsersGetStudentsApiResponse =
  /** status 200 OK */ ApiUsersGetStudentsResponseDtoRead;
export type GetApiUsersGetStudentsApiArg = {
  periodId: string;
  groupId?: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiUsersGetDeaneriesApiResponse =
  /** status 200 OK */ ApiUsersGetDeaneriesResponseDtoRead;
export type GetApiUsersGetDeaneriesApiArg = {
  facultyId?: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type GetApiUsersGetAdminsApiResponse =
  /** status 200 OK */ ApiUsersGetAdminsResponseDtoRead;
export type GetApiUsersGetAdminsApiArg = {
  pageNumber: number;
  pageSize: number;
  filter?: string;
  desc?: boolean;
  orderBy?: string;
};
export type ApiAuthRefreshResponseDto = {
  accessToken?: string | null;
  refreshToken?: string | null;
};
export type ApiAuthRefreshRequestDto = {
  accessToken: string;
  refreshToken: string;
};
export type ApiAuthLoginResponseDto = {
  accessToken?: string | null;
  refreshToken?: string | null;
};
export type ApiAuthLoginRequestDto = {
  userName: string;
  password: string;
};
export type ApiAuthInfoResponseDto = {
  userId?: string;
  role?: ApiContractsUserRoleTypeDto;
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
  departmentHead?: boolean;
};
export type ApiAuthChangePasswordRequestDto = {
  password: string;
  newPassword: string;
};
export type ApiDepartmentsGetDepartmentDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type ApiDepartmentsGetResponseDto = {
  items?: ApiDepartmentsGetDepartmentDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDepartmentsGetResponseDtoRead = {
  items?: ApiDepartmentsGetDepartmentDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDepartmentsGetFullDescriptionUserDto = {
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
export type ApiDepartmentsGetFullDescriptionResponseDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  head?: ApiDepartmentsGetFullDescriptionUserDto;
  teachers?: ApiDepartmentsGetFullDescriptionUserDto[] | null;
};
export type ApiDepartmentsCreateResponseDto = {
  id: string;
};
export type ApiDepartmentsCreateRequestDto = {
  name: string;
  shortName: string;
  facultyId: string;
};
export type ApiDiplomaProcessesGetInfoProjectTitleDto = {
  id?: string;
  title?: string | null;
  creatorId?: string;
  actorId?: string | null;
};
export type ApiDiplomaProcessesGetInfoResponseDto = {
  id?: string;
  name?: string | null;
  possibleFrom?: string | null;
  possibleTo?: string | null;
  requiredProjectTitles?: ApiDiplomaProcessesGetInfoProjectTitleDto[] | null;
  optionalProjectTitles?: ApiDiplomaProcessesGetInfoProjectTitleDto[] | null;
};
export type ApiDiplomaProcessesTeachersAddRequestDto = {
  diplomaProcessId: string;
  userId: string;
};
export type ApiDiplomaProcessesTeachersGetTeacherDto = {
  id: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  position: string;
};
export type ApiDiplomaProcessesTeachersGetResponseDto = {
  items?: ApiDiplomaProcessesTeachersGetTeacherDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDiplomaProcessesTeachersGetResponseDtoRead = {
  items?: ApiDiplomaProcessesTeachersGetTeacherDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDiplomaProcessesTeachersRemoveRequestDto = {
  diplomaProcessId: string;
  userId: string;
};
export type ApiDiplomaProcessesGroupsAddRequestDto = {
  diplomaProcessId: string;
  groupId: string;
};
export type ApiDiplomaProcessesGroupsGetFullDescriptionGroupDto = {
  id?: string;
  number?: string | null;
};
export type ApiDiplomaProcessesGroupsGetFullDescriptionResponseDto = {
  items?: ApiDiplomaProcessesGroupsGetFullDescriptionGroupDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDiplomaProcessesGroupsGetFullDescriptionResponseDtoRead = {
  items?: ApiDiplomaProcessesGroupsGetFullDescriptionGroupDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDiplomaProcessesGroupsRemoveRequestDto = {
  diplomaProcessId: string;
  groupId: string;
};
export type ApiDiplomaProcessesGetDiplomaProcessDto = {
  id?: string;
  name?: string | null;
};
export type ApiDiplomaProcessesGetResponseDto = {
  items?: ApiDiplomaProcessesGetDiplomaProcessDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDiplomaProcessesGetResponseDtoRead = {
  items?: ApiDiplomaProcessesGetDiplomaProcessDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDiplomaProcessesDiplomasGetStudentDto = {
  id: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  groupNumber: string;
};
export type ApiDiplomaProcessesDiplomasGetTeacherDto = {
  id: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  position: string;
};
export type ApiDiplomaProcessesDiplomasGetDiplomaDto = {
  id: string;
  title?: string | null;
  status?: YProcessingDomainDiplomaStatus;
  student: ApiDiplomaProcessesDiplomasGetStudentDto;
  supervisor?: ApiDiplomaProcessesDiplomasGetTeacherDto;
};
export type ApiDiplomaProcessesDiplomasGetResponseDto = {
  items?: ApiDiplomaProcessesDiplomasGetDiplomaDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDiplomaProcessesDiplomasGetResponseDtoRead = {
  items?: ApiDiplomaProcessesDiplomasGetDiplomaDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDiplomaProcessesDefenseSessionsCreateRequestDto = {
  name: string;
  date: string;
  committeeId: string;
  diplomaProcessId: string;
  studentIds: string[];
};
export type ApiDiplomaProcessesDefenseSessionsDeleteRequestDto = {
  id: string;
};
export type ApiDiplomaProcessesDefenseSessionsGetFreeStudentsStudentDto = {
  id: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  groupNumber: string;
};
export type ApiDiplomaProcessesDefenseSessionsGetFreeStudentsResponseDto = {
  students: ApiDiplomaProcessesDefenseSessionsGetFreeStudentsStudentDto[];
};
export type ApiDiplomaProcessesDefenseSessionsGetPageDefenseSessionDto = {
  id: string;
  date: string;
  committeeName: string;
};
export type ApiDiplomaProcessesDefenseSessionsGetPageResponseDto = {
  items?: ApiDiplomaProcessesDefenseSessionsGetPageDefenseSessionDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDiplomaProcessesDefenseSessionsGetPageResponseDtoRead = {
  items?: ApiDiplomaProcessesDefenseSessionsGetPageDefenseSessionDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDiplomaProcessesCreateResponseDto = {
  id?: string;
};
export type ApiDiplomaProcessesCreateRequestDto = {
  periodId: string;
  name: string;
};
export type ApiDiplomaProcessesCommitteesAddTeacherRequestDto = {
  diplomaProcessId: string;
  committeeId: string;
  userId: string;
};
export type ApiDiplomaProcessesCommitteesCreateRequestDto = {
  diplomaProcessId: string;
  name: string;
};
export type ApiDiplomaProcessesCommitteesDeleteRequestDto = {
  committeeId: string;
};
export type ApiDiplomaProcessesCommitteesGetTeacherDto = {
  id: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  position: string;
};
export type ApiDiplomaProcessesCommitteesGetCommitteeDto = {
  id: string;
  name: string;
  teachers: ApiDiplomaProcessesCommitteesGetTeacherDto[];
};
export type ApiDiplomaProcessesCommitteesGetResponseDto = {
  items?: ApiDiplomaProcessesCommitteesGetCommitteeDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiDiplomaProcessesCommitteesGetResponseDtoRead = {
  items?: ApiDiplomaProcessesCommitteesGetCommitteeDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiDiplomaProcessesCommitteesRemoveTeacherRequestDto = {
  diplomaProcessId: string;
  userId: string;
};
export type ApiFacultiesGetFacultyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type ApiFacultiesGetResponseDto = {
  items?: ApiFacultiesGetFacultyDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiFacultiesGetResponseDtoRead = {
  items?: ApiFacultiesGetFacultyDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiFacultiesGetFullDescriptionUserDto = {
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
export type ApiFacultiesGetFullDescriptionResponseDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  head?: ApiFacultiesGetFullDescriptionUserDto;
  deaneries?: ApiFacultiesGetFullDescriptionUserDto[] | null;
};
export type ApiFacultiesCreateResponseDto = {
  id?: string;
};
export type ApiFacultiesCreateRequestDto = {
  name: string;
  shortName: string;
};
export type ApiGroupsGetGroupDto = {
  id?: string;
  number?: string | null;
};
export type ApiGroupsGetResponseDto = {
  items?: ApiGroupsGetGroupDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiGroupsGetResponseDtoRead = {
  items?: ApiGroupsGetGroupDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiGroupsCreateResponseDto = {
  id: string;
};
export type ApiGroupsCreateRequestDto = {
  groupNumber: string;
  startDate: string;
  endDate: string;
  specialtyId: string;
  periodId: string;
};
export type ApiPeriodsGetPeriodDto = {
  id: string;
  name: string;
  from: string;
  to: string;
  comments?: string | null;
};
export type ApiPeriodsGetResponseDto = {
  list?: ApiPeriodsGetPeriodDto[] | null;
};
export type ApiPeriodsCreateResponseDto = {
  id: string;
};
export type ApiPeriodsCreateRequestDto = {
  name: string;
  from: string;
  to: string;
  comments?: string | null;
};
export type ApiRegistrationRegisterBaseResponseDto = {
  userId: string;
};
export type ApiRegistrationRegisterTeacherRequestDto = {
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
export type ApiRegistrationRegisterStudentRequestDto = {
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
export type ApiRegistrationRegisterDeaneryRequestDto = {
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
export type ApiRegistrationRegisterAdminRequestDto = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  phoneNumber?: string | null;
  birthday?: string | null;
};
export type ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto =
  {
    id?: string;
    name?: string | null;
  };
export type ApiRegistrationGetAvailableUniversityPositionsResponseDto = {
  list?:
    | ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto[]
    | null;
};
export type ApiRegistrationGetAvailableGroupsResponseDto = {
  groupNumbers?: string[] | null;
};
export type ApiRegistrationGetAvailableFacultiesFacultyDto = {
  id?: string;
  name?: string | null;
};
export type ApiRegistrationGetAvailableFacultiesResponseDto = {
  faculties?: ApiRegistrationGetAvailableFacultiesFacultyDto[] | null;
};
export type ApiRegistrationGetAvailableDepartmentsDepartmentDto = {
  id?: string;
  name?: string | null;
};
export type ApiRegistrationGetAvailableDepartmentsResponseDto = {
  departments?: ApiRegistrationGetAvailableDepartmentsDepartmentDto[] | null;
};
export type ApiSpecialtiesGetSpecialtyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type ApiSpecialtiesGetResponseDto = {
  items?: ApiSpecialtiesGetSpecialtyDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiSpecialtiesGetResponseDtoRead = {
  items?: ApiSpecialtiesGetSpecialtyDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiSpecialtiesCreateResponseDto = {
  id?: string;
};
export type ApiSpecialtiesCreateRequestDto = {
  name: string;
  shortName: string;
  code: string;
  departmentId: string;
};
export type ApiUsersUpdateVerificationRequestDto = {
  userId: string;
  isApproved: boolean;
};
export type ApiUsersUpdateBlockingRequestDto = {
  userId: string;
  isBlocked: boolean;
};
export type ApiUsersGetTeachersTeacherDto = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
  position?: string | null;
};
export type ApiUsersGetTeachersTeacherDtoPagedList = {
  items?: ApiUsersGetTeachersTeacherDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiUsersGetTeachersTeacherDtoPagedListRead = {
  items?: ApiUsersGetTeachersTeacherDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiUsersGetTeachersResponseDto = {
  list?: ApiUsersGetTeachersTeacherDtoPagedList;
};
export type ApiUsersGetTeachersResponseDtoRead = {
  list?: ApiUsersGetTeachersTeacherDtoPagedListRead;
};
export type ApiUsersGetStudentsStudentDto = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
};
export type ApiUsersGetStudentsStudentDtoPagedList = {
  items?: ApiUsersGetStudentsStudentDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiUsersGetStudentsStudentDtoPagedListRead = {
  items?: ApiUsersGetStudentsStudentDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiUsersGetStudentsResponseDto = {
  list?: ApiUsersGetStudentsStudentDtoPagedList;
};
export type ApiUsersGetStudentsResponseDtoRead = {
  list?: ApiUsersGetStudentsStudentDtoPagedListRead;
};
export type ApiUsersGetDeaneriesDeaneryDto = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
  position?: string | null;
};
export type ApiUsersGetDeaneriesDeaneryDtoPagedList = {
  items?: ApiUsersGetDeaneriesDeaneryDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiUsersGetDeaneriesDeaneryDtoPagedListRead = {
  items?: ApiUsersGetDeaneriesDeaneryDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiUsersGetDeaneriesResponseDto = {
  list?: ApiUsersGetDeaneriesDeaneryDtoPagedList;
};
export type ApiUsersGetDeaneriesResponseDtoRead = {
  list?: ApiUsersGetDeaneriesDeaneryDtoPagedListRead;
};
export type ApiUsersGetAdminsAdminDto = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
  blocked?: boolean;
};
export type ApiUsersGetAdminsAdminDtoPagedList = {
  items?: ApiUsersGetAdminsAdminDto[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type ApiUsersGetAdminsAdminDtoPagedListRead = {
  items?: ApiUsersGetAdminsAdminDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type ApiUsersGetAdminsResponseDto = {
  list?: ApiUsersGetAdminsAdminDtoPagedList;
};
export type ApiUsersGetAdminsResponseDtoRead = {
  list?: ApiUsersGetAdminsAdminDtoPagedListRead;
};
export enum ApiContractsUserRoleTypeDto {
  None = "None",
  Admin = "Admin",
  Deanery = "Deanery",
  Teacher = "Teacher",
  Student = "Student",
}
export enum YProcessingDomainDiplomaStatus {
  $0 = 0,
  $1 = 1,
  $2 = 2,
  $3 = 3,
  $4 = 4,
}
export const {
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
  useGetApiDiplomaProcessesGetInfoQuery,
  useLazyGetApiDiplomaProcessesGetInfoQuery,
  usePutApiDiplomaProcessesTeachersAddMutation,
  useGetApiDiplomaProcessesTeachersGetQuery,
  useLazyGetApiDiplomaProcessesTeachersGetQuery,
  usePutApiDiplomaProcessesTeachersRemoveMutation,
  usePutApiDiplomaProcessesGroupsAddMutation,
  useGetApiDiplomaProcessesGroupsGetFullDescriptionQuery,
  useLazyGetApiDiplomaProcessesGroupsGetFullDescriptionQuery,
  usePutApiDiplomaProcessesGroupsRemoveMutation,
  useGetApiDiplomaProcessesGetQuery,
  useLazyGetApiDiplomaProcessesGetQuery,
  useGetApiDiplomaProcessesDiplomasGetQuery,
  useLazyGetApiDiplomaProcessesDiplomasGetQuery,
  useDeleteApiDiplomaProcessesDeleteMutation,
  usePostApiDiplomaProcessesDefenseSessionsCreateMutation,
  useDeleteApiDiplomaProcessesDefenseSessionsDeleteMutation,
  useGetApiDiplomaProcessesDefenseSessionsGetFreeStudentsQuery,
  useLazyGetApiDiplomaProcessesDefenseSessionsGetFreeStudentsQuery,
  useGetApiDiplomaProcessesDefenseSessionsGetPageQuery,
  useLazyGetApiDiplomaProcessesDefenseSessionsGetPageQuery,
  usePostApiDiplomaProcessesCreateMutation,
  usePutApiDiplomaProcessesCommitteesAddTeacherMutation,
  usePostApiDiplomaProcessesCommitteesCreateMutation,
  useDeleteApiDiplomaProcessesCommitteesDeleteMutation,
  useGetApiDiplomaProcessesCommitteesGetQuery,
  useLazyGetApiDiplomaProcessesCommitteesGetQuery,
  usePutApiDiplomaProcessesCommitteesRemoveTeacherMutation,
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
  usePostApiRegistrationRegisterTeacherMutation,
  usePostApiRegistrationRegisterStudentMutation,
  usePostApiRegistrationRegisterDeaneryMutation,
  usePostApiRegistrationRegisterAdminMutation,
  useGetApiRegistrationGetAvailableUniversityPositionsQuery,
  useLazyGetApiRegistrationGetAvailableUniversityPositionsQuery,
  useGetApiRegistrationGetAvailableGroupsQuery,
  useLazyGetApiRegistrationGetAvailableGroupsQuery,
  useGetApiRegistrationGetAvailableFacultiesQuery,
  useLazyGetApiRegistrationGetAvailableFacultiesQuery,
  useGetApiRegistrationGetAvailableDepartmentsQuery,
  useLazyGetApiRegistrationGetAvailableDepartmentsQuery,
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
