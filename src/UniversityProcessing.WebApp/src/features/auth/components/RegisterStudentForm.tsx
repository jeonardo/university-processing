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
import { IRegisterFormProps } from './RegisterFormProps';
import { useRegistrationSubmit } from './useRegistrationSubmit';
import { enqueueSnackbar } from 'notistack';

interface StudentFormData extends CommonFormData {
  groupNumber: string;
}

const RegisterStudentForm: React.FC<IRegisterFormProps> = ({
  buttonLabel,
  verify,
  redirectToLogin,
  onSuccess }) => {
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

  const { handleSubmit } = useRegistrationSubmit<StudentFormData>({
    formData,
    validateForm,
    validationRules,
    tryRegister,
    requestKey: 'authRegistrationRegisterStudentRequest',
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