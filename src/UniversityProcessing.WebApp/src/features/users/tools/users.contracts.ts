import { ApiContractsUserRoleTypeDto } from 'src/api/backendApi';

export const roleSetByType = {
  [ApiContractsUserRoleTypeDto.None]: 'users',
  [ApiContractsUserRoleTypeDto.Admin]: 'admins',
  [ApiContractsUserRoleTypeDto.Deanery]: 'deanery',
  [ApiContractsUserRoleTypeDto.Teacher]: 'teachers',
  [ApiContractsUserRoleTypeDto.Student]: 'students'
};

export const roleSetByString: { [key: string]: ApiContractsUserRoleTypeDto } = {
  'users': ApiContractsUserRoleTypeDto.None,
  'admins': ApiContractsUserRoleTypeDto.Admin,
  'deanery': ApiContractsUserRoleTypeDto.Deanery,
  'teachers': ApiContractsUserRoleTypeDto.Teacher,
  'students': ApiContractsUserRoleTypeDto.Student
};

export const labels: Record<ApiContractsUserRoleTypeDto, string> = {
  [ApiContractsUserRoleTypeDto.Admin]: 'Админы',
  [ApiContractsUserRoleTypeDto.Deanery]: 'Деканат',
  [ApiContractsUserRoleTypeDto.Teacher]: 'Преподаватели',
  [ApiContractsUserRoleTypeDto.Student]: 'Студенты',
  [ApiContractsUserRoleTypeDto.None]: 'Неизвестно'
};