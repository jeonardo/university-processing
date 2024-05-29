import { emptySplitApi as api } from '../core/emptyApi';
const injectedRtkApi = api.injectEndpoints({
  endpoints: (build) => ({
    getApiV1DepartmentGetById: build.query<GetApiV1DepartmentGetByIdApiResponse, GetApiV1DepartmentGetByIdApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Department/Get/${queryArg.id}` })
    }),
    getApiV1DepartmentList: build.query<GetApiV1DepartmentListApiResponse, GetApiV1DepartmentListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Department/List`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1DepartmentCreate: build.mutation<PostApiV1DepartmentCreateApiResponse, PostApiV1DepartmentCreateApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Department/Create`,
        method: 'POST',
        params: { Name: queryArg.name, ShortName: queryArg.shortName, FacultyId: queryArg.facultyId }
      })
    }),
    deleteApiV1DepartmentDelete: build.mutation<DeleteApiV1DepartmentDeleteApiResponse, DeleteApiV1DepartmentDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Department/Delete`, method: 'DELETE', body: queryArg.departmentDeleteRequestDto })
    }),
    getApiV1FacultyGetById: build.query<GetApiV1FacultyGetByIdApiResponse, GetApiV1FacultyGetByIdApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Faculty/Get/${queryArg.id}` })
    }),
    getApiV1FacultyList: build.query<GetApiV1FacultyListApiResponse, GetApiV1FacultyListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Faculty/List`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1FacultyCreate: build.mutation<PostApiV1FacultyCreateApiResponse, PostApiV1FacultyCreateApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Faculty/Create`,
        method: 'POST',
        params: { Name: queryArg.name, ShortName: queryArg.shortName, UniversityId: queryArg.universityId }
      })
    }),
    deleteApiV1FacultyDelete: build.mutation<DeleteApiV1FacultyDeleteApiResponse, DeleteApiV1FacultyDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Faculty/Delete`, method: 'DELETE', body: queryArg.facultyDeleteRequestDto })
    }),
    getApiV1GroupGetById: build.query<GetApiV1GroupGetByIdApiResponse, GetApiV1GroupGetByIdApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Group/Get/${queryArg.id}` })
    }),
    getApiV1GroupList: build.query<GetApiV1GroupListApiResponse, GetApiV1GroupListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Group/List`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1GroupCreate: build.mutation<PostApiV1GroupCreateApiResponse, PostApiV1GroupCreateApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Group/Create`,
        method: 'POST',
        params: {
          GroupNumber: queryArg.groupNumber,
          StartDate: queryArg.startDate,
          EndDate: queryArg.endDate,
          SpecialtyId: queryArg.specialtyId
        }
      })
    }),
    deleteApiV1GroupDelete: build.mutation<DeleteApiV1GroupDeleteApiResponse, DeleteApiV1GroupDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Group/Delete`, method: 'DELETE', body: queryArg.groupDeleteRequestDto })
    }),
    postApiV1IdentityLogin: build.mutation<PostApiV1IdentityLoginApiResponse, PostApiV1IdentityLoginApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/Login`, method: 'POST', body: queryArg.loginRequestDto })
    }),
    postApiV1IdentityRegister: build.mutation<PostApiV1IdentityRegisterApiResponse, PostApiV1IdentityRegisterApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Identity/Register`, method: 'POST', body: queryArg.registerRequestDto })
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
    getApiV1SpecialtyGetById: build.query<GetApiV1SpecialtyGetByIdApiResponse, GetApiV1SpecialtyGetByIdApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Specialty/Get/${queryArg.id}` })
    }),
    getApiV1SpecialtyList: build.query<GetApiV1SpecialtyListApiResponse, GetApiV1SpecialtyListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Specialty/List`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1SpecialtyCreate: build.mutation<PostApiV1SpecialtyCreateApiResponse, PostApiV1SpecialtyCreateApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/Specialty/Create`,
        method: 'POST',
        params: { Name: queryArg.name, ShortName: queryArg.shortName, Code: queryArg.code, FacultyId: queryArg.facultyId }
      })
    }),
    deleteApiV1SpecialtyDelete: build.mutation<DeleteApiV1SpecialtyDeleteApiResponse, DeleteApiV1SpecialtyDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/Specialty/Delete`, method: 'DELETE', body: queryArg.specialtyDeleteRequestDto })
    }),
    getApiV1UniversityGetById: build.query<GetApiV1UniversityGetByIdApiResponse, GetApiV1UniversityGetByIdApiArg>({
      query: (queryArg) => ({ url: `/api/v1/University/Get/${queryArg.id}` })
    }),
    getApiV1UniversityList: build.query<GetApiV1UniversityListApiResponse, GetApiV1UniversityListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/University/List`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    }),
    postApiV1UniversityCreate: build.mutation<PostApiV1UniversityCreateApiResponse, PostApiV1UniversityCreateApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/University/Create`,
        method: 'POST',
        params: { Name: queryArg.name, ShortName: queryArg.shortName }
      })
    }),
    deleteApiV1UniversityDelete: build.mutation<DeleteApiV1UniversityDeleteApiResponse, DeleteApiV1UniversityDeleteApiArg>({
      query: (queryArg) => ({ url: `/api/v1/University/Delete`, method: 'DELETE', body: queryArg.universityDeleteRequestDto })
    }),
    getApiV1UniversityPositionGetById: build.query<GetApiV1UniversityPositionGetByIdApiResponse, GetApiV1UniversityPositionGetByIdApiArg>({
      query: (queryArg) => ({ url: `/api/v1/UniversityPosition/Get/${queryArg.id}` })
    }),
    getApiV1UniversityPositionList: build.query<GetApiV1UniversityPositionListApiResponse, GetApiV1UniversityPositionListApiArg>({
      query: (queryArg) => ({
        url: `/api/v1/UniversityPosition/List`,
        params: { Desc: queryArg.desc, OrderBy: queryArg.orderBy, PageNumber: queryArg.pageNumber, PageSize: queryArg.pageSize }
      })
    })
  }),
  overrideExisting: false
});
export { injectedRtkApi as backendApi };
export type GetApiV1DepartmentGetByIdApiResponse = /** status 200 Success */ DepartmentGetResponseDto;
export type GetApiV1DepartmentGetByIdApiArg = {
  id: string;
};
export type GetApiV1DepartmentListApiResponse = /** status 200 Success */ DepartmentListResponseDtoRead;
export type GetApiV1DepartmentListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1DepartmentCreateApiResponse = /** status 200 Success */ DepartmentCreateResponseDto;
export type PostApiV1DepartmentCreateApiArg = {
  name: string;
  shortName: string;
  facultyId?: string;
};
export type DeleteApiV1DepartmentDeleteApiResponse = /** status 200 Success */ void;
export type DeleteApiV1DepartmentDeleteApiArg = {
  departmentDeleteRequestDto: DepartmentDeleteRequestDto;
};
export type GetApiV1FacultyGetByIdApiResponse = /** status 200 Success */ FacultyGetResponseDto;
export type GetApiV1FacultyGetByIdApiArg = {
  id: string;
};
export type GetApiV1FacultyListApiResponse = /** status 200 Success */ FacultyListResponseDtoRead;
export type GetApiV1FacultyListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1FacultyCreateApiResponse = /** status 200 Success */ FacultyCreateResponseDto;
export type PostApiV1FacultyCreateApiArg = {
  name: string;
  shortName: string;
  universityId?: string;
};
export type DeleteApiV1FacultyDeleteApiResponse = /** status 200 Success */ void;
export type DeleteApiV1FacultyDeleteApiArg = {
  facultyDeleteRequestDto: FacultyDeleteRequestDto;
};
export type GetApiV1GroupGetByIdApiResponse = /** status 200 Success */ GroupGetResponseDto;
export type GetApiV1GroupGetByIdApiArg = {
  id: string;
};
export type GetApiV1GroupListApiResponse = /** status 200 Success */ GroupListResponseDtoRead;
export type GetApiV1GroupListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1GroupCreateApiResponse = /** status 200 Success */ GroupCreateResponseDto;
export type PostApiV1GroupCreateApiArg = {
  groupNumber: string;
  startDate?: string;
  endDate?: string;
  specialtyId?: string;
};
export type DeleteApiV1GroupDeleteApiResponse = /** status 200 Success */ void;
export type DeleteApiV1GroupDeleteApiArg = {
  groupDeleteRequestDto: GroupDeleteRequestDto;
};
export type PostApiV1IdentityLoginApiResponse = /** status 200 Success */ LoginResponseDto;
export type PostApiV1IdentityLoginApiArg = {
  loginRequestDto: LoginRequestDto;
};
export type PostApiV1IdentityRegisterApiResponse = /** status 200 Success */ void;
export type PostApiV1IdentityRegisterApiArg = {
  registerRequestDto: RegisterRequestDto;
};
export type GetApiV1IdentityRefreshApiResponse = /** status 200 Success */ LoginResponseDto;
export type GetApiV1IdentityRefreshApiArg = void;
export type GetApiV1IdentityLogoutApiResponse = /** status 200 Success */ void;
export type GetApiV1IdentityLogoutApiArg = void;
export type GetApiV1IdentityInfoApiResponse = /** status 200 Success */ InfoResponseDto;
export type GetApiV1IdentityInfoApiArg = void;
export type GetApiV1SpecialtyGetByIdApiResponse = /** status 200 Success */ SpecialtyGetResponseDto;
export type GetApiV1SpecialtyGetByIdApiArg = {
  id: string;
};
export type GetApiV1SpecialtyListApiResponse = /** status 200 Success */ SpecialtyListResponseDtoRead;
export type GetApiV1SpecialtyListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1SpecialtyCreateApiResponse = /** status 200 Success */ SpecialtyCreateResponseDto;
export type PostApiV1SpecialtyCreateApiArg = {
  name: string;
  shortName: string;
  code: string;
  facultyId?: string;
};
export type DeleteApiV1SpecialtyDeleteApiResponse = /** status 200 Success */ void;
export type DeleteApiV1SpecialtyDeleteApiArg = {
  specialtyDeleteRequestDto: SpecialtyDeleteRequestDto;
};
export type GetApiV1UniversityGetByIdApiResponse = /** status 200 Success */ UniversityGetResponseDto;
export type GetApiV1UniversityGetByIdApiArg = {
  id: string;
};
export type GetApiV1UniversityListApiResponse = /** status 200 Success */ UniversityListResponseDtoRead;
export type GetApiV1UniversityListApiArg = {
  desc?: boolean;
  orderBy?: string;
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiV1UniversityCreateApiResponse = /** status 200 Success */ UniversityCreateResponseDto;
export type PostApiV1UniversityCreateApiArg = {
  name: string;
  shortName: string;
};
export type DeleteApiV1UniversityDeleteApiResponse = /** status 200 Success */ void;
export type DeleteApiV1UniversityDeleteApiArg = {
  universityDeleteRequestDto: UniversityDeleteRequestDto;
};
export type GetApiV1UniversityPositionGetByIdApiResponse = /** status 200 Success */ UniversityPositionGetResponseDto;
export type GetApiV1UniversityPositionGetByIdApiArg = {
  id: string;
};
export type GetApiV1UniversityPositionListApiResponse = /** status 200 Success */ UniversityPositionListResponseDtoRead;
export type GetApiV1UniversityPositionListApiArg = {
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
export type DepartmentGetResponseDto = {
  department?: DepartmentDto;
};
export type FailResponseDto = {
  message?: string | null;
};
export type ProblemDetails = {
  type?: string | null;
  title?: string | null;
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  [key: string]: any;
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
export type DepartmentListResponseDto = {
  list?: DepartmentDtoPagedList;
};
export type DepartmentListResponseDtoRead = {
  list?: DepartmentDtoPagedListRead;
};
export type DepartmentCreateResponseDto = {
  id?: string;
};
export type DepartmentDeleteRequestDto = {
  id?: string;
};
export type FacultyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type FacultyGetResponseDto = {
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
export type FacultyListResponseDto = {
  list?: FacultyDtoPagedList;
};
export type FacultyListResponseDtoRead = {
  list?: FacultyDtoPagedListRead;
};
export type FacultyCreateResponseDto = {
  id?: string;
};
export type FacultyDeleteRequestDto = {
  id?: string;
};
export type GroupDto = {
  id?: string;
  number?: string | null;
};
export type GroupGetResponseDto = {
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
export type GroupListResponseDto = {
  list?: GroupDtoPagedList;
};
export type GroupListResponseDtoRead = {
  list?: GroupDtoPagedListRead;
};
export type GroupCreateResponseDto = {
  id?: string;
};
export type GroupDeleteRequestDto = {
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
export type UserRoleIdDto = 'None' | 'ApplicationAdmin' | 'Employee' | 'Student';
export type RegisterRequestDto = {
  userRole: UserRoleIdDto;
  userName: string;
  password: string;
  firstName: string;
  lastName?: string | null;
  middleName?: string | null;
  email?: string | null;
  birthday?: string | null;
  universityId?: string | null;
  universityPositionId?: string | null;
  groupId?: string | null;
};
export type InfoResponseDto = {
  userId?: string;
  roleId?: UserRoleIdDto;
  approved?: boolean;
};
export type SpecialtyDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
  code?: string | null;
};
export type SpecialtyGetResponseDto = {
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
export type SpecialtyListResponseDto = {
  list?: SpecialtyDtoPagedList;
};
export type SpecialtyListResponseDtoRead = {
  list?: SpecialtyDtoPagedListRead;
};
export type SpecialtyCreateResponseDto = {
  id?: string;
};
export type SpecialtyDeleteRequestDto = {
  id?: string;
};
export type UniversityDto = {
  id?: string;
  name?: string | null;
  shortName?: string | null;
};
export type UniversityGetResponseDto = {
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
export type UniversityListResponseDto = {
  list?: UniversityDtoPagedList;
};
export type UniversityListResponseDtoRead = {
  list?: UniversityDtoPagedListRead;
};
export type UniversityCreateResponseDto = {
  id?: string;
};
export type UniversityDeleteRequestDto = {
  id?: string;
};
export type UniversityPositionDto = {
  id?: string;
  name?: string | null;
};
export type UniversityPositionGetResponseDto = {
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
export type UniversityPositionListResponseDto = {
  list?: UniversityPositionDtoPagedList;
};
export type UniversityPositionListResponseDtoRead = {
  list?: UniversityPositionDtoPagedListRead;
};
export const {
  useGetApiV1DepartmentGetByIdQuery,
  useGetApiV1DepartmentListQuery,
  usePostApiV1DepartmentCreateMutation,
  useDeleteApiV1DepartmentDeleteMutation,
  useGetApiV1FacultyGetByIdQuery,
  useGetApiV1FacultyListQuery,
  usePostApiV1FacultyCreateMutation,
  useDeleteApiV1FacultyDeleteMutation,
  useGetApiV1GroupGetByIdQuery,
  useGetApiV1GroupListQuery,
  usePostApiV1GroupCreateMutation,
  useDeleteApiV1GroupDeleteMutation,
  usePostApiV1IdentityLoginMutation,
  usePostApiV1IdentityRegisterMutation,
  useGetApiV1IdentityRefreshQuery,
  useGetApiV1IdentityLogoutQuery,
  useGetApiV1IdentityInfoQuery,
  useGetApiV1SpecialtyGetByIdQuery,
  useGetApiV1SpecialtyListQuery,
  usePostApiV1SpecialtyCreateMutation,
  useDeleteApiV1SpecialtyDeleteMutation,
  useGetApiV1UniversityGetByIdQuery,
  useGetApiV1UniversityListQuery,
  usePostApiV1UniversityCreateMutation,
  useDeleteApiV1UniversityDeleteMutation,
  useGetApiV1UniversityPositionGetByIdQuery,
  useGetApiV1UniversityPositionListQuery
} = injectedRtkApi;
