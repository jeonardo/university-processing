import React, { useState } from 'react';
import {
  Box,
  Button,
  CircularProgress,
  Container,
  IconButton,
  InputAdornment,
  Paper,
  TextField,
  Typography
} from '@mui/material';

import { Visibility, VisibilityOff } from '@mui/icons-material';
import { usePostApiAuthChangePasswordMutation } from 'src/api/backendApi';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';

interface FormState {
  currentPassword: string;
  newPassword: string;
  confirmPassword: string;
  showPassword: boolean;
  showNewPassword: boolean;
  showConfirmPassword: boolean;
}

const PasswordChangePage: React.FC = () => {
  const [formState, setFormState] = useState<FormState>({
    currentPassword: '',
    newPassword: '',
    confirmPassword: '',
    showPassword: false,
    showNewPassword: false,
    showConfirmPassword: false
  });

  const [changePassword, { isLoading, data }] = usePostApiAuthChangePasswordMutation();

  const handleChange = (prop: keyof FormState) => (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setFormState({ ...formState, [prop]: event.target.value });
  };

  const handleClickShowPassword = (field: keyof FormState) => () => {
    setFormState({ ...formState, [field]: !formState[field] });
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    if (formState.newPassword !== formState.confirmPassword) {
      enqueueSnackbarError('Новые пароли не совпадают');
      return;
    }

    if (formState.newPassword.length < 4) {
      enqueueSnackbarError('Пароль должен содержать минимум 4 символов');
      return;
    }

    try {
      const { data, error } = await changePassword({
        apiAuthChangePasswordRequestDto: {
          password: formState.currentPassword,
          newPassword: formState.newPassword
        }
      });

      if (error) {
        enqueueSnackbarError(error);
      } else {
        enqueueSnackbar('Пароль успешно изменен', { variant: 'success' });
        setFormState({
          currentPassword: '',
          newPassword: '',
          confirmPassword: '',
          showPassword: false,
          showNewPassword: false,
          showConfirmPassword: false
        });
      }
    } catch (error: any) {
      enqueueSnackbarError(error.data.message);
    }
  };

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <Box className="flex justify-center h-full">
        <Paper elevation={3} sx={{ padding: 4 }}>
          <Typography variant="h5" component="h1" gutterBottom align="center">
            Смена пароля
          </Typography>
          <Box component="form" onSubmit={handleSubmit}>
            <>
              <TextField
                fullWidth
                label="Текущий пароль"
                type={formState.showPassword ? 'text' : 'password'}
                value={formState.currentPassword}
                onChange={handleChange('currentPassword')}
                margin="normal"
                required
                InputProps={{
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        onClick={handleClickShowPassword('showPassword')}
                        edge="end"
                      >
                        {formState.showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  )
                }}
              />

              <TextField
                fullWidth
                label="Новый пароль"
                type={formState.showNewPassword ? 'text' : 'password'}
                value={formState.newPassword}
                onChange={handleChange('newPassword')}
                margin="normal"
                required
                InputProps={{
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        onClick={handleClickShowPassword('showNewPassword')}
                        edge="end"
                      >
                        {formState.showNewPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  )
                }}
              />

              <TextField
                fullWidth
                label="Подтвердите новый пароль"
                type={formState.showConfirmPassword ? 'text' : 'password'}
                value={formState.confirmPassword}
                onChange={handleChange('confirmPassword')}
                margin="normal"
                required
                InputProps={{
                  endAdornment: (
                    <InputAdornment position="end">
                      <IconButton
                        onClick={handleClickShowPassword('showConfirmPassword')}
                        edge="end"
                      >
                        {formState.showConfirmPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  )
                }}
              />

              <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3 }}
                disabled={isLoading}
              >
                {
                  isLoading
                    ? <CircularProgress size={24} />
                    : <span>Сменить пароль</span>
                }

              </Button>
            </>
          </Box>
        </Paper>
      </Box>
    </Container>
  );
};

export default PasswordChangePage;