import {Button, CircularProgress, FormControl, Stack, TextField,} from "@mui/material";
import {useState} from "react";
import {useAppDispatch} from "../../core/hooks";
import {usePostApiV1IdentityRegisterAdminMutation} from "src/api/backendApi";
import {DatePicker} from "@mui/x-date-pickers";

const RegisterAdminForm = () => {
    const dispatch = useAppDispatch();

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [middleName, setMiddleName] = useState("");
    const [lastName, setLastName] = useState("");
    const [birthday, setBirthday] = useState(new Date());
    const [email, setEmail] = useState("");

    const [tryregister, {isLoading, isSuccess}] = usePostApiV1IdentityRegisterAdminMutation()

    const handleRegister = async () => {
        if (!userName || !password || !firstName)
            return

        const result = await tryregister({
            registerAdminRequestDto:
                {
                    password: password,
                    userName: userName,
                    firstName: firstName,
                    lastName: lastName,
                    middleName: middleName,
                    birthday: birthday.toISOString(),
                    email: email
                }
        })

        if (isSuccess) {
        }
    };

    return (
        <FormControl fullWidth sx={{pt: 2}}>
            <Stack spacing={2}>

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

                <TextField
                    disabled={isLoading}
                    margin="normal"
                    name="lastName"
                    required
                    fullWidth
                    id="lastName"
                    label="Фамилия"
                    autoFocus
                    value={firstName}
                    onChange={(e) => setLastName(e.target.value)}
                />

                <TextField
                    disabled={isLoading}
                    margin="normal"
                    name="middleName"
                    fullWidth
                    id="middleName"
                    label="Отчество"
                    autoFocus
                    value={middleName}
                    onChange={(e) => setMiddleName(e.target.value)}
                />

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

                <DatePicker
                    defaultValue={null}
                    disabled={isLoading}
                    // margin="normal"
                    name="birthday"
                    // fullWidth
                    // id="birthday"
                    label="Дата рождения"
                    autoFocus
                    // value={birthday}
                    // onChange={(e) => setBirthday(e.target.value)}
                />

                <Button
                    disabled={isLoading}
                    fullWidth
                    variant="contained"
                    onClick={handleRegister}
                >
                    {
                        isLoading
                            ? <CircularProgress size={25} color="inherit"/>
                            : <span>Зарегистрироваться</span>
                    }
                </Button>

            </Stack>
        </FormControl>
    );
}

export default RegisterAdminForm