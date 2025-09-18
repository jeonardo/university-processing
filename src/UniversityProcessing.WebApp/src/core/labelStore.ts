import { ApiContractsUserRoleTypeDto } from "src/api/backendApi";

export interface RoleLocalization {
  label: string;
  value: ApiContractsUserRoleTypeDto;
}

export const contractsRoleLocalization: Record<ApiContractsUserRoleTypeDto, RoleLocalization> = {
  [ApiContractsUserRoleTypeDto.None]: {
    label: 'Не указано',
    value: ApiContractsUserRoleTypeDto.None
  },
  [ApiContractsUserRoleTypeDto.Admin]: {
    label: 'Администратор',
    value: ApiContractsUserRoleTypeDto.Admin
  },
  [ApiContractsUserRoleTypeDto.Deanery]: {
    label: 'Сотрудник деканата',
    value: ApiContractsUserRoleTypeDto.Deanery
  },
  [ApiContractsUserRoleTypeDto.Teacher]: {
    label: 'Преподаватель',
    value: ApiContractsUserRoleTypeDto.Teacher
  },
  [ApiContractsUserRoleTypeDto.Student]: {
    label: 'Студент',
    value: ApiContractsUserRoleTypeDto.Student
  }
};

export const RoleLocalizationLabel = (role: ApiContractsUserRoleTypeDto): string => {
  return contractsRoleLocalization[role]?.label || 'Неизвестная роль';
};

// Хук для получения локализации
export const useContractsRoleLocalization = () => {
  const getRoleLabel = (role: ApiContractsUserRoleTypeDto): string => {
    return contractsRoleLocalization[role]?.label || 'Неизвестная роль';
  };

  const getAllRoles = (): RoleLocalization[] => {
    return Object.values(contractsRoleLocalization);
  };

  const getRoleInfo = (role: ApiContractsUserRoleTypeDto): RoleLocalization => {
    return contractsRoleLocalization[role] || { label: 'Неизвестная роль', value: ApiContractsUserRoleTypeDto.None };
  };

  return {
    getRoleLabel,
    getAllRoles,
    getRoleInfo,
    roles: contractsRoleLocalization
  };
};

// Утилиты для работы с ролями
export const contractsRoleUtils = {
  // Получить все роли в виде массива для селектов
  getRolesForSelect: (): Array<{ value: ApiContractsUserRoleTypeDto; label: string }> => {
    return Object.values(contractsRoleLocalization).map(role => ({
      value: role.value,
      label: role.label
    }));
  }
};

export default contractsRoleLocalization;