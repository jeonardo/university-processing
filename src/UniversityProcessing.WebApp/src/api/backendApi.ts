import { emptySplitApi as api } from "./emptyApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    putApiV1AdminUsersUpdateApproval: build.mutation<
      PutApiV1AdminUsersUpdateApprovalApiResponse,
      PutApiV1AdminUsersUpdateApprovalApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Users/UpdateApproval`,
        method: "PUT",
        body: queryArg.universityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto,
      }),
    }),
    getApiV1AdminUsersGetUsers: build.query<
      GetApiV1AdminUsersGetUsersApiResponse,
      GetApiV1AdminUsersGetUsersApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Users/GetUsers`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          OrderBy: queryArg.orderBy,
          Desc: queryArg.desc,
        },
      }),
    }),
    deleteApiV1AdminUniversitiesDelete: build.mutation<
      DeleteApiV1AdminUniversitiesDeleteApiResponse,
      DeleteApiV1AdminUniversitiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Universities/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiV1AdminUniversitiesCreate: build.mutation<
      PostApiV1AdminUniversitiesCreateApiResponse,
      PostApiV1AdminUniversitiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Universities/Create`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto,
      }),
    }),
    patchApiV1AdminUniversitiesChangeAdmin: build.mutation<
      PatchApiV1AdminUniversitiesChangeAdminApiResponse,
      PatchApiV1AdminUniversitiesChangeAdminApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Universities/ChangeAdmin`,
        method: "PATCH",
        body: queryArg.universityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto,
      }),
    }),
    deleteApiV1AdminSpecialtiesDelete: build.mutation<
      DeleteApiV1AdminSpecialtiesDeleteApiResponse,
      DeleteApiV1AdminSpecialtiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Specialties/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiV1AdminSpecialtiesCreate: build.mutation<
      PostApiV1AdminSpecialtiesCreateApiResponse,
      PostApiV1AdminSpecialtiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Specialties/Create`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto,
      }),
    }),
    deleteApiV1AdminGroupsDelete: build.mutation<
      DeleteApiV1AdminGroupsDeleteApiResponse,
      DeleteApiV1AdminGroupsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Groups/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiV1AdminGroupsCreate: build.mutation<
      PostApiV1AdminGroupsCreateApiResponse,
      PostApiV1AdminGroupsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Groups/Create`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto,
      }),
    }),
    deleteApiV1AdminFacultiesDelete: build.mutation<
      DeleteApiV1AdminFacultiesDeleteApiResponse,
      DeleteApiV1AdminFacultiesDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Faculties/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiV1AdminFacultiesCreate: build.mutation<
      PostApiV1AdminFacultiesCreateApiResponse,
      PostApiV1AdminFacultiesCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Faculties/Create`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto,
      }),
    }),
    deleteApiV1AdminDiplomaPeriodsUsersRemove: build.mutation<
      DeleteApiV1AdminDiplomaPeriodsUsersRemoveApiResponse,
      DeleteApiV1AdminDiplomaPeriodsUsersRemoveApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/DiplomaPeriods/Users/Remove`,
        method: "DELETE",
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          UserIds: queryArg.userIds,
        },
      }),
    }),
    getApiV1AdminDiplomaPeriodsUsersGet: build.query<
      GetApiV1AdminDiplomaPeriodsUsersGetApiResponse,
      GetApiV1AdminDiplomaPeriodsUsersGetApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/DiplomaPeriods/Users/Get`,
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          RoleType: queryArg.roleType,
        },
      }),
    }),
    postApiV1AdminDiplomaPeriodsUsersAdd: build.mutation<
      PostApiV1AdminDiplomaPeriodsUsersAddApiResponse,
      PostApiV1AdminDiplomaPeriodsUsersAddApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/DiplomaPeriods/Users/Add`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto,
      }),
    }),
    deleteApiV1AdminDiplomaPeriodsDelete: build.mutation<
      DeleteApiV1AdminDiplomaPeriodsDeleteApiResponse,
      DeleteApiV1AdminDiplomaPeriodsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/DiplomaPeriods/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiV1AdminDiplomaPeriodsCreate: build.mutation<
      PostApiV1AdminDiplomaPeriodsCreateApiResponse,
      PostApiV1AdminDiplomaPeriodsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/DiplomaPeriods/Create`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto,
      }),
    }),
    deleteApiV1AdminDepartmentsDelete: build.mutation<
      DeleteApiV1AdminDepartmentsDeleteApiResponse,
      DeleteApiV1AdminDepartmentsDeleteApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Departments/Delete`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postApiV1AdminDepartmentsCreate: build.mutation<
      PostApiV1AdminDepartmentsCreateApiResponse,
      PostApiV1AdminDepartmentsCreateApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Admin/Departments/Create`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto,
      }),
    }),
    getApiV1IdentityRefresh: build.query<
      GetApiV1IdentityRefreshApiResponse,
      GetApiV1IdentityRefreshApiArg
    >({
      query: () => ({ url: `/api/v1/Identity/Refresh` }),
    }),
    postApiV1IdentityLogout: build.mutation<
      PostApiV1IdentityLogoutApiResponse,
      PostApiV1IdentityLogoutApiArg
    >({
      query: () => ({ url: `/api/v1/Identity/Logout`, method: "POST" }),
    }),
    postApiV1IdentityLogin: build.mutation<
      PostApiV1IdentityLoginApiResponse,
      PostApiV1IdentityLoginApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Identity/Login`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsIdentityLoginLoginRequestDto,
      }),
    }),
    getApiV1IdentityInfo: build.query<
      GetApiV1IdentityInfoApiResponse,
      GetApiV1IdentityInfoApiArg
    >({
      query: () => ({ url: `/api/v1/Identity/Info` }),
    }),
    postApiV1RegistrationStudentRegister: build.mutation<
      PostApiV1RegistrationStudentRegisterApiResponse,
      PostApiV1RegistrationStudentRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Registration/Student/Register`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsRegistrationStudentRegisterRegisterStudentRequestDto,
      }),
    }),
    getApiV1RegistrationStudentGetAvailableGroups: build.query<
      GetApiV1RegistrationStudentGetAvailableGroupsApiResponse,
      GetApiV1RegistrationStudentGetAvailableGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Registration/Student/GetAvailableGroups`,
        params: {
          Number: queryArg["number"],
        },
      }),
    }),
    postApiV1RegistrationEmployeeRegister: build.mutation<
      PostApiV1RegistrationEmployeeRegisterApiResponse,
      PostApiV1RegistrationEmployeeRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Registration/Employee/Register`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsRegistrationEmployeeRegisterRegisterEmployeeRequestDto,
      }),
    }),
    getApiV1RegistrationEmployeeGetAvailableUniversityPositions: build.query<
      GetApiV1RegistrationEmployeeGetAvailableUniversityPositionsApiResponse,
      GetApiV1RegistrationEmployeeGetAvailableUniversityPositionsApiArg
    >({
      query: () => ({
        url: `/api/v1/Registration/Employee/GetAvailableUniversityPositions`,
      }),
    }),
    getApiV1RegistrationEmployeeGetAvailableUniversities: build.query<
      GetApiV1RegistrationEmployeeGetAvailableUniversitiesApiResponse,
      GetApiV1RegistrationEmployeeGetAvailableUniversitiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Registration/Employee/GetAvailableUniversities`,
        params: {
          Name: queryArg.name,
        },
      }),
    }),
    postApiV1RegistrationAdminRegister: build.mutation<
      PostApiV1RegistrationAdminRegisterApiResponse,
      PostApiV1RegistrationAdminRegisterApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Registration/Admin/Register`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsRegistrationAdminRegisterRegisterAdminRequestDto,
      }),
    }),
    getApiV1CommonGetDepartments: build.query<
      GetApiV1CommonGetDepartmentsApiResponse,
      GetApiV1CommonGetDepartmentsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Common/GetDepartments`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiV1CommonGetDiplomaPeriods: build.query<
      GetApiV1CommonGetDiplomaPeriodsApiResponse,
      GetApiV1CommonGetDiplomaPeriodsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Common/GetDiplomaPeriods`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiV1CommonGetFaculties: build.query<
      GetApiV1CommonGetFacultiesApiResponse,
      GetApiV1CommonGetFacultiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Common/GetFaculties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiV1CommonGetGroups: build.query<
      GetApiV1CommonGetGroupsApiResponse,
      GetApiV1CommonGetGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Common/GetGroups`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiV1CommonGetSpecialties: build.query<
      GetApiV1CommonGetSpecialtiesApiResponse,
      GetApiV1CommonGetSpecialtiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Common/GetSpecialties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getApiV1CommonGetUniversities: build.query<
      GetApiV1CommonGetUniversitiesApiResponse,
      GetApiV1CommonGetUniversitiesApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/Common/GetUniversities`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
  }),
  overrideExisting: false,
});
export { injectedRtkApi as backendApi };
export type PutApiV1AdminUsersUpdateApprovalApiResponse = unknown;
export type PutApiV1AdminUsersUpdateApprovalApiArg = {
  universityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto: UniversityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto;
};
export type GetApiV1AdminUsersGetUsersApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminUsersGetUsersGetUsersResponseDtoRead;
export type GetApiV1AdminUsersGetUsersApiArg = {
  pageNumber: number;
  pageSize: number;
  orderBy: string;
  desc: boolean;
};
export type DeleteApiV1AdminUniversitiesDeleteApiResponse = unknown;
export type DeleteApiV1AdminUniversitiesDeleteApiArg = {
  id: string;
};
export type PostApiV1AdminUniversitiesCreateApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityResponseDto;
export type PostApiV1AdminUniversitiesCreateApiArg = {
  universityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto: UniversityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto;
};
export type PatchApiV1AdminUniversitiesChangeAdminApiResponse = unknown;
export type PatchApiV1AdminUniversitiesChangeAdminApiArg = {
  universityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto: UniversityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto;
};
export type DeleteApiV1AdminSpecialtiesDeleteApiResponse = unknown;
export type DeleteApiV1AdminSpecialtiesDeleteApiArg = {
  id: string;
};
export type PostApiV1AdminSpecialtiesCreateApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyResponseDto;
export type PostApiV1AdminSpecialtiesCreateApiArg = {
  universityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto: UniversityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto;
};
export type DeleteApiV1AdminGroupsDeleteApiResponse = unknown;
export type DeleteApiV1AdminGroupsDeleteApiArg = {
  id: string;
};
export type PostApiV1AdminGroupsCreateApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminGroupsCreateCreateGroupResponseDto;
export type PostApiV1AdminGroupsCreateApiArg = {
  universityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto: UniversityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto;
};
export type DeleteApiV1AdminFacultiesDeleteApiResponse = unknown;
export type DeleteApiV1AdminFacultiesDeleteApiArg = {
  id: string;
};
export type PostApiV1AdminFacultiesCreateApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyResponseDto;
export type PostApiV1AdminFacultiesCreateApiArg = {
  universityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto: UniversityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto;
};
export type DeleteApiV1AdminDiplomaPeriodsUsersRemoveApiResponse = unknown;
export type DeleteApiV1AdminDiplomaPeriodsUsersRemoveApiArg = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type GetApiV1AdminDiplomaPeriodsUsersGetApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersGetGetDiplomaPeriodUsersResponseDto;
export type GetApiV1AdminDiplomaPeriodsUsersGetApiArg = {
  diplomaPeriodId: string;
  roleType: UniversityProcessingAPIEndpointsContractsUserRoleTypeDto;
};
export type PostApiV1AdminDiplomaPeriodsUsersAddApiResponse = unknown;
export type PostApiV1AdminDiplomaPeriodsUsersAddApiArg = {
  universityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto: UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto;
};
export type DeleteApiV1AdminDiplomaPeriodsDeleteApiResponse = unknown;
export type DeleteApiV1AdminDiplomaPeriodsDeleteApiArg = {
  id: string;
};
export type PostApiV1AdminDiplomaPeriodsCreateApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodResponseDto;
export type PostApiV1AdminDiplomaPeriodsCreateApiArg = {
  universityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto: UniversityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto;
};
export type DeleteApiV1AdminDepartmentsDeleteApiResponse = unknown;
export type DeleteApiV1AdminDepartmentsDeleteApiArg = {
  id: string;
};
export type PostApiV1AdminDepartmentsCreateApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentResponseDto;
export type PostApiV1AdminDepartmentsCreateApiArg = {
  universityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto: UniversityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto;
};
export type GetApiV1IdentityRefreshApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsIdentityRefreshRefreshResponseDto;
export type GetApiV1IdentityRefreshApiArg = void;
export type PostApiV1IdentityLogoutApiResponse = unknown;
export type PostApiV1IdentityLogoutApiArg = void;
export type PostApiV1IdentityLoginApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsIdentityLoginLoginResponseDto;
export type PostApiV1IdentityLoginApiArg = {
  universityProcessingApiEndpointsIdentityLoginLoginRequestDto: UniversityProcessingApiEndpointsIdentityLoginLoginRequestDto;
};
export type GetApiV1IdentityInfoApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsIdentityInfoInfoResponseDto;
export type GetApiV1IdentityInfoApiArg = void;
export type PostApiV1RegistrationStudentRegisterApiResponse = unknown;
export type PostApiV1RegistrationStudentRegisterApiArg = {
  universityProcessingApiEndpointsRegistrationStudentRegisterRegisterStudentRequestDto: UniversityProcessingApiEndpointsRegistrationStudentRegisterRegisterStudentRequestDto;
};
export type GetApiV1RegistrationStudentGetAvailableGroupsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsRegistrationStudentGetAvailableGroupsGetAvailableGroupsResponseDto;
export type GetApiV1RegistrationStudentGetAvailableGroupsApiArg = {
  number: string;
};
export type PostApiV1RegistrationEmployeeRegisterApiResponse = unknown;
export type PostApiV1RegistrationEmployeeRegisterApiArg = {
  universityProcessingApiEndpointsRegistrationEmployeeRegisterRegisterEmployeeRequestDto: UniversityProcessingApiEndpointsRegistrationEmployeeRegisterRegisterEmployeeRequestDto;
};
export type GetApiV1RegistrationEmployeeGetAvailableUniversityPositionsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversityPositionsGetAvailableUniversityPositionsResponseDto;
export type GetApiV1RegistrationEmployeeGetAvailableUniversityPositionsApiArg =
  void;
export type GetApiV1RegistrationEmployeeGetAvailableUniversitiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversitiesGetAvailableUniversitiesResponseDto;
export type GetApiV1RegistrationEmployeeGetAvailableUniversitiesApiArg = {
  name: string;
};
export type PostApiV1RegistrationAdminRegisterApiResponse = unknown;
export type PostApiV1RegistrationAdminRegisterApiArg = {
  universityProcessingApiEndpointsRegistrationAdminRegisterRegisterAdminRequestDto: UniversityProcessingApiEndpointsRegistrationAdminRegisterRegisterAdminRequestDto;
};
export type GetApiV1CommonGetDepartmentsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetDepartmentsGetDepartmentsResponseDtoRead;
export type GetApiV1CommonGetDepartmentsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiV1CommonGetDiplomaPeriodsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsGetDiplomaPeriodsResponseDtoRead;
export type GetApiV1CommonGetDiplomaPeriodsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiV1CommonGetFacultiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetFacultiesGetFacultiesResponseDtoRead;
export type GetApiV1CommonGetFacultiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiV1CommonGetGroupsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetGroupsGetGroupsResponseDtoRead;
export type GetApiV1CommonGetGroupsApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiV1CommonGetSpecialtiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetSpecialtiesGetSpecialtiesResponseDtoRead;
export type GetApiV1CommonGetSpecialtiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type GetApiV1CommonGetUniversitiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetUniversitiesGetUniversitiesResponseDtoRead;
export type GetApiV1CommonGetUniversitiesApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
};
export type UniversityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto =
  {
    userId: string;
    isApproved: boolean;
  };
export type UniversityProcessingApiEndpointsAdminUsersGetUsersUserDto = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  approved?: boolean;
};
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsAdminUsersGetUsersUserDto =
  {
    items?: UniversityProcessingApiEndpointsAdminUsersGetUsersUserDto[] | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsAdminUsersGetUsersUserDtoRead =
  {
    items?: UniversityProcessingApiEndpointsAdminUsersGetUsersUserDto[] | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsAdminUsersGetUsersGetUsersResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsAdminUsersGetUsersUserDto;
  };
export type UniversityProcessingApiEndpointsAdminUsersGetUsersGetUsersResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsAdminUsersGetUsersUserDtoRead;
  };
export type UniversityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityResponseDto =
  {
    id?: string;
  };
export type UniversityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto =
  {
    name: string;
    shortName: string;
    adminId?: string | null;
  };
export type UniversityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto =
  {
    universityId: string;
    userId: string;
  };
export type UniversityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyResponseDto =
  {
    id?: string;
  };
export type UniversityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto =
  {
    name: string;
    shortName: string;
    code: string;
    departmentId?: string | null;
  };
export type UniversityProcessingApiEndpointsAdminGroupsCreateCreateGroupResponseDto =
  {
    id: string;
  };
export type UniversityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto =
  {
    groupNumber: string;
    startDate: string;
    endDate: string;
    specialtyId?: string | null;
  };
export type UniversityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyResponseDto =
  {
    id?: string;
  };
export type UniversityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto =
  {
    name: string;
    shortName: string;
    universityId?: string | null;
  };
export type UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersGetDiplomaPeriodUserDto =
  {
    id?: string;
    firstName?: string | null;
    lastName?: string | null;
    middleName?: string | null;
    universityPosition?: string | null;
    added?: boolean;
  };
export type UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersGetGetDiplomaPeriodUsersResponseDto =
  {
    list?:
      | UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersGetDiplomaPeriodUserDto[]
      | null;
  };
export type UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto =
  {
    diplomaPeriodId: string;
    userIds: string[];
  };
export type UniversityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodResponseDto =
  {
    id?: string;
  };
export type UniversityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto =
  {
    startDate: string;
    endDate: string;
    name: string;
  };
export type UniversityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentResponseDto =
  {
    id?: string;
  };
export type UniversityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto =
  {
    name: string;
    shortName: string;
    facultyId?: string | null;
  };
export type UniversityProcessingApiEndpointsContractsTokenDto = {
  value?: string | null;
  expiration?: string;
};
export type UniversityProcessingApiEndpointsIdentityRefreshRefreshResponseDto =
  {
    accessToken?: UniversityProcessingApiEndpointsContractsTokenDto;
    refreshToken?: UniversityProcessingApiEndpointsContractsTokenDto;
  };
export type UniversityProcessingApiEndpointsIdentityLoginLoginResponseDto = {
  accessToken?: UniversityProcessingApiEndpointsContractsTokenDto;
  refreshToken?: UniversityProcessingApiEndpointsContractsTokenDto;
};
export type UniversityProcessingApiEndpointsIdentityLoginLoginRequestDto = {
  userName: string;
  password: string;
};
export type UniversityProcessingApiEndpointsIdentityInfoInfoResponseDto = {
  userId?: string;
  roleType?: UniversityProcessingAPIEndpointsContractsUserRoleTypeDto;
  approved?: boolean;
};
export type UniversityProcessingApiEndpointsRegistrationStudentRegisterRegisterStudentRequestDto =
  {
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    middleName?: string | null;
    email?: string | null;
    birthday?: string | null;
    groupNumber?: string | null;
  };
export type UniversityProcessingApiEndpointsRegistrationStudentGetAvailableGroupsGetAvailableGroupsResponseDto =
  {
    groupNumbers?: string[] | null;
  };
export type UniversityProcessingApiEndpointsRegistrationEmployeeRegisterRegisterEmployeeRequestDto =
  {
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
export type UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversityPositionsUniversityPositionDto =
  {
    id?: string;
    name?: string | null;
  };
export type UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversityPositionsGetAvailableUniversityPositionsResponseDto =
  {
    list?:
      | UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversityPositionsUniversityPositionDto[]
      | null;
  };
export type UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversitiesUniversityDto =
  {
    id?: string;
    name?: string | null;
  };
export type UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversitiesGetAvailableUniversitiesResponseDto =
  {
    list?:
      | UniversityProcessingApiEndpointsRegistrationEmployeeGetAvailableUniversitiesUniversityDto[]
      | null;
  };
export type UniversityProcessingApiEndpointsRegistrationAdminRegisterRegisterAdminRequestDto =
  {
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    middleName?: string | null;
    email?: string | null;
    birthday?: string | null;
  };
export type UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDto =
  {
    id?: string;
    name?: string | null;
    shortName?: string | null;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDto =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDto[]
      | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDtoRead =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDto[]
      | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsCommonGetDepartmentsGetDepartmentsResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDto;
  };
export type UniversityProcessingApiEndpointsCommonGetDepartmentsGetDepartmentsResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDepartmentsDepartmentDtoRead;
  };
export type UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDto =
  {
    id?: string;
    name?: string | null;
    studyPeriodFrom?: string;
    studyPeriodTo?: string;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDto =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDto[]
      | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDtoRead =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDto[]
      | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsGetDiplomaPeriodsResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDto;
  };
export type UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsGetDiplomaPeriodsResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsDiplomaPeriodDtoRead;
  };
export type UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDto =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDto[]
      | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDtoRead =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDto[]
      | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsCommonGetFacultiesGetFacultiesResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDto;
  };
export type UniversityProcessingApiEndpointsCommonGetFacultiesGetFacultiesResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetFacultiesFacultyDtoRead;
  };
export type UniversityProcessingApiEndpointsCommonGetGroupsGroupDto = {
  id?: string;
  number?: string | null;
};
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetGroupsGroupDto =
  {
    items?: UniversityProcessingApiEndpointsCommonGetGroupsGroupDto[] | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetGroupsGroupDtoRead =
  {
    items?: UniversityProcessingApiEndpointsCommonGetGroupsGroupDto[] | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsCommonGetGroupsGetGroupsResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetGroupsGroupDto;
  };
export type UniversityProcessingApiEndpointsCommonGetGroupsGetGroupsResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetGroupsGroupDtoRead;
  };
export type UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDto =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDto[]
      | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDtoRead =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDto[]
      | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsCommonGetSpecialtiesGetSpecialtiesResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDto;
  };
export type UniversityProcessingApiEndpointsCommonGetSpecialtiesGetSpecialtiesResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetSpecialtiesSpecialtyDtoRead;
  };
export type UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDto =
  {
    id?: string;
    name?: string | null;
    shortName?: string | null;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDto =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDto[]
      | null;
    currentPage?: number;
    pageSize?: number;
  };
export type UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDtoRead =
  {
    items?:
      | UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDto[]
      | null;
    currentPage?: number;
    totalPages?: number;
    pageSize?: number;
    totalCount?: number;
    hasPrevious?: boolean;
    hasNext?: boolean;
  };
export type UniversityProcessingApiEndpointsCommonGetUniversitiesGetUniversitiesResponseDto =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDto;
  };
export type UniversityProcessingApiEndpointsCommonGetUniversitiesGetUniversitiesResponseDtoRead =
  {
    list?: UniversityProcessingGenericSubdomainPaginationPagedList601UniversityProcessingApiEndpointsCommonGetUniversitiesUniversityDtoRead;
  };
export enum UniversityProcessingAPIEndpointsContractsUserRoleTypeDto {
  None = "None",
  ApplicationAdmin = "ApplicationAdmin",
  Employee = "Employee",
  Student = "Student",
}
export const {
  usePutApiV1AdminUsersUpdateApprovalMutation,
  useGetApiV1AdminUsersGetUsersQuery,
  useLazyGetApiV1AdminUsersGetUsersQuery,
  useDeleteApiV1AdminUniversitiesDeleteMutation,
  usePostApiV1AdminUniversitiesCreateMutation,
  usePatchApiV1AdminUniversitiesChangeAdminMutation,
  useDeleteApiV1AdminSpecialtiesDeleteMutation,
  usePostApiV1AdminSpecialtiesCreateMutation,
  useDeleteApiV1AdminGroupsDeleteMutation,
  usePostApiV1AdminGroupsCreateMutation,
  useDeleteApiV1AdminFacultiesDeleteMutation,
  usePostApiV1AdminFacultiesCreateMutation,
  useDeleteApiV1AdminDiplomaPeriodsUsersRemoveMutation,
  useGetApiV1AdminDiplomaPeriodsUsersGetQuery,
  useLazyGetApiV1AdminDiplomaPeriodsUsersGetQuery,
  usePostApiV1AdminDiplomaPeriodsUsersAddMutation,
  useDeleteApiV1AdminDiplomaPeriodsDeleteMutation,
  usePostApiV1AdminDiplomaPeriodsCreateMutation,
  useDeleteApiV1AdminDepartmentsDeleteMutation,
  usePostApiV1AdminDepartmentsCreateMutation,
  useGetApiV1IdentityRefreshQuery,
  useLazyGetApiV1IdentityRefreshQuery,
  usePostApiV1IdentityLogoutMutation,
  usePostApiV1IdentityLoginMutation,
  useGetApiV1IdentityInfoQuery,
  useLazyGetApiV1IdentityInfoQuery,
  usePostApiV1RegistrationStudentRegisterMutation,
  useGetApiV1RegistrationStudentGetAvailableGroupsQuery,
  useLazyGetApiV1RegistrationStudentGetAvailableGroupsQuery,
  usePostApiV1RegistrationEmployeeRegisterMutation,
  useGetApiV1RegistrationEmployeeGetAvailableUniversityPositionsQuery,
  useLazyGetApiV1RegistrationEmployeeGetAvailableUniversityPositionsQuery,
  useGetApiV1RegistrationEmployeeGetAvailableUniversitiesQuery,
  useLazyGetApiV1RegistrationEmployeeGetAvailableUniversitiesQuery,
  usePostApiV1RegistrationAdminRegisterMutation,
  useGetApiV1CommonGetDepartmentsQuery,
  useLazyGetApiV1CommonGetDepartmentsQuery,
  useGetApiV1CommonGetDiplomaPeriodsQuery,
  useLazyGetApiV1CommonGetDiplomaPeriodsQuery,
  useGetApiV1CommonGetFacultiesQuery,
  useLazyGetApiV1CommonGetFacultiesQuery,
  useGetApiV1CommonGetGroupsQuery,
  useLazyGetApiV1CommonGetGroupsQuery,
  useGetApiV1CommonGetSpecialtiesQuery,
  useLazyGetApiV1CommonGetSpecialtiesQuery,
  useGetApiV1CommonGetUniversitiesQuery,
  useLazyGetApiV1CommonGetUniversitiesQuery,
} = injectedRtkApi;
