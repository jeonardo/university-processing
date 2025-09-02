import React from 'react';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { usePostApiAuthRegistrationRegisterTeacherMutation, usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import {
  FormContainer,
  PositionSelector,
  FacultySelector,
  DepartmentSelector,
  useFormState,
  useFormValidation,
  ValidationRules,
  CommonFormData
} from './index';
import { AuthRegistrationGetAvailableUniversityPositionsUniversityPosition, AuthRegistrationGetAvailableFacultiesFaculty, AuthRegistrationGetAvailableDepartmentsDepartment } from 'src/api/backendApi';
import { IRegisterFormProps } from './RegisterFormProps';
import { useRegistrationSubmit } from '../hooks/useRegistrationSubmit';

interface TeacherFormData extends CommonFormData {
  universityPosition: AuthRegistrationGetAvailableUniversityPositionsUniversityPosition | null;
  faculty: AuthRegistrationGetAvailableFacultiesFaculty | null;
  department: AuthRegistrationGetAvailableDepartmentsDepartment | null;
}

const RegisterTeacherForm: React.FC<IRegisterFormProps> = ({
  buttonLabel,
  verify,
  redirectToLogin,
  onSuccess }) => {
  const initialFormData: TeacherFormData = {
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: '',
    universityPosition: null,
    faculty: null,
    department: null
  };

  const { formData, handleFormDataChange, updateFormData } = useFormState(initialFormData);
  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterTeacherMutation();
  const { validateForm } = useFormValidation();
  const [tryVerify, { }] = usePutApiUsersUpdateVerificationMutation();

  const validationRules: ValidationRules<TeacherFormData> = {
    requiredFields: ['userName', 'password', 'firstName', 'faculty', 'department']
  };

  const transformRequest = (formData: TeacherFormData) => ({
    password: formData.password,
    userName: formData.userName,
    firstName: formData.firstName,
    middleName: formData.middleName,
    lastName: formData.lastName,
    birthday: formData.birthday.toISOString(),
    email: formData.email,
    phoneNumber: formData.phoneNumber,
    universityPositionId: formData.universityPosition?.id || '',
    departmentId: formData.department?.id ?? ''
  });

  const { handleSubmit } = useRegistrationSubmit<TeacherFormData>({
    formData,
    validateForm,
    validationRules,
    tryRegister,
    requestKey: 'authRegistrationRegisterTeacherRequest',
    transformRequest,
    redirectToLogin,
    verify,
    tryVerify,
    updateFormData,
    initialFormData,
    onSuccess,
  });

  const handleFacultyChange = (faculty: AuthRegistrationGetAvailableFacultiesFaculty | null) => {
    updateFormData({ faculty, department: null });
  };

  if (isSuccess && redirectToLogin) {
    return <RegisterResultModal />;
  }

  const additionalFields = (
    <>
      <PositionSelector
        value={formData.universityPosition}
        onChange={(value) => handleFormDataChange('universityPosition', value)}
        required
      />

      <FacultySelector
        value={formData.faculty}
        onChange={handleFacultyChange}
        required
      />

      <DepartmentSelector
        value={formData.department}
        onChange={(value) => handleFormDataChange('department', value)}
        facultyId={formData.faculty?.id}
        required
      />
    </>
  );

  return (
    <FormContainer
      formData={formData}
      onFormDataChange={handleFormDataChange}
      onSubmit={handleSubmit}
      isLoading={isLoading}
      submitButtonLabel={buttonLabel ?? "Зарегистрироваться"}
      additionalFields={additionalFields}
    />
  );
};

export default RegisterTeacherForm;