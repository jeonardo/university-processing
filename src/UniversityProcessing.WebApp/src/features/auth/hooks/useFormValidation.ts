import { useCallback } from 'react';
import { enqueueSnackbarError } from 'src/core/helpers';
import { CommonFormData } from '../components/CommonFormFields';

export interface ValidationRules<T = CommonFormData> {
  requiredFields: (keyof T)[];
  customValidation?: (formData: T) => boolean;
  customErrorMessage?: string;
}

export const useFormValidation = () => {
  const validateForm = useCallback(<T extends CommonFormData>(
    formData: T,
    rules: ValidationRules<T>
  ): boolean => {
    // Проверка обязательных полей
    for (const field of rules.requiredFields) {
      if (!formData[field]) {
        enqueueSnackbarError('Заполните обязательные поля');
        return false;
      }
    }

    // Кастомная валидация
    if (rules.customValidation && !rules.customValidation(formData)) {
      enqueueSnackbarError(rules.customErrorMessage || 'Ошибка валидации');
      return false;
    }

    return true;
  }, []);

  return { validateForm };
};
