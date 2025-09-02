import React, { useEffect, useRef, useState } from 'react';
import {
  Box, Button, Container, InputAdornment, Paper,
  Switch,
  TextField, Tooltip, Typography
} from '@mui/material';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
} from '@mui/material';
import { useAppSelector } from 'src/core/hooks';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppList from 'src/components/lists/AppList';
import UserItem from './components/UserItem';
import AppListSearch from 'src/components/lists/AppListSearch';
import { ContractsUserRoleType, useLazyGetApiUsersGetAdminsQuery, usePatchApiFacultiesSetFacultyHeadMutation } from 'src/api/backendApi';
import {
  Add as AddIcon,
  Block as BlockIcon,
  CheckCircle as CheckCircleIcon,
  Delete as DeleteIcon,
  Edit as EditIcon,
  School as SchoolIcon,
  Search as SearchIcon,
  VerifiedUser as VerifiedUserIcon,
  Work as WorkIcon
} from '@mui/icons-material';
import { useNavigate } from 'react-router-dom';
import RegisterAdminForm from '../auth/components/RegisterAdminForm';

const AddUserModal: React.FC<{
  open: boolean;
  onClose: () => void;
}> = ({ open, onClose }) => {
  const [verification, setVerification] = useState(false);
  return (
    <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
      <DialogTitle>Добавить нового пользователя</DialogTitle>
      <DialogContent>
        <RegisterAdminForm buttonLabel='Добавить' verify={verification} />
        <Container className="flex items-center gap-2 mt-4">
          <Tooltip title="Будет ли пользователь верифицирован при создании">
            <Switch
              checked={verification}
              onChange={(e: any) => setVerification(e.target.checked)}
              color="success"
              size="small"
              className='opacity-50'
            />
          </Tooltip>
          <Typography variant="body2" className="font-medium">
            {verification ? 'Верифицировать' : 'Не верифицировать'}
          </Typography>
        </Container>
      </DialogContent>
    </Dialog>
  );
};

const AdministratorsPage: React.FC = () => {
  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const [isModalOpen, setIsModalOpen] = useState(false);

  const [getData, { data, isLoading }] = useLazyGetApiUsersGetAdminsQuery(
    {
      pollingInterval: 15000
    });

  const currentUser = useAppSelector(state => state.auth.user);

  useEffect(() => {
    getData({ filter: search, pageNumber: pageNumber, pageSize: 25 });
  }, [pageNumber, search, currentUser]);

  const SearchValueChanged = (newSearch: string) => {
    setPageNumber(1);
    setSearch(newSearch);
  };

  const handleOpenModal = () => {
    setIsModalOpen(true);
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  return (
    <>
      <AddUserModal
        open={isModalOpen}
        onClose={handleCloseModal}
      />
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
          <Typography variant="h4" component="h1" className="font-bold">
            Администраторы
          </Typography>
          <Button
            variant="contained"
            startIcon={<AddIcon />}
            onClick={handleOpenModal}
            sx={{ borderRadius: 2 }}
          >
            <span className="hidden sm:inline">Добавить пользователя</span>
          </Button>
        </Box>
        <AppListSearch
          label="Поиск"
          placeholder='Введите ФИО'
          onSearchValueChangedDebounced={SearchValueChanged} />
      </Paper>
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={data?.list?.items?.length == 0}
            height={'55vh'}>
            {
              data?.list?.items?.map((item) => (
                <UserItem
                  key={item.id}
                  item={item}
                  currentUser={currentUser}
                />
              ))
            }
          </AppList>
        </Box>
      </Paper>
      <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.list?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>
    </>
  );
};

export default AdministratorsPage;