import { Avatar, Box, Button, CircularProgress, Container, CssBaseline, FormControl, Grid, Stack, TextField, Typography, } from "@mui/material";
import { LockOutlined } from "@mui/icons-material";
import { useState } from "react";
import { Link } from "react-router-dom";
import { useAppDispatch } from "../../core/hooks";
import { ENV } from "../../env";
import { unwrapResult } from "@reduxjs/toolkit";

const RegisterPage = () => {
    const dispatch = useAppDispatch();

    const [name, setName] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);

    const handleRegister = async () => {
        if (!name || !password)
            return

        // dispatch(register({userName: name, password: password}))
        //     .then(unwrapResult)
        //     .then((originalPromiseResult) => {
        //         // handle result here
        //     })
        //     .catch((rejectedValueOrSerializedError) => {
        //         if (ENV.VITE_IS_DEVELOPMENT)
        //             console.log(rejectedValueOrSerializedError);
        //     })
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

                <Typography sx={{ pt: 2 }} variant="h5">Форма регистрации</Typography>

                <FormControl sx={{ p: 3 }} fullWidth>
                    <Stack spacing={2}>

                        <TextField
                            disabled={loading}
                            margin="normal"
                            name="name"
                            required
                            fullWidth
                            id="name"
                            label="Логин"
                            autoFocus
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                        />

                        <TextField
                            disabled={loading}
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
                            disabled={loading}
                            fullWidth
                            variant="contained"
                            onClick={handleRegister}
                        >
                            {
                                loading
                                    ? <CircularProgress size={25} color="inherit" />
                                    : <span>Зарегистрироваться</span>
                            }
                        </Button>

                    </Stack>

                    <Box sx={{ p: 3, textAlign: "center" }}>
                        <Link to="/signin">Уже есть аккаунт? Авторизоваться</Link>
                    </Box>

                </FormControl>
            </Container>
        </>
    );
};

export default RegisterPage;