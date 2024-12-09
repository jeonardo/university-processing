import { emptySplitApi as api } from "./emptyApi";
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    putUpdateApproval: build.mutation<
      PutUpdateApprovalApiResponse,
      PutUpdateApprovalApiArg
    >({
      query: (queryArg) => ({
        url: `/UpdateApproval`,
        method: "PUT",
        body: queryArg.universityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto,
      }),
    }),
    getGetUsers: build.query<GetGetUsersApiResponse, GetGetUsersApiArg>({
      query: (queryArg) => ({
        url: `/GetUsers`,
        params: {
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          OrderBy: queryArg.orderBy,
          Desc: queryArg.desc,
        },
      }),
    }),
    deleteDeleteUniversity: build.mutation<
      DeleteDeleteUniversityApiResponse,
      DeleteDeleteUniversityApiArg
    >({
      query: (queryArg) => ({
        url: `/DeleteUniversity`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postCreateUniversity: build.mutation<
      PostCreateUniversityApiResponse,
      PostCreateUniversityApiArg
    >({
      query: (queryArg) => ({
        url: `/CreateUniversity`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto,
      }),
    }),
    patchChangeUniversityAdmin: build.mutation<
      PatchChangeUniversityAdminApiResponse,
      PatchChangeUniversityAdminApiArg
    >({
      query: (queryArg) => ({
        url: `/ChangeUniversityAdmin`,
        method: "PATCH",
        body: queryArg.universityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto,
      }),
    }),
    deleteDeleteSpecialty: build.mutation<
      DeleteDeleteSpecialtyApiResponse,
      DeleteDeleteSpecialtyApiArg
    >({
      query: (queryArg) => ({
        url: `/DeleteSpecialty`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postCreateSpecialty: build.mutation<
      PostCreateSpecialtyApiResponse,
      PostCreateSpecialtyApiArg
    >({
      query: (queryArg) => ({
        url: `/CreateSpecialty`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto,
      }),
    }),
    deleteDeleteGroup: build.mutation<
      DeleteDeleteGroupApiResponse,
      DeleteDeleteGroupApiArg
    >({
      query: (queryArg) => ({
        url: `/DeleteGroup`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postCreateGroup: build.mutation<
      PostCreateGroupApiResponse,
      PostCreateGroupApiArg
    >({
      query: (queryArg) => ({
        url: `/CreateGroup`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto,
      }),
    }),
    deleteDeleteFaculty: build.mutation<
      DeleteDeleteFacultyApiResponse,
      DeleteDeleteFacultyApiArg
    >({
      query: (queryArg) => ({
        url: `/DeleteFaculty`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postCreateFaculty: build.mutation<
      PostCreateFacultyApiResponse,
      PostCreateFacultyApiArg
    >({
      query: (queryArg) => ({
        url: `/CreateFaculty`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto,
      }),
    }),
    deleteRemoveUsers: build.mutation<
      DeleteRemoveUsersApiResponse,
      DeleteRemoveUsersApiArg
    >({
      query: (queryArg) => ({
        url: `/RemoveUsers`,
        method: "DELETE",
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          UserIds: queryArg.userIds,
        },
      }),
    }),
    getGetDiplomaPeriodUsers: build.query<
      GetGetDiplomaPeriodUsersApiResponse,
      GetGetDiplomaPeriodUsersApiArg
    >({
      query: (queryArg) => ({
        url: `/GetDiplomaPeriodUsers`,
        params: {
          DiplomaPeriodId: queryArg.diplomaPeriodId,
          RoleType: queryArg.roleType,
        },
      }),
    }),
    postAddUsers: build.mutation<PostAddUsersApiResponse, PostAddUsersApiArg>({
      query: (queryArg) => ({
        url: `/AddUsers`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto,
      }),
    }),
    deleteDeleteDiplomaPeriod: build.mutation<
      DeleteDeleteDiplomaPeriodApiResponse,
      DeleteDeleteDiplomaPeriodApiArg
    >({
      query: (queryArg) => ({
        url: `/DeleteDiplomaPeriod`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postCreateDiplomaPeriod: build.mutation<
      PostCreateDiplomaPeriodApiResponse,
      PostCreateDiplomaPeriodApiArg
    >({
      query: (queryArg) => ({
        url: `/CreateDiplomaPeriod`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto,
      }),
    }),
    deleteDeleteDepartment: build.mutation<
      DeleteDeleteDepartmentApiResponse,
      DeleteDeleteDepartmentApiArg
    >({
      query: (queryArg) => ({
        url: `/DeleteDepartment`,
        method: "DELETE",
        params: {
          Id: queryArg.id,
        },
      }),
    }),
    postCreateDepartment: build.mutation<
      PostCreateDepartmentApiResponse,
      PostCreateDepartmentApiArg
    >({
      query: (queryArg) => ({
        url: `/CreateDepartment`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto,
      }),
    }),
    getRefresh: build.query<GetRefreshApiResponse, GetRefreshApiArg>({
      query: () => ({ url: `/Refresh` }),
    }),
    postLogout: build.mutation<PostLogoutApiResponse, PostLogoutApiArg>({
      query: () => ({ url: `/Logout`, method: "POST" }),
    }),
    postLogin: build.mutation<PostLoginApiResponse, PostLoginApiArg>({
      query: (queryArg) => ({
        url: `/Login`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsIdentityLoginLoginRequestDto,
      }),
    }),
    getInfo: build.query<GetInfoApiResponse, GetInfoApiArg>({
      query: () => ({ url: `/Info` }),
    }),
    postRegisterAdmin: build.mutation<
      PostRegisterAdminApiResponse,
      PostRegisterAdminApiArg
    >({
      query: (queryArg) => ({
        url: `/RegisterAdmin`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsRegistrationRegisterAdminRegisterRegisterAdminRequestDto,
      }),
    }),
    postRegisterEmployee: build.mutation<
      PostRegisterEmployeeApiResponse,
      PostRegisterEmployeeApiArg
    >({
      query: (queryArg) => ({
        url: `/RegisterEmployee`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsRegistrationRegisterEmployeeRegisterRegisterEmployeeRequestDto,
      }),
    }),
    getGetAvailableUniversityPositions: build.query<
      GetGetAvailableUniversityPositionsApiResponse,
      GetGetAvailableUniversityPositionsApiArg
    >({
      query: () => ({ url: `/GetAvailableUniversityPositions` }),
    }),
    getGetAvailableUniversities: build.query<
      GetGetAvailableUniversitiesApiResponse,
      GetGetAvailableUniversitiesApiArg
    >({
      query: (queryArg) => ({
        url: `/GetAvailableUniversities`,
        params: {
          Name: queryArg.name,
        },
      }),
    }),
    postRegisterStudent: build.mutation<
      PostRegisterStudentApiResponse,
      PostRegisterStudentApiArg
    >({
      query: (queryArg) => ({
        url: `/RegisterStudent`,
        method: "POST",
        body: queryArg.universityProcessingApiEndpointsRegistrationRegisterStudentRegisterRegisterStudentRequestDto,
      }),
    }),
    getGetAvailableGroups: build.query<
      GetGetAvailableGroupsApiResponse,
      GetGetAvailableGroupsApiArg
    >({
      query: (queryArg) => ({
        url: `/GetAvailableGroups`,
        params: {
          Number: queryArg["number"],
        },
      }),
    }),
    getGetDepartments: build.query<
      GetGetDepartmentsApiResponse,
      GetGetDepartmentsApiArg
    >({
      query: (queryArg) => ({
        url: `/GetDepartments`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getGetDiplomaPeriods: build.query<
      GetGetDiplomaPeriodsApiResponse,
      GetGetDiplomaPeriodsApiArg
    >({
      query: (queryArg) => ({
        url: `/GetDiplomaPeriods`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getGetFaculties: build.query<
      GetGetFacultiesApiResponse,
      GetGetFacultiesApiArg
    >({
      query: (queryArg) => ({
        url: `/GetFaculties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getGetGroups: build.query<GetGetGroupsApiResponse, GetGetGroupsApiArg>({
      query: (queryArg) => ({
        url: `/GetGroups`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getGetSpecialties: build.query<
      GetGetSpecialtiesApiResponse,
      GetGetSpecialtiesApiArg
    >({
      query: (queryArg) => ({
        url: `/GetSpecialties`,
        params: {
          Desc: queryArg.desc,
          OrderBy: queryArg.orderBy,
          PageNumber: queryArg.pageNumber,
          PageSize: queryArg.pageSize,
          Filter: queryArg.filter,
        },
      }),
    }),
    getGetUniversities: build.query<
      GetGetUniversitiesApiResponse,
      GetGetUniversitiesApiArg
    >({
      query: (queryArg) => ({
        url: `/GetUniversities`,
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
export type PutUpdateApprovalApiResponse = unknown;
export type PutUpdateApprovalApiArg = {
  universityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto: UniversityProcessingApiEndpointsAdminUsersUpdateApprovalUpdateApprovalRequestDto;
};
export type GetGetUsersApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminUsersGetUsersGetUsersResponseDtoRead;
export type GetGetUsersApiArg = {
  pageNumber: number;
  pageSize: number;
  orderBy: string;
  desc: boolean;
};
export type DeleteDeleteUniversityApiResponse = unknown;
export type DeleteDeleteUniversityApiArg = {
  id: string;
};
export type PostCreateUniversityApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityResponseDto;
export type PostCreateUniversityApiArg = {
  universityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto: UniversityProcessingApiEndpointsAdminUniversitiesCreateCreateUniversityRequestDto;
};
export type PatchChangeUniversityAdminApiResponse = unknown;
export type PatchChangeUniversityAdminApiArg = {
  universityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto: UniversityProcessingApiEndpointsAdminUniversitiesChangeAdminChangeUniversityAdminRequestDto;
};
export type DeleteDeleteSpecialtyApiResponse = unknown;
export type DeleteDeleteSpecialtyApiArg = {
  id: string;
};
export type PostCreateSpecialtyApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyResponseDto;
export type PostCreateSpecialtyApiArg = {
  universityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto: UniversityProcessingApiEndpointsAdminSpecialtiesCreateCreateSpecialtyRequestDto;
};
export type DeleteDeleteGroupApiResponse = unknown;
export type DeleteDeleteGroupApiArg = {
  id: string;
};
export type PostCreateGroupApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminGroupsCreateCreateGroupResponseDto;
export type PostCreateGroupApiArg = {
  universityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto: UniversityProcessingApiEndpointsAdminGroupsCreateCreateGroupRequestDto;
};
export type DeleteDeleteFacultyApiResponse = unknown;
export type DeleteDeleteFacultyApiArg = {
  id: string;
};
export type PostCreateFacultyApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyResponseDto;
export type PostCreateFacultyApiArg = {
  universityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto: UniversityProcessingApiEndpointsAdminFacultiesCreateCreateFacultyRequestDto;
};
export type DeleteRemoveUsersApiResponse = unknown;
export type DeleteRemoveUsersApiArg = {
  diplomaPeriodId: string;
  userIds: string[];
};
export type GetGetDiplomaPeriodUsersApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersGetGetDiplomaPeriodUsersResponseDto;
export type GetGetDiplomaPeriodUsersApiArg = {
  diplomaPeriodId: string;
  roleType: UniversityProcessingAPIEndpointsContractsUserRoleTypeDto;
};
export type PostAddUsersApiResponse = unknown;
export type PostAddUsersApiArg = {
  universityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto: UniversityProcessingApiEndpointsAdminDiplomaPeriodsUsersAddAddUsersRequestDto;
};
export type DeleteDeleteDiplomaPeriodApiResponse = unknown;
export type DeleteDeleteDiplomaPeriodApiArg = {
  id: string;
};
export type PostCreateDiplomaPeriodApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodResponseDto;
export type PostCreateDiplomaPeriodApiArg = {
  universityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto: UniversityProcessingApiEndpointsAdminDiplomaPeriodsCreateCreateDiplomaPeriodRequestDto;
};
export type DeleteDeleteDepartmentApiResponse = unknown;
export type DeleteDeleteDepartmentApiArg = {
  id: string;
};
export type PostCreateDepartmentApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentResponseDto;
export type PostCreateDepartmentApiArg = {
  universityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto: UniversityProcessingApiEndpointsAdminDepartmentsCreateCreateDepartmentRequestDto;
};
export type GetRefreshApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsIdentityRefreshRefreshResponseDto;
export type GetRefreshApiArg = void;
export type PostLogoutApiResponse = unknown;
export type PostLogoutApiArg = void;
export type PostLoginApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsIdentityLoginLoginResponseDto;
export type PostLoginApiArg = {
  universityProcessingApiEndpointsIdentityLoginLoginRequestDto: UniversityProcessingApiEndpointsIdentityLoginLoginRequestDto;
};
export type GetInfoApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsIdentityInfoInfoResponseDto;
export type GetInfoApiArg = void;
export type PostRegisterAdminApiResponse = unknown;
export type PostRegisterAdminApiArg = {
  universityProcessingApiEndpointsRegistrationRegisterAdminRegisterRegisterAdminRequestDto: UniversityProcessingApiEndpointsRegistrationRegisterAdminRegisterRegisterAdminRequestDto;
};
export type PostRegisterEmployeeApiResponse = unknown;
export type PostRegisterEmployeeApiArg = {
  universityProcessingApiEndpointsRegistrationRegisterEmployeeRegisterRegisterEmployeeRequestDto: UniversityProcessingApiEndpointsRegistrationRegisterEmployeeRegisterRegisterEmployeeRequestDto;
};
export type GetGetAvailableUniversityPositionsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversityPositionsGetAvailableUniversityPositionsResponseDto;
export type GetGetAvailableUniversityPositionsApiArg = void;
export type GetGetAvailableUniversitiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversitiesGetAvailableUniversitiesResponseDto;
export type GetGetAvailableUniversitiesApiArg = {
  name: string;
};
export type PostRegisterStudentApiResponse = unknown;
export type PostRegisterStudentApiArg = {
  universityProcessingApiEndpointsRegistrationRegisterStudentRegisterRegisterStudentRequestDto: UniversityProcessingApiEndpointsRegistrationRegisterStudentRegisterRegisterStudentRequestDto;
};
export type GetGetAvailableGroupsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsRegistrationRegisterStudentGetAvailableGroupsGetAvailableGroupsResponseDto;
export type GetGetAvailableGroupsApiArg = {
  number: string;
};
export type GetGetDepartmentsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetDepartmentsGetDepartmentsResponseDtoRead;
export type GetGetDepartmentsApiArg = {
  desc: boolean;
  orderBy: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
};
export type GetGetDiplomaPeriodsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetDiplomaPeriodsGetDiplomaPeriodsResponseDtoRead;
export type GetGetDiplomaPeriodsApiArg = {
  desc: boolean;
  orderBy: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
};
export type GetGetFacultiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetFacultiesGetFacultiesResponseDtoRead;
export type GetGetFacultiesApiArg = {
  desc: boolean;
  orderBy: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
};
export type GetGetGroupsApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetGroupsGetGroupsResponseDtoRead;
export type GetGetGroupsApiArg = {
  desc: boolean;
  orderBy: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
};
export type GetGetSpecialtiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetSpecialtiesGetSpecialtiesResponseDtoRead;
export type GetGetSpecialtiesApiArg = {
  desc: boolean;
  orderBy: string;
  pageNumber: number;
  pageSize: number;
  filter?: string;
};
export type GetGetUniversitiesApiResponse =
  /** status 200 OK */ UniversityProcessingApiEndpointsCommonGetUniversitiesGetUniversitiesResponseDtoRead;
export type GetGetUniversitiesApiArg = {
  desc: boolean;
  orderBy: string;
  pageNumber: number;
  pageSize: number;
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
export type UniversityProcessingApiEndpointsRegistrationRegisterAdminRegisterRegisterAdminRequestDto =
  {
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    middleName?: string | null;
    email?: string | null;
    birthday?: string | null;
  };
export type UniversityProcessingApiEndpointsRegistrationRegisterEmployeeRegisterRegisterEmployeeRequestDto =
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
export type UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversityPositionsUniversityPositionDto =
  {
    id?: string;
    name?: string | null;
  };
export type UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversityPositionsGetAvailableUniversityPositionsResponseDto =
  {
    list?:
      | UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversityPositionsUniversityPositionDto[]
      | null;
  };
export type UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversitiesUniversityDto =
  {
    id?: string;
    name?: string | null;
  };
export type UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversitiesGetAvailableUniversitiesResponseDto =
  {
    list?:
      | UniversityProcessingApiEndpointsRegistrationRegisterEmployeeGetAvailableUniversitiesUniversityDto[]
      | null;
  };
export type UniversityProcessingApiEndpointsRegistrationRegisterStudentRegisterRegisterStudentRequestDto =
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
export type UniversityProcessingApiEndpointsRegistrationRegisterStudentGetAvailableGroupsGetAvailableGroupsResponseDto =
  {
    groupNumbers?: string[] | null;
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
  usePutUpdateApprovalMutation,
  useGetGetUsersQuery,
  useLazyGetGetUsersQuery,
  useDeleteDeleteUniversityMutation,
  usePostCreateUniversityMutation,
  usePatchChangeUniversityAdminMutation,
  useDeleteDeleteSpecialtyMutation,
  usePostCreateSpecialtyMutation,
  useDeleteDeleteGroupMutation,
  usePostCreateGroupMutation,
  useDeleteDeleteFacultyMutation,
  usePostCreateFacultyMutation,
  useDeleteRemoveUsersMutation,
  useGetGetDiplomaPeriodUsersQuery,
  useLazyGetGetDiplomaPeriodUsersQuery,
  usePostAddUsersMutation,
  useDeleteDeleteDiplomaPeriodMutation,
  usePostCreateDiplomaPeriodMutation,
  useDeleteDeleteDepartmentMutation,
  usePostCreateDepartmentMutation,
  useGetRefreshQuery,
  useLazyGetRefreshQuery,
  usePostLogoutMutation,
  usePostLoginMutation,
  useGetInfoQuery,
  useLazyGetInfoQuery,
  usePostRegisterAdminMutation,
  usePostRegisterEmployeeMutation,
  useGetGetAvailableUniversityPositionsQuery,
  useLazyGetGetAvailableUniversityPositionsQuery,
  useGetGetAvailableUniversitiesQuery,
  useLazyGetGetAvailableUniversitiesQuery,
  usePostRegisterStudentMutation,
  useGetGetAvailableGroupsQuery,
  useLazyGetGetAvailableGroupsQuery,
  useGetGetDepartmentsQuery,
  useLazyGetGetDepartmentsQuery,
  useGetGetDiplomaPeriodsQuery,
  useLazyGetGetDiplomaPeriodsQuery,
  useGetGetFacultiesQuery,
  useLazyGetGetFacultiesQuery,
  useGetGetGroupsQuery,
  useLazyGetGetGroupsQuery,
  useGetGetSpecialtiesQuery,
  useLazyGetGetSpecialtiesQuery,
  useGetGetUniversitiesQuery,
  useLazyGetGetUniversitiesQuery,
} = injectedRtkApi;
