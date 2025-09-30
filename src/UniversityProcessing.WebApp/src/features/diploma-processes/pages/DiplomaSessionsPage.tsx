import React, { useEffect, useState } from 'react';
import { Box, Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, IconButton, InputLabel, List, ListItem, ListItemSecondaryAction, ListItemText, MenuItem, Select, TextField, Typography } from '@mui/material';
import { Add as AddIcon, Delete as DeleteIcon } from '@mui/icons-material';
import { useParams } from 'react-router-dom';
import AppList from 'src/components/lists/AppList';
import AppListSearch from 'src/components/lists/AppListSearch';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import {
  useLazyGetApiDiplomaProcessesDefenseSessionsGetPageQuery,
  usePostApiDiplomaProcessesDefenseSessionsCreateMutation,
  useDeleteApiDiplomaProcessesDefenseSessionsDeleteMutation,
  useLazyGetApiDiplomaProcessesCommitteesGetQuery,
  useGetApiDiplomaProcessesDefenseSessionsGetFreeStudentsQuery
} from 'src/api/backendApi';

const DiplomaSessionsPage: React.FC = () => {
  const { id } = useParams();
  const diplomaProcessId = id as string;

  const [search, setSearch] = useState('');
  const [getSessions, sessionsState] = useLazyGetApiDiplomaProcessesDefenseSessionsGetPageQuery({ pollingInterval: 15000 });
  const [createSession, createSessionState] = usePostApiDiplomaProcessesDefenseSessionsCreateMutation();
  const [deleteSession, deleteSessionState] = useDeleteApiDiplomaProcessesDefenseSessionsDeleteMutation();
  const [getCommittees, committeesState] = useLazyGetApiDiplomaProcessesCommitteesGetQuery();
  const { data: freeStudentsData } = useGetApiDiplomaProcessesDefenseSessionsGetFreeStudentsQuery({ diplomaProcessId }, { skip: !diplomaProcessId });

  const sessions = sessionsState.data?.items ?? [];
  const committees = committeesState.data?.items ?? [];

  const [isCreateOpen, setIsCreateOpen] = useState(false);
  const [name, setName] = useState('');
  const [date, setDate] = useState('');
  const [committeeId, setCommitteeId] = useState('');
  const [studentIds, setStudentIds] = useState<string[]>([]);

  useEffect(() => {
    if (!diplomaProcessId) return;
    getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
    getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50 });
  }, [diplomaProcessId, search, getSessions, getCommittees]);

  const handleCreate = async () => {
    try {
      await createSession({ apiDiplomaProcessesDefenseSessionsCreateRequestDto: { name, date, committeeId, diplomaProcessId, studentIds } }).unwrap();
      enqueueSnackbar('Сессия защиты создана', { variant: 'success' });
      setIsCreateOpen(false);
      setName(''); setDate(''); setCommitteeId(''); setStudentIds([]);
      getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
    } catch (e: any) { enqueueSnackbarError(e); }
  };

  const handleDelete = async (id: string) => {
    try {
      await deleteSession({ apiDiplomaProcessesDefenseSessionsDeleteRequestDto: { id } }).unwrap();
      enqueueSnackbar('Сессия защиты удалена', { variant: 'success' });
      getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
    } catch (e: any) { enqueueSnackbarError(e); }
  };

  return (
    <Box>
      <AppListSearch label="Поиск" placeholder="Фильтр по дате/комитету" onSearchValueChangedDebounced={setSearch} />
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 1 }}>
        <Button startIcon={<AddIcon />} variant="contained" onClick={() => setIsCreateOpen(true)}>Создать сессию</Button>
      </Box>
      <AppList isLoading={sessionsState.isLoading} isEmpty={sessions.length === 0} height="60vh">
        {sessions.map((s: any) => (
          <ListItem key={s.id} divider>
            <ListItemText primary={`${s.date} • ${s.committeeName}`} secondary={`ID: ${s.id}`} />
            <ListItemSecondaryAction>
              <IconButton color="error" onClick={() => handleDelete(s.id)} disabled={deleteSessionState.isLoading}>
                <DeleteIcon />
              </IconButton>
            </ListItemSecondaryAction>
          </ListItem>
        ))}
      </AppList>

      <Dialog open={isCreateOpen} onClose={() => setIsCreateOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Создать сессию защиты</DialogTitle>
        <DialogContent>
          <TextField fullWidth label="Название" value={name} onChange={(e) => setName(e.target.value)} sx={{ mt: 2 }} />
          <TextField fullWidth type="datetime-local" label="Дата и время" value={date} onChange={(e) => setDate(e.target.value)} sx={{ mt: 2 }} InputLabelProps={{ shrink: true }} />
          <FormControl fullWidth sx={{ mt: 2 }}>
            <InputLabel>Комитет</InputLabel>
            <Select value={committeeId} onChange={(e) => setCommitteeId(e.target.value)}>
              {committees.map((c: any) => (<MenuItem key={c.id} value={c.id}>{c.name}</MenuItem>))}
            </Select>
          </FormControl>
          <FormControl fullWidth sx={{ mt: 2 }}>
            <InputLabel>Студенты</InputLabel>
            <Select multiple value={studentIds} onChange={(e) => setStudentIds(e.target.value as string[])} renderValue={(v) => (v as string[]).length + ' выбрано'}>
              {(freeStudentsData?.students ?? []).map(s => (<MenuItem key={s.id} value={s.id}>{s.lastName} {s.firstName} ({s.groupNumber})</MenuItem>))}
            </Select>
          </FormControl>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsCreateOpen(false)}>Отмена</Button>
          <Button variant="contained" onClick={handleCreate} disabled={!name.trim() || !date || !committeeId || createSessionState.isLoading}>Создать</Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};

export default DiplomaSessionsPage;


