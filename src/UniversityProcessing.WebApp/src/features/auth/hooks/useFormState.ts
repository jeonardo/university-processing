import { useCallback, useState } from 'react';
import { Dayjs } from 'dayjs';
import { CommonFormData } from '../components/CommonFormFields';

export const useFormState = <T extends CommonFormData>(initialData: T) => {
  const [formData, setFormData] = useState<T>(initialData);

  const handleFormDataChange = useCallback((
    field: keyof T,
    value: string | Dayjs | any
  ) => {
    setFormData(prev => ({ ...prev, [field]: value }));
  }, []);

  const resetForm = useCallback(() => {
    setFormData(initialData);
  }, [initialData]);

  const updateFormData = useCallback((updates: Partial<T>) => {
    setFormData(prev => ({ ...prev, ...updates }));
  }, []);

  return {
    formData,
    handleFormDataChange,
    resetForm,
    updateFormData
  };
};
