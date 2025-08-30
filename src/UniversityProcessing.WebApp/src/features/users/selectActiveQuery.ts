import { ContractsUserRoleType } from 'src/api/backendApi';

type AnyQuery = {
    data?: any;
    isLoading: boolean;
    isFetching?: boolean;
    refetch: () => void;
};

export function selectActiveQuery(
    role: ContractsUserRoleType,
    queries: {
        admins: AnyQuery;
        deaneries: AnyQuery;
        teachers: AnyQuery;
        students: AnyQuery;
    }
) {
    const chosen =
        role === ContractsUserRoleType.Admin
            ? queries.admins
            : role === ContractsUserRoleType.Deanery
                ? queries.deaneries
                : role === ContractsUserRoleType.Teacher
                    ? queries.teachers
                    : queries.students;



    return {
        data: chosen.data,
        isLoading: chosen.isLoading || Boolean(chosen.isFetching),
        refetch: chosen.refetch,
    };
}
