import React from 'react';
import { Box, Pagination as MUIPagination } from '@mui/material';

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

const AppListPagination: React.FC<PaginationProps> = ({ currentPage, totalPages, onPageChange }) => {
  return (
    <Box className={`flex justify-center`}>
      <MUIPagination
        count={totalPages}
        page={currentPage}
        onChange={(_, page) => {
          onPageChange(page);
        }}
        color="primary"
      />

    </Box>
  );
};

export default AppListPagination;

