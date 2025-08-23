import React, { useState, useCallback, useMemo } from 'react';
import {
  Autocomplete,
  FormControl,
  Stack,
  TextField,
} from '@mui/material';
import dayjs, { Dayjs } from 'dayjs';
import { debounce } from '@mui/material/utils';
import RegisterResultModal from './RegisterResultModal';
import { enqueueSnackbarError } from 'src/core/helpers';
import {
  useLazyGetApiAuthRegistrationGetAvailableGroupsQuery,
  usePostApiAuthRegistrationRegisterStudentMutation,
} from 'src/api/backendApi';
import CommonFormFields, { CommonFormData } from './CommonFormFields';
import DatePickerField from 'src/components/forms/DatePickerField';
import SubmitButton from 'src/components/forms/SubmitButton';

interface StudentFormData extends CommonFormData {
  groupNumber: string;
}

const RegisterStudentForm: React.FC = () => {
  const [formData, setFormData] = useState<StudentFormData>({
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: '',
    groupNumber: '',
  });

  const [inputGroupValue, setInputGroupValue] = useState('');
  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterStudentMutation();
  const [fetchGroups, { data: groupsData }] = useLazyGetApiAuthRegistrationGetAvailableGroupsQuery();

  const groups = useMemo(() => groupsData?.groupNumbers || [], [groupsData]);

  const debouncedFetchGroups = useCallback(
    debounce((searchValue: string) => {
      if (searchValue) {
        fetchGroups({ number: searchValue });
      }
    }, 500),
    [fetchGroups]
  );

  const handleFormDataChange = (field: keyof StudentFormData, value: string | Dayjs) => {
    setFormData(prev => ({ ...prev, [field]: value }));
  };

  const handleGroupInputChange = useCallback(
    (event: React.SyntheticEvent, value: string) => {
      setInputGroupValue(value);
      debouncedFetchGroups(value);
    },
    [debouncedFetchGroups]
  );

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    const { userName, password, firstName, groupNumber, ...rest } = formData;

    if (!userName || !password || !firstName || !groupNumber) {
      enqueueSnackbarError('Заполните обязательные поля');
      return;
    }

    const response = await tryRegister({
      authRegistrationRegisterStudentRequest: {
        ...formData,
        birthday: formData.birthday.toISOString(),
      },
    });

    if (response.error) {
      enqueueSnackbarError(response.error);
    }
  };

  if (isSuccess) {
    return <RegisterResultModal />;
  }

  return (
    <FormControl component="form" fullWidth sx={{ pt: 2 }} onSubmit={handleSubmit}>
      <Stack spacing={2}>
        <CommonFormFields
          formData={formData}
          onFormDataChange={handleFormDataChange}
          isLoading={isLoading}
        />

        <Autocomplete
          freeSolo
          options={groups}
          inputValue={inputGroupValue}
          onInputChange={handleGroupInputChange}
          value={formData.groupNumber}
          onChange={(_, value) => handleFormDataChange('groupNumber', value || '')}
          renderInput={(params) => (
            <TextField {...params} label="Номер группы" required />
          )}
        />

        <SubmitButton
          isLoading={isLoading}
          label="Зарегистрироваться"
        />
      </Stack>
    </FormControl>
  );
};

export default RegisterStudentForm;