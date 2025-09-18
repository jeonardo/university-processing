import React, { useState } from 'react';
import {
  Box,
  Chip,
  CircularProgress,
  IconButton,
  ListItem,
  ListItemIcon,
  ListItemText,
  Menu,
  MenuItem,
  Switch,
  Tooltip,
  Typography
} from '@mui/material';
import { MoreVert, Star, Verified as VerifiedIcon } from '@mui/icons-material';
import {
  ApiDepartmentsGetFullDescriptionResponseDto,
  ApiDepartmentsGetFullDescriptionUserDto,
  usePatchApiDepartmentsSetDepartmentHeadMutation,
  usePutApiUsersUpdateVerificationMutation
} from 'src/api/backendApi';
import { namingTools } from 'src/core/namingTools';
import { enqueueSnackbar } from 'notistack';
import { enqueueSnackbarError } from 'src/core/helpers';
import { AuthUser } from '../auth/auth.contracts';

interface TeacherItemProps {
  currentUser: AuthUser | null;
  department: ApiDepartmentsGetFullDescriptionResponseDto | null;
  item: ApiDepartmentsGetFullDescriptionUserDto;
  refetch: () => void;
}

const TeacherItem = ({ currentUser, department, item, refetch }: TeacherItemProps) => {
  const [updateHead] = usePatchApiDepartmentsSetDepartmentHeadMutation();
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
    if (selectedStaff && department?.id) {
      try {
        await updateHead({ departmentId: department?.id ?? '', userId: selectedStaff.id }).unwrap();
        refetch();
      } catch (error) {
        enqueueSnackbarError(error ?? 'Не удалось назначить завкафедрой');
      }
      handleMenuClose();
    }
  };

  const isDean = (staff: any) => department?.head?.id === staff.id;

  const [updateVerification, { isLoading: isLoadingVerification }] = usePutApiUsersUpdateVerificationMutation();
  const [verification, setVerification] = useState(item.approved);
  const fullName = namingTools.fullName(item);

  const handleUpdateApproval = async (
    event: React.ChangeEvent<HTMLInputElement>,
    checked: boolean) => {
    const result = await updateVerification({
      apiUsersUpdateVerificationRequestDto: {
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
          onClick={(e) => handleMenuOpen(e, item)}>
          <MoreVert />
        </IconButton>
      }>
      <ListItemText
        primary={
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            {namingTools.fullName(item)}
            {isDean(item) && (
              <Chip
                label="Завкафедрой"
                size="small"
                color="primary"
                variant="outlined"
              />
            )}
          </Box>
        }
        secondary={
          <>
            <Typography
              variant="body2"
              sx={{ display: 'block' }}
              component="span">
              {item.position}
            </Typography>
            <Typography
              variant="body2"
              sx={{ display: 'block' }}
              component="span">
              {item.email}
            </Typography>

          </>
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
                        ? 'Загружается'
                        : verification ? 'Заблокировать'
                          : 'Верифицировать'}
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
            Назначить завкафедрой
          </MenuItem>

        </Menu>)
      }
    </ListItem>
  );
};

export default TeacherItem;