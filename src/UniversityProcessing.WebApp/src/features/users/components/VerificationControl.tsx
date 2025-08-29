import React from 'react';
import { Stack, Tooltip, CircularProgress, Typography, Switch } from '@mui/material';
import { Verified as VerifiedIcon } from '@mui/icons-material';
import { usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import { useState } from 'react';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';

interface VerificationControlProps {
  userId: string;
  isApproved: boolean;
}

export const VerificationControl: React.FC<VerificationControlProps> = ({ userId, isApproved }) => {
  const [verification, setVerificationState] = useState(isApproved);
  const [setVerification, { isLoading }] = usePutApiUsersUpdateVerificationMutation();

  const handleVerificationChange = async (event: React.ChangeEvent<HTMLInputElement>) => {
    const newVerification = event.target.checked;
    const result = await setVerification({ 
      usersUpdateVerificationRequest: { 
        userId, 
        isApproved: newVerification 
      } 
    });
    
    if (result.error) {
      enqueueSnackbarError(result.error);
      return;
    }
    
    setVerificationState(newVerification);
    enqueueSnackbar(
      newVerification ? 'Пользователь верифицирован' : 'Пользователь заблокирован',
      { variant: 'success' }
    );
  };

  return (
    <Stack direction="row" spacing={1} alignItems="center">
      <Tooltip title={verification ? 'Снять верификацию' : 'Подтвердить верификацию'}>
        {isLoading ? (
          <>
            <CircularProgress size={16} />
            <Typography variant="body2" className="font-medium text-gray-500">
              Проверка...
            </Typography>
          </>
        ) : (
          <>
            <VerifiedIcon className={`text-sm ${verification ? 'text-green-500' : 'text-gray-400'}`} />
            <Typography variant="body2" className="font-medium">
              {verification ? 'Верифицирован' : 'Не верифицирован'}
            </Typography>
          </>
        )}
      </Tooltip>
      <Tooltip
        title={
          isLoading
            ? "Загружается"
            : verification
              ? "Заблокировать"
              : "Верифицировать"
        }
        arrow
      >
        <span>
          <Switch
            checked={verification}
            onChange={handleVerificationChange}
            color="success"
            size="small"
            disabled={isLoading}
            className={isLoading ? 'opacity-50' : ''}
          />
        </span>
      </Tooltip>
    </Stack>
  );
};
