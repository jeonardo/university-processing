import React, { useState } from 'react';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { usePostApiAuthRegistrationRegisterAdminMutation, usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import {
  FormContainer,
  useFormState,
  useFormValidation,
  ValidationRules,
  CommonFormData
} from './index';
import { enqueueSnackbarError } from 'src/core/helpers';
import { IRegisterFormProps } from './RegisterFormProps';
import { enqueueSnackbar } from 'notistack';

interface AdminFormData extends CommonFormData { }

const RegisterAdminForm: React.FC<IRegisterFormProps> = ({
  buttonLabel,
  verify,
  redirectToLogin }) => {
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
  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterAdminMutation();
  const { validateForm } = useFormValidation();
  const [tryVerify, { }] = usePutApiUsersUpdateVerificationMutation();

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

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    if (!validateForm(formData, validationRules)) {
      return;
    }

    const response = await tryRegister({
      authRegistrationRegisterAdminRequest: transformRequest(formData)
    });

    if (response.error) {
      enqueueSnackbarError(response.error);
      return;
    }

    if (redirectToLogin)
      return;

    updateFormData(initialFormData);
    enqueueSnackbar('Пользователь создан', { variant: 'success' });

    if (verify) {
      const verifyResponse = await tryVerify({ usersUpdateVerificationRequest: { userId: response.data.userId, isApproved: true } });

      if (verifyResponse.error) {
        enqueueSnackbarError(verifyResponse.error);
        return;
      }

      enqueueSnackbar('Пользователь верифицирован', { variant: 'success' });
    }
  };

  if (isSuccess && redirectToLogin) {
    return <RegisterResultModal />;
  }

  return (
    <FormContainer
      formData={formData}
      onFormDataChange={handleFormDataChange}
      onSubmit={handleSubmit}
      isLoading={isLoading}
      submitButtonLabel={buttonLabel ?? "Зарегистрироваться"}
    />
  );
};

export default RegisterAdminForm;