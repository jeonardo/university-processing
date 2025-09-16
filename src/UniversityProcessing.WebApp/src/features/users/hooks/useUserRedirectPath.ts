import { useEffect, useMemo } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useAppSelector } from 'src/core';
import { roleSetByString, roleSetByType } from '../tools/users.contracts';
import { ContractsUserRoleType } from 'src/api/backendApi';

export const getAvailableRoles = (userRole: ContractsUserRoleType | null | undefined): ContractsUserRoleType[] => {
    if (!userRole
        || userRole === ContractsUserRoleType.None) {
        return [];
    }

    switch (userRole) {
        case ContractsUserRoleType.Admin:
            return [ContractsUserRoleType.Admin, ContractsUserRoleType.Deanery];
        default:
            return [ContractsUserRoleType.Deanery, ContractsUserRoleType.Teacher, ContractsUserRoleType.Student];
    }
};

export const useUserRedirect = () => {
    const currentUserRole = useAppSelector(state => state.auth.user?.role);
    const availableRoles = useMemo(() => getAvailableRoles(currentUserRole), [currentUserRole]);

    const location = useLocation();
    const pathSegments = useMemo(() => location.pathname.split('/').filter(Boolean), [location.pathname]);
    const lastSegment = pathSegments[pathSegments.length - 1];

    const navigate = useNavigate();

    const routeRole = roleSetByString[lastSegment]

    useEffect(() => {
        if (!currentUserRole || !(lastSegment in roleSetByString))
            return
        switch (lastSegment) {
            case "users":
                navigate(`/users/${roleSetByType[availableRoles[0]]}`, { replace: true });
                break;
            default:
                if (!availableRoles.includes(roleSetByString[lastSegment]))
                    navigate(`/users/${roleSetByType[availableRoles[0]]}`, { replace: true });
                break;
        }
    }, [currentUserRole, location]);

    return { availableRoles, routeRole };
};