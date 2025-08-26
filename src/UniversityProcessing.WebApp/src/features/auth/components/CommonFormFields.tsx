import React from 'react';
import { TextField } from '@mui/material';
import { Dayjs } from 'dayjs';
import DatePickerField from 'src/components/forms/DatePickerField';

export interface CommonFormData {
  userName: string;
  password: string;
  firstName: string;
  middleName: string;
  lastName: string;
  birthday: Dayjs;
  email: string;
  phoneNumber: string;
}

interface CommonFormFieldsProps {
  formData: CommonFormData;
  onFormDataChange: (field: keyof CommonFormData, value: string | Dayjs) => void;
  isLoading: boolean;
}

const CommonFormFields: React.FC<CommonFormFieldsProps> = ({
                                                             formData,
                                                             onFormDataChange,
                                                             isLoading
                                                           }) => {
  const handleChange = (field: keyof CommonFormData) => (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    onFormDataChange(field, event.target.value);
  };

  const handleFormDataChange = (field: keyof CommonFormData, value: string | Dayjs) => {
    onFormDataChange(field, value);
  };

  return (
    <>
      <TextField
        required
        label="Логин"
        value={formData.userName}
        onChange={handleChange('userName')}
        disabled={isLoading}
      />
      <TextField
        required
        type="password"
        label="Пароль"
        value={formData.password}
        onChange={handleChange('password')}
        disabled={isLoading}
      />
      <TextField
        type="email"
        label="Почта"
        value={formData.email}
        onChange={handleChange('email')}
        disabled={isLoading}
      />
      <TextField
        label="Номер телефона"
        value={formData.phoneNumber}
        onChange={handleChange('phoneNumber')}
        disabled={isLoading}
      />
      <TextField
        required
        label="Имя"
        value={formData.firstName}
        onChange={handleChange('firstName')}
        disabled={isLoading}
      />
      <TextField
        required
        label="Фамилия"
        value={formData.lastName}
        onChange={handleChange('lastName')}
        disabled={isLoading}
      />
      <TextField
        label="Отчество"
        value={formData.middleName}
        onChange={handleChange('middleName')}
        disabled={isLoading}
      />
      <DatePickerField
        label="Дата рождения"
        value={formData.birthday}
        onChange={(value => handleFormDataChange('birthday', value ?? ''))}
        disabled={isLoading}
      />
    </>
  );
};

export default CommonFormFields;