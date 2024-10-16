import { LockOutlined } from "@mui/icons-material";
import { Avatar, Box, Container, FormControl, InputLabel, MenuItem, Select, Typography } from "@mui/material";
import { useState } from "react";
import { UserRoleIdDto } from "src/api/backendApi";
import RegisterAdminForm from "./RegisterAdminForm";
import RegisterEmployeeForm from "./RegisterEmployeeForm";
import RegisterStudentForm from "./RegisterStudentForm";
import { Link } from "react-router-dom";

const RegisterPage = () => {
    const [userRole, setUserRole] = useState<UserRoleIdDto>(UserRoleIdDto.None);

    return (
        <Container maxWidth="xs" sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
        }}>

            <Avatar sx={{ bgcolor: "primary.light" }}>
                <LockOutlined />
            </Avatar>

            <Typography sx={{ p: 2 }} variant="h5">Форма регистрации</Typography>

            <FormControl fullWidth>
                <InputLabel id="user-role-label">Роль</InputLabel>
                <Select
                    labelId="user-role-label"
                    id="user-role-select"
                    value={userRole}
                    label="Роль"
                    onChange={(e) => {
                        switch (e.target.value) {
                            case UserRoleIdDto.Student:
                                setUserRole(UserRoleIdDto.Student);
                                break;
                            case UserRoleIdDto.ApplicationAdmin:
                                setUserRole(UserRoleIdDto.ApplicationAdmin);
                                break;
                            case UserRoleIdDto.Employee:
                                setUserRole(UserRoleIdDto.Employee);
                                break;
                            default:
                                setUserRole(UserRoleIdDto.None);
                                break;
                        }
                    }}
                >
                    <MenuItem disabled value={UserRoleIdDto.None}>Не выбрана</MenuItem>
                    <MenuItem value={UserRoleIdDto.Student}>Студент</MenuItem>
                    <MenuItem value={UserRoleIdDto.ApplicationAdmin}>Администратор</MenuItem>
                    <MenuItem value={UserRoleIdDto.Employee}>Сотрудник университета</MenuItem>
                </Select>
            </FormControl>

            {
                userRole == "ApplicationAdmin"
                    ? <RegisterAdminForm />
                    : userRole == "Employee"
                        ? <RegisterEmployeeForm />
                        : userRole == "Student"
                            ? <RegisterStudentForm />
                            : <></>
            }

            <Box sx={{ p: 3, textAlign: "center" }}>
                <Link to="/signin">Уже есть аккаунт? Авторизоваться</Link>
            </Box>

        </Container>
    )
};

export default RegisterPage;