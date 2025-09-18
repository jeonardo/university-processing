// src/features/users/useVerification.ts
import { usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';
import { useState } from 'react';

interface VerificationProps {
  userId: string;
  isApproved: boolean;
}

const useVerification = ({ isApproved }: { isApproved: boolean; }) => {
  const [verification, setVerification] = useState(isApproved);
  const [updateVerification, { isLoading }] = usePutApiUsersUpdateVerificationMutation();

  const handleUpdateVerification = async ({ userId, isApproved }: VerificationProps) => {
    const result = await updateVerification({
      apiUsersUpdateVerificationRequestDto: {
        isApproved,
        userId
      }
    });

    if (result.error) {
      enqueueSnackbarError(`Произошла ошибка при верификации ${result.error}`);
      return;
    }

    enqueueSnackbar(isApproved ? 'Пользователь верифицирован' : 'Пользователь заблокирован', { variant: 'success' });
    setVerification(isApproved);
  };

  return { handleUpdateVerification, verification, isLoading };
};

export default useVerification;