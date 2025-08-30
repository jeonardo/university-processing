import React from 'react';
import { Box, Pagination as MUIPagination } from '@mui/material';

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

const AppListPagination: React.FC<PaginationProps> = ({ currentPage, totalPages, onPageChange }) => {
  if (totalPages <= 1) {
    return null;
  }

  // Проверяем, что currentPage в допустимом диапазоне
  const validCurrentPage = Math.min(Math.max(1, currentPage), totalPages);
  return (
    <Box className={`flex justify-center`}>
      <MUIPagination
        count={totalPages}
        page={validCurrentPage}
        onChange={(_, page) => {
          onPageChange(page);
        }}
        color="primary"
      />

    </Box>
  );
};

export default AppListPagination;

