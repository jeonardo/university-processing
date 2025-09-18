import React, { useCallback, useMemo, useState } from 'react';
import { CircularProgress, Stack, Switch, Tooltip, Typography } from '@mui/material';
import { Verified as VerifiedIcon } from '@mui/icons-material';
import { usePutApiUsersUpdateVerificationMutation } from 'src/api/backendApi';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';

interface VerificationControlProps {
  userId: string;
  isApproved: boolean;
}

export const VerificationControl = React.memo<VerificationControlProps>(({ userId, isApproved }) => {
  const [verification, setVerificationState] = useState(isApproved);
  const [setVerification, { isLoading }] = usePutApiUsersUpdateVerificationMutation();

  const handleVerificationChange = useCallback(async (event: React.ChangeEvent<HTMLInputElement>) => {
    const newVerification = event.target.checked;
    const result = await setVerification({
      apiUsersUpdateVerificationRequestDto: {
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
  }, [setVerification, userId]);

  const tooltipTitle = useMemo(() =>
      verification ? 'Снять верификацию' : 'Подтвердить верификацию',
    [verification]
  );

  const switchTooltipTitle = useMemo(() =>
      isLoading
        ? 'Загружается'
        : verification
          ? 'Заблокировать'
          : 'Верифицировать',
    [isLoading, verification]
  );

  const statusText = useMemo(() =>
      verification ? 'Верифицирован' : 'Не верифицирован',
    [verification]
  );

  const iconClassName = useMemo(() =>
      `text-sm ${verification ? 'text-green-500' : 'text-gray-400'}`,
    [verification]
  );

  return (
    <Stack direction="row" spacing={1} alignItems="center">
      <Tooltip title={tooltipTitle}>
        {isLoading ? (
          <>
            <CircularProgress size={16} />
            <Typography variant="body2" className="font-medium text-gray-500">
              Проверка...
            </Typography>
          </>
        ) : (
          <>
            <VerifiedIcon className={iconClassName} />
            <Typography variant="body2" className="font-medium">
              {statusText}
            </Typography>
          </>
        )}
      </Tooltip>
      <Tooltip title={switchTooltipTitle} arrow>
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
});

VerificationControl.displayName = 'VerificationControl';
