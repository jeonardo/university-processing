import React, { ReactNode } from 'react';
import { Box, CircularProgress, List, Typography } from '@mui/material';

interface AppListProps {
  isEmpty: boolean;
  isLoading: boolean;
  children?: ReactNode;
}

const AppList: React.FC<AppListProps> = ({ isEmpty, isLoading, children }) => {

  if (isEmpty) {
    return <Typography className="text-center py-4">Информация не найдена</Typography>;
  }

  return (
    <List className={`relative divide-y divide-gray-300 ${isLoading ? 'blur-sm pointer-events-none' : ''}`}>
      {
        isLoading
        && (
          <Box className="absolute inset-0 flex justify-center items-center bg-white bg-opacity-50">
            <CircularProgress />
          </Box>)
      }
      {
        children
      }
    </List>
  );
};

export default AppList;