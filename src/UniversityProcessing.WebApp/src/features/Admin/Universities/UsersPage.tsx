import React, { useState } from 'react';
import { useSelector } from 'react-redux';
import { useGetUniversitiesQuery, useCreateUniversityMutation, useDeleteUniversityMutation } from '../features/universities/universitiesApiSlice';
import UniversityList from '../components/UniversityList';
import Pagination from '../components/Pagination';
import AddUniversityForm from '../components/AddUniversityForm';
import SearchBar from '../components/SearchBar';
import { RootState } from '../store/store';
import { Container, Typography, Box, CircularProgress, Alert } from '@mui/material';

const ITEMS_PER_PAGE = 5;

const UsersPage: React.FC = () => {
  const [page, setPage] = useState(1);
  const [searchQuery, setSearchQuery] = useState('');
  const { data, error, isLoading, isFetching } = useGetUniversitiesQuery({ page, limit: ITEMS_PER_PAGE, search: searchQuery });
  const [createUniversity] = useCreateUniversityMutation();
  const [deleteUniversity] = useDeleteUniversityMutation();

  // In a real application, you would get this from your authentication system
  const isAdmin = useSelector((state: RootState) => state.auth?.isAdmin ?? true);

  const handlePageChange = (newPage: number) => {
    setPage(newPage);
  };

  const handleSearch = (query: string) => {
    setSearchQuery(query);
    setPage(1);
  };

  const handleAddUniversity = async (name: string, location: string) => {
    try {
      await createUniversity({ name, location }).unwrap();
    } catch (err) {
      console.error('Failed to create university:', err);
      // You might want to show an error message to the user here
    }
  };

  const handleDeleteUniversity = async (id: string) => {
    try {
      await deleteUniversity(id).unwrap();
    } catch (err) {
      console.error('Failed to delete university:', err);
      // You might want to show an error message to the user here
    }
  };

  if (isLoading) {
    return (
      <Box className="flex justify-center items-center h-screen">
        <CircularProgress />
      </Box>
    );
  }

  if (error) {
    return (
      <Box className="flex justify-center items-center h-screen">
        <Alert severity="error">
          <Typography>Error loading universities.</Typography>
          <Typography>{(error as any).message || 'Please try again later.'}</Typography>
        </Alert>
      </Box>
    );
  }

  if (!data || !data.universities) {
    return (
      <Box className="flex justify-center items-center h-screen">
        <Typography>No universities found.</Typography>
      </Box>
    );
  }

  const totalPages = Math.ceil((data.totalCount || 0) / ITEMS_PER_PAGE);

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="mb-6 font-bold">Universities</Typography>
      <SearchBar onSearch={handleSearch} />
      {isAdmin && <AddUniversityForm onSubmit={handleAddUniversity} />}
      <UniversityList
        universities={data.universities}
        onDelete={handleDeleteUniversity}
        isAdmin={isAdmin}
      />
      {isFetching && (
        <Box className="flex justify-center py-2">
          <CircularProgress size={24} />
        </Box>
      )}
      <Pagination
        currentPage={page}
        totalPages={totalPages}
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
//     <div className="w-full h-full items-center">
//       <Box sx={{ display: 'flex', gap: '1rem' }}>
//         {
//           true
//             ? <Tooltip title="Заблокировать пользователя">
//               {/* //TODO */}
//               <IconButton color="error" onClick={() => sendUpdateApprovement(false, null)}>
//                 <NotInterestedIcon />
//               </IconButton>
//             </Tooltip>
//             : <Tooltip title="Активировать пользователя">
//               {/* //TODO */}
//               <IconButton color="success" onClick={() => sendUpdateApprovement(true, null)}>
//                 <CheckCircleOutlineIcon />
//               </IconButton>
//             </Tooltip>
//         }
//       </Box>
//     </div>
//   );
// };

// export default UsersPage;