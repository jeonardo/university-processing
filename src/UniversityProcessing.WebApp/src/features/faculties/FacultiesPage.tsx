import { useEffect, useState } from 'react';
import { Container, Paper, Typography } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import FacultyItem from './FacultyItem';
import AppListPagination from 'src/components/lists/AppListPagination';
import { ContractsUserRoleType, useGetApiFacultiesGetQuery, useLazyGetApiFacultiesGetQuery } from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import { useNavigate } from 'react-router-dom';

const FacultiesPage = () => {
  const navigate = useNavigate();
  const [pageNumber, setPageNumber] = useState(1);
  const authState = useAppSelector(state => state.auth);

  const [getData, { data, isLoading }] = useLazyGetApiFacultiesGetQuery({ pollingInterval: 5000 });

  useEffect(() => {
    if (authState.user?.role != ContractsUserRoleType.Admin)
      navigate('/');
    getData({ pageNumber: pageNumber, pageSize: 25 });
  }, [pageNumber, authState]);

  return (
    <Container maxWidth="md">
      <Paper className="p-6 mb-3">
        <Typography variant="h4" component="h1" className="font-bold">
          Список факультетов
        </Typography>
      </Paper>
      <Paper className="p-6">
        <AppList isLoading={isLoading} isEmpty={data?.items?.length == 0}>
          {
            data?.items?.map((item) => (
              <FacultyItem key={item.id} item={item} />
            ))
          }
        </AppList>
      </Paper>
      <Paper className="mt-3 pb-3">
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>
    </Container>
  );
};

export default FacultiesPage;