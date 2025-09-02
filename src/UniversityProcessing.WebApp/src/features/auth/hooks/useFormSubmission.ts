import { useCallback } from 'react';
import { enqueueSnackbarError } from 'src/core/helpers';
import { ValidationRules } from './useFormValidation';

export interface FormSubmissionConfig<T> {
  mutationHook: any;
  validationRules: ValidationRules<T>;
  transformRequest: (formData: T) => any;
  onSuccess?: () => void;
  onError?: (error: any) => void;
}

export const useFormSubmission = <T>() => {
  const handleSubmit = useCallback(async (
    formData: T,
    config: FormSubmissionConfig<T>
  ): Promise<boolean> => {
    const { mutationHook, validationRules, transformRequest, onSuccess, onError } = config;
    const [trySubmit, { isLoading }] = mutationHook;

    // Валидация
    if (!validationRules) {
      enqueueSnackbarError('Правила валидации не определены');
      return false;
    }

    // Проверка обязательных полей
    for (const field of validationRules.requiredFields) {
      if (!formData[field]) {
        enqueueSnackbarError('Заполните обязательные поля');
        return false;
      }
    }

    // Кастомная валидация
    if (validationRules.customValidation && !validationRules.customValidation(formData)) {
      enqueueSnackbarError(validationRules.customErrorMessage || 'Ошибка валидации');
      return false;
    }

    try {
      const response = await trySubmit({
        authRegistrationRegisterRequest: transformRequest(formData)
      });

      if (response.error) {
        enqueueSnackbarError(response.error);
        onError?.(response.error);
        return false;
      }

      onSuccess?.();
      return true;
    } catch (error) {
      enqueueSnackbarError('Произошла ошибка при отправке формы');
      onError?.(error);
      return false;
    }
  }, []);

  return { handleSubmit };
};
