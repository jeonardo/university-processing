import React from 'react';
import { List, ListItem, ListItemText, Button, Typography, Box, Tooltip, IconButton } from '@mui/material';
import { AdminUsersGetUser, AdminUsersGetUserPagedListRead, CommonGetUniversitiesUniversity } from 'src/api/backendApi';
import { useEffect, useMemo, useState } from 'react';
import NotInterestedIcon from '@mui/icons-material/NotInterested';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';

interface UserListProps<T> {
  users: T[];
  onStatusUpdate: (user: AdminUsersGetUser, value: boolean) => void;
  isAdmin: boolean;
}

const UserList: React.FC<UserListProps<AdminUsersGetUser>> = ({ users: users, onStatusUpdate, isAdmin }) => {

  if (users.length === 0) {
    return <Typography className="text-center py-4">No users available.</Typography>;
  }

  return (
    <List className="divide-y divide-gray-200">
      {users.map((user) => (
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
              {
                user.approved
                  ? <Tooltip title="Заблокировать пользователя">
                    <IconButton color="error" onClick={() => onStatusUpdate(user, false)}>
                      <NotInterestedIcon />
                    </IconButton>
                  </Tooltip>
                  : <Tooltip title="Активировать пользователя">
                    <IconButton color="success" onClick={() => onStatusUpdate(user, true)}>
                      <CheckCircleOutlineIcon />
                    </IconButton>
                  </Tooltip>
              }
            </Box>
          )}
        </ListItem>
      ))}
    </List>
  );
};

export default UserList;

