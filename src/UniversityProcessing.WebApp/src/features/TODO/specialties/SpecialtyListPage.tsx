import React, { useEffect, useState } from 'react';
import { Container, Typography } from '@mui/material';
import AppListPagination from '../../components/AppListPagination';
// import { useLazyGetApiCommonGetSpecialtiesQuery } from 'src/api/backendApi';
import AppList from 'src/components/AppList';
import SpecialtyItem from './Сomponents/SpecialtyItem';

const SpecialtyListPage: React.FC = () => {
  const [pageNumber, setPageNumber] = useState(1);

  // const [getData, { data, isLoading }] = useLazyGetApiCommonGetSpecialtiesQuery({ pollingInterval: 5000 });

  // useEffect(() => {
  //   getData({ pageNumber: pageNumber });
  // }, [pageNumber]);

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">
        Список специальностей (направлений)
      </Typography>
      {/* <AppList isLoading={isLoading} isEmpty={data?.list?.items?.length == 0}>
        {
          data?.list?.items?.map((item) => (
            <SpecialtyItem key={item.id} item={item} />
          ))
        }
      </AppList>
      <AppListPagination
        currentPage={pageNumber}
        totalPages={data?.list?.totalPages ?? 0}
        onPageChange={setPageNumber}
      /> */}
    </Container>
  );
};

export default SpecialtyListPage;