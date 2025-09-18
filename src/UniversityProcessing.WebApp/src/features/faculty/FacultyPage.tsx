import { useNavigate, useParams } from 'react-router-dom';
import React, { useEffect, useState } from 'react';
import {
  Avatar,
  Box,
  Button,
  Chip,
  Container,
  IconButton,
  List,
  Paper,
  Stack,
  Switch,
  Tooltip,
  Typography,
  useMediaQuery
} from '@mui/material';
import { Add, Person } from '@mui/icons-material';
import { useGetApiFacultiesGetFullDescriptionQuery } from 'src/api/backendApi';
import AppLoader from 'src/components/AppLoader';
import { namingTools } from 'src/core/namingTools';
import { RegisterDeaneryForm } from '../auth/components';
import DeaneryItem from './DeaneryItem';
import { useAppSelector } from 'src/core/hooks';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { useTheme } from '@mui/material/styles';
import ModalForm from 'src/components/layout/ModalForm';

const AddUserModal: React.FC<{
  open: boolean;
  onClose: () => void;
  onSuccess: () => void;
}> = ({ open, onClose, onSuccess }) => {
  const [verification, setVerification] = useState(false);
  return (
    <ModalForm open={open} onClose={onClose} title="Добавить нового сотрудника">
      <RegisterDeaneryForm
        buttonLabel="Добавить"
        verify={verification}
        onSuccess={onSuccess}
      />
      <Box className="flex items-center gap-2 mt-4">
        <Tooltip title="Будет ли пользователь верифицирован при создании">
          <Switch
            checked={verification}
            onChange={(e: any) => setVerification(e.target.checked)}
            color="success"
            size="small"
            className="opacity-50"
          />
        </Tooltip>
        <Typography variant="body2" className="font-medium">
          {verification ? 'Верифицировать' : 'Не верифицировать'}
        </Typography>
      </Box>
    </ModalForm>
  );
};

const BackButton: React.FC = () => {
  const navigate = useNavigate();

  return (
    <Tooltip title="Назад">
      <IconButton
        onClick={() => navigate(-1)}
        size="small"
        sx={{
          border: '1px solid',
          borderColor: 'primary.main',
          borderRadius: '50%',
          width: 36,
          height: 36,
          color: 'primary.main'
        }}
      >
        <ArrowBackIcon fontSize="small" />
      </IconButton>
    </Tooltip>
  );
};

const FacultyPage: React.FC = () => {
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down('sm'));
  const { id } = useParams<{ id: string }>();
  const { data, isLoading, refetch, error } = useGetApiFacultiesGetFullDescriptionQuery({ id: id ?? '' });
  const [isModalOpen, setIsModalOpen] = useState(false);
  const currentUser = useAppSelector(state => state.auth.user);
  const navigate = useNavigate();

  useEffect(() => {
    if (error) {
      navigate('/');
    }
  }, [error]);

  const handleOpenModal = () => {
    setIsModalOpen(true);
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  if (isLoading)
    return <AppLoader />;

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <AddUserModal
        open={isModalOpen}
        onClose={handleCloseModal}
        onSuccess={() => {
          handleCloseModal();
          refetch();
        }}
      />

      <Paper elevation={3} sx={{ p: 3 }}>
        <Stack
          direction={isMobile ? 'column' : 'row'}
          spacing={2}
          alignItems={isMobile ? 'flex-start' : 'center'}
          justifyContent="left"
        >
          <BackButton />
          <Typography
            variant={isMobile ? 'h6' : 'h4'}
            component="h1"
            sx={{ wordBreak: 'break-word', textAlign: true ? 'left' : 'right' }}
          >
            {data?.name} ({data?.shortName})
          </Typography>
        </Stack>
        <Box sx={{ mt: 2 }}>
          <Chip
            avatar={<Avatar><Person /></Avatar>}
            label={
              data?.head == null
                ? 'Декан не назначен'
                : `Декан: ${namingTools.fullName(data.head)}`
            }
            color={data?.head ? 'primary' : 'default'}
            variant="outlined"
            sx={{
              fontSize: { xs: '0.9rem', sm: '1.1rem' },
              px: 2,
              py: 1,
              maxWidth: '100%',
              whiteSpace: 'normal'
            }}
          />
        </Box>
      </Paper>

      {/* Список сотрудников */}
      <Paper elevation={3}>
        <Box sx={{ p: 2, display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <Typography variant="h5">Сотрудники деканата</Typography>
          <Button
            variant="contained"
            startIcon={<Add />}
            onClick={handleOpenModal}
          >
            Добавить сотрудника
          </Button>
        </Box>

        <List>
          {data?.deaneries?.map((staff) => (
            <DeaneryItem
              key={staff.id}
              currentUser={currentUser}
              faculty={data}
              item={staff}
              refetch={refetch} />
          ))}
        </List>
      </Paper>
    </Container>
  );
};

export default FacultyPage;