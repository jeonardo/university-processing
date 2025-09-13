import React, { useEffect, useState } from 'react';
import {
  Box,
  Button,
  Container,
  Paper,
  Stack,
  Typography,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  IconButton,
  Chip
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
  useGetApiGroupsGetQuery,
  useDeleteApiGroupsDeleteMutation,
  usePostApiGroupsCreateMutation,
  GroupsGetGroup
} from 'src/api/backendApi';
import { useAppSelector, useRequireAdmin } from 'src/core/hooks';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useSearchParams } from 'react-router-dom';

const GroupsPage: React.FC = () => {
  useRequireAdmin();

  const [searchParams, setSearchParams] = useSearchParams();
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);
  const [deleteTarget, setDeleteTarget] = useState<GroupsGetGroup | null>(null);

  // Получаем параметры из URL
  const pageNumber = parseInt(searchParams.get('page') || '1');
  const search = searchParams.get('search') || '';

  // API хуки
  const { data, isLoading, refetch } = useGetApiGroupsGetQuery({
    pageNumber,
    pageSize: 25,
    filter: search,
    desc: false,
    orderBy: 'number'
  });

  const [createGroup, { isLoading: isCreating }] = usePostApiGroupsCreateMutation();
  const [deleteGroup, { isLoading: isDeleting }] = useDeleteApiGroupsDeleteMutation();

  const handleSearchChange = (value: string) => {
    setSearchParams(prev => {
      const newParams = new URLSearchParams(prev);
      newParams.set('search', value);
      newParams.set('page', '1'); // Сбрасываем на первую страницу при поиске
      return newParams;
    });
  };

  const handlePageChange = (newPage: number) => {
    setSearchParams(prev => {
      const newParams = new URLSearchParams(prev);
      newParams.set('page', newPage.toString());
      return newParams;
    });
  };

  const handleCreateGroup = async (groupData: any) => {
    try {
      const result = await createGroup({ groupsCreateRequest: groupData }).unwrap();
      enqueueSnackbar('Группа успешно создана', { variant: 'success' });
      setIsCreateDialogOpen(false);
      refetch();
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
      refetch();
    } catch (error) {
      enqueueSnackbarError(error);
    }
  };

  const handleDeleteCancel = () => {
    setDeleteTarget(null);
  };

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      {/* Заголовок и кнопка создания */}
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', mb: 3 }}>
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
      {data && data.totalPages && data.totalPages > 1 && (
        <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
          <AppListPagination
            currentPage={pageNumber}
            totalPages={data.totalPages}
            onPageChange={handlePageChange}
          />
        </Paper>
      )}

      {/* Диалог создания группы */}
      <GroupFormDialog
        open={isCreateDialogOpen}
        onClose={() => setIsCreateDialogOpen(false)}
        onSubmit={handleCreateGroup}
        isLoading={isCreating}
      />

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
