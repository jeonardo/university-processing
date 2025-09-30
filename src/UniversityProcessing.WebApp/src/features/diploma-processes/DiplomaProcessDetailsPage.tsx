import React, { useEffect, useMemo, useState } from 'react';
import {
  Box,
  Button,
  Chip,
  Container,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Divider,
  FormControl,
  Grid,
  IconButton,
  InputLabel,
  List,
  ListItem,
  ListItemSecondaryAction,
  ListItemText,
  MenuItem,
  Select,
  Tab,
  Tabs,
  TextField,
  Typography
} from '@mui/material';
import {
  Delete as DeleteIcon,
  Add as AddIcon
} from '@mui/icons-material';
import { useNavigate, useParams } from 'react-router-dom';
import {
  useLazyGetApiDiplomaProcessesDiplomasGetQuery,
  useLazyGetApiDiplomaProcessesCommitteesGetQuery,
  usePostApiDiplomaProcessesCommitteesCreateMutation,
  usePutApiDiplomaProcessesCommitteesAddTeacherMutation,
  usePutApiDiplomaProcessesCommitteesRemoveTeacherMutation,
  useDeleteApiDiplomaProcessesCommitteesDeleteMutation,
  useLazyGetApiDiplomaProcessesTeachersGetQuery,
  usePutApiDiplomaProcessesTeachersAddMutation,
  usePutApiDiplomaProcessesTeachersRemoveMutation,
  useLazyGetApiDiplomaProcessesGroupsGetFullDescriptionQuery,
  usePutApiDiplomaProcessesGroupsAddMutation,
  usePutApiDiplomaProcessesGroupsRemoveMutation,
  useLazyGetApiGroupsGetQuery,
  useLazyGetApiUsersGetTeachersQuery,
  useLazyGetApiDiplomaProcessesDefenseSessionsGetPageQuery,
  usePostApiDiplomaProcessesDefenseSessionsCreateMutation,
  useDeleteApiDiplomaProcessesDefenseSessionsDeleteMutation,
  useGetApiDiplomaProcessesDefenseSessionsGetFreeStudentsQuery
} from 'src/api/backendApi';
import AppList from 'src/components/lists/AppList';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppListSearch from 'src/components/lists/AppListSearch';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useAppSelector } from 'src/core/hooks';

