import React, { useState, useMemo } from 'react';
import {
  Autocomplete,
  FormControl,
  Stack,
  TextField,
} from '@mui/material';
import dayjs, { Dayjs } from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { enqueueSnackbarError } from 'src/core/helpers';
import {
  AuthRegistrationGetAvailableDepartmentsDepartment,
  AuthRegistrationGetAvailableFacultiesFaculty,
  useGetApiAuthRegistrationGetAvailableFacultiesQuery,
  useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery,
  useLazyGetApiAuthRegistrationGetAvailableDepartmentsQuery,
  usePostApiAuthRegistrationRegisterAdminMutation,
  usePostApiAuthRegistrationRegisterTeacherMutation,
} from 'src/api/backendApi';
import CommonFormFields, { CommonFormData } from './CommonFormFields';
import DatePickerField from 'src/components/forms/DatePickerField';
import SubmitButton from 'src/components/forms/SubmitButton';

interface AdminFormData extends CommonFormData {
}

const RegisterAdminForm: React.FC = () => {
  const [formData, setFormData] = useState<AdminFormData>({
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: ''
  });

  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterAdminMutation();

  const handleFormDataChange = (field: keyof AdminFormData, value: string | Dayjs) => {
    setFormData(prev => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    const { userName, password, firstName, ...rest } = formData;

    if (!userName || !password || !firstName) {
      enqueueSnackbarError('Заполните обязательные поля');
      return;
    }

    const response = await tryRegister({
      authRegistrationRegisterAdminRequest: {
        password,
        userName,
        firstName,
        ...rest,
        birthday: formData.birthday.toISOString()
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

        <SubmitButton
          isLoading={isLoading}
          label="Зарегистрироваться"
        />
      </Stack>
    </FormControl>
  );
};

export default RegisterAdminForm;