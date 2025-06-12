import React, { useEffect, useState } from 'react';
import { Container, Typography } from '@mui/material';
import { ContractsUserRoleType, useLazyGetApiAdminUsersGetQuery } from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppList from 'src/components/lists/AppList';
import UserItem from './UserItem';
import AppListSearch from 'src/components/lists/AppListSearch';

const UsersPage: React.FC = () => {
  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');

  const [getData, { data, isLoading }] = useLazyGetApiAdminUsersGetQuery({ pollingInterval: 3000 });
  const isAdmin = useAppSelector(state => state.auth.user?.roleType == ContractsUserRoleType.Admin);

  useEffect(() => {
    getData({ filter: search, pageNumber: pageNumber });
  }, [pageNumber, search]);

  const SearchValueChanged = (newSearch: string) => {
    setPageNumber(1);
    setSearch(newSearch);
  };

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">Пользователи</Typography>
      <AppListSearch
        label="Поиск по ФИО"
        onSearchValueChangedDebounced={SearchValueChanged} />
      <AppList isLoading={isLoading} isEmpty={data?.list?.items?.length == 0}>
        {
          data?.list?.items?.map((user) => (
            <UserItem key={user.id} isAdmin={isAdmin} item={user} />
          ))
        }
      </AppList>
      <AppListPagination
        currentPage={pageNumber}
        totalPages={data?.list?.totalPages ?? 0}
        onPageChange={setPageNumber}
      />
    </Container>
  );
};

export default UsersPage;