import React, { useState } from 'react';
import { Box, Button, Chip, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle, ListItem, ListItemText, Switch, Tooltip, Typography } from '@mui/material';
import { usePutApiUsersUpdateBlockingMutation, usePutApiUsersUpdateVerificationMutation, UsersGetAdminsAdmin } from 'src/api/backendApi';
import {
    Block as BlockIcon,
    Verified as VerifiedIcon,
    Person as PersonIcon
} from '@mui/icons-material';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';
import { namingTools } from 'src/core/namingTools';

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
                        ? "Загружается"
                        : isVerified ? "Заблокировать"
                            : "Верифицировать"}
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
    )
}

export default UserActions