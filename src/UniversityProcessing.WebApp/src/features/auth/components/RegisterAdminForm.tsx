import React from 'react';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import {
  usePostApiRegistrationRegisterAdminMutation,
  usePutApiUsersUpdateVerificationMutation
} from 'src/api/backendApi';
import { CommonFormData, FormContainer, useFormState, useFormValidation, ValidationRules } from './index';
import { IRegisterFormProps } from './RegisterFormProps';
import { useRegistrationSubmit } from '../hooks/useRegistrationSubmit';

interface AdminFormData extends CommonFormData {
}

const RegisterAdminForm: React.FC<IRegisterFormProps> = ({
                                                           buttonLabel,
                                                           verify,
                                                           redirectToLogin,
                                                           onSuccess
                                                         }) => {
  const initialFormData: AdminFormData = {
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: ''
  };

  const { formData, handleFormDataChange, updateFormData } = useFormState(initialFormData);
  const [tryRegister, { isLoading, isSuccess }] = usePostApiRegistrationRegisterAdminMutation();
  const { validateForm } = useFormValidation();
  const [tryVerify, {}] = usePutApiUsersUpdateVerificationMutation();

  const validationRules: ValidationRules = {
    requiredFields: ['userName', 'password', 'firstName']
  };

  const transformRequest = (formData: AdminFormData) => ({
    password: formData.password,
    userName: formData.userName,
    firstName: formData.firstName,
    middleName: formData.middleName,
    lastName: formData.lastName,
    birthday: formData.birthday.toISOString(),
    email: formData.email,
    phoneNumber: formData.phoneNumber
  });

  const { handleSubmit } = useRegistrationSubmit<AdminFormData>({
    formData,
    validateForm,
    validationRules,
    tryRegister,
    requestKey: 'authRegistrationRegisterAdminRequest',
    transformRequest,
    redirectToLogin,
    verify,
    tryVerify,
    updateFormData,
    initialFormData,
    onSuccess
  });

  if (isSuccess && redirectToLogin) {
    return <RegisterResultModal />;
  }

  return (
    <FormContainer
      formData={formData}
      onFormDataChange={handleFormDataChange}
      onSubmit={handleSubmit}
      isLoading={isLoading}
      submitButtonLabel={buttonLabel ?? 'Зарегистрироваться'}
    />
  );
};

export default RegisterAdminForm;