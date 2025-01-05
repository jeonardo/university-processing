import React, { useCallback, useEffect, useState } from 'react';
import { Container, Typography, Box, CircularProgress, Alert, Modal, TextField, debounce } from '@mui/material';
import Pagination from './components/Pagination';
import UserList from './components/UserList';
import { ContractsUserRoleType, useGetApiAdminUsersGetQuery, useLazyGetApiAdminUsersGetQuery } from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import CommonLoader from 'src/components/commonLoader';
import { useLocation } from 'react-router-dom'
import { usePagination } from 'src/hooks/usePagination';
import { AdminUsersGetUser, AdminUsersGetUserPagedListRead, CommonGetUniversitiesUniversity } from 'src/api/backendApi';
import { useSearchParams } from 'react-router-dom';

const ITEMS_PER_PAGE = 5;

const UsersPage: React.FC = () => {

  const [getUsers, users] = useLazyGetApiAdminUsersGetQuery()

  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(1);
  const [filter, setFilter] = useState('');

  const isAdmin = useAppSelector(state => state.auth.user?.role == ContractsUserRoleType.Admin);

  const handlePageChange = (newPage: number) => {
    setPage(newPage);
  };

  const handleSearch = (query: string) => {
    setSearchQuery(query);
    setPage(1);
  };

  const handleStatusUpdate = (user: AdminUsersGetUser, value: boolean) => {

  }

  const handleDebouncedSearch = useCallback(debounce((newValue) => { }, 1000), []);

  if (isLoading) {
    return (
      <CommonLoader />
    );
  }

  if (error) {
    return (
      <Box className="flex justify-center items-center h-screen">
        <Alert severity="error">
          <Typography>Error loading users.</Typography>
          <Typography>{(error as any).message || 'Please try again later.'}</Typography>
        </Alert>
      </Box>
    );
  }

  if (!data || !data.list?.items) {
    return (
      <Box className="flex justify-center items-center h-screen">
        <Typography>No universities found.</Typography>
      </Box>
    );
  }

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">Пользователи</Typography>

      <TextField
        id="filter"
        name="filter"
        fullWidth
        label="Поиск по ФИО"
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
      />

      <UserList
        users={data.list.items}
        onStatusUpdate={handleStatusUpdate}
        isAdmin={isAdmin}
      />
      {isFetching && (
        <Box className="flex justify-center py-2">
          <CircularProgress size={24} />
        </Box>
      )}
      <Pagination
        currentPage={page}
        totalPages={data?.list?.totalPages ?? 0}
        onPageChange={handlePageChange}
      />
    </Container>
  );
};

export default UsersPage;




// import { useEffect, useMemo, useState } from 'react';
// import { Box, IconButton, Tooltip } from '@mui/material';
// import NotInterestedIcon from '@mui/icons-material/NotInterested';
// import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
// import { useLazyGetApiAdminUsersGetUsersQuery, usePutApiAdminUsersUpdateApprovalMutation } from 'src/api/backendApi';

// type Pagination = {
//   pageIndex: number;
//   pageSize: number;
// }

// const UsersPage = () => {
//   const [pagination, setPagination] = useState<Pagination>({
//     pageIndex: 0,
//     pageSize: 25
//   });

//   const [getTableData, tableData] = useLazyGetApiAdminUsersGetUsersQuery({ pollingInterval: 50000 });
//   const [handleUpdateApprovement, handleUpdateApprovementState] = usePutApiAdminUsersUpdateApprovalMutation();
//   const [isActualTableData, setIsActualTableData] = useState(false);

//   const sendUpdateApprovement = (approved: boolean, user: any) => {
//     handleUpdateApprovement({ adminUsersUpdateApprovalRequest: { isApproved: approved, userId: user.id ?? '' } });
//     setTimeout(() => {
//       setIsActualTableData(false);
//     }, 1500);
//   };

//   useEffect(() => {
//     if (isActualTableData) {
//       return;
//     }
//     //TODO getTableData({ pageNumber: pagination.pageIndex + 1, pageSize: pagination.pageSize });
//     setIsActualTableData(true);
//   }, [pagination, isActualTableData, handleUpdateApprovementState]);

//   return (

//   );
// };

// export default UsersPage;