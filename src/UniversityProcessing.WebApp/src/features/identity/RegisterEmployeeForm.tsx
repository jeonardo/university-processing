import React, { useCallback, useState } from 'react';
import { Autocomplete, Button, CircularProgress, debounce, FormControl, Stack, TextField } from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { useGetApiRegistrationEmployeeGetAvailableUniversitiesQuery, useGetApiRegistrationEmployeeGetAvailableUniversityPositionsQuery, useLazyGetApiRegistrationEmployeeGetAvailableUniversitiesQuery, usePostApiRegistrationEmployeeRegisterMutation } from 'src/api/backendApi';
import { enqueueSnackbarError } from 'src/core/helpers';

const RegisterEmployeeForm = () => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [middleName, setMiddleName] = useState('');
  const [lastName, setLastName] = useState('');
  const [birthday, setBirthday] = useState(dayjs());
  const [email, setEmail] = useState('');

  const [inputUniversityValue, setInputUniversityValue] = useState<string>('');
  const [university, setUniversity] = useState<string>('');

  const [inputUniversityPositionValue, setInputUniversityPositionValue] = useState<string>('');
  const [universityPosition, setUniversityPosition] = useState<string>('');

  const [tryregister, { isLoading, isSuccess }] = usePostApiRegistrationEmployeeRegisterMutation();
  const [getAvailableUniversities, availableUniversities] = useLazyGetApiRegistrationEmployeeGetAvailableUniversitiesQuery();
  const getAvailableUniversityPositionsResponse = useGetApiRegistrationEmployeeGetAvailableUniversityPositionsQuery();

  const debouncedSave = useCallback(debounce((newValue) => getAvailableUniversities({ name: newValue }), 1000), []);

  const handleUniversityOnInputChange = (event: React.ChangeEvent<{}>, newValue: string) => {
    setInputUniversityValue(newValue);
    debouncedSave(newValue);
  };


  //TODO check when is filled and button available
  const handleRegister = async () => {
    if (!userName || !password || !firstName)
      return;

    const response = await tryregister({
      registrationEmployeeRegisterRequest:
      {
        password: password,
        userName: userName,
        firstName: firstName,
        lastName: lastName,
        middleName: middleName,
        birthday: birthday.toISOString(),
        email: email,
        universityId: availableUniversities?.data?.list?.filter(x => x.name === university)[0].id ?? '',
        universityPositionId: getAvailableUniversityPositionsResponse?.data?.list?.filter(x => x.name === universityPosition)[0].id ?? ''
      }
    });

    if (response.error) {
      enqueueSnackbarError(response.error)
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
          options={availableUniversities?.data?.list?.map(x => x.name ?? '') ?? []}
          getOptionLabel={(option: string) => option}
          value={university}
          onChange={(e, value) => setUniversity(value ?? '')}
          inputValue={inputUniversityValue}
          onInputChange={handleUniversityOnInputChange}
          renderInput={(params) => (
            <TextField
              {...params}
              label="Университет"
              variant="outlined"
            />
          )}
        />

        <Autocomplete
          options={getAvailableUniversityPositionsResponse?.data?.list?.map(x => x.name ?? '') ?? []}
          getOptionLabel={(option: string) => option}
          value={universityPosition}
          onChange={(e, value) => setUniversityPosition(value ?? '')}
          inputValue={inputUniversityPositionValue}
          onInputChange={(e, value) => setInputUniversityPositionValue(value)}
          renderInput={(params) => (
            <TextField
              {...params}
              label="Должность"
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

export default RegisterEmployeeForm;