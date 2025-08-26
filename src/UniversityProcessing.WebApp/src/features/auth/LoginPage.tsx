import { LockOutlined } from '@mui/icons-material';
import {
  Avatar,
  Box,
  Button,
  Checkbox,
  CircularProgress,
  Container,
  FormControl,
  FormControlLabel,
  Stack,
  TextField,
  Typography
} from '@mui/material';
import { useState } from 'react';
import { Link } from 'react-router-dom';
import { useAppDispatch } from '../../core/hooks';
import { login } from './auth.slice';
import { usePostApiAuthLoginMutation } from 'src/api/backendApi';
import { enqueueSnackbarError } from 'src/core/helpers';
import TestUsersCard from './components/TestUsersCard';
import { logDebug } from 'src/core/logger';

const LoginPage = () => {
  const dispatch = useAppDispatch();

  const [testVisible, setTestVisible] = useState(true);
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const [tryLogin, { isLoading }] = usePostApiAuthLoginMutation();

  const handleLogin = async (userName: string, password: string) => {
    const result = await tryLogin({ authLoginRequest: { password: password, userName: userName } });

    if (result.error) {
      enqueueSnackbarError(result.error);
      return;
    }
    logDebug('login success started')
    dispatch(login({
      accessToken: result.data.accessToken ?? '',
      refreshToken: result.data.refreshToken ?? ''
    }));
    logDebug('login success ended')
  };

  return (
    <Container maxWidth="xs" sx={{
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center'
    }}>

      <Avatar sx={{ bgcolor: 'primary.light' }}>
        <LockOutlined />
      </Avatar>

      <Typography sx={{ pt: 2 }} variant="h5">Форма авторизации</Typography>

      <FormControl sx={{ p: 3 }} fullWidth>
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
            value={username}
            onChange={(e) => setUsername(e.target.value)}
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
            disabled={isLoading || username.length === 0 || password.length === 0}
            fullWidth
            variant="contained"
            onClick={() => {
              handleLogin(username, password);
            }}
          >
            {
              isLoading
                ? <CircularProgress size={25} color="inherit" />
                : <span>Авторизоваться</span>
            }
          </Button>

        </Stack>

        <Box sx={{ p: 3, textAlign: 'center' }}>
          <Link to="/signup">Нет аккаунта? Зарегистрироваться</Link>
        </Box>

        <FormControlLabel
          control={
            <Checkbox
              checked={testVisible}
              onChange={() => setTestVisible(!testVisible)}
              color="primary"
            />
          }
          label="Показать тестовых пользователей"
          sx={{ mb: 1, ml: 1 }}
        />

        {
          testVisible
            ? (
              <TestUsersCard isLoading={false} handleTestLogin={(username, password) => {
                setUsername(username);
                setPassword(password);
                handleLogin(username, password);
              }} />
            )
            : (<></>)
        }

      </FormControl>
    </Container>
  );
};

export default LoginPage;