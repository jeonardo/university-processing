import React, { useState } from 'react';
import { Box, Button, Chip, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle, ListItem, ListItemText, Switch, Tooltip, Typography } from '@mui/material';
import { usePutApiUsersUpdateBlockingMutation, usePutApiUsersUpdateVerificationMutation, UsersGetAdminsAdmin } from 'src/api/backendApi';
import { AuthUser } from '../auth/auth.contracts';
import {
  Block as BlockIcon,
  Verified as VerifiedIcon,
  Person as PersonIcon
} from '@mui/icons-material';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';
import { namingTools } from 'src/core/namingTools';

interface UserItemProps<T> {
  item: T;
  currentUser: AuthUser | null;
  showVerificationAction?: boolean;
}

const AdministratorItem: React.FC<UserItemProps<UsersGetAdminsAdmin>> = ({
  item,
  currentUser,
  showVerificationAction
}) => {
  const [updateVerification, { isLoading: isLoadingVerification }] = usePutApiUsersUpdateVerificationMutation();
  const [verification, setVerification] = useState(item.approved);
  const fullName = namingTools.fullName(item);

  const handleUpdateApproval = async (
    event: React.ChangeEvent<HTMLInputElement>,
    checked: boolean) => {
    const result = await updateVerification({
      usersUpdateVerificationRequest: {
        isApproved: checked,
        userId: item.id ?? ''
      }
    });

    if (result.error) {
      enqueueSnackbarError(`Произошла ошибка при верификации ${result.error}`);
      return;
    }

    enqueueSnackbar(checked
      ? 'Пользователь верифицирован'
      : 'Пользователь заблокирован', { variant: 'success' });

    setVerification(!item.approved!);
  };


  return (
    <ListItem key={item.id} className="py-4 flex justify-between items-center">
      <ListItemText
        primary={fullName}
      />
      {
        item.id == currentUser?.userId
          ?
          (
            <Typography variant="body2" color="text.secondary" component="span">
              (Вы)
            </Typography>
          )
          :
          (
            <>
              {showVerificationAction && (
                <Box className="flex items-center justify-between space-x-4 mt-2">
                  <Box className="flex items-center space-x-2">
                    {isLoadingVerification ? (
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
                  </Box>
                  <Tooltip
                    title={
                      isLoadingVerification
                        ? "Загружается"
                        : verification ? "Заблокировать"
                          : "Верифицировать"}
                    arrow
                  >
                    <span>
                      <Switch
                        checked={verification}
                        onChange={handleUpdateApproval}
                        color="success"
                        size="small"
                        disabled={isLoadingVerification}
                        className={isLoadingVerification ? 'opacity-50' : ''}
                      />
                    </span>
                  </Tooltip>
                </Box>
              )}
            </>
          )
      }
    </ListItem>);
};

export default AdministratorItem;