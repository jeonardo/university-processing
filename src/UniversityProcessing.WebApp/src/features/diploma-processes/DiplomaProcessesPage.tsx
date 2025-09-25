import React, { useEffect, useState } from 'react';
import {
  Box,
  Button,
  Container,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Paper,
  Typography,
  Chip,
  IconButton,
  Tooltip,
  Divider,
  Grid,
  Card,
  CardContent,
  CardActions,
  List,
  ListItem,
  ListItemText,
  ListItemSecondaryAction,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Alert
} from '@mui/material';
import {
  Add as AddIcon,
  Delete as DeleteIcon,
  School as SchoolIcon,
  PersonAdd as PersonAddIcon,
  GroupAdd as GroupAddIcon,
  PersonRemove as PersonRemoveIcon,
  GroupRemove as GroupRemoveIcon,
  Assignment as AssignmentIcon
} from '@mui/icons-material';
import AppList from 'src/components/lists/AppList';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppListSearch from 'src/components/lists/AppListSearch';
import {
  ApiDiplomaProcessesGetDiplomaProcessDto,
  ApiContractsUserRoleTypeDto,
  useDeleteApiDiplomaProcessesDeleteMutation,
  useLazyGetApiDiplomaProcessesGetQuery,
  usePostApiDiplomaProcessesCreateMutation,
  usePostApiDiplomaProcessesUsersAddGroupMutation,
  usePostApiDiplomaProcessesUsersAddTeacherMutation,
  usePostApiDiplomaProcessesUsersRemoveGroupMutation,
  usePostApiDiplomaProcessesUsersRemoveTeacherMutation,
  useLazyGetApiGroupsGetQuery,
  useLazyGetApiUsersGetTeachersQuery
} from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';

interface DiplomaProcessFormData {
  name: string;
  periodId: string;
}

interface UserManagementData {
  diplomaProcessId: string;
  groupId?: string;
  userId?: string;
}

