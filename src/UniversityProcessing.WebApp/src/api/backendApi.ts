import { emptySplitApi as api } from '../core/emptyApi';
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    getApiV1DepartmentGet: build.query<GetApiV1DepartmentGetApiResponse, GetApiV1DepartmentGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Department/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1DepartmentGetList: build.query<GetApiV1DepartmentGetListApiResponse, GetApiV1DepartmentGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Department/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1DepartmentCreate: build.mutation<PostApiV1DepartmentCreateApiResponse, PostApiV1DepartmentCreateApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Department/Create`, method: 'POST', body: queryArg.createDepartmentRequestDto })
    }),
    deleteApiV1DepartmentDelete: build.mutation<DeleteApiV1DepartmentDeleteApiResponse, DeleteApiV1DepartmentDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Department/Delete`, method: 'DELETE', body: queryArg.deleteDepartmentRequestDto })
    }),
    getApiV1DiplomaPeriodGet: build.query<GetApiV1DiplomaPeriodGetApiResponse, GetApiV1DiplomaPeriodGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/DiplomaPeriod/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1DiplomaPeriodGetActualList: build.query<
      GetApiV1DiplomaPeriodGetActualListApiResponse,
      GetApiV1DiplomaPeriodGetActualListApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/DiplomaPeriod/GetActualList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1DiplomaPeriodGetActualTeachers: build.mutation<
      PostApiV1DiplomaPeriodGetActualTeachersApiResponse,
      PostApiV1DiplomaPeriodGetActualTeachersApiArg
    >({
      query: (queryArg) => ({
        url: `/api/v1/DiplomaPeriod/GetActualTeachers`,
        method: 'POST',
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    getApiV1FacultyGet: build.query<GetApiV1FacultyGetApiResponse, GetApiV1FacultyGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Faculty/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1FacultyGetList: build.query<GetApiV1FacultyGetListApiResponse, GetApiV1FacultyGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Faculty/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1FacultyCreate: build.mutation<PostApiV1FacultyCreateApiResponse, PostApiV1FacultyCreateApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Faculty/Create`, method: 'POST', body: queryArg.createFacultyRequestDto })
    }),
    deleteApiV1FacultyDelete: build.mutation<DeleteApiV1FacultyDeleteApiResponse, DeleteApiV1FacultyDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Faculty/Delete`, method: 'DELETE', body: queryArg.deleteFacultyRequestDto })
    }),
    getApiV1GroupGet: build.query<GetApiV1GroupGetApiResponse, GetApiV1GroupGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Group/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1GroupGetList: build.query<GetApiV1GroupGetListApiResponse, GetApiV1GroupGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Group/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1GroupCreate: build.mutation<PostApiV1GroupCreateApiResponse, PostApiV1GroupCreateApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Group/Create`, method: 'POST', body: queryArg.createGroupRequestDto })
    }),
    deleteApiV1GroupDelete: build.mutation<DeleteApiV1GroupDeleteApiResponse, DeleteApiV1GroupDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Group/Delete`, method: 'DELETE', body: queryArg.deleteGroupRequestDto })
    }),
    deleteApiV1IdentityDelete: build.mutation<DeleteApiV1IdentityDeleteApiResponse, DeleteApiV1IdentityDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/Delete`, method: 'DELETE', body: queryArg.deleteUserRequestDto })
    }),
    postApiV1IdentityLogin: build.mutation<PostApiV1IdentityLoginApiResponse, PostApiV1IdentityLoginApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/Login`, method: 'POST', body: queryArg.loginRequestDto })
    }),
    postApiV1IdentityRegisterEmployee: build.mutation<
      PostApiV1IdentityRegisterEmployeeApiResponse,
      PostApiV1IdentityRegisterEmployeeApiArg
    >({
      query: (queryArg) => ({ url: `/api/v1/Identity/RegisterEmployee`, method: 'POST', body: queryArg.registerEmployeeRequestDto })
    }),
    postApiV1IdentityRegisterAdmin: build.mutation<PostApiV1IdentityRegisterAdminApiResponse, PostApiV1IdentityRegisterAdminApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/RegisterAdmin`, method: 'POST', body: queryArg.registerAdminRequestDto })
    }),
    postApiV1IdentityRegisterStudent: build.mutation<PostApiV1IdentityRegisterStudentApiResponse, PostApiV1IdentityRegisterStudentApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/RegisterStudent`, method: 'POST', body: queryArg.registerStudentRequestDto })
    }),
    getApiV1IdentityRefresh: build.query<GetApiV1IdentityRefreshApiResponse, GetApiV1IdentityRefreshApiArg>({
      query: () => ({ url: `/api/v1/Identity/Refresh` })
    }),
    getApiV1IdentityLogout: build.query<GetApiV1IdentityLogoutApiResponse, GetApiV1IdentityLogoutApiArg>({
      query: () => ({ url: `/api/v1/Identity/Logout` })
    }),
    getApiV1IdentityInfo: build.query<GetApiV1IdentityInfoApiResponse, GetApiV1IdentityInfoApiArg>({
      query: () => ({ url: `/api/v1/Identity/Info` })
    }),
    postApiV1IdentityApprove: build.mutation<PostApiV1IdentityApproveApiResponse, PostApiV1IdentityApproveApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/Approve`, method: 'POST', body: queryArg.approveUserRequestDto })
    }),
    getApiV1SpecialtyGet: build.query<GetApiV1SpecialtyGetApiResponse, GetApiV1SpecialtyGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Specialty/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1SpecialtyGetList: build.query<GetApiV1SpecialtyGetListApiResponse, GetApiV1SpecialtyGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Specialty/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1SpecialtyCreate: build.mutation<PostApiV1SpecialtyCreateApiResponse, PostApiV1SpecialtyCreateApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Specialty/Create`, method: 'POST', body: queryArg.createSpecialtyRequestDto })
    }),
    deleteApiV1SpecialtyDelete: build.mutation<DeleteApiV1SpecialtyDeleteApiResponse, DeleteApiV1SpecialtyDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Specialty/Delete`, method: 'DELETE', body: queryArg.deleteSpecialtyRequestDto })
    }),
    getApiV1UniversityGet: build.query<GetApiV1UniversityGetApiResponse, GetApiV1UniversityGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/University/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1UniversityGetList: build.query<GetApiV1UniversityGetListApiResponse, GetApiV1UniversityGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/University/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1UniversityCreate: build.mutation<PostApiV1UniversityCreateApiResponse, PostApiV1UniversityCreateApiArg>({
      query: (queryArg) => ({ url: `/api/v1/University/Create`, method: 'POST', body: queryArg.createUniversityRequestDto })
    }),
    deleteApiV1UniversityDelete: build.mutation<DeleteApiV1UniversityDeleteApiResponse, DeleteApiV1UniversityDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/University/Delete`, method: 'DELETE', body: queryArg.deleteUniversityRequestDto })
    }),
    getApiV1UniversityPositionGet: build.query<GetApiV1UniversityPositionGetApiResponse, GetApiV1UniversityPositionGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/UniversityPosition/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1UniversityPositionGetList: build.query<GetApiV1UniversityPositionGetListApiResponse, GetApiV1UniversityPositionGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/UniversityPosition/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    getApiV1UserGet: build.query<GetApiV1UserGetApiResponse, GetApiV1UserGetApiArg>({
      query: (queryArg) => ({ url: `/api/v1/User/Get`, params: { Id: queryArg.id } })
    }),
    getApiV1UserGetList: build.query<GetApiV1UserGetListApiResponse, GetApiV1UserGetListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/User/GetList`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    })
  }),
  overrideExisting: false
});
export { injectedRtkApi as backendApi };
export type GetApiV1DepartmentGetApiResponse = /** status 200 Success */ GetDepartmentResponseDto;
export type GetApiV1DepartmentGetApiArg = {
  id?: string;
};
export type GetApiV1DepartmentGetListApiResponse = /** status 200 Success */ GetDepartmentsResponseDtoRead;
export type GetApiV1DepartmentGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1DepartmentCreateApiResponse = /** status 200 Success */ CreateDepartmentResponseDto;
export type PostApiV1DepartmentCreateApiArg = {
  createDepartmentRequestDto: CreateDepartmentRequestDto;
};
export type DeleteApiV1DepartmentDeleteApiResponse = unknown;
export type DeleteApiV1DepartmentDeleteApiArg = {
  deleteDepartmentRequestDto: DeleteDepartmentRequestDto;
};
export type GetApiV1DiplomaPeriodGetApiResponse = /** status 200 Success */ GetDiplomaPeriodResponseDto;
export type GetApiV1DiplomaPeriodGetApiArg = {
  id?: string;
};
export type GetApiV1DiplomaPeriodGetActualListApiResponse = /** status 200 Success */ GetActualDiplomaPeriodsResponseDtoRead;
export type GetApiV1DiplomaPeriodGetActualListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1DiplomaPeriodGetActualTeachersApiResponse = /** status 200 Success */ GetActualTeachersResponseDtoRead;
export type PostApiV1DiplomaPeriodGetActualTeachersApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type GetApiV1FacultyGetApiResponse = /** status 200 Success */ GetFacultyResponseDto;
export type GetApiV1FacultyGetApiArg = {
  id?: string;
};
export type GetApiV1FacultyGetListApiResponse = /** status 200 Success */ GetFacultiesResponseDtoRead;
export type GetApiV1FacultyGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1FacultyCreateApiResponse = /** status 200 Success */ CreateFacultyResponseDto;
export type PostApiV1FacultyCreateApiArg = {
  createFacultyRequestDto: CreateFacultyRequestDto;
};
export type DeleteApiV1FacultyDeleteApiResponse = unknown;
export type DeleteApiV1FacultyDeleteApiArg = {
  deleteFacultyRequestDto: DeleteFacultyRequestDto;
};
export type GetApiV1GroupGetApiResponse = /** status 200 Success */ GetGroupResponseDto;
export type GetApiV1GroupGetApiArg = {
  id?: string;
};
export type GetApiV1GroupGetListApiResponse = /** status 200 Success */ GetGroupsResponseDtoRead;
export type GetApiV1GroupGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1GroupCreateApiResponse = /** status 200 Success */ CreateGroupResponseDto;
export type PostApiV1GroupCreateApiArg = {
  createGroupRequestDto: CreateGroupRequestDto;
};
export type DeleteApiV1GroupDeleteApiResponse = unknown;
export type DeleteApiV1GroupDeleteApiArg = {
  deleteGroupRequestDto: DeleteGroupRequestDto;
};
export type DeleteApiV1IdentityDeleteApiResponse = unknown;
export type DeleteApiV1IdentityDeleteApiArg = {
  deleteUserRequestDto: DeleteUserRequestDto;
};
export type PostApiV1IdentityLoginApiResponse = /** status 200 Success */ LoginResponseDto;
export type PostApiV1IdentityLoginApiArg = {
  loginRequestDto: LoginRequestDto;
};
export type PostApiV1IdentityRegisterEmployeeApiResponse = unknown;
export type PostApiV1IdentityRegisterEmployeeApiArg = {
  registerEmployeeRequestDto: RegisterEmployeeRequestDto;
};
export type PostApiV1IdentityRegisterAdminApiResponse = unknown;
export type PostApiV1IdentityRegisterAdminApiArg = {
  registerAdminRequestDto: RegisterAdminRequestDto;
};
export type PostApiV1IdentityRegisterStudentApiResponse = unknown;
export type PostApiV1IdentityRegisterStudentApiArg = {
  registerStudentRequestDto: RegisterStudentRequestDto;
};
export type GetApiV1IdentityRefreshApiResponse = /** status 200 Success */ RefreshResponseDto;
export type GetApiV1IdentityRefreshApiArg = void;
export type GetApiV1IdentityLogoutApiResponse = unknown;
export type GetApiV1IdentityLogoutApiArg = void;
export type GetApiV1IdentityInfoApiResponse = /** status 200 Success */ InfoResponseDto;
export type GetApiV1IdentityInfoApiArg = void;
export type PostApiV1IdentityApproveApiResponse = unknown;
export type PostApiV1IdentityApproveApiArg = {
  approveUserRequestDto: ApproveUserRequestDto;
};
export type GetApiV1SpecialtyGetApiResponse = /** status 200 Success */ GetSpecialtyResponseDto;
export type GetApiV1SpecialtyGetApiArg = {
  id?: string;
};
export type GetApiV1SpecialtyGetListApiResponse = /** status 200 Success */ GetSpecialtiesResponseDtoRead;
export type GetApiV1SpecialtyGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1SpecialtyCreateApiResponse = /** status 200 Success */ CreateSpecialtyResponseDto;
export type PostApiV1SpecialtyCreateApiArg = {
  createSpecialtyRequestDto: CreateSpecialtyRequestDto;
};
export type DeleteApiV1SpecialtyDeleteApiResponse = unknown;
export type DeleteApiV1SpecialtyDeleteApiArg = {
  deleteSpecialtyRequestDto: DeleteSpecialtyRequestDto;
};
export type GetApiV1UniversityGetApiResponse = /** status 200 Success */ GetUniversityResponseDto;
export type GetApiV1UniversityGetApiArg = {
  id?: string;
};
export type GetApiV1UniversityGetListApiResponse = /** status 200 Success */ GetUniversitiesResponseDtoRead;
export type GetApiV1UniversityGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1UniversityCreateApiResponse = /** status 200 Success */ CreateUniversityResponseDto;
export type PostApiV1UniversityCreateApiArg = {
  createUniversityRequestDto: CreateUniversityRequestDto;
};
export type DeleteApiV1UniversityDeleteApiResponse = unknown;
export type DeleteApiV1UniversityDeleteApiArg = {
  deleteUniversityRequestDto: DeleteUniversityRequestDto;
};
export type GetApiV1UniversityPositionGetApiResponse = /** status 200 Success */ GetUniversityPositionResponseDto;
export type GetApiV1UniversityPositionGetApiArg = {
  id?: string;
};
export type GetApiV1UniversityPositionGetListApiResponse = /** status 200 Success */ GetUniversityPositionsResponseDtoRead;
export type GetApiV1UniversityPositionGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type GetApiV1UserGetApiResponse = /** status 200 Success */ GetUserResponseDto;
export type GetApiV1UserGetApiArg = {
  id?: string;
};
export type GetApiV1UserGetListApiResponse = /** status 200 Success */ GetUsersResponseDtoRead;
export type GetApiV1UserGetListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type DepartmentDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type GetDepartmentResponseDto = {
  department?: DepartmentDto;
};
export type DepartmentDtoPagedList = {
  items?: DepartmentDto[] | null;
  pageSize?: number;
};
export type DepartmentDtoPagedListRead = {
  items?: DepartmentDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetDepartmentsResponseDto = {
  list?: DepartmentDtoPagedList;
};
export type GetDepartmentsResponseDtoRead = {
  list?: DepartmentDtoPagedListRead;
};
export type CreateDepartmentResponseDto = {
  id?: string;
};
export type CreateDepartmentRequestDto = {
  name: string;
  shortName: string;
  facultyId?: string;
};
export type DeleteDepartmentRequestDto = {
  id?: string;
};
export type DiplomaPeriodDto = {
  id?: string;
  startDate?: string;
  endDate?: string;
};
export type GetDiplomaPeriodResponseDto = {
  diplomaPeriod?: DiplomaPeriodDto;
};
export type DiplomaPeriodDtoPagedList = {
  items?: DiplomaPeriodDto[] | null;
  pageSize?: number;
};
export type DiplomaPeriodDtoPagedListRead = {
  items?: DiplomaPeriodDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetActualDiplomaPeriodsResponseDto = {
  list?: DiplomaPeriodDtoPagedList;
};
export type GetActualDiplomaPeriodsResponseDtoRead = {
  list?: DiplomaPeriodDtoPagedListRead;
};
export type TeacherDto = object;
export type TeacherDtoPagedList = {
  items?: TeacherDto[] | null;
  pageSize?: number;
};
export type TeacherDtoPagedListRead = {
  items?: TeacherDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetActualTeachersResponseDto = {
  list?: TeacherDtoPagedList;
};
export type GetActualTeachersResponseDtoRead = {
  list?: TeacherDtoPagedListRead;
};
export type FacultyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type GetFacultyResponseDto = {
  faculty?: FacultyDto;
};
export type FacultyDtoPagedList = {
  items?: FacultyDto[] | null;
  pageSize?: number;
};
export type FacultyDtoPagedListRead = {
  items?: FacultyDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetFacultiesResponseDto = {
  list?: FacultyDtoPagedList;
};
export type GetFacultiesResponseDtoRead = {
  list?: FacultyDtoPagedListRead;
};
export type CreateFacultyResponseDto = {
  id?: string;
};
export type CreateFacultyRequestDto = {
  name: string;
  shortName: string;
  universityId?: string;
};
export type DeleteFacultyRequestDto = {
  id?: string;
};
export type GroupDto = {
  id?: string;
  number?: string | null;
};
export type GetGroupResponseDto = {
  group?: GroupDto;
};
export type GroupDtoPagedList = {
  items?: GroupDto[] | null;
  pageSize?: number;
};
export type GroupDtoPagedListRead = {
  items?: GroupDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetGroupsResponseDto = {
  list?: GroupDtoPagedList;
};
export type GetGroupsResponseDtoRead = {
  list?: GroupDtoPagedListRead;
};
export type CreateGroupResponseDto = {
  id?: string;
};
export type CreateGroupRequestDto = {
  groupNumber: string;
  startDate?: string;
  endDate?: string;
  specialtyId?: string;
};
export type DeleteGroupRequestDto = {
  id?: string;
};
export type DeleteUserRequestDto = {
  id?: string;
};
export type TokenDto = {
  value?: string | null;
  expiration?: string;
};
export type LoginResponseDto = {
  accessToken?: TokenDto;
  refreshToken?: TokenDto;
};
export type LoginRequestDto = {
  userName: string;
  password: string;
};
export type RegisterEmployeeRequestDto = {
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
export type RegisterAdminRequestDto = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
};
export type RegisterStudentRequestDto = {
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
  groupNumber?: string | null;
};
export type RefreshResponseDto = {
  accessToken?: TokenDto;
  refreshToken?: TokenDto;
};
export type UserRoleIdDto = 'None' | 'ApplicationAdmin' | 'Employee' | 'Student';
export type InfoResponseDto = {
  userId?: string;
  roleId?: UserRoleIdDto;
  approved?: boolean;
};
export type ApproveUserRequestDto = {
  userId: string;
};
export type SpecialtyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type GetSpecialtyResponseDto = {
  specialty?: SpecialtyDto;
};
export type SpecialtyDtoPagedList = {
  items?: SpecialtyDto[] | null;
  pageSize?: number;
};
export type SpecialtyDtoPagedListRead = {
  items?: SpecialtyDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetSpecialtiesResponseDto = {
  list?: SpecialtyDtoPagedList;
};
export type GetSpecialtiesResponseDtoRead = {
  list?: SpecialtyDtoPagedListRead;
};
export type CreateSpecialtyResponseDto = {
  id?: string;
};
export type CreateSpecialtyRequestDto = {
  name: string;
  shortName: string;
  code: string;
  facultyId?: string;
};
export type DeleteSpecialtyRequestDto = {
  id?: string;
};
export type UniversityDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type GetUniversityResponseDto = {
  university?: UniversityDto;
};
export type UniversityDtoPagedList = {
  items?: UniversityDto[] | null;
  pageSize?: number;
};
export type UniversityDtoPagedListRead = {
  items?: UniversityDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetUniversitiesResponseDto = {
  list?: UniversityDtoPagedList;
};
export type GetUniversitiesResponseDtoRead = {
  list?: UniversityDtoPagedListRead;
};
export type CreateUniversityResponseDto = {
  id?: string;
};
export type CreateUniversityRequestDto = {
  name: string;
  shortName: string;
};
export type DeleteUniversityRequestDto = {
  id?: string;
};
export type UniversityPositionDto = {
  id?: string;
  name?: string | null;
};
export type GetUniversityPositionResponseDto = {
  universityPosition?: UniversityPositionDto;
};
export type UniversityPositionDtoPagedList = {
  items?: UniversityPositionDto[] | null;
  pageSize?: number;
};
export type UniversityPositionDtoPagedListRead = {
  items?: UniversityPositionDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetUniversityPositionsResponseDto = {
  list?: UniversityPositionDtoPagedList;
};
export type GetUniversityPositionsResponseDtoRead = {
  list?: UniversityPositionDtoPagedListRead;
};
export type UserDto = {
  id?: string;
  firstName?: string | null;
  lastName?: string | null;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
};
export type GetUserResponseDto = {
  user?: UserDto;
};
export type UserDtoPagedList = {
  items?: UserDto[] | null;
  pageSize?: number;
};
export type UserDtoPagedListRead = {
  items?: UserDto[] | null;
  currentPage?: number;
  totalPages?: number;
  pageSize?: number;
  totalCount?: number;
  hasPrevious?: boolean;
  hasNext?: boolean;
};
export type GetUsersResponseDto = {
  list?: UserDtoPagedList;
};
export type GetUsersResponseDtoRead = {
  list?: UserDtoPagedListRead;
};
export const {
  useGetApiV1DepartmentGetQuery,
  useGetApiV1DepartmentGetListQuery,
  usePostApiV1DepartmentCreateMutation,
  useDeleteApiV1DepartmentDeleteMutation,
  useGetApiV1DiplomaPeriodGetQuery,
  useGetApiV1DiplomaPeriodGetActualListQuery,
  usePostApiV1DiplomaPeriodGetActualTeachersMutation,
  useGetApiV1FacultyGetQuery,
  useGetApiV1FacultyGetListQuery,
  usePostApiV1FacultyCreateMutation,
  useDeleteApiV1FacultyDeleteMutation,
  useGetApiV1GroupGetQuery,
  useGetApiV1GroupGetListQuery,
  usePostApiV1GroupCreateMutation,
  useDeleteApiV1GroupDeleteMutation,
  useDeleteApiV1IdentityDeleteMutation,
  usePostApiV1IdentityLoginMutation,
  usePostApiV1IdentityRegisterEmployeeMutation,
  usePostApiV1IdentityRegisterAdminMutation,
  usePostApiV1IdentityRegisterStudentMutation,
  useGetApiV1IdentityRefreshQuery,
  useGetApiV1IdentityLogoutQuery,
  useGetApiV1IdentityInfoQuery,
  usePostApiV1IdentityApproveMutation,
  useGetApiV1SpecialtyGetQuery,
  useGetApiV1SpecialtyGetListQuery,
  usePostApiV1SpecialtyCreateMutation,
  useDeleteApiV1SpecialtyDeleteMutation,
  useGetApiV1UniversityGetQuery,
  useGetApiV1UniversityGetListQuery,
  usePostApiV1UniversityCreateMutation,
  useDeleteApiV1UniversityDeleteMutation,
  useGetApiV1UniversityPositionGetQuery,
  useGetApiV1UniversityPositionGetListQuery,
  useGetApiV1UserGetQuery,
  useGetApiV1UserGetListQuery
} = injectedRtkApi;
