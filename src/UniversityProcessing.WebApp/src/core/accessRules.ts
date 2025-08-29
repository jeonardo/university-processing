import { ContractsUserRoleType } from 'src/api/backendApi';

export interface AccessRule {
  canViewAdmins: boolean;
  canViewDeanery: boolean;
  canViewTeachers: boolean;
  canViewStudents: boolean;
  canCreateAdmins: boolean;
  canCreateDeanery: boolean;
  canCreateTeachers: boolean;
  canCreateStudents: boolean;
}

export const accessRules: Record<ContractsUserRoleType, AccessRule> = {
  [ContractsUserRoleType.Admin]: {
    canViewAdmins: true,
    canViewDeanery: true,
    canViewTeachers: false,
    canViewStudents: false,
    canCreateAdmins: true,
    canCreateDeanery: true,
    canCreateTeachers: false,
    canCreateStudents: false,
  },
  [ContractsUserRoleType.Deanery]: {
    canViewAdmins: true,
    canViewDeanery: true,
    canViewTeachers: true,
    canViewStudents: true,
    canCreateAdmins: false,
    canCreateDeanery: false,
    canCreateTeachers: true,
    canCreateStudents: true,
  },
  [ContractsUserRoleType.Teacher]: {
    canViewAdmins: false,
    canViewDeanery: false,
    canViewTeachers: false,
    canViewStudents: true,
    canCreateAdmins: false,
    canCreateDeanery: false,
    canCreateTeachers: false,
    canCreateStudents: false,
  },
  [ContractsUserRoleType.Student]: {
    canViewAdmins: false,
    canViewDeanery: false,
    canViewTeachers: false,
    canViewStudents: false,
    canCreateAdmins: false,
    canCreateDeanery: false,
    canCreateTeachers: false,
    canCreateStudents: false,
  },
  [ContractsUserRoleType.None]: {
    canViewAdmins: false,
    canViewDeanery: false,
    canViewTeachers: false,
    canViewStudents: false,
    canCreateAdmins: false,
    canCreateDeanery: false,
    canCreateTeachers: false,
    canCreateStudents: false,
  },
};

// Вспомогательные функции для проверки доступа
export const getAvailableRoles = (userRole: ContractsUserRoleType | null | undefined): ContractsUserRoleType[] => {
  if (!userRole || userRole === ContractsUserRoleType.None) {
    return [];
  }

  const rules = accessRules[userRole];
  const availableRoles: ContractsUserRoleType[] = [];

  if (rules.canViewAdmins) availableRoles.push(ContractsUserRoleType.Admin);
  if (rules.canViewDeanery) availableRoles.push(ContractsUserRoleType.Deanery);
  if (rules.canViewTeachers) availableRoles.push(ContractsUserRoleType.Teacher);
  if (rules.canViewStudents) availableRoles.push(ContractsUserRoleType.Student);

  return availableRoles;
};

export const canCreateUser = (userRole: ContractsUserRoleType | null | undefined, targetRole: ContractsUserRoleType): boolean => {
  if (!userRole || userRole === ContractsUserRoleType.None) {
    return false;
  }

  const rules = accessRules[userRole];
  
  switch (targetRole) {
    case ContractsUserRoleType.Admin:
      return rules.canCreateAdmins;
    case ContractsUserRoleType.Deanery:
      return rules.canCreateDeanery;
    case ContractsUserRoleType.Teacher:
      return rules.canCreateTeachers;
    case ContractsUserRoleType.Student:
      return rules.canCreateStudents;
    default:
      return false;
  }
};

export const canViewRole = (userRole: ContractsUserRoleType | null | undefined, targetRole: ContractsUserRoleType): boolean => {
  if (!userRole || userRole === ContractsUserRoleType.None) {
    return false;
  }

  const rules = accessRules[userRole];
  
  switch (targetRole) {
    case ContractsUserRoleType.Admin:
      return rules.canViewAdmins;
    case ContractsUserRoleType.Deanery:
      return rules.canViewDeanery;
    case ContractsUserRoleType.Teacher:
      return rules.canViewTeachers;
    case ContractsUserRoleType.Student:
      return rules.canViewStudents;
    default:
      return false;
  }
};
