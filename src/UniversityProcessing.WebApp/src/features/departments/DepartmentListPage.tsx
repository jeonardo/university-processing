import { useEffect, useState } from 'react';
import { Container, Typography } from '@mui/material';
import AppListPagination from '../../components/AppListPagination';
// import { useLazyGetApiCommonGetDepartmentsQuery } from 'src/api/backendApi';
import AppList from 'src/components/AppList';
import DepartmentItem from './Сomponents/DepartmentItem';

const DepartmentListPage = () => {
  const [pageNumber, setPageNumber] = useState(1);

  // const [getData, { data, isLoading }] = useLazyGetApiCommonGetDepartmentsQuery({ pollingInterval: 5000 });

  // useEffect(() => {
  //   getData({ pageNumber: pageNumber });
  // }, [pageNumber]);

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">
        Список кафедр
      </Typography>
      {/* <AppList isLoading={isLoading} isEmpty={data?.list?.items?.length == 0}>
        {
          data?.list?.items?.map((item) => (
            <DepartmentItem key={item.id} item={item} />
          ))
        }
      </AppList> */}
      {/* <AppListPagination
        currentPage={pageNumber}
        totalPages={data?.list?.totalPages ?? 0}
        onPageChange={setPageNumber}
      /> */}
    </Container>
  );
};

export default DepartmentListPage;