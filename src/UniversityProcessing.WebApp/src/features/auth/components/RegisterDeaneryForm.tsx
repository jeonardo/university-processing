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
  usePostApiAuthRegistrationRegisterDeaneryMutation,
  usePostApiAuthRegistrationRegisterTeacherMutation,
} from 'src/api/backendApi';
import CommonFormFields, { CommonFormData } from './CommonFormFields';
import DatePickerField from 'src/components/forms/DatePickerField';
import SubmitButton from 'src/components/forms/SubmitButton';

interface DeaneryFormData extends CommonFormData {
  universityPosition: string;
  faculty: AuthRegistrationGetAvailableFacultiesFaculty | null;
}

const RegisterDeaneryForm: React.FC = () => {
  const [formData, setFormData] = useState<DeaneryFormData>({
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: '',
    universityPosition: '',
    faculty: null,
  });

  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterDeaneryMutation();
  const { data: positionsData } = useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery();
  const { data: facultiesData } = useGetApiAuthRegistrationGetAvailableFacultiesQuery();

  const universityPositions = useMemo(() =>
    positionsData?.list?.map((item) => item.name) || [], [positionsData]);

  const faculties = useMemo(() =>
    facultiesData?.faculties || [], [facultiesData]);

  const handleFormDataChange = (field: keyof DeaneryFormData, value: string | Dayjs) => {
    setFormData(prev => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    const { userName, password, firstName, faculty, universityPosition, ...rest } = formData;

    if (!userName || !password || !firstName || !faculty) {
      enqueueSnackbarError('Заполните обязательные поля');
      return;
    }

    const response = await tryRegister({
      authRegistrationRegisterDeaneryRequest: {
        password,
        userName,
        firstName,
        ...rest,
        birthday: formData.birthday.toISOString(),
        universityPositionId: positionsData?.list?.find(
          pos => pos.name === universityPosition
        )?.id || '',
        facultyId: faculty.id ?? '',
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
          options={universityPositions}
          value={formData.universityPosition}
          onChange={(_, value) => handleFormDataChange('universityPosition', value || '')}
          renderInput={(params) => (
            <TextField {...params} label="Должность" required />
          )}
        />

        <Autocomplete
          options={faculties}
          getOptionLabel={(option) => option.name || ''}
          value={formData.faculty}
          onChange={
            (_: React.SyntheticEvent, newValue: AuthRegistrationGetAvailableFacultiesFaculty | null) => {
              setFormData(prev => ({ ...prev, faculty: newValue, department: null }));
            }
          }
          renderInput={(params) => (
            <TextField {...params} label="Факультет" required />
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

export default RegisterDeaneryForm;