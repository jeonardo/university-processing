import { useState } from 'react';
import { Container, Typography } from '@mui/material';
// import { useLazyGetApiCommonGetGroupsQuery } from 'src/api/backendApi';

const GroupListPage = () => {
  const [pageNumber, setPageNumber] = useState(1);

  // const [getData, { data, isLoading }] = useLazyGetApiCommonGetGroupsQuery({ pollingInterval: 5000 });

  // useEffect(() => {
  //   getData({ pageNumber: pageNumber });
  // }, [pageNumber]);

  return (
    <Container maxWidth="md" className="py-8">
      <Typography variant="h4" component="h1" className="pb-6 font-bold">
        Список учебных групп
      </Typography>
      {/* <AppList isLoading={isLoading} isEmpty={data?.list?.items?.length == 0}>
        {
          data?.list?.items?.map((item) => (
            <GroupItem key={item.id} item={item} />
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

export default GroupListPage;