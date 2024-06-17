import { Avatar, Box, Button, CircularProgress, Container, CssBaseline, FormControl, Grid, InputLabel, MenuItem, Select, Stack, TextField, Typography, } from "@mui/material";
import { LockOutlined } from "@mui/icons-material";
import { useState } from "react";
import { Link } from "react-router-dom";
import { useAppDispatch } from "../../core/hooks";
import { ENV } from "../../core/env";
import { unwrapResult } from "@reduxjs/toolkit";
import { UserRoleIdDto, usePostApiV1IdentityRegisterAdminMutation } from "src/api/backendApi";

const RegisterPage = () => {
    const dispatch = useAppDispatch();

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");

    const [userRole, setUserRole] = useState<UserRoleIdDto>('None');
    const userRoles = ['None', 'ApplicationAdmin', 'Employee', 'Student'];
    const isUserRole = (x: any): x is UserRoleIdDto => userRoles.includes(x);

    const [tryregister, { isLoading, isSuccess }] = usePostApiV1IdentityRegisterAdminMutation()

    const handleRegister = async () => {
        if (!userName || !password || userRole == 'None' || !firstName)
            return

        const result = await tryregister({
            registerAdminRequestDto:
            {
                password: password,
                userName: userName,
                userRole: userRole,
                firstName: firstName
            }
        })

        if (isSuccess) {
        }
    };

    return (
        <>
            <Container maxWidth="xs" sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
            }}>

                <Avatar sx={{ bgcolor: "primary.light" }}>
                    <LockOutlined />
                </Avatar>

                <Typography sx={{ pt: 2 }} variant="h5">Форма регистрации (возможно необходимо вынести этот блок под контроль пользователя с правами)</Typography>

                <FormControl sx={{ p: 3 }} fullWidth>
                    <Stack spacing={2}>

                        <TextField
                            disabled={isLoading}
                            margin="normal"
                            name="login"
                            required
                            fullWidth
                            id="login"
                            label="Логин"
                            autoFocus
                            value={userName}
                            onChange={(e) => setUserName(e.target.value)}
                        />

                        <TextField
                            disabled={isLoading}
                            margin="normal"
                            name="name"
                            required
                            fullWidth
                            id="name"
                            label="Имя"
                            autoFocus
                            value={firstName}
                            onChange={(e) => setFirstName(e.target.value)}
                        />

                        <FormControl fullWidth>
                            <InputLabel id="user-role-label">Роль</InputLabel>
                            <Select
                                labelId="user-role-label"
                                id="user-role-select"
                                value={userRole}
                                label="Роль"
                                onChange={(e) =>
                                    setUserRole(isUserRole(e.target.value) ? e.target.value : "None")
                                }
                            >
                                <MenuItem value={'None'}>Не выбрана</MenuItem>
                                <MenuItem value={'Student'}>Студент</MenuItem>
                                <MenuItem value={'ApplicationAdmin'}>Администратор</MenuItem>
                                <MenuItem value={'Employee'}>Сотрудник университета</MenuItem>
                            </Select>
                        </FormControl>

                        <TextField
                            disabled={isLoading}
                            margin="normal"
                            required
                            fullWidth
                            id="password"
                            name="password"
                            type="password"
                            label="Пароль"
                            autoFocus
                            value={password}
                            onChange={(e) => {
                                setPassword(e.target.value);
                            }}
                        />

                        <Button
                            disabled={isLoading}
                            fullWidth
                            variant="contained"
                            onClick={handleRegister}
                        >
                            {
                                isLoading
                                    ? <CircularProgress size={25} color="inherit" />
                                    : <span>Зарегистрироваться</span>
                            }
                        </Button>

                    </Stack>

                    <Box sx={{ p: 3, textAlign: "center" }}>
                        <Link to="/signin">Уже есть аккаунт? Авторизоваться</Link>
                    </Box>

                </FormControl>
            </Container >
        </>
    );
};

export default RegisterPage;