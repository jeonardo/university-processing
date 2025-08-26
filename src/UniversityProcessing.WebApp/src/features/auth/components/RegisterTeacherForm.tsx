import React, { useMemo, useState } from 'react';
import { Autocomplete, FormControl, Stack, TextField } from '@mui/material';
import dayjs, { Dayjs } from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { enqueueSnackbarError } from 'src/core/helpers';
import {
  AuthRegistrationGetAvailableDepartmentsDepartment,
  AuthRegistrationGetAvailableFacultiesFaculty,
  useGetApiAuthRegistrationGetAvailableFacultiesQuery,
  useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery,
  useLazyGetApiAuthRegistrationGetAvailableDepartmentsQuery,
  usePostApiAuthRegistrationRegisterTeacherMutation
} from 'src/api/backendApi';
import CommonFormFields, { CommonFormData } from './CommonFormFields';
import SubmitButton from 'src/components/forms/SubmitButton';

interface TeacherFormData extends CommonFormData {
  universityPosition: string;
  faculty: AuthRegistrationGetAvailableFacultiesFaculty | null;
  department: AuthRegistrationGetAvailableDepartmentsDepartment | null;
}

const RegisterTeacherForm: React.FC = () => {
  const [formData, setFormData] = useState<TeacherFormData>({
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
    department: null
  });

  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterTeacherMutation();
  const { data: positionsData } = useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery();
  const { data: facultiesData } = useGetApiAuthRegistrationGetAvailableFacultiesQuery();
  const [fetchDepartments, { data: departmentsData }] = useLazyGetApiAuthRegistrationGetAvailableDepartmentsQuery();

  const universityPositions = useMemo(() =>
    positionsData?.list?.map((item) => item.name) || [], [positionsData]);

  const faculties = useMemo(() =>
    facultiesData?.faculties || [], [facultiesData]);

  const departments = useMemo(() =>
    departmentsData?.departments || [], [departmentsData]);

  const handleFormDataChange = (field: keyof TeacherFormData, value: string | Dayjs) => {
    setFormData(prev => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    const { userName, password, firstName, faculty, department, universityPosition, ...rest } = formData;

    if (!userName || !password || !firstName || !faculty || !department) {
      enqueueSnackbarError('Заполните обязательные поля');
      return;
    }

    const response = await tryRegister({
      authRegistrationRegisterTeacherRequest: {
        password,
        userName,
        firstName,
        ...rest,
        birthday: formData.birthday.toISOString(),
        universityPositionId: positionsData?.list?.find(
          pos => pos.name === universityPosition
        )?.id || '',
        departmentId: department.id ?? ''
      }
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
              if (newValue?.id) {
                fetchDepartments({ facultyId: newValue.id });
              }
            }
          }
          renderInput={(params) => (
            <TextField {...params} label="Факультет" required />
          )}
        />

        <Autocomplete
          options={departments}
          getOptionLabel={(option) => option.name || ''}
          value={formData.department}
          onChange={
            (_: React.SyntheticEvent, newValue: AuthRegistrationGetAvailableDepartmentsDepartment | null) => {
              setFormData(prev => ({ ...prev, department: newValue }));
            }
          }
          disabled={!formData.faculty}
          renderInput={(params) => (
            <TextField {...params} label="Кафедра" required />
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

export default RegisterTeacherForm;