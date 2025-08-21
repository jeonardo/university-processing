import { emptySplitApi as api } from './emptyApi';

const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    getApiAdminUsersGet: build.query<
      GetApiAdminUsersGetApiResponse,
      GetApiAdminUsersGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Users/Get`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    }),
    postApiAdminRegister: build.mutation<
      PostApiAdminRegisterApiResponse,
      PostApiAdminRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Register`,
        method: 'POST',
        body: queryArg.adminRegisterRequest
      })
    }),
    deleteApiAdminPeriodsDelete: build.mutation<
      DeleteApiAdminPeriodsDeleteApiResponse,
      DeleteApiAdminPeriodsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Periods/Delete`,
        method: 'DELETE',
        params: {
          Id: queryArg.id
        }
      })
    }),
    postApiAdminPeriodsCreate: build.mutation<
      PostApiAdminPeriodsCreateApiResponse,
      PostApiAdminPeriodsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Periods/Create`,
        method: 'POST',
        body: queryArg.adminPeriodsCreateRequest
      })
    }),
    getApiAdminFacultiesGet: build.query<
      GetApiAdminFacultiesGetApiResponse,
      GetApiAdminFacultiesGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Faculties/Get`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    }),
    deleteApiAdminFacultiesDelete: build.mutation<
      DeleteApiAdminFacultiesDeleteApiResponse,
      DeleteApiAdminFacultiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Faculties/Delete`,
        method: 'DELETE',
        params: {
          Id: queryArg.id
        }
      })
    }),
    postApiAdminFacultiesCreate: build.mutation<
      PostApiAdminFacultiesCreateApiResponse,
      PostApiAdminFacultiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Faculties/Create`,
        method: 'POST',
        body: queryArg.adminFacultiesCreateRequest
      })
    }),
    postApiAuthRegistrationStudentRegister: build.mutation<
      PostApiAuthRegistrationStudentRegisterApiResponse,
      PostApiAuthRegistrationStudentRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Student/Register`,
        method: 'POST',
        body: queryArg.authRegistrationStudentRegisterRequest
      })
    }),
    getApiAuthRegistrationStudentGetAvailableGroups: build.query<
      GetApiAuthRegistrationStudentGetAvailableGroupsApiResponse,
      GetApiAuthRegistrationStudentGetAvailableGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Student/GetAvailableGroups`,
        params: {
          Number: queryArg['number']
        }
      })
    }),
    postApiAuthRegistrationEmployeeRegister: build.mutation<
      PostApiAuthRegistrationEmployeeRegisterApiResponse,
      PostApiAuthRegistrationEmployeeRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Registration/Employee/Register`,
        method: 'POST',
        body: queryArg.authRegistrationEmployeeRegisterRequest
      })
    }),
    getApiAuthRegistrationEmployeeGetAvailableUniversityPositions: build.query<
      GetApiAuthRegistrationEmployeeGetAvailableUniversityPositionsApiResponse,
      GetApiAuthRegistrationEmployeeGetAvailableUniversityPositionsApiArg
    >({
      query: () => ({
        url: `/api/Auth/Registration/Employee/GetAvailableUniversityPositions`
      })
    }),
    getApiAuthRefresh: build.query<
      GetApiAuthRefreshApiResponse,
      GetApiAuthRefreshApiArg
    >({
      query: () => ({ url: `/api/Auth/Refresh` })
    }),
    postApiAuthLogout: build.mutation<
      PostApiAuthLogoutApiResponse,
      PostApiAuthLogoutApiArg
    >({
      query: () => ({ url: `/api/Auth/Logout`, method: 'POST' })
    }),
    postApiAuthLogin: build.mutation<
      PostApiAuthLoginApiResponse,
      PostApiAuthLoginApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/Login`,
        method: 'POST',
        body: queryArg.authLoginRequest
      })
    }),
    getApiAuthInfo: build.query<
      GetApiAuthInfoApiResponse,
      GetApiAuthInfoApiArg
    >({
      query: () => ({ url: `/api/Auth/Info` })
    }),
    postApiAuthChangePassword: build.mutation<
      PostApiAuthChangePasswordApiResponse,
      PostApiAuthChangePasswordApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Auth/ChangePassword`,
        method: 'POST',
        body: queryArg.authChangePasswordRequest
      })
    }),
    putApiEmployeeUpdateApproval: build.mutation<
      PutApiEmployeeUpdateApprovalApiResponse,
      PutApiEmployeeUpdateApprovalApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/UpdateApproval`,
        method: 'PUT',
        body: queryArg.employeeUpdateApprovalRequest
      })
    }),
    deleteApiEmployeeTeacherDepartmentLeaderSpecialtiesDelete: build.mutation<
      DeleteApiEmployeeTeacherDepartmentLeaderSpecialtiesDeleteApiResponse,
      DeleteApiEmployeeTeacherDepartmentLeaderSpecialtiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Teacher/DepartmentLeader/Specialties/Delete`,
        method: 'DELETE',
        params: {
          Id: queryArg.id
        }
      })
    }),
    postApiEmployeeTeacherDepartmentLeaderSpecialtiesCreate: build.mutation<
      PostApiEmployeeTeacherDepartmentLeaderSpecialtiesCreateApiResponse,
      PostApiEmployeeTeacherDepartmentLeaderSpecialtiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Teacher/DepartmentLeader/Specialties/Create`,
        method: 'POST',
        body: queryArg.employeeTeacherDepartmentLeaderSpecialtiesCreateRequest
      })
    }),
    deleteApiEmployeeTeacherDepartmentLeaderGroupsDelete: build.mutation<
      DeleteApiEmployeeTeacherDepartmentLeaderGroupsDeleteApiResponse,
      DeleteApiEmployeeTeacherDepartmentLeaderGroupsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Teacher/DepartmentLeader/Groups/Delete`,
        method: 'DELETE',
        params: {
          Id: queryArg.id
        }
      })
    }),
    postApiEmployeeTeacherDepartmentLeaderGroupsCreate: build.mutation<
      PostApiEmployeeTeacherDepartmentLeaderGroupsCreateApiResponse,
      PostApiEmployeeTeacherDepartmentLeaderGroupsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Teacher/DepartmentLeader/Groups/Create`,
        method: 'POST',
        body: queryArg.employeeTeacherDepartmentLeaderGroupsCreateRequest
      })
    }),
    deleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersRemove:
      build.mutation<
        DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersRemoveApiResponse,
        DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersRemoveApiArg
      >({
        query: (queryArg) => ({
          url: `/api/Employee/Teacher/DepartmentLeader/DiplomaProcesses/Users/Remove`,
          method: 'DELETE',
          params: {
            DiplomaPeriodId: queryArg.diplomaPeriodId,
            UserIds: queryArg.userIds
          }
        })
      }),
    getApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGet: build.query<
      GetApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetApiResponse,
      GetApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Teacher/DepartmentLeader/DiplomaProcesses/Users/Get`,
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          RoleType: queryArg.roleType
        }
      })
    }),
    postApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAdd:
      build.mutation<
        PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddApiResponse,
        PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddApiArg
      >({
        query: (queryArg) => ({
          url: `/api/Employee/Teacher/DepartmentLeader/DiplomaProcesses/Users/Add`,
          method: 'POST',
          body: queryArg.employeeTeacherDepartmentLeaderDiplomaProcessesUsersAddRequest
        })
      }),
    deleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesDelete:
      build.mutation<
        DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesDeleteApiResponse,
        DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesDeleteApiArg
      >({
        query: (queryArg) => ({
          url: `/api/Employee/Teacher/DepartmentLeader/DiplomaProcesses/Delete`,
          method: 'DELETE',
          params: {
            Id: queryArg.id
          }
        })
      }),
    postApiEmployeeTeacherDepartmentLeaderDiplomaProcessesCreate:
      build.mutation<
        PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesCreateApiResponse,
        PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesCreateApiArg
      >({
        query: (queryArg) => ({
          url: `/api/Employee/Teacher/DepartmentLeader/DiplomaProcesses/Create`,
          method: 'POST',
          body: queryArg.employeeTeacherDepartmentLeaderDiplomaProcessesCreateRequest
        })
      }),
    getApiEmployeeGetSpecialties: build.query<
      GetApiEmployeeGetSpecialtiesApiResponse,
      GetApiEmployeeGetSpecialtiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/GetSpecialties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    }),
    getApiEmployeeGetGroups: build.query<
      GetApiEmployeeGetGroupsApiResponse,
      GetApiEmployeeGetGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/GetGroups`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    }),
    getApiEmployeeGetDiplomaProcesses: build.query<
      GetApiEmployeeGetDiplomaProcessesApiResponse,
      GetApiEmployeeGetDiplomaProcessesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/GetDiplomaProcesses`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    }),
    getApiEmployeeGetDepartments: build.query<
      GetApiEmployeeGetDepartmentsApiResponse,
      GetApiEmployeeGetDepartmentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/GetDepartments`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    }),
    deleteApiEmployeeDeaneryDepartmentsDelete: build.mutation<
      DeleteApiEmployeeDeaneryDepartmentsDeleteApiResponse,
      DeleteApiEmployeeDeaneryDepartmentsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Deanery/Departments/Delete`,
        method: 'DELETE',
        params: {
          Id: queryArg.id
        }
      })
    }),
    postApiEmployeeDeaneryDepartmentsCreate: build.mutation<
      PostApiEmployeeDeaneryDepartmentsCreateApiResponse,
      PostApiEmployeeDeaneryDepartmentsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Employee/Deanery/Departments/Create`,
        method: 'POST',
        body: queryArg.employeeDeaneryDepartmentsCreateRequest
      })
    }),
    getApiNotificationsGet: build.query<
      GetApiNotificationsGetApiResponse,
      GetApiNotificationsGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Notifications/Get`,
        params: {
          PageNumber: queryArg.pageNumber
        }
      })
    }),
    getApiPeriodsGet: build.query<
      GetApiPeriodsGetApiResponse,
      GetApiPeriodsGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Periods/Get`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter
        }
      })
    })
  }),
  overrideExisting: false
});
export { injectedRtkApi as backendApi };
export type GetApiAdminUsersGetApiResponse =
/** status 200 OK */ AdminUsersGetResponseRead;
export type GetApiAdminUsersGetApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type PostApiAdminRegisterApiResponse = unknown;
export type PostApiAdminRegisterApiArg = {
  adminRegisterRequest: AdminRegisterRequest;
};
export type DeleteApiAdminPeriodsDeleteApiResponse = unknown;
export type DeleteApiAdminPeriodsDeleteApiArg = {
  id: string;
};
export type PostApiAdminPeriodsCreateApiResponse =
/** status 200 OK */ AdminPeriodsCreateResponse;
export type PostApiAdminPeriodsCreateApiArg = {
  adminPeriodsCreateRequest: AdminPeriodsCreateRequest;
};
export type GetApiAdminFacultiesGetApiResponse =
/** status 200 OK */ AdminFacultiesGetResponseRead;
export type GetApiAdminFacultiesGetApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type DeleteApiAdminFacultiesDeleteApiResponse = unknown;
export type DeleteApiAdminFacultiesDeleteApiArg = {
  id: string;
};
export type PostApiAdminFacultiesCreateApiResponse =
/** status 200 OK */ AdminFacultiesCreateResponse;
export type PostApiAdminFacultiesCreateApiArg = {
  adminFacultiesCreateRequest: AdminFacultiesCreateRequest;
};
export type PostApiAuthRegistrationStudentRegisterApiResponse = unknown;
export type PostApiAuthRegistrationStudentRegisterApiArg = {
  authRegistrationStudentRegisterRequest: AuthRegistrationStudentRegisterRequest;
};
export type GetApiAuthRegistrationStudentGetAvailableGroupsApiResponse =
/** status 200 OK */ AuthRegistrationStudentGetAvailableGroupsResponse;
export type GetApiAuthRegistrationStudentGetAvailableGroupsApiArg = {
  number: string;
};
export type PostApiAuthRegistrationEmployeeRegisterApiResponse = unknown;
export type PostApiAuthRegistrationEmployeeRegisterApiArg = {
  authRegistrationEmployeeRegisterRequest: AuthRegistrationEmployeeRegisterRequest;
};
export type GetApiAuthRegistrationEmployeeGetAvailableUniversityPositionsApiResponse =
/** status 200 OK */ AuthRegistrationEmployeeGetAvailableUniversityPositionsResponse;
export type GetApiAuthRegistrationEmployeeGetAvailableUniversityPositionsApiArg =
  void;
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
export type PutApiEmployeeUpdateApprovalApiResponse = unknown;
export type PutApiEmployeeUpdateApprovalApiArg = {
  employeeUpdateApprovalRequest: EmployeeUpdateApprovalRequest;
};
export type DeleteApiEmployeeTeacherDepartmentLeaderSpecialtiesDeleteApiResponse =
  unknown;
export type DeleteApiEmployeeTeacherDepartmentLeaderSpecialtiesDeleteApiArg = {
  id: string;
};
export type PostApiEmployeeTeacherDepartmentLeaderSpecialtiesCreateApiResponse =
/** status 200 OK */ EmployeeTeacherDepartmentLeaderSpecialtiesCreateResponse;
export type PostApiEmployeeTeacherDepartmentLeaderSpecialtiesCreateApiArg = {
  employeeTeacherDepartmentLeaderSpecialtiesCreateRequest: EmployeeTeacherDepartmentLeaderSpecialtiesCreateRequest;
};
export type DeleteApiEmployeeTeacherDepartmentLeaderGroupsDeleteApiResponse =
  unknown;
export type DeleteApiEmployeeTeacherDepartmentLeaderGroupsDeleteApiArg = {
  id: string;
};
export type PostApiEmployeeTeacherDepartmentLeaderGroupsCreateApiResponse =
/** status 200 OK */ EmployeeTeacherDepartmentLeaderGroupsCreateResponse;
export type PostApiEmployeeTeacherDepartmentLeaderGroupsCreateApiArg = {
  employeeTeacherDepartmentLeaderGroupsCreateRequest: EmployeeTeacherDepartmentLeaderGroupsCreateRequest;
};
export type DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersRemoveApiResponse =
  unknown;
export type DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersRemoveApiArg =
  {
    diplomaPeriodId: string;
    userIds: string[];
  };
export type GetApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetApiResponse =
/** status 200 OK */ EmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetResponse;
export type GetApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetApiArg =
  {
    diplomaPeriodId: string;
    roleType: ContractsUserRoleType;
  };
export type PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddApiResponse =
  unknown;
export type PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddApiArg =
  {
    employeeTeacherDepartmentLeaderDiplomaProcessesUsersAddRequest: EmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddRequest;
  };
export type DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesDeleteApiResponse =
  unknown;
export type DeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesDeleteApiArg =
  {
    id: string;
  };
export type PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesCreateApiResponse =
/** status 200 OK */ EmployeeTeacherDepartmentLeaderDiplomaProcessesCreateResponse;
export type PostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesCreateApiArg =
  {
    employeeTeacherDepartmentLeaderDiplomaProcessesCreateRequest: EmployeeTeacherDepartmentLeaderDiplomaProcessesCreateRequest;
  };
export type GetApiEmployeeGetSpecialtiesApiResponse =
/** status 200 OK */ EmployeeGetSpecialtiesResponseRead;
export type GetApiEmployeeGetSpecialtiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiEmployeeGetGroupsApiResponse =
/** status 200 OK */ EmployeeGetGroupsResponseRead;
export type GetApiEmployeeGetGroupsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiEmployeeGetDiplomaProcessesApiResponse =
/** status 200 OK */ EmployeeGetDiplomaProcessesResponseRead;
export type GetApiEmployeeGetDiplomaProcessesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiEmployeeGetDepartmentsApiResponse =
/** status 200 OK */ EmployeeGetDepartmentsResponseRead;
export type GetApiEmployeeGetDepartmentsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type DeleteApiEmployeeDeaneryDepartmentsDeleteApiResponse = unknown;
export type DeleteApiEmployeeDeaneryDepartmentsDeleteApiArg = {
  id: string;
};
export type PostApiEmployeeDeaneryDepartmentsCreateApiResponse =
/** status 200 OK */ EmployeeDeaneryDepartmentsCreateResponse;
export type PostApiEmployeeDeaneryDepartmentsCreateApiArg = {
  employeeDeaneryDepartmentsCreateRequest: EmployeeDeaneryDepartmentsCreateRequest;
};
export type GetApiNotificationsGetApiResponse =
/** status 200 OK */ NotificationsGetResponse;
export type GetApiNotificationsGetApiArg = {
  pageNumber: number;
};
export type GetApiPeriodsGetApiResponse =
/** status 200 OK */ PeriodsGetResponseRead;
export type GetApiPeriodsGetApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type AdminUsersGetUser = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
};
export type AdminUsersGetUserPagedList = {
  items?: AdminUsersGetUser[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type AdminUsersGetUserPagedListRead = {
  items?: AdminUsersGetUser[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type AdminUsersGetResponse = {
  list?: AdminUsersGetUserPagedList;
};
export type AdminUsersGetResponseRead = {
  list?: AdminUsersGetUserPagedListRead;
};
export type AdminRegisterRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
};
export type AdminPeriodsCreateResponse = {
  id?: string;
};
export type AdminPeriodsCreateRequest = {};
export type AdminPeriodsCreateRequestRead = {
  from: string;
  to: string;
  comments?: string | null;
};
export type AdminFacultiesGetFaculty = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type AdminFacultiesGetFacultyPagedList = {
  items?: AdminFacultiesGetFaculty[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type AdminFacultiesGetFacultyPagedListRead = {
  items?: AdminFacultiesGetFaculty[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type AdminFacultiesGetResponse = {
  list?: AdminFacultiesGetFacultyPagedList;
};
export type AdminFacultiesGetResponseRead = {
  list?: AdminFacultiesGetFacultyPagedListRead;
};
export type AdminFacultiesCreateResponse = {
  id?: string;
};
export type AdminFacultiesCreateRequest = {
  name: string;
  shortName: string;
};
export type AuthRegistrationStudentRegisterRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
  groupNumber?: string | null;
};
export type AuthRegistrationStudentGetAvailableGroupsResponse = {
  groupNumbers?: string[] | null;
};
export type AuthRegistrationEmployeeRegisterRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
  universityId?: string | null;
  universityPositionId?: string | null;
};
export type AuthRegistrationEmployeeGetAvailableUniversityPositionsUniversityPosition =
  {
    id?: string;
    name?: string | null;
  };
export type AuthRegistrationEmployeeGetAvailableUniversityPositionsResponse = {
  list?:
    | AuthRegistrationEmployeeGetAvailableUniversityPositionsUniversityPosition[]
    | null;
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
  roleType?: ContractsUserRoleType;
  approved?: boolean;
  blocked?: boolean;
};
export type AuthChangePasswordRequest = {
  userName: string;
  password: string;
  newPassword: string;
};
export type EmployeeUpdateApprovalRequest = {
  userId: string;
  isApproved: boolean;
};
export type EmployeeTeacherDepartmentLeaderSpecialtiesCreateResponse = {
  id?: string;
};
export type EmployeeTeacherDepartmentLeaderSpecialtiesCreateRequest = {
  name: string;
  shortName: string;
  code: string;
  departmentId?: string | null;
};
export type EmployeeTeacherDepartmentLeaderGroupsCreateResponse = {
  id: string;
};
export type EmployeeTeacherDepartmentLeaderGroupsCreateRequest = {
  groupNumber: string;
  startDate: string;
  endDate: string;
  specialtyId?: string | null;
};
export type EmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetDiplomaPeriodUser =
  {
    id?: string;
    firstName?: string | null;
    lastName?: string | null;
    middleName?: string | null;
    universityPosition?: string | null;
    added?: boolean;
  };
export type EmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetResponse = {
  list?:
    | EmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetDiplomaPeriodUser[]
    | null;
};
export type EmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddRequest = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type EmployeeTeacherDepartmentLeaderDiplomaProcessesCreateResponse = {
  id?: string;
};
export type EmployeeTeacherDepartmentLeaderDiplomaProcessesCreateRequest = {
  periodId: string;
  name: string;
};
export type EmployeeGetSpecialtiesSpecialty = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type EmployeeGetSpecialtiesSpecialtyPagedList = {
  items?: EmployeeGetSpecialtiesSpecialty[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type EmployeeGetSpecialtiesSpecialtyPagedListRead = {
  items?: EmployeeGetSpecialtiesSpecialty[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type EmployeeGetSpecialtiesResponse = {
  list?: EmployeeGetSpecialtiesSpecialtyPagedList;
};
export type EmployeeGetSpecialtiesResponseRead = {
  list?: EmployeeGetSpecialtiesSpecialtyPagedListRead;
};
export type EmployeeGetGroupsGroup = {
  id?: string;
  number?: string | null;
};
export type EmployeeGetGroupsGroupPagedList = {
  items?: EmployeeGetGroupsGroup[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type EmployeeGetGroupsGroupPagedListRead = {
  items?: EmployeeGetGroupsGroup[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type EmployeeGetGroupsResponse = {
  list?: EmployeeGetGroupsGroupPagedList;
};
export type EmployeeGetGroupsResponseRead = {
  list?: EmployeeGetGroupsGroupPagedListRead;
};
export type EmployeeGetDiplomaProcessesDiplomaProcess = {
  id?: string;
  name?: string | null;
};
export type EmployeeGetDiplomaProcessesDiplomaProcessPagedList = {
  items?: EmployeeGetDiplomaProcessesDiplomaProcess[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type EmployeeGetDiplomaProcessesDiplomaProcessPagedListRead = {
  items?: EmployeeGetDiplomaProcessesDiplomaProcess[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type EmployeeGetDiplomaProcessesResponse = {
  list?: EmployeeGetDiplomaProcessesDiplomaProcessPagedList;
};
export type EmployeeGetDiplomaProcessesResponseRead = {
  list?: EmployeeGetDiplomaProcessesDiplomaProcessPagedListRead;
};
export type EmployeeGetDepartmentsDepartment = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type EmployeeGetDepartmentsDepartmentPagedList = {
  items?: EmployeeGetDepartmentsDepartment[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type EmployeeGetDepartmentsDepartmentPagedListRead = {
  items?: EmployeeGetDepartmentsDepartment[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type EmployeeGetDepartmentsResponse = {
  list?: EmployeeGetDepartmentsDepartmentPagedList;
};
export type EmployeeGetDepartmentsResponseRead = {
  list?: EmployeeGetDepartmentsDepartmentPagedListRead;
};
export type EmployeeDeaneryDepartmentsCreateResponse = {
  id?: string;
};
export type EmployeeDeaneryDepartmentsCreateRequest = {
  name: string;
  shortName: string;
  facultyId?: string | null;
};
export type ContractsNotification = {
  title?: string | null;
  message?: string | null;
};
export type NotificationsGetResponse = {
  notifications?: ContractsNotification[] | null;
};
export type PeriodsGetPeriod = {
  id?: string;
  from?: string;
  to?: string;
  comments?: string | null;
};
export type PeriodsGetPeriodPagedList = {
  items?: PeriodsGetPeriod[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type PeriodsGetPeriodPagedListRead = {
  items?: PeriodsGetPeriod[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type PeriodsGetResponse = {
  list?: PeriodsGetPeriodPagedList;
};
export type PeriodsGetResponseRead = {
  list?: PeriodsGetPeriodPagedListRead;
};

export enum ContractsUserRoleType {
  None = 'None',
  Admin = 'Admin',
  Employee = 'Employee',
  Student = 'Student',
}

export const {
  useGetApiAdminUsersGetQuery,
  useLazyGetApiAdminUsersGetQuery,
  usePostApiAdminRegisterMutation,
  useDeleteApiAdminPeriodsDeleteMutation,
  usePostApiAdminPeriodsCreateMutation,
  useGetApiAdminFacultiesGetQuery,
  useLazyGetApiAdminFacultiesGetQuery,
  useDeleteApiAdminFacultiesDeleteMutation,
  usePostApiAdminFacultiesCreateMutation,
  usePostApiAuthRegistrationStudentRegisterMutation,
  useGetApiAuthRegistrationStudentGetAvailableGroupsQuery,
  useLazyGetApiAuthRegistrationStudentGetAvailableGroupsQuery,
  usePostApiAuthRegistrationEmployeeRegisterMutation,
  useGetApiAuthRegistrationEmployeeGetAvailableUniversityPositionsQuery,
  useLazyGetApiAuthRegistrationEmployeeGetAvailableUniversityPositionsQuery,
  useGetApiAuthRefreshQuery,
  useLazyGetApiAuthRefreshQuery,
  usePostApiAuthLogoutMutation,
  usePostApiAuthLoginMutation,
  useGetApiAuthInfoQuery,
  useLazyGetApiAuthInfoQuery,
  usePostApiAuthChangePasswordMutation,
  usePutApiEmployeeUpdateApprovalMutation,
  useDeleteApiEmployeeTeacherDepartmentLeaderSpecialtiesDeleteMutation,
  usePostApiEmployeeTeacherDepartmentLeaderSpecialtiesCreateMutation,
  useDeleteApiEmployeeTeacherDepartmentLeaderGroupsDeleteMutation,
  usePostApiEmployeeTeacherDepartmentLeaderGroupsCreateMutation,
  useDeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersRemoveMutation,
  useGetApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetQuery,
  useLazyGetApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersGetQuery,
  usePostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesUsersAddMutation,
  useDeleteApiEmployeeTeacherDepartmentLeaderDiplomaProcessesDeleteMutation,
  usePostApiEmployeeTeacherDepartmentLeaderDiplomaProcessesCreateMutation,
  useGetApiEmployeeGetSpecialtiesQuery,
  useLazyGetApiEmployeeGetSpecialtiesQuery,
  useGetApiEmployeeGetGroupsQuery,
  useLazyGetApiEmployeeGetGroupsQuery,
  useGetApiEmployeeGetDiplomaProcessesQuery,
  useLazyGetApiEmployeeGetDiplomaProcessesQuery,
  useGetApiEmployeeGetDepartmentsQuery,
  useLazyGetApiEmployeeGetDepartmentsQuery,
  useDeleteApiEmployeeDeaneryDepartmentsDeleteMutation,
  usePostApiEmployeeDeaneryDepartmentsCreateMutation,
  useGetApiNotificationsGetQuery,
  useLazyGetApiNotificationsGetQuery,
  useGetApiPeriodsGetQuery,
  useLazyGetApiPeriodsGetQuery
} = injectedRtkApi;
