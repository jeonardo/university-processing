import { useEffect, useState } from 'react';
import { Box, Button, Container, Dialog, DialogContent, DialogTitle, FormControl, Paper, Stack, TextField, Typography } from '@mui/material';
import ModalForm from 'src/components/layout/ModalForm';
import AppList from 'src/components/lists/AppList';
import FacultyItem from './FacultyItem';
import AppListPagination from 'src/components/lists/AppListPagination';
import { ContractsUserRoleType, useGetApiFacultiesGetQuery, useLazyGetApiFacultiesGetQuery, usePostApiFacultiesCreateMutation } from 'src/api/backendApi';
import { useAppSelector, useRequireAdmin } from 'src/core/hooks';
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
import SubmitButton from 'src/components/forms/SubmitButton';
import { enqueueSnackbar } from 'notistack';
import { on } from 'events';
import { enqueueSnackbarError } from 'src/core/helpers';
import { useSearchParams } from 'react-router-dom';


const AddFacultyModal: React.FC<{
  open: boolean;
  onClose: () => void;
  onSuccess: () => void;
}> = ({ open, onClose, onSuccess }) => {
  const [name, setName] = useState('');
  const [shortName, setShortName] = useState('');

  const [createFaculty, { isLoading, error }] = usePostApiFacultiesCreateMutation();

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    const result = await createFaculty({
      facultiesCreateRequest: {
        name: name,
        shortName: shortName
      }
    });
    if (result.error) {
      enqueueSnackbarError(result.error);
    }
    else {
      enqueueSnackbar('Факультет добавлен', { variant: 'success' });
      onClose();
      onSuccess();
    }
  };

  return (
    <ModalForm open={open} onClose={onClose} title="Добавить новый факультет">
      <FormControl component="form" fullWidth sx={{ pt: 2 }} onSubmit={handleSubmit}>
        <Stack spacing={2}>
          <TextField
            required
            label="Название"
            value={name}
            onChange={(event) => setName(event.target.value)}
            disabled={isLoading}
          />
          <TextField
            required
            label="Короткое название"
            value={shortName}
            onChange={(event) => setShortName(event.target.value)}
            disabled={isLoading}
          />
          <SubmitButton
            isLoading={isLoading}
            label={'Добавить'}
          />
        </Stack>
      </FormControl>
    </ModalForm>
  );
};

const FacultiesPage = () => {
  useRequireAdmin();

  const [getData, { data, isLoading }] = useLazyGetApiFacultiesGetQuery();
  const [searchParams, setSearchParams] = useSearchParams();

  // Получаем параметры из URL
  const pageNumber = parseInt(searchParams.get('page') || '1');
  const search = searchParams.get('search') || '';

  // Загружаем данные при изменении параметров
  useEffect(() => {
    getData({ filter: search, pageNumber, pageSize: 25 });
  }, [getData, search, pageNumber]);

  const onSearchValueChanged = (value: string) => {
    setSearchParams(prev => {
      const newParams = new URLSearchParams(prev);
      newParams.set('search', value);
      newParams.set('page', '1'); // Сбрасываем на первую страницу при поиске
      return newParams;
    });
  };

  const onPageChange = (newPage: number) => {
    setSearchParams(prev => {
      const newParams = new URLSearchParams(prev);
      newParams.set('page', newPage.toString());
      return newParams;
    });
  };

  const navigate = useNavigate();
  const [isModalOpen, setIsModalOpen] = useState(false);


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
        onSuccess={() => getData({ filter: search, pageNumber: pageNumber, pageSize: 25 })}
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
          onSearchValueChangedDebounced={onSearchValueChanged} />
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
      {
        data
        && data.totalPages
        && data.totalPages > 1 && (
          <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
            <AppListPagination
              currentPage={pageNumber}
              totalPages={data?.totalPages ?? 0}
              onPageChange={onPageChange}
            />
          </Paper>)
      }
    </Container >
  );
};

export default FacultiesPage;