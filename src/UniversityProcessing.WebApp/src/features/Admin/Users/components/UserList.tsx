import React from 'react';
import { Box, CircularProgress, List, Typography } from '@mui/material';
import { AdminUsersGetUser } from 'src/api/backendApi';
import UserItem from './UserItem';

interface UserListProps<T> {
  users: T[];
  isAdmin: boolean;
  isLoading: boolean;
}

const UserList: React.FC<UserListProps<AdminUsersGetUser>> = ({ users, isAdmin, isLoading }) => {

  if (users.length === 0) {
    return <Typography className="text-center py-4">Пользователи не найдены</Typography>;
  }

  return (
    // <Container>
    <List className={`relative divide-y divide-gray-300 ${isLoading ? 'blur-sm pointer-events-none' : ''}`}>
      {
        isLoading
        && (
          <Box className="absolute inset-0 flex justify-center items-center bg-white bg-opacity-50">
            <CircularProgress />
          </Box>)
      }
      {
        users.map((user) => (
          <UserItem key={user.id} isAdmin={isAdmin} user={user} />
        ))
      }
    </List>
    /* </Container> */
  );
};

export default UserList;