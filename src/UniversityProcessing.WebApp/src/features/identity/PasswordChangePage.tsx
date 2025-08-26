import React, { useState } from 'react';
import { Alert, Box, Button, IconButton, InputAdornment, Paper, TextField, Typography } from '@mui/material';
import { Visibility, VisibilityOff } from '@mui/icons-material';
import { usePostApiAuthChangePasswordMutation } from 'src/api/backendApi';

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

  const [error, setError] = useState<string>('');
  const [success, setSuccess] = useState<boolean>(false);
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
    setError('');

    if (formState.newPassword !== formState.confirmPassword) {
      setError('Новые пароли не совпадают');
      return;
    }

    if (formState.newPassword.length < 4) {
      setError('Пароль должен содержать минимум 4 символов');
      return;
    }

    try {
      const { data, error } = await changePassword({
        authChangePasswordRequest: {
          password: formState.currentPassword,
          newPassword: formState.newPassword
        }
      });

      if (error && typeof error === 'string') {
        setError(error);
      } else {
        setSuccess(true);
      }
    } catch (error: any) {
      setError(error.data.message);
    }
  };

  return (
    <Box className="flex justify-center items-center h-full"
    >
      <Paper elevation={3} sx={{ padding: 4, width: 400 }}>
        <Typography variant="h5" component="h1" gutterBottom align="center">
          Смена пароля
        </Typography>

        <Box component="form" onSubmit={handleSubmit}>
          {error && (
            <Alert severity="error" sx={{ mb: 2 }}>
              {error}
            </Alert>
          )}

          {success ? (
            <Alert severity="success">
              Пароль успешно изменен!
            </Alert>
          ) : (
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
              >
                Сменить пароль
              </Button>
            </>
          )}
        </Box>
      </Paper>
    </Box>
  );
};

export default PasswordChangePage;