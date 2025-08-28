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
    Menu,
    CircularProgress
} from '@mui/material';
import { Person, Add, Edit, Star, StarBorder, MoreVert } from '@mui/icons-material';
import { FacultiesGetFullDescriptionFacultyFullDescriptionUser, FacultiesGetFullDescriptionResponse, useGetApiFacultiesGetFullDescriptionQuery, usePatchApiFacultiesSetFacultyHeadMutation, usePutApiUsersUpdateVerificationMutation } from "src/api/backendApi";
import AppLoader from "src/components/AppLoader";
import { namingTools } from "src/core/namingTools";
import { RegisterDeaneryForm } from "../auth/components";
import { enqueueSnackbar } from "notistack";
import { enqueueSnackbarError } from "src/core/helpers";
import { AuthUser } from "../auth/auth.contracts";
import {
    Block as BlockIcon,
    Verified as VerifiedIcon,
    Person as PersonIcon
} from '@mui/icons-material';

interface DeaneryItemProps {
    currentUser: AuthUser | null
    faculty: FacultiesGetFullDescriptionResponse | null
    item: FacultiesGetFullDescriptionFacultyFullDescriptionUser
    refetch: () => void
}
const DeaneryItem = ({ currentUser, faculty, item, refetch }: DeaneryItemProps) => {
    const [updateHead] = usePatchApiFacultiesSetFacultyHeadMutation();
    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const [selectedStaff, setSelectedStaff] = useState<any>(null);

    const handleMenuOpen = (event: React.MouseEvent<HTMLElement>, staff: any) => {
        setAnchorEl(event.currentTarget);
        setSelectedStaff(staff);
    };

    const handleMenuClose = () => {
        setAnchorEl(null);
        setSelectedStaff(null);
    };

    const handleSetAsDean = async () => {
        if (selectedStaff && faculty?.id) {
            try {
                await updateHead({ facultyId: faculty.id, userId: selectedStaff.id }).unwrap();
                refetch();
            } catch (error) {
                enqueueSnackbarError(error ?? 'Не удалось назначить декана');
            }
            handleMenuClose();
        }
    };

    const isDean = (staff: any) => faculty?.head?.id === staff.id;

    const [updateVerification, { isLoading: isLoadingVerification }] = usePutApiUsersUpdateVerificationMutation();
    const [verification, setVerification] = useState(item.approved);
    const fullName = namingTools.fullName(item);

    const handleUpdateApproval = async (
        event: React.ChangeEvent<HTMLInputElement>,
        checked: boolean) => {
        const result = await updateVerification({
            usersUpdateVerificationRequest: {
                isApproved: checked,
                userId: item.id ?? ''
            }
        });

        if (result.error) {
            enqueueSnackbarError(`Произошла ошибка при верификации ${result.error}`);
            return;
        }

        enqueueSnackbar(checked
            ? 'Пользователь верифицирован'
            : 'Пользователь заблокирован', { variant: 'success' });

        setVerification(!item.approved!);
    };

    return (
        <ListItem
            key={item.id}
            divider
            secondaryAction={
                !isDean(item) &&
                <IconButton
                    edge="end"
                    onClick={(e) => handleMenuOpen(e, item)}
                >
                    <MoreVert />
                </IconButton>
            }
        >
            <ListItemText
                primary={
                    <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                        {namingTools.fullName(item)}
                        {isDean(item) && (
                            <Chip
                                label="Декан"
                                size="small"
                                color="primary"
                                variant="outlined"
                            />
                        )}
                    </Box>
                }
                secondary={
                    <React.Fragment>
                        <Typography variant="body2">{item.position}</Typography>
                        <Typography variant="body2">{item.email}</Typography>
                    </React.Fragment>
                }
            />

            {
                item.id == currentUser?.userId
                    ?
                    (
                        <Typography variant="body2" color="text.secondary" component="span">
                            (Вы)
                        </Typography>
                    )
                    :
                    (
                        <>
                            {true && (
                                <Box className="flex items-center justify-between space-x-4 mt-2">
                                    <Box className="flex items-center space-x-2">
                                        {isLoadingVerification ? (
                                            <>
                                                <CircularProgress size={16} />
                                                <Typography variant="body2" className="font-medium text-gray-500">
                                                    Проверка...
                                                </Typography>
                                            </>
                                        ) : (
                                            <>
                                                <VerifiedIcon className={`text-sm ${verification ? 'text-green-500' : 'text-gray-400'}`} />
                                                <Typography variant="body2" className="font-medium">
                                                    {verification ? 'Верифицирован' : 'Не верифицирован'}
                                                </Typography>
                                            </>
                                        )}
                                    </Box>
                                    <Tooltip
                                        title={
                                            isLoadingVerification
                                                ? "Загружается"
                                                : verification ? "Заблокировать"
                                                    : "Верифицировать"}
                                        arrow
                                    >
                                        <span>
                                            <Switch
                                                checked={verification}
                                                onChange={handleUpdateApproval}
                                                color="success"
                                                size="small"
                                                disabled={isLoadingVerification}
                                                className={isLoadingVerification ? 'opacity-50' : ''}
                                            />
                                        </span>
                                    </Tooltip>
                                </Box>
                            )}
                        </>
                    )
            }

            {/* Меню действий с сотрудником */}
            {
                selectedStaff
                && !isDean(selectedStaff)
                && (<Menu
                    anchorEl={anchorEl}
                    open={Boolean(anchorEl)}
                    onClose={handleMenuClose}
                >

                    <MenuItem onClick={handleSetAsDean}>
                        <ListItemIcon>
                            <Star fontSize="small" />
                        </ListItemIcon>
                        Назначить деканом
                    </MenuItem>

                </Menu>)
            }
        </ListItem>
    )
}

export default DeaneryItem