import React from 'react';
import dayjs from 'dayjs';
import RegisterResultModal from './RegisterResultModal';
import { usePostApiAuthRegistrationRegisterStudentMutation, usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import {
  FormContainer,
  GroupSelector,
  useFormState,
  useFormValidation,
  ValidationRules,
  CommonFormData
} from './index';
import { enqueueSnackbarError } from 'src/core/helpers';
import { IRegisterFormProps } from './RegisterFormProps';
import { enqueueSnackbar } from 'notistack';

interface StudentFormData extends CommonFormData {
  groupNumber: string;
}

const RegisterStudentForm: React.FC<IRegisterFormProps> = ({
  buttonLabel,
  verify,
  redirectToLogin }) => {
  const initialFormData: StudentFormData = {
    userName: '',
    password: '',
    firstName: '',
    middleName: '',
    lastName: '',
    birthday: dayjs(),
    email: '',
    phoneNumber: '',
    groupNumber: ''
  };

  const { formData, handleFormDataChange, updateFormData } = useFormState(initialFormData);
  const [tryRegister, { isLoading, isSuccess }] = usePostApiAuthRegistrationRegisterStudentMutation();
  const { validateForm } = useFormValidation();
  const [tryVerify, { }] = usePutApiUsersUpdateVerificationMutation();

  const validationRules: ValidationRules<StudentFormData> = {
    requiredFields: ['userName', 'password', 'firstName', 'groupNumber']
  };

  const transformRequest = (formData: StudentFormData) => ({
    ...formData,
    birthday: formData.birthday.toISOString()
  });

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    if (!validateForm(formData, validationRules)) {
      return;
    }

    const response = await tryRegister({
      authRegistrationRegisterStudentRequest: transformRequest(formData)
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

  const additionalFields = (
    <GroupSelector
      value={formData.groupNumber}
      onChange={(value) => handleFormDataChange('groupNumber', value)}
      required
    />
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

export default RegisterStudentForm;