import { useCallback } from 'react';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { ValidationRules } from './useFormValidation';

interface RegistrationSubmitParams<T> {
  formData: T;
  validateForm: (data: T, rules: ValidationRules<T>) => boolean;
  validationRules: ValidationRules<T>;
  tryRegister: any; // RTK mutation trigger
  requestKey: string; // e.g. 'authRegistrationRegisterAdminRequest'
  transformRequest: (data: T) => any;
  redirectToLogin?: boolean;
  verify?: boolean;
  tryVerify?: any; // RTK mutation trigger for verification
  updateFormData: (data: T) => void;
  initialFormData: T;
  onSuccess?: () => void;
}

export function useRegistrationSubmit<T>(params: RegistrationSubmitParams<T>) {
  const {
    formData,
    validateForm,
    validationRules,
    tryRegister,
    requestKey,
    transformRequest,
    redirectToLogin,
    verify,
    tryVerify,
    updateFormData,
    initialFormData,
    onSuccess
  } = params;

  const handleSubmit = useCallback(async (
    event: React.FormEvent
  ) => {
    event.preventDefault();

    if (!validateForm(formData, validationRules)) {
      return;
    }

    const response = await tryRegister({
      [requestKey]: transformRequest(formData)
    });

    if (response.error) {
      enqueueSnackbarError(response.error);
      return;
    }

    if (redirectToLogin) {
      return;
    }

    updateFormData(initialFormData);
    enqueueSnackbar('Пользователь создан', { variant: 'success' });

    if (verify && tryVerify) {
      const verifyResponse = await tryVerify({
        usersUpdateVerificationRequest: {
          userId: response.data.userId,
          isApproved: true
        }
      });
      if (verifyResponse.error) {
        enqueueSnackbarError(verifyResponse.error);
        return;
      }
      enqueueSnackbar('Пользователь верифицирован', { variant: 'success' });
    }

    onSuccess?.();
  }, [
    formData,
    validateForm,
    validationRules,
    tryRegister,
    requestKey,
    transformRequest,
    redirectToLogin,
    verify,
    tryVerify,
    updateFormData,
    initialFormData,
    onSuccess
  ]);

  return { handleSubmit };
}



