import { LockOutlined } from "@mui/icons-material";
import {
    Avatar,
    Box,
    Button,
    CircularProgress,
    Container,
    CssBaseline,
    FormControl,
    Grid,
    Stack,
    TextField,
    Typography,
} from "@mui/material";
import { useState } from "react";
import { Link } from "react-router-dom";
import { useAppDispatch } from "../../core/hooks";
import { GetApiV1FacultyGetByIdApiArg, backendApi, useGetApiV1DepartmentListQuery } from "../../apis/backendApi";
import { login } from "./auth.slice";

const LoginPage = () => {

    const req: GetApiV1FacultyGetByIdApiArg = { id: "fasfsa" }
    const { isLoading, data } = backendApi.useGetApiV1FacultyGetByIdQuery(req);


    const dispatch = useAppDispatch();

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);

    const handleLogin = async () => {
        setLoading(true)
        setTimeout(() => {
            setLoading(false)
        }, 1500)
        if (userName && password) {
            try {
                // await dispatch(
                //     login({
                //         userName,
                //         password,
                //     })
                // ).unwrap();
            } catch (e) {
                console.error(e);
            }
        } else {
            // Show an error message.
        }
    };

    const handleFakeLogin = async () => {
        dispatch(login({}))
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

                <Typography sx={{ pt: 2 }} variant="h5">Форма авторизации</Typography>

                <FormControl sx={{ p: 3 }} fullWidth >
                    <Stack spacing={2}>

                        <TextField
                            disabled={loading}
                            margin="normal"
                            required
                            fullWidth
                            id="name"
                            label="Логин"
                            name="name"
                            autoFocus
                            value={userName}
                            onChange={(e) => setUserName(e.target.value)}
                        />

                        <TextField
                            disabled={loading}
                            margin="normal"
                            required
                            fullWidth
                            id="password"
                            name="password"
                            label="Пароль"
                            type="password"
                            value={password}
                            onChange={(e) => {
                                setPassword(e.target.value);
                            }}
                        />

                        <Button
                            disabled={loading}
                            fullWidth
                            variant="contained"
                            onClick={handleLogin}
                        >
                            {
                                loading
                                    ? <CircularProgress size={25} color="inherit" />
                                    : <span>Авторизоваться</span>
                            }
                        </Button>

                        <Button
                            disabled={loading}
                            fullWidth
                            variant="contained"
                            onClick={handleFakeLogin}
                        >
                            {
                                loading
                                    ? <CircularProgress size={25} color="inherit" />
                                    : <span>Fake login</span>
                            }
                        </Button>

                    </Stack>

                    <Box sx={{ p: 3, textAlign: "center" }}>
                        <Link to="/signup">Нет аккаунта? Зарегистрироваться</Link>
                    </Box>

                </FormControl>
            </Container>
        </>
    )
}

export default LoginPage;