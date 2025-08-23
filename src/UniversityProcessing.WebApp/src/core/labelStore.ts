import { ContractsUserRoleType } from "src/api/backendApi";

export interface RoleLocalization {
    label: string;
    value: ContractsUserRoleType;
}

export const contractsRoleLocalization: Record<ContractsUserRoleType, RoleLocalization> = {
    [ContractsUserRoleType.None]: {
        label: 'Не указано',
        value: ContractsUserRoleType.None
    },
    [ContractsUserRoleType.Admin]: {
        label: 'Администратор',
        value: ContractsUserRoleType.Admin
    },
    [ContractsUserRoleType.Deanery]: {
        label: 'Сотрудник деканата',
        value: ContractsUserRoleType.Deanery
    },
    [ContractsUserRoleType.Teacher]: {
        label: 'Преподаватель',
        value: ContractsUserRoleType.Teacher
    },
    [ContractsUserRoleType.Student]: {
        label: 'Студент',
        value: ContractsUserRoleType.Student
    }
};

export const RoleLocalizationLabel = (role: ContractsUserRoleType): string => {
    return contractsRoleLocalization[role]?.label || 'Неизвестная роль';
};

// Хук для получения локализации
export const useContractsRoleLocalization = () => {
    const getRoleLabel = (role: ContractsUserRoleType): string => {
        return contractsRoleLocalization[role]?.label || 'Неизвестная роль';
    };

    const getAllRoles = (): RoleLocalization[] => {
        return Object.values(contractsRoleLocalization);
    };

    const getRoleInfo = (role: ContractsUserRoleType): RoleLocalization => {
        return contractsRoleLocalization[role] || { label: 'Неизвестная роль', value: ContractsUserRoleType.None };
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
    getRolesForSelect: (): Array<{ value: ContractsUserRoleType; label: string }> => {
        return Object.values(contractsRoleLocalization).map(role => ({
            value: role.value,
            label: role.label
        }));
    },
};

export default contractsRoleLocalization;