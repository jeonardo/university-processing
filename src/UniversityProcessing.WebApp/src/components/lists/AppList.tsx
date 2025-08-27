import React, { ReactNode } from 'react';
import { Box, CircularProgress, List, Typography } from '@mui/material';

interface AppListProps {
  isEmpty: boolean;
  isLoading: boolean;
  children?: ReactNode;
  maxHeight?: number | string;
}

const AppList: React.FC<AppListProps> = ({ isEmpty, isLoading, children, maxHeight = '60vh' }) => {

  if (isEmpty) {
    return <Typography className="text-center py-4">Информация не найдена</Typography>;
  }

  return (
    <Box sx={{ position: 'relative', maxHeight, overflowY: 'auto' }}>
      {isLoading && (
        <Box className="absolute inset-0 flex justify-center items-center bg-white bg-opacity-50">
          <CircularProgress />
        </Box>
      )}
      <List className={`divide-y divide-gray-300 ${isLoading ? 'blur-sm pointer-events-none' : ''}`}>
        {children}
      </List>
    </Box>
  );
};

export default AppList;