import React from 'react';
import { FormControl, Stack } from '@mui/material';
import CommonFormFields, { CommonFormData } from './CommonFormFields';
import SubmitButton from 'src/components/forms/SubmitButton';

interface FormContainerProps<T extends CommonFormData> {
  formData: T;
  onFormDataChange: (field: keyof T, value: string | any) => void;
  onSubmit: (event: React.FormEvent) => void;
  isLoading: boolean;
  submitButtonLabel?: string;
  additionalFields?: React.ReactNode;
}

const FormContainer = <T extends CommonFormData>({
  formData,
  onFormDataChange,
  onSubmit,
  isLoading,
  submitButtonLabel = 'Зарегистрироваться',
  additionalFields
}: FormContainerProps<T>) => {
  return (
    <FormControl component="form" fullWidth sx={{ pt: 2 }} onSubmit={onSubmit}>
      <Stack spacing={2}>
        <CommonFormFields
          formData={formData}
          onFormDataChange={onFormDataChange}
          isLoading={isLoading}
        />

        {additionalFields}

        <SubmitButton
          isLoading={isLoading}
          label={submitButtonLabel}
        />
      </Stack>
    </FormControl>
  );
};

export default FormContainer;
