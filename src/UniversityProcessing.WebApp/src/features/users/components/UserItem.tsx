import React from 'react';
import { ListItem, ListItemText, Typography } from '@mui/material';
import { ApiUsersGetAdminsAdminDto } from 'src/api/backendApi';
import { AuthUser } from '../../auth/auth.contracts';
import { namingTools } from 'src/core/namingTools';
import useVerification from '../hooks/useVerification';
import UserActions from './UserActions';

interface UserItemProps<T> {
  item: T;
  currentUser: AuthUser | null;
  canVerify?: boolean;
}

const UserItem: React.FC<UserItemProps<ApiUsersGetAdminsAdminDto>> = ({
                                                                        item,
                                                                        currentUser,
                                                                        canVerify
                                                                      }) => {
  const fullName = namingTools.fullName(item);

  const {
    handleUpdateVerification,
    verification,
    isLoading: isVerificationLoading
  } = useVerification({ isApproved: item.approved ?? false });

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
              handleUpdateVerification={({ isApproved }) => handleUpdateVerification({
                userId: item.id ?? '',
                isApproved
              })} />
          )
      }
    </ListItem>);
};

export default UserItem;