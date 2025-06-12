import React, { useState } from 'react';
import { Box, ListItem, ListItemText, Typography } from '@mui/material';
import { AdminUsersGetUser } from 'src/api/backendApi';
import ToggleStatus from './ToggleStatus';

interface UserItemProps<T> {
  item: T;
  isAdmin: boolean;
}

const UserItem: React.FC<UserItemProps<AdminUsersGetUser>> = ({ item: user, isAdmin }) => {
  // const [updateApproval] = usePutApiAdminUsersUpdateApprovalMutation();
  const [approved, setApproved] = useState(user.approved);

  const handleUpdateApproval = () => {
    // updateApproval({ adminUsersUpdateApprovalRequest: { isApproved: !user.approved!, userId: user.id ?? '' } });
    setApproved(!user.approved!);
  };

  return (
    <ListItem key={user.id} className="py-4 flex justify-between items-center">
      <ListItemText
        primary={user.firstName}
        secondary={
          <Typography variant="body2" color="text.secondary" component="span">
            {user.lastName}
          </Typography>
        }
      />
      {isAdmin && (
        <Box sx={{ display: 'flex', gap: '1rem' }}>
          <ToggleStatus onToggled={handleUpdateApproval} isActive={approved!} />
        </Box>
      )}
    </ListItem>);
};

export default UserItem;