import React, { useCallback, useState } from 'react';
import { Autocomplete, Button, CircularProgress, debounce, FormControl, Stack, TextField } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useLazyGetApiAuthRegistrationStudentGetAvailableGroupsQuery, usePostApiAuthRegistrationStudentRegisterMutation } from 'src/api/backendApi';

const RegisterStudentForm = () => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [middleName, setMiddleName] = useState('');
  const [lastName, setLastName] = useState('');
  const [birthday, setBirthday] = useState(dayjs());
  const [email, setEmail] = useState('');
  const [inputGroupValue, setInputGroupValue] = useState<string>('');
  const [group, setGroup] = useState<string>('');

  const [tryregister, { isLoading, isSuccess }] = usePostApiAuthRegistrationStudentRegisterMutation();
  const [getAvailableGroups, availableGroups] = useLazyGetApiAuthRegistrationStudentGetAvailableGroupsQuery();

  const debouncedSave = useCallback(debounce((newValue) => getAvailableGroups({ number: newValue }), 1000), []);

  const handleGroupOnInputChange = (event: React.ChangeEvent<{}>, newValue: string) => {
    setInputGroupValue(newValue);
    if (newValue)
      debouncedSave(newValue);
  };

  const handleRegister = async () => {
    if (!userName || !password || !firstName)
      return;

    const response = await tryregister({
      authRegistrationStudentRegisterRequest:
        {
          password: password,
          userName: userName,
          firstName: firstName,
          lastName: lastName,
          middleName: middleName,
          birthday: birthday.toISOString(),
          email: email,
          groupNumber: group

        }
    });

    if (response.error) {
      enqueueSnackbarError(response.error);
    }
  };

  if (isSuccess) {
    return (
      <RegisterResultModal />
    );
  }

  return (
    <FormControl fullWidth sx={{ pt: 2 }}>
      <Stack spacing={2}>

        <Autocomplete
          options={availableGroups?.data?.groupNumbers?.map(group => group) ?? []}
          getOptionLabel={(option: string) => option}
          value={group}
          onChange={(e, value) => setGroup(value ?? '')}
          inputValue={inputGroupValue}
          onInputChange={handleGroupOnInputChange}
          renderInput={(params) => (
            <TextField
              {...params}
              label="Номер группы"
              variant="outlined"
            />
          )}
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

        <TextField
          disabled={isLoading}
          margin="normal"
          name="lastName"
          required
          fullWidth
          id="lastName"
          label="Фамилия"
          autoFocus
          value={lastName}
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

        <TextField
          disabled={isLoading}
          margin="normal"
          name="email"
          fullWidth
          id="email"
          label="Почта"
          autoFocus
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />

        <DatePicker
          disabled={isLoading}
          name="birthday"
          label="Дата рождения"
          autoFocus
          value={birthday}
          onChange={(e) => e == null
            ? setBirthday(dayjs())
            : setBirthday(e)}
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
    </FormControl>
  );
};

export default RegisterStudentForm;