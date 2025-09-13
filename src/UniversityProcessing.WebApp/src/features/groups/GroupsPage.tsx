import React, { useEffect, useState } from 'react';
import {
  Box,
  Button,
  Paper,
  Typography,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Container
} from '@mui/material';
import {
  Add as AddIcon,
  Delete as DeleteIcon,
  School as SchoolIcon
} from '@mui/icons-material';
import AppList from 'src/components/lists/AppList';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppListSearch from 'src/components/lists/AppListSearch';
import GroupItem from './GroupItem';
import GroupFormDialog from './GroupFormDialog';
import {
  useLazyGetApiGroupsGetQuery,
  useDeleteApiGroupsDeleteMutation,
  usePostApiGroupsCreateMutation,
  GroupsGetGroup
} from 'src/api/backendApi';
import { useAppSelector, useRequireAdmin } from 'src/core/hooks';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';

const GroupsPage: React.FC = () => {
  useRequireAdmin();

  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);
  const [deleteTarget, setDeleteTarget] = useState<GroupsGetGroup | null>(null);

  // API хуки
  const [getData, { data, isLoading }] = useLazyGetApiGroupsGetQuery({
    pollingInterval: 15000
  });

  const [createGroup, { isLoading: isCreating }] = usePostApiGroupsCreateMutation();
  const [deleteGroup, { isLoading: isDeleting }] = useDeleteApiGroupsDeleteMutation();

  // Загружаем данные при изменении параметров
  useEffect(() => {
    getData({
      filter: search,
      pageNumber: pageNumber,
      pageSize: 25,
      desc: false,
      orderBy: 'number'
    });
  }, [pageNumber, search, getData]);

  const handleSearchChange = (value: string) => {
    setPageNumber(1);
    setSearch(value);
  };

  const handleCreateGroup = async (groupData: any) => {
    try {
      const result = await createGroup({ groupsCreateRequest: groupData }).unwrap();
      enqueueSnackbar('Группа успешно создана', { variant: 'success' });
      setIsCreateDialogOpen(false);
      // Перезагружаем данные
      getData({
        filter: search,
        pageNumber: pageNumber,
        pageSize: 25,
        desc: false,
        orderBy: 'number'
      });
    } catch (error) {
      enqueueSnackbarError(error);
    }
  };

  const handleDeleteClick = (group: GroupsGetGroup) => {
    setDeleteTarget(group);
  };

  const handleDeleteConfirm = async () => {
    if (!deleteTarget) return;

    try {
      await deleteGroup({ id: deleteTarget.id! }).unwrap();
      enqueueSnackbar('Группа успешно удалена', { variant: 'success' });
      setDeleteTarget(null);
      // Перезагружаем данные
      getData({
        filter: search,
        pageNumber: pageNumber,
        pageSize: 25,
        desc: false,
        orderBy: 'number'
      });
    } catch (error) {
      enqueueSnackbarError(error);
    }
  };

  const handleDeleteCancel = () => {
    setDeleteTarget(null);
  };

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      {/* Диалог создания группы */}
      <GroupFormDialog
        open={isCreateDialogOpen}
        onClose={() => setIsCreateDialogOpen(false)}
        onSubmit={handleCreateGroup}
        isLoading={isCreating}
      />

      {/* Заголовок и кнопка создания */}
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <SchoolIcon color="primary" />
            <Typography variant="h4" component="h1" className="font-bold">
              Учебные группы
            </Typography>
          </Box>
          <Button
            variant="contained"
            startIcon={<AddIcon />}
            onClick={() => setIsCreateDialogOpen(true)}
            sx={{ borderRadius: 2 }}
          >
            <span className="hidden sm:inline">Добавить группу</span>
          </Button>
        </Box>

        <AppListSearch
          label="Поиск"
          placeholder="Введите номер группы"
          onSearchValueChangedDebounced={handleSearchChange}
        />
      </Paper>

      {/* Список групп */}
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={data?.items?.length === 0}
            height="55vh"
          >
            {data?.items?.map((group) => (
              <GroupItem
                key={group.id}
                item={group}
                className="cursor-pointer hover:bg-gray-50 rounded-md"
                sx={{
                  '&:hover': { bgcolor: 'action.hover' },
                  borderRadius: 1,
                  position: 'relative'
                }}
                onClick={() => {
                  // Можно добавить навигацию к детальной странице группы
                  console.log('Group clicked:', group);
                }}
                onDelete={handleDeleteClick}
              />
            ))}
          </AppList>
        </Box>
      </Paper>

      {/* Пагинация */}
      <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>

      {/* Диалог подтверждения удаления */}
      <Dialog open={!!deleteTarget} onClose={handleDeleteCancel}>
        <DialogTitle>Удалить группу?</DialogTitle>
        <DialogContent>
          <Typography>
            Вы уверены, что хотите удалить группу <strong>{deleteTarget?.number}</strong>?
            <br />
            Это действие нельзя отменить.
          </Typography>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleDeleteCancel} disabled={isDeleting}>
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

export default GroupsPage;
