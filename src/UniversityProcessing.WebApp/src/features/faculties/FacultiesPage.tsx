import { useEffect, useState } from 'react';
import { Box, Button, Container, Dialog, DialogContent, DialogTitle, Paper, Switch, Tooltip, Typography } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import FacultyItem from './FacultyItem';
import AppListPagination from 'src/components/lists/AppListPagination';
import { ContractsUserRoleType, useGetApiFacultiesGetQuery, useLazyGetApiFacultiesGetQuery } from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import { useNavigate } from 'react-router-dom';
import { RegisterAdminForm } from '../auth/components';
import AppListSearch from 'src/components/lists/AppListSearch';
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

const AddFacultyModal: React.FC<{
  open: boolean;
  onClose: () => void;
}> = ({ open, onClose }) => {
  return (
    <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
      <DialogTitle>Добавить новый факультет</DialogTitle>
      <DialogContent>

      </DialogContent>
    </Dialog>
  );
};

const FacultiesPage = () => {
  const [pageNumber, setPageNumber] = useState(1);
  const [search, setSearch] = useState('');
  const navigate = useNavigate();
  const [isModalOpen, setIsModalOpen] = useState(false);

  const [getData, { data, isLoading }] = useLazyGetApiFacultiesGetQuery(
    {
      pollingInterval: 15000
    });

  const currentUser = useAppSelector(state => state.auth.user);
  const isAdmin = currentUser?.role == ContractsUserRoleType.Admin;

  useEffect(() => {
    if (!isAdmin)
      navigate('/');
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
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <AddFacultyModal
        open={isModalOpen}
        onClose={handleCloseModal}
      />
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
          <Typography variant="h4" component="h1" className="font-bold">
            Факультеты
          </Typography>
          <Button
            variant="contained"
            startIcon={<AddIcon />}
            onClick={handleOpenModal}
            sx={{ borderRadius: 2 }}
          >
            <span className="hidden sm:inline">Добавить факультет</span>
          </Button>
        </Box>
        <AppListSearch
          label="Поиск"
          placeholder='Введите название факультета'
          onSearchValueChangedDebounced={SearchValueChanged} />
      </Paper>
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={data?.items?.length == 0}
            height={'55vh'}>
            {
              data?.items?.map((item) => (
                <FacultyItem
                  key={item.id}
                  item={item}
                  className="cursor-pointer hover:bg-gray-50 rounded-md"
                  sx={{ '&:hover': { bgcolor: 'action.hover' }, borderRadius: 1 }}
                  onClick={(clicked) => navigate(`/faculties/${clicked.id}`)}
                />
              ))
            }
          </AppList>
        </Box>
      </Paper>
      <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>
    </Container >
  );
};

export default FacultiesPage;