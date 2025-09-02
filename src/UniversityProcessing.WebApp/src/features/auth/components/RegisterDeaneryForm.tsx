import React from 'react';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { usePostApiAuthRegistrationRegisterDeaneryMutation, usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import {
  FormContainer,
  PositionSelector,
  FacultySelector,
  useFormState,
  useFormValidation,
  ValidationRules,
  CommonFormData
} from './index';
import { AuthRegistrationGetAvailableUniversityPositionsUniversityPosition, AuthRegistrationGetAvailableFacultiesFaculty } from 'src/api/backendApi';
import { IRegisterFormProps } from './RegisterFormProps';
import { useRegistrationSubmit } from '../hooks/useRegistrationSubmit';

interface DeaneryFormData extends CommonFormData {
  universityPosition: AuthRegistrationGetAvailableUniversityPositionsUniversityPosition | null;
  faculty: AuthRegistrationGetAvailableFacultiesFaculty | null;
}

const RegisterDeaneryForm: React.FC<IRegisterFormProps> = ({
  buttonLabel,
  verify,
  redirectToLogin,
  onSuccess }) => {
  const initialFormData: DeaneryFormData = {
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: '',
    universityPosition: null,
    faculty: null
  };

  const { formData, handleFormDataChange, updateFormData } = useFormState(initialFormData);
  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterDeaneryMutation();
  const { validateForm } = useFormValidation();
  const [tryVerify, { }] = usePutApiUsersUpdateVerificationMutation();

  const validationRules: ValidationRules<DeaneryFormData> = {
    requiredFields: ['userName', 'password', 'firstName', 'faculty']
  };

  const transformRequest = (formData: DeaneryFormData) => ({
    password: formData.password,
    userName: formData.userName,
    firstName: formData.firstName,
    middleName: formData.middleName,
    lastName: formData.lastName,
    birthday: formData.birthday.toISOString(),
    email: formData.email,
    phoneNumber: formData.phoneNumber,
    universityPositionId: formData.universityPosition?.id || '',
    facultyId: formData.faculty?.id ?? ''
  });

  const { handleSubmit } = useRegistrationSubmit<DeaneryFormData>({
    formData,
    validateForm,
    validationRules,
    tryRegister,
    requestKey: 'authRegistrationRegisterDeaneryRequest',
    transformRequest,
    redirectToLogin,
    verify,
    tryVerify,
    updateFormData,
    initialFormData,
    onSuccess,
  });

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
        onChange={(value) => handleFormDataChange('faculty', value)}
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

export default RegisterDeaneryForm;