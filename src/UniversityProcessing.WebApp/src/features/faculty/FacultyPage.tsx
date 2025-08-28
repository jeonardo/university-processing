import { useParams } from "react-router-dom";
import React, { useState } from 'react';
import {
    Container,
    Typography,
    Box,
    Paper,
    List,
    ListItem,
    ListItemText,
    Button,
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    TextField,
    Grid,
    Chip,
    Avatar,
    Tooltip,
    Switch,
    MenuItem,
    ListItemIcon,
    IconButton,
    Menu
} from '@mui/material';
import { Person, Add, Edit, Star, StarBorder, MoreVert } from '@mui/icons-material';
import { useGetApiFacultiesGetFullDescriptionQuery, usePatchApiFacultiesSetFacultyHeadMutation } from "src/api/backendApi";
import AppLoader from "src/components/AppLoader";
import { namingTools } from "src/core/namingTools";
import { RegisterDeaneryForm } from "../auth/components";
import { enqueueSnackbar } from "notistack";
import { enqueueSnackbarError } from "src/core/helpers";
import DeaneryItem from "./DeaneryItem";
import { useSelector } from "react-redux";
import { useAppSelector } from "src/core/hooks";

const AddUserModal: React.FC<{
    open: boolean;
    onClose: () => void;
}> = ({ open, onClose }) => {
    const [verification, setVerification] = useState(false);
    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>Добавить нового сотрудника</DialogTitle>
            <DialogContent>
                <RegisterDeaneryForm buttonLabel='Добавить' verify={verification} />
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

const FacultyPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const { data, isLoading, refetch } = useGetApiFacultiesGetFullDescriptionQuery({ id: id ?? '' });
    const [isModalOpen, setIsModalOpen] = useState(false);
    const currentUser = useAppSelector(state => state.auth.user);

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
            />

            {/* Заголовок и информация о декане */}
            <Paper elevation={3} sx={{ p: 3 }}>
                <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Typography variant="h4" component="h1">
                        {data?.name} ({data?.shortName})
                    </Typography>
                </Box>
                <Box sx={{ mt: 2 }}>
                    <Chip
                        avatar={<Avatar><Person /></Avatar>}
                        label={data?.head == null
                            ? 'Декан не назначен'
                            : `Декан: ${namingTools.fullName(data?.head)}`}
                        color={data?.head ? "primary" : "default"}
                        variant="outlined"
                        sx={{ fontSize: '1.1rem', p: 2 }}
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