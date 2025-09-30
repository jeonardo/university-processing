import React, { useEffect, useState } from 'react';
import { Box, ListItem, ListItemText } from '@mui/material';
import { useParams } from 'react-router-dom';
import AppList from 'src/components/lists/AppList';
import AppListSearch from 'src/components/lists/AppListSearch';
import AppListPagination from 'src/components/lists/AppListPagination';
import { useLazyGetApiDiplomaProcessesDiplomasGetQuery } from 'src/api/backendApi';

const DiplomaDiplomasPage: React.FC = () => {
  const { id } = useParams();
  const diplomaProcessId = id as string;

  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const [getDiplomas, diplomasState] = useLazyGetApiDiplomaProcessesDiplomasGetQuery({ pollingInterval: 15000 });

  useEffect(() => {
    if (!diplomaProcessId) return;
    getDiplomas({ diplomaProcessId, pageNumber, pageSize: 25, filter: search });
  }, [diplomaProcessId, pageNumber, search, getDiplomas]);

  const diplomas = diplomasState.data?.items ?? [];

  return (
    <Box>
      <AppListSearch label="Поиск" placeholder="ФИО студента или тема" onSearchValueChangedDebounced={v => { setPageNumber(1); setSearch(v); }} />
      <AppList isLoading={diplomasState.isLoading} isEmpty={diplomas.length === 0} height="60vh">
        {diplomas.map((d: any) => (
          <ListItem key={d.id} divider>
            <ListItemText
              primary={d.title ?? 'Без названия'}
              secondary={`Студент: ${d.student.lastName} ${d.student.firstName} (${d.student.groupNumber}) ${d.supervisor ? '• Руководитель: ' + d.supervisor.lastName + ' ' + d.supervisor.firstName : ''}`}
            />
          </ListItem>
        ))}
      </AppList>
      <Box sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination currentPage={pageNumber} totalPages={diplomasState.data?.totalPages ?? 0} onPageChange={setPageNumber} />
      </Box>
    </Box>
  );
};

export default DiplomaDiplomasPage;