const DiplomaProcessesPage: React.FC = () => {
  const user = useAppSelector(state => state.auth.user);
  const selectedPeriod = useAppSelector(state => state.period.SelectedPeriod);

  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);
  const [isUserManagementDialogOpen, setIsUserManagementDialogOpen] = useState(false);
  const [deleteTarget, setDeleteTarget] = useState<ApiDiplomaProcessesGetDiplomaProcessDto | null>(null);
  const [selectedProcess, setSelectedProcess] = useState<ApiDiplomaProcessesGetDiplomaProcessDto | null>(null);
  const [userManagementData, setUserManagementData] = useState<UserManagementData>({
    diplomaProcessId: '',
    groupId: '',
    userId: ''
  });

  // Form data
  const [formData, setFormData] = useState<DiplomaProcessFormData>({
    name: '',
    periodId: selectedPeriod.id
  });

  // API hooks
  const [getData, { data, isLoading }] = useLazyGetApiDiplomaProcessesGetQuery({
    pollingInterval: 15000
  });

  const [createProcess, { isLoading: isCreating }] = usePostApiDiplomaProcessesCreateMutation();
  const [deleteProcess, { isLoading: isDeleting }] = useDeleteApiDiplomaProcessesDeleteMutation();
  
  // User management mutations
  const [addGroup, { isLoading: isAddingGroup }] = usePostApiDiplomaProcessesUsersAddGroupMutation();
  const [addTeacher, { isLoading: isAddingTeacher }] = usePostApiDiplomaProcessesUsersAddTeacherMutation();
  const [removeGroup, { isLoading: isRemovingGroup }] = usePostApiDiplomaProcessesUsersRemoveGroupMutation();
  const [removeTeacher, { isLoading: isRemovingTeacher }] = usePostApiDiplomaProcessesUsersRemoveTeacherMutation();

  // Additional data queries
  const [getGroups] = useLazyGetApiGroupsGetQuery();
  const [getTeachers] = useLazyGetApiUsersGetTeachersQuery();

  const [groups, setGroups] = useState<any[]>([]);
  const [teachers, setTeachers] = useState<any[]>([]);

  // Load diploma processes
  useEffect(() => {
    if (selectedPeriod.id) {
      getData({
        periodId: selectedPeriod.id,
        filter: search,
        pageNumber: pageNumber,
        pageSize: 25,
        desc: false,
        orderBy: 'name'
      });
    }
  }, [pageNumber, search, selectedPeriod.id, getData]);

  // Load groups and teachers for user management
  useEffect(() => {
    if (selectedPeriod.id) {
      getGroups({
        periodId: selectedPeriod.id,
        pageNumber: 1,
        pageSize: 100,
        desc: false,
        orderBy: 'number'
      }).then(result => {
        if (result.data?.items) {
          setGroups(result.data.items);
        }
      });

      getTeachers({
        pageNumber: 1,
        pageSize: 100,
        desc: false,
        orderBy: 'lastName'
      }).then(result => {
        if (result.data?.list?.items) {
          setTeachers(result.data.list.items);
        }
      });
    }
  }, [selectedPeriod.id, getGroups, getTeachers]);

  const handleSearchChange = (value: string) => {
    setPageNumber(1);
    setSearch(value);
  };

  const handleCreateProcess = async () => {
    try {
      await createProcess({
        apiDiplomaProcessesCreateRequestDto: {
          name: formData.name,
          periodId: formData.periodId
        }
      }).unwrap();
      
      enqueueSnackbar('Дипломный процесс успешно создан', { variant: 'success' });
      setIsCreateDialogOpen(false);
      setFormData({ name: '', periodId: selectedPeriod.id });
      
      // Reload data
      if (selectedPeriod.id) {
        getData({
          periodId: selectedPeriod.id,
          filter: search,
          pageNumber: pageNumber,
          pageSize: 25,
          desc: false,
          orderBy: 'name'
        });
      }
    } catch (error: any) {
      enqueueSnackbarError(error);
    }
  };

  const handleDeleteClick = (process: ApiDiplomaProcessesGetDiplomaProcessDto) => {
    setDeleteTarget(process);
  };

  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;

    try {
      await deleteProcess({ id: deleteTarget.id! }).unwrap();
      enqueueSnackbar('Дипломный процесс успешно удален', { variant: 'success' });
      setDeleteTarget(null);
      
      // Reload data
      if (selectedPeriod.id) {
        getData({
          periodId: selectedPeriod.id,
          filter: search,
          pageNumber: pageNumber,
          pageSize: 25,
          desc: false,
          orderBy: 'name'
        });
      }
    } catch (error: any) {
      enqueueSnackbarError(error);
    }
  };

  const handleUserManagementClick = (process: ApiDiplomaProcessesGetDiplomaProcessDto) => {
    setSelectedProcess(process);
    setUserManagementData({
      diplomaProcessId: process.id!,
      groupId: '',
      userId: ''
    });
    setIsUserManagementDialogOpen(true);
  };

  const handleAddGroup = async () => {
    if (!userManagementData.groupId) return;

    try {
      await addGroup({
        apiDiplomaProcessesUsersAddGroupRequestDto: {
          diplomaProcessId: userManagementData.diplomaProcessId,
          groupId: userManagementData.groupId
        }
      }).unwrap();
      
      enqueueSnackbar('Группа успешно добавлена к дипломному процессу', { variant: 'success' });
      setUserManagementData(prev => ({ ...prev, groupId: '' }));
    } catch (error: any) {
      enqueueSnackbarError(error);
    }
  };

  const handleAddTeacher = async () => {
    if (!userManagementData.userId) return;

    try {
      await addTeacher({
        apiDiplomaProcessesUsersAddTeacherRequestDto: {
          diplomaProcessId: userManagementData.diplomaProcessId,
          userId: userManagementData.userId
        }
      }).unwrap();
      
      enqueueSnackbar('Преподаватель успешно добавлен к дипломному процессу', { variant: 'success' });
      setUserManagementData(prev => ({ ...prev, userId: '' }));
    } catch (error: any) {
      enqueueSnackbarError(error);
    }
  };

  const handleRemoveGroup = async (groupId: string) => {
    try {
      await removeGroup({
        apiDiplomaProcessesUsersRemoveGroupRequestDto: {
          diplomaProcessId: userManagementData.diplomaProcessId,
          groupId: groupId
        }
      }).unwrap();
      
      enqueueSnackbar('Группа успешно удалена из дипломного процесса', { variant: 'success' });
    } catch (error: any) {
      enqueueSnackbarError(error);
    }
  };

  const handleRemoveTeacher = async (userId: string) => {
    try {
      await removeTeacher({
        apiDiplomaProcessesUsersRemoveTeacherRequestDto: {
          diplomaProcessId: userManagementData.diplomaProcessId,
          userId: userId
        }
      }).unwrap();
      
      enqueueSnackbar('Преподаватель успешно удален из дипломного процесса', { variant: 'success' });
    } catch (error: any) {
      enqueueSnackbarError(error);
    }
  };

  const canManage = user?.role === ApiContractsUserRoleTypeDto.Deanery || user?.departmentHead;

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="lg">
      {/* Header */}
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <AssignmentIcon color="primary" />
            <Typography variant="h4" component="h1" className="font-bold">
              Дипломные процессы
            </Typography>
          </Box>
          {canManage && (
            <Button
              variant="contained"
              startIcon={<AddIcon />}
              onClick={() => setIsCreateDialogOpen(true)}
              sx={{ borderRadius: 2 }}
            >
              <span className="hidden sm:inline">Добавить процесс</span>
            </Button>
          )}
        </Box>

        <AppListSearch
          label="Поиск"
          placeholder="Введите название дипломного процесса"
          onSearchValueChangedDebounced={handleSearchChange}
        />
      </Paper>

      {/* Diploma Processes List */}
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={data?.items?.length === 0}
            height="55vh"
          >
            {data?.items?.map((process) => (
              <Card key={process.id} sx={{ mb: 2, '&:hover': { bgcolor: 'action.hover' } }}>
                <CardContent>
                  <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Box>
                      <Typography variant="h6" component="h2">
                        {process.name}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        ID: {process.id}
                      </Typography>
                    </Box>
                    <Box sx={{ display: 'flex', gap: 1 }}>
                      {canManage && (
                        <>
                          <Tooltip title="Управление участниками">
                            <IconButton
                              color="primary"
                              onClick={() => handleUserManagementClick(process)}
                            >
                              <PersonAddIcon />
                            </IconButton>
                          </Tooltip>
                          <Tooltip title="Удалить процесс">
                            <IconButton
                              color="error"
                              onClick={() => handleDeleteClick(process)}
                            >
                              <DeleteIcon />
                            </IconButton>
                          </Tooltip>
                        </>
                      )}
                    </Box>
                  </Box>
                </CardContent>
              </Card>
            ))}
          </AppList>
        </Box>
      </Paper>

      {/* Pagination */}
      <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>

      {/* Create Dialog */}
      <Dialog open={isCreateDialogOpen} onClose={() => setIsCreateDialogOpen(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Создать дипломный процесс</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Название процесса"
            fullWidth
            variant="outlined"
            value={formData.name}
            onChange={(e) => setFormData(prev => ({ ...prev, name: e.target.value }))}
            sx={{ mt: 2 }}
          />
          <Alert severity="info" sx={{ mt: 2 }}>
            Период: {selectedPeriod.name}
          </Alert>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsCreateDialogOpen(false)}>Отмена</Button>
          <Button
            onClick={handleCreateProcess}
            variant="contained"
            disabled={isCreating || !formData.name.trim()}
          >
            {isCreating ? 'Создание...' : 'Создать'}
          </Button>
        </DialogActions>
      </Dialog>

      {/* User Management Dialog */}
      <Dialog open={isUserManagementDialogOpen} onClose={() => setIsUserManagementDialogOpen(false)} maxWidth="md" fullWidth>
        <DialogTitle>
          Управление участниками: {selectedProcess?.name}
        </DialogTitle>
        <DialogContent>
          <Grid container spacing={3} sx={{ mt: 1 }}>
            {/* Add Groups */}
            <Grid item xs={12} md={6}>
              <Typography variant="h6" gutterBottom>
                Добавить группу
              </Typography>
              <Box sx={{ display: 'flex', gap: 1, mb: 2 }}>
                <FormControl fullWidth>
                  <InputLabel>Выберите группу</InputLabel>
                  <Select
                    value={userManagementData.groupId}
                    onChange={(e) => setUserManagementData(prev => ({ ...prev, groupId: e.target.value }))}
                  >
                    {groups.map((group) => (
                      <MenuItem key={group.id} value={group.id}>
                        {group.number}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <Button
                  variant="contained"
                  startIcon={<GroupAddIcon />}
                  onClick={handleAddGroup}
                  disabled={isAddingGroup || !userManagementData.groupId}
                >
                  Добавить
                </Button>
              </Box>
            </Grid>

            {/* Add Teachers */}
            <Grid item xs={12} md={6}>
              <Typography variant="h6" gutterBottom>
                Добавить преподавателя
              </Typography>
              <Box sx={{ display: 'flex', gap: 1, mb: 2 }}>
                <FormControl fullWidth>
                  <InputLabel>Выберите преподавателя</InputLabel>
                  <Select
                    value={userManagementData.userId}
                    onChange={(e) => setUserManagementData(prev => ({ ...prev, userId: e.target.value }))}
                  >
                    {teachers.map((teacher) => (
                      <MenuItem key={teacher.id} value={teacher.id}>
                        {teacher.lastName} {teacher.firstName} {teacher.middleName}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <Button
                  variant="contained"
                  startIcon={<PersonAddIcon />}
                  onClick={handleAddTeacher}
                  disabled={isAddingTeacher || !userManagementData.userId}
                >
                  Добавить
                </Button>
              </Box>
            </Grid>
          </Grid>

          <Divider sx={{ my: 2 }} />

          <Typography variant="h6" gutterBottom>
            Управление участниками
          </Typography>
          <Alert severity="info" sx={{ mb: 2 }}>
            Здесь будут отображаться добавленные группы и преподаватели. 
            Функциональность удаления будет доступна после реализации соответствующих API endpoints.
          </Alert>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setIsUserManagementDialogOpen(false)}>Закрыть</Button>
        </DialogActions>
      </Dialog>

      {/* Delete Confirmation Dialog */}
      <Dialog open={!!deleteTarget} onClose={() => setDeleteTarget(null)}>
        <DialogTitle>Удалить дипломный процесс?</DialogTitle>
        <DialogContent>
          <Typography>
            Вы уверены, что хотите удалить дипломный процесс <strong>{deleteTarget?.name}</strong>?
            <br />
            Это действие нельзя отменить.
          </Typography>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setDeleteTarget(null)} disabled={isDeleting}>
            Отмена
          </Button>
          <Button
            onClick={handleDeleteConfirm}
            color="error"
            variant="contained"
            disabled={isDeleting}
          >
            {isDeleting ? 'Удаление...' : 'Удалить'}
          </Button>
        </DialogActions>
      </Dialog>
    </Container>
  );
};

export default DiplomaProcessesPage;
