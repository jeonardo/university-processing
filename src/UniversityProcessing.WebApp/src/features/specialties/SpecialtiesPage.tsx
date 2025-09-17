import React, { useEffect, useMemo, useState } from 'react';
import { Box, Button, Container, Dialog, DialogActions, DialogContent, DialogTitle, Paper, Typography } from '@mui/material';
import {
  useLazyGetApiSpecialtiesGetQuery,
  usePostApiSpecialtiesCreateMutation,
  useDeleteApiSpecialtiesDeleteMutation,
  SpecialtiesGetSpecialty,
  SpecialtiesCreateRequest
} from 'src/api/backendApi';
import AppList from 'src/components/lists/AppList';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppListSearch from 'src/components/lists/AppListSearch';
import SpecialtyItem from './SpecialtyItem';
import SpecialtyFormDialog from './SpecialtyFormDialog';
import { Add as AddIcon, Delete as DeleteIcon, School as SchoolIcon } from '@mui/icons-material';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useAppSelector } from 'src/core';

const SpecialtiesPage: React.FC = () => {
  const user = useAppSelector((state) => state.auth.user);
  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);
  const [deleteTarget, setDeleteTarget] = useState<SpecialtiesGetSpecialty | null>(null);

  const [getData, { data, isLoading }] = useLazyGetApiSpecialtiesGetQuery({
    pollingInterval: 15000
  });
  const [createSpecialty, { isLoading: isCreating }] = usePostApiSpecialtiesCreateMutation();
  const [deleteSpecialty, { isLoading: isDeleting }] = useDeleteApiSpecialtiesDeleteMutation();

  useEffect(() => {
    getData({ departmentId: user?.departmentId ?? '', pageNumber, pageSize: 25, filter: search, desc: false, orderBy: 'name' });
  }, [pageNumber, search, getData]);

  const handleSearchChange = (value: string) => {
    setPageNumber(1);
    setSearch(value);
  };

  const handleCreate = async (form: SpecialtiesCreateRequest) => {
    try {
      await createSpecialty({ specialtiesCreateRequest: form }).unwrap();
      enqueueSnackbar('Специальность создана', { variant: 'success' });
      setIsCreateDialogOpen(false);
      getData({ departmentId: user?.departmentId ?? '', pageNumber, pageSize: 25, filter: search, desc: false, orderBy: 'name' });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleDeleteClick = (item: SpecialtiesGetSpecialty) => setDeleteTarget(item);

  const handleDeleteConfirm = async () => {
    if (!deleteTarget?.id) return;
    try {
      await deleteSpecialty({ id: deleteTarget.id }).unwrap();
      enqueueSnackbar('Специальность удалена', { variant: 'success' });
      setDeleteTarget(null);
      getData({ departmentId: user?.departmentId ?? '', pageNumber, pageSize: 25, filter: search, desc: false, orderBy: 'name' });
    } catch (e: any) {
      enqueueSnackbarError(e);
    }
  };

  const handleDeleteCancel = () => setDeleteTarget(null);

  const totalPages = data?.totalPages ?? 1;
  const items = data?.items ?? [];

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <SpecialtyFormDialog
        open={isCreateDialogOpen}
        onClose={() => setIsCreateDialogOpen(false)}
        onSubmit={handleCreate}
        isLoading={isCreating}
      />

      <Dialog open={!!deleteTarget} onClose={handleDeleteCancel} maxWidth="xs" fullWidth>
        <DialogTitle>Удалить специальность</DialogTitle>
        <DialogContent>
          <Typography>Вы уверены, что хотите удалить «{deleteTarget?.name}»?</Typography>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleDeleteCancel} disabled={isDeleting}>Отмена</Button>
          <Button onClick={handleDeleteConfirm} color="error" startIcon={<DeleteIcon />} disabled={isDeleting}>
            Удалить
          </Button>
        </DialogActions>
      </Dialog>

      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <SchoolIcon color="primary" />
            <Typography variant="h4" component="h1" className="font-bold">Специальности</Typography>
          </Box>
          <Button variant="contained" startIcon={<AddIcon />} onClick={() => setIsCreateDialogOpen(true)} sx={{ borderRadius: 2 }}>
            <span className="hidden sm:inline">Добавить специальность</span>
          </Button>
        </Box>
        <AppListSearch label="Поиск" placeholder="Введите название или код" onSearchValueChangedDebounced={handleSearchChange} />
      </Paper>

      <Paper className="p-4">
        <AppList isEmpty={items.length === 0} isLoading={isLoading}>
          {items.map((s) => (
            <SpecialtyItem key={s.id} item={s} onDelete={handleDeleteClick} />
          ))}
        </AppList>
      </Paper>

      <AppListPagination currentPage={data?.currentPage ?? pageNumber} totalPages={totalPages} onPageChange={setPageNumber} />
    </Container>
  );
};

export default SpecialtiesPage;