const DiplomaProcessDetailsPage: React.FC = () => {
  const params = useParams();
  const navigate = useNavigate();
  const diplomaProcessId = params.id as string;
  const selectedPeriod = useAppSelector(state => state.period.SelectedPeriod);

  const [tab, setTab] = useState(0);

  const [pageNumber, setPageNumber] = useState(1);
  const [diplomasSearch, setDiplomasSearch] = useState('');
  const [committeesSearch, setCommitteesSearch] = useState('');
  const [sessionsSearch, setSessionsSearch] = useState('');
  const [groupsSearch, setGroupsSearch] = useState('');
  const [teachersSearch, setTeachersSearch] = useState('');

  // Diplomas
  const [getDiplomas, diplomasState] = useLazyGetApiDiplomaProcessesDiplomasGetQuery({ pollingInterval: 15000 });

  // Committees
  const [getCommittees, committeesState] = useLazyGetApiDiplomaProcessesCommitteesGetQuery({ pollingInterval: 15000 });
  const [createCommittee, createCommitteeState] = usePostApiDiplomaProcessesCommitteesCreateMutation();
  const [addCommitteeTeacher, addCommitteeTeacherState] = usePutApiDiplomaProcessesCommitteesAddTeacherMutation();
  const [removeCommitteeTeacher, removeCommitteeTeacherState] = usePutApiDiplomaProcessesCommitteesRemoveTeacherMutation();
  const [deleteCommittee, deleteCommitteeState] = useDeleteApiDiplomaProcessesCommitteesDeleteMutation();
  const [getProcessTeachers] = useLazyGetApiDiplomaProcessesTeachersGetQuery();
  const [addTeacherToProcess, addTeacherToProcessState] = usePutApiDiplomaProcessesTeachersAddMutation();
  const [removeTeacherFromProcess, removeTeacherFromProcessState] = usePutApiDiplomaProcessesTeachersRemoveMutation();
  const [getProcessGroups] = useLazyGetApiDiplomaProcessesGroupsGetFullDescriptionQuery();
  const [addGroupToProcess, addGroupToProcessState] = usePutApiDiplomaProcessesGroupsAddMutation();
  const [removeGroupFromProcess, removeGroupFromProcessState] = usePutApiDiplomaProcessesGroupsRemoveMutation();
  const [getGroups] = useLazyGetApiGroupsGetQuery();
  const [getTeachersList] = useLazyGetApiUsersGetTeachersQuery();

  // Defense sessions
  const [getSessions, sessionsState] = useLazyGetApiDiplomaProcessesDefenseSessionsGetPageQuery({ pollingInterval: 15000 });
  const [createSession, createSessionState] = usePostApiDiplomaProcessesDefenseSessionsCreateMutation();
  const [deleteSession, deleteSessionState] = useDeleteApiDiplomaProcessesDefenseSessionsDeleteMutation();

  // Create committee dialog
  const [isCreateCommitteeOpen, setIsCreateCommitteeOpen] = useState(false);
  const [committeeName, setCommitteeName] = useState('');

  // Manage committee dialog
  const [isManageCommitteeOpen, setIsManageCommitteeOpen] = useState(false);
  const [selectedCommitteeId, setSelectedCommitteeId] = useState<string | null>(null);
  const [processTeachers, setProcessTeachers] = useState<any[]>([]);
  const [selectedTeacherId, setSelectedTeacherId] = useState('');

  // Create session dialog
  const [isCreateSessionOpen, setIsCreateSessionOpen] = useState(false);
  const [sessionName, setSessionName] = useState('');
  const [sessionDate, setSessionDate] = useState('');
  const [sessionCommitteeId, setSessionCommitteeId] = useState('');
  const [selectedStudentIds, setSelectedStudentIds] = useState<string[]>([]);
  const { data: freeStudentsData } = useGetApiDiplomaProcessesDefenseSessionsGetFreeStudentsQuery({ diplomaProcessId }, { skip: !diplomaProcessId });

  const committees = committeesState.data?.items ?? [];
  const diplomas = diplomasState.data?.items ?? [];
  const sessions = sessionsState.data?.items ?? [];
  const [processGroups, setProcessGroups] = useState<any[]>([]);
  const [processTeachersList, setProcessTeachersList] = useState<any[]>([]);
  const [allGroups, setAllGroups] = useState<any[]>([]);
  const [allTeachers, setAllTeachers] = useState<any[]>([]);

  useEffect(() => {
    if (!diplomaProcessId) return;
    // initial loads per tab
    getDiplomas({ diplomaProcessId, pageNumber: 1, pageSize: 25, filter: diplomasSearch });
    getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: committeesSearch });
    getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: sessionsSearch } as any);
    // process groups/teachers
    getProcessGroups({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: groupsSearch })
      .then(r => setProcessGroups(r.data?.items ?? []));
    getProcessTeachers({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: teachersSearch })
      .then(r => setProcessTeachersList(r.data?.items ?? []));
    // sources for add dialogs
    if (selectedPeriod?.id) {
      getGroups({ periodId: selectedPeriod.id, pageNumber: 1, pageSize: 100, filter: groupsSearch, orderBy: 'number', desc: false })
        .then(r => setAllGroups(r.data?.items ?? []));
    }
    getTeachersList({ pageNumber: 1, pageSize: 100, filter: teachersSearch, orderBy: 'lastName', desc: false })
      .then(r => setAllTeachers(r.data?.list?.items ?? []));
  }, [diplomaProcessId, getDiplomas, getCommittees, getSessions]);

  useEffect(() => {
    if (!diplomaProcessId) return;
    getDiplomas({ diplomaProcessId, pageNumber, pageSize: 25, filter: diplomasSearch });
  }, [pageNumber, diplomasSearch, diplomaProcessId, getDiplomas]);

  const handleCreateCommittee = async () => {
    try {
      await createCommittee({ apiDiplomaProcessesCommitteesCreateRequestDto: { diplomaProcessId, name: committeeName } }).unwrap();
      enqueueSnackbar('Комитет создан', { variant: 'success' });
      setCommitteeName('');
      setIsCreateCommitteeOpen(false);
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50 });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const openManageCommittee = async (committeeId: string) => {
    setSelectedCommitteeId(committeeId);
    setIsManageCommitteeOpen(true);
    try {
      const r = await getProcessTeachers({ diplomaProcessId, pageNumber: 1, pageSize: 100 });
      setProcessTeachers(r.data?.items ?? []);
    } catch {}
  };

  const handleAddTeacherToCommittee = async () => {
    if (!selectedCommitteeId || !selectedTeacherId) return;
    try {
      await addCommitteeTeacher({ apiDiplomaProcessesCommitteesAddTeacherRequestDto: { diplomaProcessId, committeeId: selectedCommitteeId, userId: selectedTeacherId } }).unwrap();
      enqueueSnackbar('Преподаватель добавлен в комитет', { variant: 'success' });
      setSelectedTeacherId('');
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50 });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleRemoveTeacherFromCommittee = async (teacherId: string) => {
    if (!selectedCommitteeId) return;
    try {
      await removeCommitteeTeacher({ apiDiplomaProcessesCommitteesRemoveTeacherRequestDto: { diplomaProcessId, userId: teacherId } }).unwrap();
      enqueueSnackbar('Преподаватель удален из комитета', { variant: 'success' });
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50 });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleDeleteCommittee = async (committeeId: string) => {
    try {
      await deleteCommittee({ apiDiplomaProcessesCommitteesDeleteRequestDto: { committeeId } }).unwrap();
      enqueueSnackbar('Комитет удален', { variant: 'success' });
      getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50 });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleCreateSession = async () => {
    if (!sessionName || !sessionDate || !sessionCommitteeId) return;
    try {
      await createSession({ apiDiplomaProcessesDefenseSessionsCreateRequestDto: { name: sessionName, date: sessionDate, committeeId: sessionCommitteeId, diplomaProcessId, studentIds: selectedStudentIds } }).unwrap();
      enqueueSnackbar('Сессия защиты создана', { variant: 'success' });
      setIsCreateSessionOpen(false);
      setSessionName('');
      setSessionDate('');
      setSessionCommitteeId('');
      setSelectedStudentIds([]);
      getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50 } as any);
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleDeleteSession = async (id: string) => {
    try {
      await deleteSession({ apiDiplomaProcessesDefenseSessionsDeleteRequestDto: { id } }).unwrap();
      enqueueSnackbar('Сессия защиты удалена', { variant: 'success' });
      getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50 } as any);
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleDiplomasSearchChange = (value: string) => { setPageNumber(1); setDiplomasSearch(value); };
  const handleCommitteesSearchChange = (value: string) => { setCommitteesSearch(value); getCommittees({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: value }); };
  const handleSessionsSearchChange = (value: string) => { setSessionsSearch(value); getSessions({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: value } as any); };
  const handleGroupsSearchChange = (value: string) => {
    setGroupsSearch(value);
    getProcessGroups({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: value }).then(r => setProcessGroups(r.data?.items ?? []));
    if (selectedPeriod?.id) {
      getGroups({ periodId: selectedPeriod.id, pageNumber: 1, pageSize: 100, filter: value, orderBy: 'number', desc: false }).then(r => setAllGroups(r.data?.items ?? []));
    }
  };
  const handleTeachersSearchChange = (value: string) => {
    setTeachersSearch(value);
    getProcessTeachers({ diplomaProcessId, pageNumber: 1, pageSize: 50, filter: value }).then(r => setProcessTeachersList(r.data?.items ?? []));
    getTeachersList({ pageNumber: 1, pageSize: 100, filter: value, orderBy: 'lastName', desc: false }).then(r => setAllTeachers(r.data?.list?.items ?? []));
  };

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="lg">
      <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
        <Typography variant="h4" component="h1" className="font-bold">Дипломный процесс</Typography>
        <Button onClick={() => navigate(-1)}>Назад</Button>
      </Box>

      <Tabs value={tab} onChange={(_, v) => setTab(v)} sx={{ mb: 1 }}>
        <Tab label="Комитеты" />
        <Tab label="Сессии защиты" />
        <Tab label="Дипломы" />
        <Tab label="Группы" />
        <Tab label="Преподаватели" />
      </Tabs>

      {tab === 2 && (
        <Box>
          <AppListSearch label="Поиск" placeholder="ФИО студента или тема" onSearchValueChangedDebounced={handleDiplomasSearchChange} />
          <AppList isLoading={diplomasState.isLoading} isEmpty={(diplomas?.length ?? 0) === 0} height="60vh">
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
      )}

      {tab === 0 && (
        <Box>
          <AppListSearch label="Поиск" placeholder="Название комитета" onSearchValueChangedDebounced={handleCommitteesSearchChange} />
          <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 1 }}>
            <Button startIcon={<AddIcon />} variant="contained" onClick={() => setIsCreateCommitteeOpen(true)}>Создать комитет</Button>
          </Box>
          <List>
            {committees.map((c: any) => (
              <ListItem key={c.id} divider alignItems="flex-start">
                <ListItemText
                  primary={c.name}
                  secondary={
                    <Box sx={{ mt: 0.5, display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
                      {(c.teachers ?? []).map((t: any) => (
                        <Chip key={t.id} label={`${t.lastName} ${t.firstName}`} onDelete={() => handleRemoveTeacherFromCommittee(t.id)} />
                      ))}
                    </Box>
                  }
                />
                <Box sx={{ display: 'flex', gap: 1 }}>
                  <Button size="small" onClick={() => openManageCommittee(c.id)}>Управлять</Button>
                  <IconButton color="error" onClick={() => handleDeleteCommittee(c.id)} disabled={deleteCommitteeState.isLoading}>
                    <DeleteIcon />
                  </IconButton>
                </Box>
              </ListItem>
            ))}
            {committees.length === 0 && (
              <Typography color="text.secondary">Комитеты отсутствуют</Typography>
            )}
          </List>
        </Box>
      )}

      {tab === 1 && (
        <Box>
          <AppListSearch label="Поиск" placeholder="Фильтр по дате/комитету" onSearchValueChangedDebounced={handleSessionsSearchChange} />
          <Box sx={{ display: 'flex', justifyContent: 'flex-end', mb: 1 }}>
            <Button startIcon={<AddIcon />} variant="contained" onClick={() => setIsCreateSessionOpen(true)}>Создать сессию</Button>
          </Box>
          <List>
            {sessions.map((s: any) => (
              <ListItem key={s.id} divider>
                <ListItemText primary={`${s.date} • ${s.committeeName}`} secondary={`ID: ${s.id}`} />
                <ListItemSecondaryAction>
                  <IconButton color="error" onClick={() => handleDeleteSession(s.id)} disabled={deleteSessionState.isLoading}>
                    <DeleteIcon />
                  </IconButton>
                </ListItemSecondaryAction>
              </ListItem>
            ))}
            {sessions.length === 0 && (
              <Typography color="text.secondary">Сессии отсутствуют</Typography>
            )}
          </List>
        </Box>
      )}

      {tab === 3 && (
        <Box>
          <AppListSearch label="Поиск" placeholder="Номер группы" onSearchValueChangedDebounced={handleGroupsSearchChange} />
          <Box sx={{ display: 'flex', gap: 1, alignItems: 'center', mb: 1 }}>
            <FormControl fullWidth>
              <InputLabel>Выберите группу</InputLabel>
              <Select value={''} onChange={() => {}} renderValue={() => 'Выберите группу из списка ниже'}>
                <MenuItem value="" disabled>Выберите группу</MenuItem>
              </Select>
            </FormControl>
          </Box>
          <List>
            {(allGroups ?? []).map((g: any) => (
              <ListItem key={g.id} divider>
                <ListItemText primary={g.number} secondary={`ID: ${g.id}`} />
                <ListItemSecondaryAction>
                  {processGroups.some(pg => pg.id === g.id) ? (
                    <Button size="small" color="error" onClick={() => removeGroupFromProcess({ apiDiplomaProcessesGroupsRemoveRequestDto: { diplomaProcessId, groupId: g.id } }).unwrap().then(() => { enqueueSnackbar('Группа удалена из процесса', { variant: 'success' }); setProcessGroups(prev => prev.filter(x => x.id !== g.id)); }).catch(enqueueSnackbarError)} disabled={removeGroupFromProcessState.isLoading}>Удалить</Button>
                  ) : (
                    <Button size="small" variant="contained" onClick={() => addGroupToProcess({ apiDiplomaProcessesGroupsAddRequestDto: { diplomaProcessId, groupId: g.id } }).unwrap().then(() => { enqueueSnackbar('Группа добавлена в процесс', { variant: 'success' }); setProcessGroups(prev => [...prev, g]); }).catch(enqueueSnackbarError)} disabled={addGroupToProcessState.isLoading}>Добавить</Button>
                  )}
                </ListItemSecondaryAction>
              </ListItem>
            ))}
            {(allGroups ?? []).length === 0 && (
              <Typography color="text.secondary">Группы не найдены</Typography>
            )}
          </List>
        </Box>
      )}

      {tab === 4 && (
        <Box>
          <AppListSearch label="Поиск" placeholder="Фамилия преподавателя" onSearchValueChangedDebounced={handleTeachersSearchChange} />
          <List>
            {(allTeachers ?? []).map((t: any) => (
              <ListItem key={t.id} divider>
                <ListItemText primary={`${t.lastName} ${t.firstName} ${t.middleName ?? ''}`} secondary={t.position} />
                <ListItemSecondaryAction>
                  {processTeachersList.some(pt => pt.id === t.id) ? (
                    <Button size="small" color="error" onClick={() => removeTeacherFromProcess({ apiDiplomaProcessesTeachersRemoveRequestDto: { diplomaProcessId, userId: t.id } }).unwrap().then(() => { enqueueSnackbar('Преподаватель удален из процесса', { variant: 'success' }); setProcessTeachersList(prev => prev.filter(x => x.id !== t.id)); }).catch(enqueueSnackbarError)} disabled={removeTeacherFromProcessState.isLoading}>Удалить</Button>
                  ) : (
                    <Button size="small" variant="contained" onClick={() => addTeacherToProcess({ apiDiplomaProcessesTeachersAddRequestDto: { diplomaProcessId, userId: t.id } }).unwrap().then(() => { enqueueSnackbar('Преподаватель добавлен в процесс', { variant: 'success' }); setProcessTeachersList(prev => [...prev, t]); }).catch(enqueueSnackbarError)} disabled={addTeacherToProcessState.isLoading}>Добавить</Button>
                  )}
                </ListItemSecondaryAction>
              </ListItem>
            ))}
            {(allTeachers ?? []).length === 0 && (
              <Typography color="text.secondary">Преподаватели не найдены</Typography>
            )}
          </List>
        </Box>
      )}

      {/* Create committee dialog */}
      <Dialog open={isCreateCommitteeOpen} onClose={() => setIsCreateCommitteeOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Создать комитет</DialogTitle>
        <DialogContent>
          <TextField fullWidth label="Название" value={committeeName} onChange={(e) => setCommitteeName(e.target.value)} sx={{ mt: 2 }} />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsCreateCommitteeOpen(false)}>Отмена</Button>
          <Button variant="contained" onClick={handleCreateCommittee} disabled={!committeeName.trim() || createCommitteeState.isLoading}>Создать</Button>
        </DialogActions>
      </Dialog>

      {/* Manage committee dialog */}
      <Dialog open={isManageCommitteeOpen} onClose={() => setIsManageCommitteeOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Управление комитетом</DialogTitle>
        <DialogContent>
          <FormControl fullWidth sx={{ mt: 2 }}>
            <InputLabel>Преподаватель</InputLabel>
            <Select value={selectedTeacherId} onChange={(e) => setSelectedTeacherId(e.target.value)}>
              {processTeachers.map((t: any) => (
                <MenuItem key={t.id} value={t.id}>{t.lastName} {t.firstName} {t.middleName ?? ''}</MenuItem>
              ))}
            </Select>
          </FormControl>
          <Box sx={{ display: 'flex', justifyContent: 'flex-end', mt: 2 }}>
            <Button onClick={handleAddTeacherToCommittee} variant="contained" disabled={!selectedTeacherId || addCommitteeTeacherState.isLoading}>Добавить в комитет</Button>
          </Box>
          <Divider sx={{ my: 2 }} />
          <Typography variant="body2" color="text.secondary">Чтобы удалить преподавателя из комитета, выберите его на карточке комитета после обновления списка.</Typography>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsManageCommitteeOpen(false)}>Закрыть</Button>
        </DialogActions>
      </Dialog>

      {/* Create defense session dialog */}
      <Dialog open={isCreateSessionOpen} onClose={() => setIsCreateSessionOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Создать сессию защиты</DialogTitle>
        <DialogContent>
          <TextField fullWidth label="Название" value={sessionName} onChange={(e) => setSessionName(e.target.value)} sx={{ mt: 2 }} />
          <TextField fullWidth type="datetime-local" label="Дата и время" value={sessionDate} onChange={(e) => setSessionDate(e.target.value)} sx={{ mt: 2 }} InputLabelProps={{ shrink: true }} />
          <FormControl fullWidth sx={{ mt: 2 }}>
            <InputLabel>Комитет</InputLabel>
            <Select value={sessionCommitteeId} onChange={(e) => setSessionCommitteeId(e.target.value)}>
              {committees.map((c: any) => (
                <MenuItem key={c.id} value={c.id}>{c.name}</MenuItem>
              ))}
            </Select>
          </FormControl>
          <FormControl fullWidth sx={{ mt: 2 }}>
            <InputLabel>Студенты</InputLabel>
            <Select
              multiple
              value={selectedStudentIds}
              onChange={(e) => setSelectedStudentIds(e.target.value as string[])}
              renderValue={(selected) => (selected as string[]).length + ' выбрано'}
            >
              {(freeStudentsData?.students ?? []).map(s => (
                <MenuItem key={s.id} value={s.id}>{s.lastName} {s.firstName} ({s.groupNumber})</MenuItem>
              ))}
            </Select>
          </FormControl>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsCreateSessionOpen(false)}>Отмена</Button>
          <Button variant="contained" onClick={handleCreateSession} disabled={!sessionName.trim() || !sessionDate || !sessionCommitteeId || createSessionState.isLoading}>Создать</Button>
        </DialogActions>
      </Dialog>
    </Container>
  );
};

export default DiplomaProcessDetailsPage;


