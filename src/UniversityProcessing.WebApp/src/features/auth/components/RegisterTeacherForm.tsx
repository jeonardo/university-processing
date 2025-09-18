import React from 'react';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import {
  ApiRegistrationGetAvailableDepartmentsDepartmentDto,
  ApiRegistrationGetAvailableFacultiesFacultyDto,
  ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto,
  usePostApiRegistrationRegisterTeacherMutation,
  usePutApiUsersUpdateVerificationMutation
} from 'src/api/backendApi';
import {
  CommonFormData,
  DepartmentSelector,
  FacultySelector,
  FormContainer,
  PositionSelector,
  useFormState,
  useFormValidation,
  ValidationRules
} from './index';
import { IRegisterFormProps } from './RegisterFormProps';
import { useRegistrationSubmit } from '../hooks/useRegistrationSubmit';

interface TeacherFormData extends CommonFormData {
  universityPosition: ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto | null;
  faculty: ApiRegistrationGetAvailableFacultiesFacultyDto | null;
  department: ApiRegistrationGetAvailableDepartmentsDepartmentDto | null;
}

const RegisterTeacherForm: React.FC<IRegisterFormProps> = ({
                                                             buttonLabel,
                                                             verify,
                                                             redirectToLogin,
                                                             onSuccess
                                                           }) => {
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
  const [tryRegister, { isLoading, isSuccess }] = usePostApiRegistrationRegisterTeacherMutation();
  const { validateForm } = useFormValidation();
  const [tryVerify, {}] = usePutApiUsersUpdateVerificationMutation();

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
    onSuccess
  });

  const handleFacultyChange = (faculty: ApiRegistrationGetAvailableFacultiesFacultyDto | null) => {
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
      submitButtonLabel={buttonLabel ?? 'Зарегистрироваться'}
      additionalFields={additionalFields}
    />
  );
};

export default RegisterTeacherForm;