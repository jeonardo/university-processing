import React, { useState } from 'react';
import { Box, Button, Chip, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle, ListItem, ListItemText, Switch, Tooltip, Typography } from '@mui/material';
import { usePutApiUsersUpdateBlockingMutation, usePutApiUsersUpdateVerificationMutation, UsersGetAdminsAdmin } from 'src/api/backendApi';
import { AuthUser } from '../../auth/auth.contracts';
import {
  Block as BlockIcon,
  Verified as VerifiedIcon,
  Person as PersonIcon
} from '@mui/icons-material';
import { enqueueSnackbarError } from 'src/core/helpers';
import { enqueueSnackbar } from 'notistack';
import { namingTools } from 'src/core/namingTools';
import useVerification from '../hooks/useVerification';
import UserActions from './UserActions';

interface UserItemProps<T> {
  item: T;
  currentUser: AuthUser | null;
  canVerify?: boolean;
}

const UserItem: React.FC<UserItemProps<UsersGetAdminsAdmin>> = ({
  item,
  currentUser,
  canVerify
}) => {
  const fullName = namingTools.fullName(item);

  const { handleUpdateVerification, verification, isLoading: isVerificationLoading } = useVerification({ isApproved: item.approved ?? false });

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
            canVerify &&
            <UserActions
              isLoading={isVerificationLoading}
              isVerified={verification}
              handleUpdateVerification={({ isApproved }) => handleUpdateVerification({ userId: item.id ?? '', isApproved })} />
          )
      }
    </ListItem>);
};

export default UserItem;