import React, { useCallback, useEffect, useState } from 'react';
import { Container, debounce, TextField, Typography } from '@mui/material';
import Pagination from './components/Pagination';
import UserList from './components/UserList';
import { ContractsUserRoleType, useLazyGetApiAdminUsersGetQuery } from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';

const UsersPage: React.FC = () => {

  const [getUsers, { data, isLoading }] = useLazyGetApiAdminUsersGetQuery({ pollingInterval: 5000 });

  const [pageNumber, setPageNumber] = useState(1);
  const [filter, setFilter] = useState('');
  const [search, setSearch] = useState('');

  const isAdmin = useAppSelector(state => state.auth.user?.role == ContractsUserRoleType.Admin);

  useEffect(() => {
    getUsers({ filter: filter, pageNumber: pageNumber });
  }, [pageNumber, filter]);

  const handlePageChange = (newPageNumber: number) => {
    if (newPageNumber <= 0) return;
    setPageNumber(newPageNumber);
  };

  const handleSearchDebounced = useCallback(debounce((filter: string) => {
    setPageNumber(1);
    setFilter(filter);
  }, 1000), []);

  const handleSearch = (query: string) => {
    if (filter == query) return;
    setSearch(query);
    handleSearchDebounced(query);
  };

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">Пользователи</Typography>
      <TextField
        id="filter"
        name="filter"
        fullWidth
        label="Поиск по ФИО"
        value={search}
        onChange={(e) => handleSearch(e.target.value)}
      />
      <UserList
        users={data?.list?.items ?? []}
        isAdmin={isAdmin}
        isLoading={isLoading}
      />
      <Pagination
        currentPage={pageNumber}
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