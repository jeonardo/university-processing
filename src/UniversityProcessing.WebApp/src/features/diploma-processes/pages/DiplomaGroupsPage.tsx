import React, { useEffect, useState } from 'react';
import { Box, Button, ListItem, ListItemSecondaryAction, ListItemText, Typography } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import AppListSearch from 'src/components/lists/AppListSearch';
import { useAppSelector } from 'src/core/hooks';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useParams } from 'react-router-dom';
import {
  useLazyGetApiDiplomaProcessesGroupsGetFullDescriptionQuery,
  usePutApiDiplomaProcessesGroupsAddMutation,
  usePutApiDiplomaProcessesGroupsRemoveMutation,
  useLazyGetApiGroupsGetQuery
} from 'src/api/backendApi';

const DiplomaGroupsPage: React.FC = () => {
  const { id } = useParams();
  const diplomaProcessId = id as string;
  const selectedPeriod = useAppSelector(state => state.period.SelectedPeriod);

  const [search, setSearch] = useState('');
  const [getProcessGroups] = useLazyGetApiDiplomaProcessesGroupsGetFullDescriptionQuery();
  const [addGroupToProcess, addState] = usePutApiDiplomaProcessesGroupsAddMutation();
  const [removeGroupFromProcess, removeState] = usePutApiDiplomaProcessesGroupsRemoveMutation();
  const [getGroups] = useLazyGetApiGroupsGetQuery();

  const [processGroups, setProcessGroups] = useState<any[]>([]);
  const [allGroups, setAllGroups] = useState<any[]>([]);

  useEffect(() => {
    if (!diplomaProcessId) return;
    getProcessGroups({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search }).then(r => setProcessGroups(r.data?.items ?? []));
    if (selectedPeriod?.id) {
      getGroups({ periodId: selectedPeriod.id, pageNumber: 1, pageSize: 100, filter: search, orderBy: 'number', desc: false }).then(r => setAllGroups(r.data?.items ?? []));
    }
  }, [diplomaProcessId, selectedPeriod?.id, search, getProcessGroups, getGroups]);

  return (
    <Box>
      <AppListSearch label="Поиск" placeholder="Номер группы" onSearchValueChangedDebounced={setSearch} />
      <Typography variant="subtitle2" sx={{ mt: 1, mb: 1 }}>Все группы периода</Typography>
      <AppList isLoading={false} isEmpty={(allGroups ?? []).length === 0} height="28vh">
        {(allGroups ?? []).map((g: any) => (
          <ListItem key={g.id} divider>
            <ListItemText primary={g.number} secondary={`ID: ${g.id}`} />
            <ListItemSecondaryAction>
              {processGroups.some(pg => pg.id === g.id) ? (
                <Button size="small" color="error" onClick={() => removeGroupFromProcess({ apiDiplomaProcessesGroupsRemoveRequestDto: { diplomaProcessId, groupId: g.id } }).unwrap().then(() => { enqueueSnackbar('Группа удалена из процесса', { variant: 'success' }); setProcessGroups(prev => prev.filter(x => x.id !== g.id)); }).catch(enqueueSnackbarError)} disabled={removeState.isLoading}>Удалить</Button>
              ) : (
                <Button size="small" variant="contained" onClick={() => addGroupToProcess({ apiDiplomaProcessesGroupsAddRequestDto: { diplomaProcessId, groupId: g.id } }).unwrap().then(() => { enqueueSnackbar('Группа добавлена в процесс', { variant: 'success' }); setProcessGroups(prev => [...prev, g]); }).catch(enqueueSnackbarError)} disabled={addState.isLoading}>Добавить</Button>
              )}
            </ListItemSecondaryAction>
          </ListItem>
        ))}
      </AppList>

      <Typography variant="subtitle2" sx={{ mt: 2, mb: 1 }}>Группы в процессе</Typography>
      <AppList isLoading={false} isEmpty={(processGroups ?? []).length === 0} height="28vh">
        {(processGroups ?? []).map((g: any) => (
          <ListItem key={g.id} divider>
            <ListItemText primary={g.number} secondary={`ID: ${g.id}`} />
            <ListItemSecondaryAction>
              <Button size="small" color="error" onClick={() => removeGroupFromProcess({ apiDiplomaProcessesGroupsRemoveRequestDto: { diplomaProcessId, groupId: g.id } }).unwrap().then(() => { enqueueSnackbar('Группа удалена из процесса', { variant: 'success' }); setProcessGroups(prev => prev.filter(x => x.id !== g.id)); }).catch(enqueueSnackbarError)} disabled={removeState.isLoading}>Удалить</Button>
            </ListItemSecondaryAction>
          </ListItem>
        ))}
      </AppList>
    </Box>
  );
};

export default DiplomaGroupsPage;


