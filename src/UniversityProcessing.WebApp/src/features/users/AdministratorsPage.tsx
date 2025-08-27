import React, { useEffect, useState } from 'react';
import { Box, Button, Container, InputAdornment, Paper, TextField, Typography } from '@mui/material';
import { useAppSelector } from 'src/core/hooks';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppList from 'src/components/lists/AppList';
import UserItem from './UserItem';
import AppListSearch from 'src/components/lists/AppListSearch';
import { ContractsUserRoleType, useLazyGetApiUsersGetAdminsQuery } from 'src/api/backendApi';
import {
  Add as AddIcon,
  Block as BlockIcon,
  CheckCircle as CheckCircleIcon,
  Delete as DeleteIcon,
  Edit as EditIcon,
  School as SchoolIcon,
  Search as SearchIcon,
  VerifiedUser as VerifiedUserIcon,
  Work as WorkIcon
} from '@mui/icons-material';
import { useNavigate } from 'react-router-dom';
const AdministratorsPage: React.FC = () => {
  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const navigate = useNavigate();

  const [getData, { data, isLoading }] = useLazyGetApiUsersGetAdminsQuery(
    {
      pollingInterval: 15000
    });

  const currentUser = useAppSelector(state => state.auth.user);
  const isAdmin = currentUser?.role == ContractsUserRoleType.Admin;

  useEffect(() => {
    if (!isAdmin)
      navigate('/');
    getData({ filter: search, pageNumber: pageNumber, pageSize: 25 });
  }, [pageNumber, search, currentUser]);

  const SearchValueChanged = (newSearch: string) => {
    setPageNumber(1);
    setSearch(newSearch);
  };

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
          <Typography variant="h4" component="h1" className="font-bold">
            Администраторы
          </Typography>
          <Button
            variant="contained"
            startIcon={<AddIcon />}
            onClick={() => { }}
            sx={{ borderRadius: 2 }}
          >
            <span className="hidden sm:inline">Добавить пользователя</span>
          </Button>
        </Box>
        <AppListSearch
          label="Поиск"
          placeholder='Введите ФИО'
          onSearchValueChangedDebounced={SearchValueChanged} />
      </Paper>
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={data?.list?.items?.length == 0}
            maxHeight={'55vh'}>
            {
              data?.list?.items?.map((item) => (
                <UserItem
                  key={item.id}
                  item={item}
                  currentUser={currentUser}
                  showVerificationAction={isAdmin}
                />
              ))
            }
          </AppList>
        </Box>
      </Paper>
      <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.list?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>
    </Container>
  );
};

export default AdministratorsPage;