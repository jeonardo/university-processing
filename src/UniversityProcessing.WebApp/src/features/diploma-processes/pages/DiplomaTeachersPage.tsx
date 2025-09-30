import React, { useEffect, useState } from 'react';
import { Box, Button, ListItem, ListItemSecondaryAction, ListItemText, Typography } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import AppListSearch from 'src/components/lists/AppListSearch';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useParams } from 'react-router-dom';
import {
  useLazyGetApiDiplomaProcessesTeachersGetQuery,
  usePutApiDiplomaProcessesTeachersAddMutation,
  usePutApiDiplomaProcessesTeachersRemoveMutation,
  useLazyGetApiUsersGetTeachersQuery
} from 'src/api/backendApi';

const DiplomaTeachersPage: React.FC = () => {
  const { id } = useParams();
  const diplomaProcessId = id as string;

  const [search, setSearch] = useState('');
  const [getProcessTeachers] = useLazyGetApiDiplomaProcessesTeachersGetQuery();
  const [addTeacherToProcess, addState] = usePutApiDiplomaProcessesTeachersAddMutation();
  const [removeTeacherFromProcess, removeState] = usePutApiDiplomaProcessesTeachersRemoveMutation();
  const [getTeachers] = useLazyGetApiUsersGetTeachersQuery();

  const [processTeachers, setProcessTeachers] = useState<any[]>([]);
  const [allTeachers, setAllTeachers] = useState<any[]>([]);

  useEffect(() => {
    if (!diplomaProcessId) return;
    getProcessTeachers({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search }).then(r => setProcessTeachers(r.data?.items ?? []));
    getTeachers({ pageNumber: 1, pageSize: 100, filter: search, orderBy: 'lastName', desc: false }).then(r => setAllTeachers(r.data?.list?.items ?? []));
  }, [diplomaProcessId, search, getProcessTeachers, getTeachers]);

  return (
    <Box>
      <AppListSearch label="Поиск" placeholder="Фамилия преподавателя" onSearchValueChangedDebounced={setSearch} />
      <Typography variant="subtitle2" sx={{ mt: 1, mb: 1 }}>Все преподаватели</Typography>
      <AppList isLoading={false} isEmpty={(allTeachers ?? []).length === 0} height="28vh">
        {(allTeachers ?? []).map((t: any) => (
          <ListItem key={t.id} divider>
            <ListItemText primary={`${t.lastName} ${t.firstName} ${t.middleName ?? ''}`} secondary={t.position} />
            <ListItemSecondaryAction>
              {processTeachers.some(pt => pt.id === t.id) ? (
                <Button size="small" color="error" onClick={() => removeTeacherFromProcess({ apiDiplomaProcessesTeachersRemoveRequestDto: { diplomaProcessId, userId: t.id } }).unwrap().then(() => { enqueueSnackbar('Преподаватель удален из процесса', { variant: 'success' }); setProcessTeachers(prev => prev.filter(x => x.id !== t.id)); }).catch(enqueueSnackbarError)} disabled={removeState.isLoading}>Удалить</Button>
              ) : (
                <Button size="small" variant="contained" onClick={() => addTeacherToProcess({ apiDiplomaProcessesTeachersAddRequestDto: { diplomaProcessId, userId: t.id } }).unwrap().then(() => { enqueueSnackbar('Преподаватель добавлен в процесс', { variant: 'success' }); setProcessTeachers(prev => [...prev, t]); }).catch(enqueueSnackbarError)} disabled={addState.isLoading}>Добавить</Button>
              )}
            </ListItemSecondaryAction>
          </ListItem>
        ))}
      </AppList>

      <Typography variant="subtitle2" sx={{ mt: 2, mb: 1 }}>Преподаватели в процессе</Typography>
      <AppList isLoading={false} isEmpty={(processTeachers ?? []).length === 0} height="28vh">
        {(processTeachers ?? []).map((t: any) => (
          <ListItem key={t.id} divider>
            <ListItemText primary={`${t.lastName} ${t.firstName} ${t.middleName ?? ''}`} secondary={t.position} />
            <ListItemSecondaryAction>
              <Button size="small" color="error" onClick={() => removeTeacherFromProcess({ apiDiplomaProcessesTeachersRemoveRequestDto: { diplomaProcessId, userId: t.id } }).unwrap().then(() => { enqueueSnackbar('Преподаватель удален из процесса', { variant: 'success' }); setProcessTeachers(prev => prev.filter(x => x.id !== t.id)); }).catch(enqueueSnackbarError)} disabled={removeState.isLoading}>Удалить</Button>
            </ListItemSecondaryAction>
          </ListItem>
        ))}
      </AppList>
    </Box>
  );
};

export default DiplomaTeachersPage;


