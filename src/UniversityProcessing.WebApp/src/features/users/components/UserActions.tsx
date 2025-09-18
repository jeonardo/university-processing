import React from 'react';
import { Box, CircularProgress, Switch, Tooltip, Typography } from '@mui/material';
import { Verified as VerifiedIcon } from '@mui/icons-material';

const UserActions = ({ isLoading, isVerified, handleUpdateVerification }: {
  isLoading: boolean,
  isVerified: boolean,
  handleUpdateVerification: ({ isApproved }: { isApproved: boolean }) => void
}) => {
  return (
    <Box className="flex items-center justify-between space-x-4 mt-2">
      <Box className="flex items-center space-x-2">
        {isLoading ? (
          <>
            <CircularProgress size={16} />
            <Typography variant="body2" className="font-medium text-gray-500">
              Проверка...
            </Typography>
          </>
        ) : (
          <>
            <VerifiedIcon className={`text-sm ${isVerified ? 'text-green-500' : 'text-gray-400'}`} />
            <Typography variant="body2" className="font-medium">
              {isVerified ? 'Верифицирован' : 'Не верифицирован'}
            </Typography>
          </>
        )}
      </Box>
      <Tooltip
        title={
          isLoading
            ? 'Загружается'
            : isVerified ? 'Заблокировать'
              : 'Верифицировать'}
        arrow
      >
                <span>
                    <Switch
                      checked={isVerified}
                      onChange={(value) => handleUpdateVerification({ isApproved: value.target.checked })}
                      color="success"
                      size="small"
                      disabled={isLoading}
                      className={isLoading ? 'opacity-50' : ''}
                    />
                </span>
      </Tooltip>
    </Box>
  );
};

export default UserActions;