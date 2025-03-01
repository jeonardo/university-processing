import React from 'react';
import { Box, Pagination as MUIPagination } from '@mui/material';

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

const AppListPagination: React.FC<PaginationProps> = ({ currentPage, totalPages, onPageChange }) => {
  return (
    <Box className="flex justify-center pt-4">
      <MUIPagination
        count={totalPages}
        page={currentPage}
        onChange={(_, page) => {
          if (page <= 0) return;
          onPageChange(page);
        }}
        color="primary"
      />
    </Box>
  );
};

export default AppListPagination;

