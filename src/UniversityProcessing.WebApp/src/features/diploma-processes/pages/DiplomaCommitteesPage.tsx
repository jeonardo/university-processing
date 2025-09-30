import React, { useEffect, useState } from 'react';
import { Box, Button, Chip, Dialog, DialogActions, DialogContent, DialogTitle, IconButton, List, ListItem, ListItemText, TextField, Typography } from '@mui/material';
import { Add as AddIcon, Delete as DeleteIcon } from '@mui/icons-material';
import { useParams } from 'react-router-dom';
import AppList from 'src/components/lists/AppList';
import AppListSearch from 'src/components/lists/AppListSearch';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import {
  useLazyGetApiDiplomaProcessesCommitteesGetQuery,
  usePostApiDiplomaProcessesCommitteesCreateMutation,
  usePutApiDiplomaProcessesCommitteesRemoveTeacherMutation,
  useDeleteApiDiplomaProcessesCommitteesDeleteMutation
} from 'src/api/backendApi';

const DiplomaCommitteesPage: React.FC = () => {
  const { id } = useParams();
  const diplomaProcessId = id as string;

  const [search, setSearch] = useState('');
  const [getCommittees, committeesState] = useLazyGetApiDiplomaProcessesCommitteesGetQuery({ pollingInterval: 15000 });
  const [createCommittee, createCommitteeState] = usePostApiDiplomaProcessesCommitteesCreateMutation();
  const [removeCommitteeTeacher] = usePutApiDiplomaProcessesCommitteesRemoveTeacherMutation();
  const [deleteCommittee, deleteCommitteeState] = useDeleteApiDiplomaProcessesCommitteesDeleteMutation();

  const [isCreateOpen, setIsCreateOpen] = useState(false);
  const [committeeName, setCommitteeName] = useState('');

  useEffect(() => {
    if (!diplomaProcessId) return;
    getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
  }, [diplomaProcessId, search, getCommittees]);

  const committees = committeesState.data?.items ?? [];

  const handleCreate = async () => {
    try {
      await createCommittee({ apiDiplomaProcessesCommitteesCreateRequestDto: { diplomaProcessId, name: committeeName } }).unwrap();
      enqueueSnackbar('Комитет создан', { variant: 'success' });
      setCommitteeName('');
      setIsCreateOpen(false);
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleDelete = async (committeeId: string) => {
    try {
      await deleteCommittee({ apiDiplomaProcessesCommitteesDeleteRequestDto: { committeeId } }).unwrap();
      enqueueSnackbar('Комитет удален', { variant: 'success' });
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleChipDelete = async (teacherId: string) => {
    try {
      await removeCommitteeTeacher({ apiDiplomaProcessesCommitteesRemoveTeacherRequestDto: { diplomaProcessId, userId: teacherId } }).unwrap();
      enqueueSnackbar('Преподаватель удален из комитета', { variant: 'success' });
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: search });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  return (
    <Box>
      <AppListSearch label="Поиск" placeholder="Название комитета" onSearchValueChangedDebounced={setSearch} />
      <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 1 }}>
        <Button startIcon={<AddIcon />} variant="contained" onClick={() => setIsCreateOpen(true)}>Создать комитет</Button>
      </Box>
      <AppList isLoading={committeesState.isLoading} isEmpty={committees.length === 0} height="60vh">
        {committees.map((c: any) => (
          <ListItem key={c.id} divider alignItems="flex-start">
            <ListItemText
              primary={c.name}
              secondary={
                <Box sx={{ mt: 0.5, display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
                  {(c.teachers ?? []).map((t: any) => (
                    <Chip key={t.id} label={`${t.lastName} ${t.firstName}`} onDelete={() => handleChipDelete(t.id)} />
                  ))}
                </Box>
              }
            />
            <IconButton color="error" onClick={() => handleDelete(c.id)} disabled={deleteCommitteeState.isLoading}>
              <DeleteIcon />
            </IconButton>
          </ListItem>
        ))}
      </AppList>

      <Dialog open={isCreateOpen} onClose={() => setIsCreateOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Создать комитет</DialogTitle>
        <DialogContent>
          <TextField fullWidth label="Название" value={committeeName} onChange={(e) => setCommitteeName(e.target.value)} sx={{ mt: 2 }} />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsCreateOpen(false)}>Отмена</Button>
          <Button variant="contained" onClick={handleCreate} disabled={!committeeName.trim() || createCommitteeState.isLoading}>Создать</Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};

export default DiplomaCommitteesPage;


