import { ContractsUserRoleType } from "src/api/backendApi"

export const roleSetByType = {
    [ContractsUserRoleType.None]: "users",
    [ContractsUserRoleType.Admin]: "admins",
    [ContractsUserRoleType.Deanery]: "deanery",
    [ContractsUserRoleType.Teacher]: "teachers",
    [ContractsUserRoleType.Student]: "students",
}

export const roleSetByString: { [key: string]: ContractsUserRoleType } = {
    "users": ContractsUserRoleType.None,
    "admins": ContractsUserRoleType.Admin,
    "deanery": ContractsUserRoleType.Deanery,
    "teachers": ContractsUserRoleType.Teacher,
    "students": ContractsUserRoleType.Student,
}

export const labels: Record<ContractsUserRoleType, string> = {
    [ContractsUserRoleType.Admin]: "Админы",
    [ContractsUserRoleType.Deanery]: "Деканат",
    [ContractsUserRoleType.Teacher]: "Преподаватели",
    [ContractsUserRoleType.Student]: "Студенты",
    [ContractsUserRoleType.None]: "Неизвестно",
};