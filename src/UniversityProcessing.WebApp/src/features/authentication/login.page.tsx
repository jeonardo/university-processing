import {LockOutlined} from "@mui/icons-material";
import {
    Avatar,
    Box,
    Button,
    CircularProgress,
    Container,
    FormControl,
    Stack,
    TextField,
    Typography,
} from "@mui/material";
import {useState} from "react";
import {Link} from "react-router-dom";
import {useAppDispatch} from "../../core/hooks";
import {usePostApiV1IdentityLoginMutation} from "../../api/backendApi";
import {login} from "./auth.slice";

const LoginPage = () => {
    const dispatch = useAppDispatch();

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");

    const [trylogin, {isLoading}] = usePostApiV1IdentityLoginMutation()

    const handleLogin = async () => {
        const result = await trylogin({loginRequestDto: {password: password, userName: userName}})

        if (result.error)
            return

        dispatch(login({
            accessToken: result.data.accessToken,
            refreshToken: result.data.refreshToken,
        }))
    };

    return (
        <>
            <Container maxWidth="xs" sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
            }}>

                <Avatar sx={{bgcolor: "primary.light"}}>
                    <LockOutlined/>
                </Avatar>

                <Typography sx={{pt: 2}} variant="h5">Форма авторизации</Typography>

                <FormControl sx={{p: 3}} fullWidth>
                    <Stack spacing={2}>

                        <TextField
                            disabled={isLoading}
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
                            disabled={isLoading}
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
                            disabled={isLoading || userName.length === 0 || password.length === 0}
                            fullWidth
                            variant="contained"
                            onClick={handleLogin}
                        >
                            {
                                isLoading
                                    ? <CircularProgress size={25} color="inherit"/>
                                    : <span>Авторизоваться</span>
                            }
                        </Button>
                    </Stack>

                    <Box sx={{p: 3, textAlign: "center"}}>
                        <Link to="/signup">Нет аккаунта? Зарегистрироваться</Link>
                    </Box>

                </FormControl>
            </Container>
        </>
    )
}

export default LoginPage;