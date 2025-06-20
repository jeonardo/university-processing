import { useEffect, useState } from 'react';
import { Container, Typography } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import FacultyItem from './FacultyItem';
import { useLazyGetApiAdminFacultiesGetQuery } from 'src/api/backendApi';
import AppListPagination from 'src/components/lists/AppListPagination';

const FacultiesPage = () => {
  const [pageNumber, setPageNumber] = useState(1);

  const [getData, { data, isLoading }] = useLazyGetApiAdminFacultiesGetQuery({ pollingInterval: 5000 });

  useEffect(() => {
    getData({ pageNumber: pageNumber });
  }, [pageNumber]);

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">
        Список факультетов
      </Typography>
      <AppList isLoading={isLoading} isEmpty={data?.list?.items?.length == 0}>
        {
          data?.list?.items?.map((item) => (
            <FacultyItem key={item.id} item={item} />
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

export default FacultiesPage;