import { emptySplitApi as api } from "./emptyApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    putApiAdminUsersUpdateApproval: build.mutation<
      PutApiAdminUsersUpdateApprovalApiResponse,
      PutApiAdminUsersUpdateApprovalApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Users/UpdateApproval`,
        method: "PUT",
        body: queryArg.adminUsersUpdateApprovalRequest,
      }),
    }),
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
          Filter: queryArg.filter,
        },
      }),
    }),
    deleteApiAdminUniversitiesDelete: build.mutation<
      DeleteApiAdminUniversitiesDeleteApiResponse,
      DeleteApiAdminUniversitiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Universities/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiAdminUniversitiesCreate: build.mutation<
      PostApiAdminUniversitiesCreateApiResponse,
      PostApiAdminUniversitiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Universities/Create`,
        method: "POST",
        body: queryArg.adminUniversitiesCreateRequest,
      }),
    }),
    patchApiAdminUniversitiesChangeAdmin: build.mutation<
      PatchApiAdminUniversitiesChangeAdminApiResponse,
      PatchApiAdminUniversitiesChangeAdminApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Universities/ChangeAdmin`,
        method: "PATCH",
        body: queryArg.adminUniversitiesChangeAdminRequest,
      }),
    }),
    deleteApiAdminSpecialtiesDelete: build.mutation<
      DeleteApiAdminSpecialtiesDeleteApiResponse,
      DeleteApiAdminSpecialtiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Specialties/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiAdminSpecialtiesCreate: build.mutation<
      PostApiAdminSpecialtiesCreateApiResponse,
      PostApiAdminSpecialtiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Specialties/Create`,
        method: "POST",
        body: queryArg.adminSpecialtiesCreateRequest,
      }),
    }),
    deleteApiAdminGroupsDelete: build.mutation<
      DeleteApiAdminGroupsDeleteApiResponse,
      DeleteApiAdminGroupsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Groups/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiAdminGroupsCreate: build.mutation<
      PostApiAdminGroupsCreateApiResponse,
      PostApiAdminGroupsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Groups/Create`,
        method: "POST",
        body: queryArg.adminGroupsCreateRequest,
      }),
    }),
    deleteApiAdminFacultiesDelete: build.mutation<
      DeleteApiAdminFacultiesDeleteApiResponse,
      DeleteApiAdminFacultiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Faculties/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiAdminFacultiesCreate: build.mutation<
      PostApiAdminFacultiesCreateApiResponse,
      PostApiAdminFacultiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Faculties/Create`,
        method: "POST",
        body: queryArg.adminFacultiesCreateRequest,
      }),
    }),
    deleteApiAdminDiplomaPeriodsUsersRemove: build.mutation<
      DeleteApiAdminDiplomaPeriodsUsersRemoveApiResponse,
      DeleteApiAdminDiplomaPeriodsUsersRemoveApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/DiplomaPeriods/Users/Remove`,
        method: "DELETE",
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          UserIds: queryArg.userIds,
        },
      }),
    }),
    getApiAdminDiplomaPeriodsUsersGet: build.query<
      GetApiAdminDiplomaPeriodsUsersGetApiResponse,
      GetApiAdminDiplomaPeriodsUsersGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/DiplomaPeriods/Users/Get`,
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          RoleType: queryArg.roleType,
        },
      }),
    }),
    postApiAdminDiplomaPeriodsUsersAdd: build.mutation<
      PostApiAdminDiplomaPeriodsUsersAddApiResponse,
      PostApiAdminDiplomaPeriodsUsersAddApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/DiplomaPeriods/Users/Add`,
        method: "POST",
        body: queryArg.adminDiplomaPeriodsUsersAddRequest,
      }),
    }),
    deleteApiAdminDiplomaPeriodsDelete: build.mutation<
      DeleteApiAdminDiplomaPeriodsDeleteApiResponse,
      DeleteApiAdminDiplomaPeriodsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/DiplomaPeriods/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiAdminDiplomaPeriodsCreate: build.mutation<
      PostApiAdminDiplomaPeriodsCreateApiResponse,
      PostApiAdminDiplomaPeriodsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/DiplomaPeriods/Create`,
        method: "POST",
        body: queryArg.adminDiplomaPeriodsCreateRequest,
      }),
    }),
    deleteApiAdminDepartmentsDelete: build.mutation<
      DeleteApiAdminDepartmentsDeleteApiResponse,
      DeleteApiAdminDepartmentsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Departments/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiAdminDepartmentsCreate: build.mutation<
      PostApiAdminDepartmentsCreateApiResponse,
      PostApiAdminDepartmentsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Admin/Departments/Create`,
        method: "POST",
        body: queryArg.adminDepartmentsCreateRequest,
      }),
    }),
    getApiCommonGetUniversities: build.query<
      GetApiCommonGetUniversitiesApiResponse,
      GetApiCommonGetUniversitiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Common/GetUniversities`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiCommonGetSpecialties: build.query<
      GetApiCommonGetSpecialtiesApiResponse,
      GetApiCommonGetSpecialtiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Common/GetSpecialties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiCommonGetGroups: build.query<
      GetApiCommonGetGroupsApiResponse,
      GetApiCommonGetGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Common/GetGroups`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiCommonGetFaculties: build.query<
      GetApiCommonGetFacultiesApiResponse,
      GetApiCommonGetFacultiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Common/GetFaculties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiCommonGetDiplomaPeriods: build.query<
      GetApiCommonGetDiplomaPeriodsApiResponse,
      GetApiCommonGetDiplomaPeriodsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Common/GetDiplomaPeriods`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiCommonGetDepartments: build.query<
      GetApiCommonGetDepartmentsApiResponse,
      GetApiCommonGetDepartmentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Common/GetDepartments`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiIdentityRefresh: build.query<
      GetApiIdentityRefreshApiResponse,
      GetApiIdentityRefreshApiArg
    >({
      query: () => ({ url: `/api/Identity/Refresh` }),
    }),
    postApiIdentityLogout: build.mutation<
      PostApiIdentityLogoutApiResponse,
      PostApiIdentityLogoutApiArg
    >({
      query: () => ({ url: `/api/Identity/Logout`, method: "POST" }),
    }),
    postApiIdentityLogin: build.mutation<
      PostApiIdentityLoginApiResponse,
      PostApiIdentityLoginApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Identity/Login`,
        method: "POST",
        body: queryArg.identityLoginRequest,
      }),
    }),
    getApiIdentityInfo: build.query<
      GetApiIdentityInfoApiResponse,
      GetApiIdentityInfoApiArg
    >({
      query: () => ({ url: `/api/Identity/Info` }),
    }),
    postApiRegistrationStudentRegister: build.mutation<
      PostApiRegistrationStudentRegisterApiResponse,
      PostApiRegistrationStudentRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Student/Register`,
        method: "POST",
        body: queryArg.registrationStudentRegisterRequest,
      }),
    }),
    getApiRegistrationStudentGetAvailableGroups: build.query<
      GetApiRegistrationStudentGetAvailableGroupsApiResponse,
      GetApiRegistrationStudentGetAvailableGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Student/GetAvailableGroups`,
        params: {
          Number: queryArg["number"],
        },
      }),
    }),
    postApiRegistrationEmployeeRegister: build.mutation<
      PostApiRegistrationEmployeeRegisterApiResponse,
      PostApiRegistrationEmployeeRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Employee/Register`,
        method: "POST",
        body: queryArg.registrationEmployeeRegisterRequest,
      }),
    }),
    getApiRegistrationEmployeeGetAvailableUniversityPositions: build.query<
      GetApiRegistrationEmployeeGetAvailableUniversityPositionsApiResponse,
      GetApiRegistrationEmployeeGetAvailableUniversityPositionsApiArg
    >({
      query: () => ({
        url: `/api/Registration/Employee/GetAvailableUniversityPositions`,
      }),
    }),
    getApiRegistrationEmployeeGetAvailableUniversities: build.query<
      GetApiRegistrationEmployeeGetAvailableUniversitiesApiResponse,
      GetApiRegistrationEmployeeGetAvailableUniversitiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Employee/GetAvailableUniversities`,
        params: {
          Name: queryArg.name,
        },
      }),
    }),
    postApiRegistrationAdminRegister: build.mutation<
      PostApiRegistrationAdminRegisterApiResponse,
      PostApiRegistrationAdminRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/Registration/Admin/Register`,
        method: "POST",
        body: queryArg.registrationAdminRegisterRequest,
      }),
    }),
  }),
  overrideExisting: false,
});
export { injectedRtkApi as backendApi };
export type PutApiAdminUsersUpdateApprovalApiResponse = unknown;
export type PutApiAdminUsersUpdateApprovalApiArg = {
  adminUsersUpdateApprovalRequest: AdminUsersUpdateApprovalRequest;
};
export type GetApiAdminUsersGetApiResponse =
  /** status 200 OK */ AdminUsersGetResponseRead;
export type GetApiAdminUsersGetApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type DeleteApiAdminUniversitiesDeleteApiResponse = unknown;
export type DeleteApiAdminUniversitiesDeleteApiArg = {
  id: string;
};
export type PostApiAdminUniversitiesCreateApiResponse =
  /** status 200 OK */ AdminUniversitiesCreateResponse;
export type PostApiAdminUniversitiesCreateApiArg = {
  adminUniversitiesCreateRequest: AdminUniversitiesCreateRequest;
};
export type PatchApiAdminUniversitiesChangeAdminApiResponse = unknown;
export type PatchApiAdminUniversitiesChangeAdminApiArg = {
  adminUniversitiesChangeAdminRequest: AdminUniversitiesChangeAdminRequest;
};
export type DeleteApiAdminSpecialtiesDeleteApiResponse = unknown;
export type DeleteApiAdminSpecialtiesDeleteApiArg = {
  id: string;
};
export type PostApiAdminSpecialtiesCreateApiResponse =
  /** status 200 OK */ AdminSpecialtiesCreateResponse;
export type PostApiAdminSpecialtiesCreateApiArg = {
  adminSpecialtiesCreateRequest: AdminSpecialtiesCreateRequest;
};
export type DeleteApiAdminGroupsDeleteApiResponse = unknown;
export type DeleteApiAdminGroupsDeleteApiArg = {
  id: string;
};
export type PostApiAdminGroupsCreateApiResponse =
  /** status 200 OK */ AdminGroupsCreateResponse;
export type PostApiAdminGroupsCreateApiArg = {
  adminGroupsCreateRequest: AdminGroupsCreateRequest;
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
export type DeleteApiAdminDiplomaPeriodsUsersRemoveApiResponse = unknown;
export type DeleteApiAdminDiplomaPeriodsUsersRemoveApiArg = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type GetApiAdminDiplomaPeriodsUsersGetApiResponse =
  /** status 200 OK */ AdminDiplomaPeriodsUsersGetResponse;
export type GetApiAdminDiplomaPeriodsUsersGetApiArg = {
  diplomaPeriodId: string;
  roleType: ContractsUserRoleType;
};
export type PostApiAdminDiplomaPeriodsUsersAddApiResponse = unknown;
export type PostApiAdminDiplomaPeriodsUsersAddApiArg = {
  adminDiplomaPeriodsUsersAddRequest: AdminDiplomaPeriodsUsersAddRequest;
};
export type DeleteApiAdminDiplomaPeriodsDeleteApiResponse = unknown;
export type DeleteApiAdminDiplomaPeriodsDeleteApiArg = {
  id: string;
};
export type PostApiAdminDiplomaPeriodsCreateApiResponse =
  /** status 200 OK */ AdminDiplomaPeriodsCreateResponse;
export type PostApiAdminDiplomaPeriodsCreateApiArg = {
  adminDiplomaPeriodsCreateRequest: AdminDiplomaPeriodsCreateRequest;
};
export type DeleteApiAdminDepartmentsDeleteApiResponse = unknown;
export type DeleteApiAdminDepartmentsDeleteApiArg = {
  id: string;
};
export type PostApiAdminDepartmentsCreateApiResponse =
  /** status 200 OK */ AdminDepartmentsCreateResponse;
export type PostApiAdminDepartmentsCreateApiArg = {
  adminDepartmentsCreateRequest: AdminDepartmentsCreateRequest;
};
export type GetApiCommonGetUniversitiesApiResponse =
  /** status 200 OK */ CommonGetUniversitiesResponseRead;
export type GetApiCommonGetUniversitiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiCommonGetSpecialtiesApiResponse =
  /** status 200 OK */ CommonGetSpecialtiesResponseRead;
export type GetApiCommonGetSpecialtiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiCommonGetGroupsApiResponse =
  /** status 200 OK */ CommonGetGroupsResponseRead;
export type GetApiCommonGetGroupsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiCommonGetFacultiesApiResponse =
  /** status 200 OK */ CommonGetFacultiesResponseRead;
export type GetApiCommonGetFacultiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiCommonGetDiplomaPeriodsApiResponse =
  /** status 200 OK */ CommonGetDiplomaPeriodsResponseRead;
export type GetApiCommonGetDiplomaPeriodsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiCommonGetDepartmentsApiResponse =
  /** status 200 OK */ CommonGetDepartmentsResponseRead;
export type GetApiCommonGetDepartmentsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiIdentityRefreshApiResponse =
  /** status 200 OK */ IdentityRefreshResponse;
export type GetApiIdentityRefreshApiArg = void;
export type PostApiIdentityLogoutApiResponse = unknown;
export type PostApiIdentityLogoutApiArg = void;
export type PostApiIdentityLoginApiResponse =
  /** status 200 OK */ IdentityLoginResponse;
export type PostApiIdentityLoginApiArg = {
  identityLoginRequest: IdentityLoginRequest;
};
export type GetApiIdentityInfoApiResponse =
  /** status 200 OK */ IdentityInfoResponse;
export type GetApiIdentityInfoApiArg = void;
export type PostApiRegistrationStudentRegisterApiResponse = unknown;
export type PostApiRegistrationStudentRegisterApiArg = {
  registrationStudentRegisterRequest: RegistrationStudentRegisterRequest;
};
export type GetApiRegistrationStudentGetAvailableGroupsApiResponse =
  /** status 200 OK */ RegistrationStudentGetAvailableGroupsResponse;
export type GetApiRegistrationStudentGetAvailableGroupsApiArg = {
  number: string;
};
export type PostApiRegistrationEmployeeRegisterApiResponse = unknown;
export type PostApiRegistrationEmployeeRegisterApiArg = {
  registrationEmployeeRegisterRequest: RegistrationEmployeeRegisterRequest;
};
export type GetApiRegistrationEmployeeGetAvailableUniversityPositionsApiResponse =
  /** status 200 OK */ RegistrationEmployeeGetAvailableUniversityPositionsResponse;
export type GetApiRegistrationEmployeeGetAvailableUniversityPositionsApiArg =
  void;
export type GetApiRegistrationEmployeeGetAvailableUniversitiesApiResponse =
  /** status 200 OK */ RegistrationEmployeeGetAvailableUniversitiesResponse;
export type GetApiRegistrationEmployeeGetAvailableUniversitiesApiArg = {
  name: string;
};
export type PostApiRegistrationAdminRegisterApiResponse = unknown;
export type PostApiRegistrationAdminRegisterApiArg = {
  registrationAdminRegisterRequest: RegistrationAdminRegisterRequest;
};
export type AdminUsersUpdateApprovalRequest = {
  userId: string;
  isApproved: boolean;
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
export type AdminUniversitiesCreateResponse = {
  id?: string;
};
export type AdminUniversitiesCreateRequest = {
  name: string;
  shortName: string;
  adminId?: string | null;
};
export type AdminUniversitiesChangeAdminRequest = {
  universityId: string;
  userId: string;
};
export type AdminSpecialtiesCreateResponse = {
  id?: string;
};
export type AdminSpecialtiesCreateRequest = {
  name: string;
  shortName: string;
  code: string;
  departmentId?: string | null;
};
export type AdminGroupsCreateResponse = {
  id: string;
};
export type AdminGroupsCreateRequest = {
  groupNumber: string;
  startDate: string;
  endDate: string;
  specialtyId?: string | null;
};
export type AdminFacultiesCreateResponse = {
  id?: string;
};
export type AdminFacultiesCreateRequest = {
  name: string;
  shortName: string;
  universityId?: string | null;
};
export type AdminDiplomaPeriodsUsersGetDiplomaPeriodUser = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  universityPosition?: string | null;
  added?: boolean;
};
export type AdminDiplomaPeriodsUsersGetResponse = {
  list?: AdminDiplomaPeriodsUsersGetDiplomaPeriodUser[] | null;
};
export type AdminDiplomaPeriodsUsersAddRequest = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type AdminDiplomaPeriodsCreateResponse = {
  id?: string;
};
export type AdminDiplomaPeriodsCreateRequest = {
  startDate: string;
  endDate: string;
  name: string;
};
export type AdminDepartmentsCreateResponse = {
  id?: string;
};
export type AdminDepartmentsCreateRequest = {
  name: string;
  shortName: string;
  facultyId?: string | null;
};
export type CommonGetUniversitiesUniversity = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type CommonGetUniversitiesUniversityPagedList = {
  items?: CommonGetUniversitiesUniversity[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type CommonGetUniversitiesUniversityPagedListRead = {
  items?: CommonGetUniversitiesUniversity[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type CommonGetUniversitiesResponse = {
  list?: CommonGetUniversitiesUniversityPagedList;
};
export type CommonGetUniversitiesResponseRead = {
  list?: CommonGetUniversitiesUniversityPagedListRead;
};
export type CommonGetSpecialtiesSpecialty = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type CommonGetSpecialtiesSpecialtyPagedList = {
  items?: CommonGetSpecialtiesSpecialty[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type CommonGetSpecialtiesSpecialtyPagedListRead = {
  items?: CommonGetSpecialtiesSpecialty[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type CommonGetSpecialtiesResponse = {
  list?: CommonGetSpecialtiesSpecialtyPagedList;
};
export type CommonGetSpecialtiesResponseRead = {
  list?: CommonGetSpecialtiesSpecialtyPagedListRead;
};
export type CommonGetGroupsGroup = {
  id?: string;
  number?: string | null;
};
export type CommonGetGroupsGroupPagedList = {
  items?: CommonGetGroupsGroup[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type CommonGetGroupsGroupPagedListRead = {
  items?: CommonGetGroupsGroup[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type CommonGetGroupsResponse = {
  list?: CommonGetGroupsGroupPagedList;
};
export type CommonGetGroupsResponseRead = {
  list?: CommonGetGroupsGroupPagedListRead;
};
export type CommonGetFacultiesFaculty = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type CommonGetFacultiesFacultyPagedList = {
  items?: CommonGetFacultiesFaculty[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type CommonGetFacultiesFacultyPagedListRead = {
  items?: CommonGetFacultiesFaculty[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type CommonGetFacultiesResponse = {
  list?: CommonGetFacultiesFacultyPagedList;
};
export type CommonGetFacultiesResponseRead = {
  list?: CommonGetFacultiesFacultyPagedListRead;
};
export type CommonGetDiplomaPeriodsDiplomaPeriod = {
  id?: string;
  name?: string | null;
  studyPeriodFrom?: string;
  studyPeriodTo?: string;
};
export type CommonGetDiplomaPeriodsDiplomaPeriodPagedList = {
  items?: CommonGetDiplomaPeriodsDiplomaPeriod[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type CommonGetDiplomaPeriodsDiplomaPeriodPagedListRead = {
  items?: CommonGetDiplomaPeriodsDiplomaPeriod[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type CommonGetDiplomaPeriodsResponse = {
  list?: CommonGetDiplomaPeriodsDiplomaPeriodPagedList;
};
export type CommonGetDiplomaPeriodsResponseRead = {
  list?: CommonGetDiplomaPeriodsDiplomaPeriodPagedListRead;
};
export type CommonGetDepartmentsDepartment = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type CommonGetDepartmentsDepartmentPagedList = {
  items?: CommonGetDepartmentsDepartment[] | null;
  currentPage?: number;
  pageSize?: number;
};
export type CommonGetDepartmentsDepartmentPagedListRead = {
  items?: CommonGetDepartmentsDepartment[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type CommonGetDepartmentsResponse = {
  list?: CommonGetDepartmentsDepartmentPagedList;
};
export type CommonGetDepartmentsResponseRead = {
  list?: CommonGetDepartmentsDepartmentPagedListRead;
};
export type ContractsToken = {
  value?: string | null;
  expiration?: string;
};
export type IdentityRefreshResponse = {
  accessToken?: ContractsToken;
  refreshToken?: ContractsToken;
};
export type IdentityLoginResponse = {
  accessToken?: ContractsToken;
  refreshToken?: ContractsToken;
};
export type IdentityLoginRequest = {
  userName: string;
  password: string;
};
export type IdentityInfoResponse = {
  userId?: string;
  roleType?: ContractsUserRoleType;
  approved?: boolean;
};
export type RegistrationStudentRegisterRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
  groupNumber?: string | null;
};
export type RegistrationStudentGetAvailableGroupsResponse = {
  groupNumbers?: string[] | null;
};
export type RegistrationEmployeeRegisterRequest = {
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
export type RegistrationEmployeeGetAvailableUniversityPositionsUniversityPosition =
  {
    id?: string;
    name?: string | null;
  };
export type RegistrationEmployeeGetAvailableUniversityPositionsResponse = {
  list?:
    | RegistrationEmployeeGetAvailableUniversityPositionsUniversityPosition[]
    | null;
};
export type RegistrationEmployeeGetAvailableUniversitiesUniversity = {
  id?: string;
  name?: string | null;
};
export type RegistrationEmployeeGetAvailableUniversitiesResponse = {
  list?: RegistrationEmployeeGetAvailableUniversitiesUniversity[] | null;
};
export type RegistrationAdminRegisterRequest = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
};
export enum ContractsUserRoleType {
  None = "None",
  Admin = "Admin",
  Employee = "Employee",
  Student = "Student",
}
export const {
  usePutApiAdminUsersUpdateApprovalMutation,
  useGetApiAdminUsersGetQuery,
  useLazyGetApiAdminUsersGetQuery,
  useDeleteApiAdminUniversitiesDeleteMutation,
  usePostApiAdminUniversitiesCreateMutation,
  usePatchApiAdminUniversitiesChangeAdminMutation,
  useDeleteApiAdminSpecialtiesDeleteMutation,
  usePostApiAdminSpecialtiesCreateMutation,
  useDeleteApiAdminGroupsDeleteMutation,
  usePostApiAdminGroupsCreateMutation,
  useDeleteApiAdminFacultiesDeleteMutation,
  usePostApiAdminFacultiesCreateMutation,
  useDeleteApiAdminDiplomaPeriodsUsersRemoveMutation,
  useGetApiAdminDiplomaPeriodsUsersGetQuery,
  useLazyGetApiAdminDiplomaPeriodsUsersGetQuery,
  usePostApiAdminDiplomaPeriodsUsersAddMutation,
  useDeleteApiAdminDiplomaPeriodsDeleteMutation,
  usePostApiAdminDiplomaPeriodsCreateMutation,
  useDeleteApiAdminDepartmentsDeleteMutation,
  usePostApiAdminDepartmentsCreateMutation,
  useGetApiCommonGetUniversitiesQuery,
  useLazyGetApiCommonGetUniversitiesQuery,
  useGetApiCommonGetSpecialtiesQuery,
  useLazyGetApiCommonGetSpecialtiesQuery,
  useGetApiCommonGetGroupsQuery,
  useLazyGetApiCommonGetGroupsQuery,
  useGetApiCommonGetFacultiesQuery,
  useLazyGetApiCommonGetFacultiesQuery,
  useGetApiCommonGetDiplomaPeriodsQuery,
  useLazyGetApiCommonGetDiplomaPeriodsQuery,
  useGetApiCommonGetDepartmentsQuery,
  useLazyGetApiCommonGetDepartmentsQuery,
  useGetApiIdentityRefreshQuery,
  useLazyGetApiIdentityRefreshQuery,
  usePostApiIdentityLogoutMutation,
  usePostApiIdentityLoginMutation,
  useGetApiIdentityInfoQuery,
  useLazyGetApiIdentityInfoQuery,
  usePostApiRegistrationStudentRegisterMutation,
  useGetApiRegistrationStudentGetAvailableGroupsQuery,
  useLazyGetApiRegistrationStudentGetAvailableGroupsQuery,
  usePostApiRegistrationEmployeeRegisterMutation,
  useGetApiRegistrationEmployeeGetAvailableUniversityPositionsQuery,
  useLazyGetApiRegistrationEmployeeGetAvailableUniversityPositionsQuery,
  useGetApiRegistrationEmployeeGetAvailableUniversitiesQuery,
  useLazyGetApiRegistrationEmployeeGetAvailableUniversitiesQuery,
  usePostApiRegistrationAdminRegisterMutation,
} = injectedRtkApi;
