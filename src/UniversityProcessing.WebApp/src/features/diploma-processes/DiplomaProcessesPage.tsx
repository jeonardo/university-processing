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
  usePostApiDiplomaProcessesCreateMutation
} from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useNavigate } from 'react-router-dom';

interface DiplomaProcessFormData {
  name: string;
}


const DiplomaProcessesPage: React.FC = () => {
  const user = useAppSelector(state => state.auth.user);
  const selectedPeriod = useAppSelector(state => state.period.SelectedPeriod);
  const navigate = useNavigate();

  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);
  const [deleteTarget, setDeleteTarget] = useState<ApiDiplomaProcessesGetDiplomaProcessDto | null>(null);

  // Form data
  const [formData, setFormData] = useState<DiplomaProcessFormData>({
    name: ''
  });

  // API hooks
  const [getData, { data, isLoading }] = useLazyGetApiDiplomaProcessesGetQuery({
    pollingInterval: 15000
  });

  const [createProcess, { isLoading: isCreating }] = usePostApiDiplomaProcessesCreateMutation();
  const [deleteProcess, { isLoading: isDeleting }] = useDeleteApiDiplomaProcessesDeleteMutation();

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


  const handleSearchChange = (value: string) => {
    setPageNumber(1);
    setSearch(value);
  };

  const handleCreateProcess = async () => {
    try {
      await createProcess({
        apiDiplomaProcessesCreateRequestDto: {
          name: formData.name,
          periodId: selectedPeriod.id
        }
      }).unwrap();

      enqueueSnackbar('Дипломный процесс успешно создан', { variant: 'success' });
      setIsCreateDialogOpen(false);
      setFormData({ name: '' });

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
                      <Typography
                        variant="h6"
                        component="h2"
                        sx={{ cursor: 'pointer' }}
                        onClick={() => navigate(`/diploma-processes/${process.id}`)}
                      >
                        {process.name}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        ID: {process.id}
                      </Typography>
                    </Box>
                    <Box sx={{ display: 'flex', gap: 1 }}>
                      <Button size="small" variant="outlined" onClick={() => navigate(`/diploma-processes/${process.id}`)}>
                        Открыть
                      </Button>
                      {canManage && (
                        <Tooltip title="Удалить процесс">
                          <IconButton
                            color="error"
                            onClick={() => handleDeleteClick(process)}
                          >
                            <DeleteIcon />
                          </IconButton>
                        </Tooltip>
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

