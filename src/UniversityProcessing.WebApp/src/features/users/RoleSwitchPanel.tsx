import { Box, Paper } from "@mui/material";
import { styled } from "@mui/system";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import { ContractsUserRoleType } from "src/api/backendApi";
import { getAvailableRoles } from "src/core";

const SwitchRoot = styled(Paper)(({ theme }) => ({
    display: "flex",
    position: "relative",
    borderRadius: 24,
    padding: 4,
    background: theme.palette.grey[200],
    userSelect: "none",
}));

const Thumb = styled(Box)(({ theme }) => ({
    position: "absolute",
    top: 4,
    bottom: 4,
    borderRadius: 20,
    background: theme.palette.primary.main,
    transition: "all 0.25s ease",
}));

interface RoleSwitchPanelProps {
    onChange: (role: ContractsUserRoleType) => void;
    currentUserRole?: ContractsUserRoleType | null;
}

export default function RoleSwitchPanel({ onChange, currentUserRole }: RoleSwitchPanelProps) {
    // Получаем доступные роли из централизованных правил доступа
    const availableRoles = getAvailableRoles(currentUserRole);
    
    // Создаем массив ролей с метками для отображения
    const roles = availableRoles.map(role => {
        const labels: Record<ContractsUserRoleType, string> = {
            [ContractsUserRoleType.Admin]: "Админ",
            [ContractsUserRoleType.Deanery]: "Деканат",
            [ContractsUserRoleType.Teacher]: "Преподаватель",
            [ContractsUserRoleType.Student]: "Студент",
            [ContractsUserRoleType.None]: "Неизвестно",
        };
        return { value: role, label: labels[role] };
    });

    const [role, setRole] = useState(ContractsUserRoleType.None);
    const activeIndex = roles.findIndex(r => r.value === role);

    const [searchParams, setSearchParams] = useSearchParams();
    const paramRole = searchParams.get("role");

    useEffect(() => {
        if (paramRole && Object.values(ContractsUserRoleType).includes(paramRole as any)) {
            // Проверяем, что выбранная роль доступна для текущего пользователя
            const availableRole = roles.find(r => r.value === paramRole);
            if (availableRole) {
                setRole(paramRole as ContractsUserRoleType);
                onChange(paramRole as ContractsUserRoleType);
            } else {
                // Если выбранная роль недоступна, устанавливаем первую доступную
                const firstAvailableRole = roles[0];
                if (firstAvailableRole) {
                    setRole(firstAvailableRole.value);
                    onChange(firstAvailableRole.value);
                    setSearchParams({ role: firstAvailableRole.value });
                }
            }
        } else {
            // Если нет параметра в URL, устанавливаем первую доступную роль
            const firstAvailableRole = roles[0];
            if (firstAvailableRole) {
                setRole(firstAvailableRole.value);
                onChange(firstAvailableRole.value);
                setSearchParams({ role: firstAvailableRole.value });
            }
        }
    }, [paramRole, roles, onChange, setSearchParams]);

    const onSwitchClicked = (switchRole: ContractsUserRoleType) => {
        setSearchParams({ role: switchRole });
    };

    // Если нет доступных ролей, не показываем панель
    if (roles.length === 0) {
        return null;
    }

    return (
        <SwitchRoot elevation={0}>
            <Thumb
                sx={{
                    width: `calc(100% / ${roles.length} - 8px)`,
                    left: `calc(${activeIndex} * (100% / ${roles.length}) + 4px)`,
                }}
            />
            {roles.map(r => (
                <Box
                    key={r.value}
                    onClick={() => onSwitchClicked(r.value)}
                    sx={{
                        flex: 1,
                        textAlign: "center",
                        zIndex: 1,
                        cursor: "pointer",
                        lineHeight: "32px",
                        fontWeight: role === r.value ? 600 : 400,
                        color: role === r.value ? "#fff" : "inherit",
                        transition: "color 0.25s ease",
                    }}
                >
                    {r.label}
                </Box>
            ))}
        </SwitchRoot>
    );
}
