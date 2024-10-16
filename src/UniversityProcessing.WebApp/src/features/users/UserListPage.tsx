import { MRT_Localization_RU } from 'material-react-table/locales/ru';

import { useEffect, useMemo, useState } from 'react';
import {
    MaterialReactTable,
    type MRT_ColumnDef,
    MRT_EditActionButtons,
    type MRT_Row,
    type MRT_TableOptions,
    useMaterialReactTable,
} from 'material-react-table';
import {
    Box,
    Button,
    DialogActions,
    DialogContent,
    DialogTitle,
    FormControl,
    IconButton,
    InputLabel,
    MenuItem,
    Select,
    Tooltip,
    Typography,
} from '@mui/material';
import NotInterestedIcon from '@mui/icons-material/NotInterested';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import {
    RegisterAdminRequestDto,
    RegisterEmployeeRequestDto,
    RegisterStudentRequestDto,
    useGetApiV1AdminGetUsersQuery,
    useLazyGetApiV1AdminGetUsersQuery,
    usePostApiV1RegistrationRegisterAdminMutation,
    usePostApiV1RegistrationRegisterEmployeeMutation,
    usePostApiV1RegistrationRegisterStudentMutation,
    usePutApiV1AdminUpdateIsApprovedStatusMutation,
    UserDto,
    UserRoleIdDto
} from 'src/api/backendApi';
import { Switch } from 'src/core/Switch';
import ValidationRules from 'src/core/ValidationRules';

function validateUserAdmin(university: RegisterAdminRequestDto) {
    return {
        //name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        //shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

function validateUserStudent(university: RegisterStudentRequestDto) {
    return {
        //  name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        //  shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

function validateUserEmployee(university: RegisterEmployeeRequestDto) {
    return {
        //     name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        //     shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

const UserListPage = () => {
    const [getDataState, dataState] = useLazyGetApiV1AdminGetUsersQuery({})

    const [createUserRole, setCreateUserRole] = useState<UserRoleIdDto>(UserRoleIdDto.None)

    const [handleCreateAdmin, handleCreateAdminState] = usePostApiV1RegistrationRegisterAdminMutation()
    const [handleCreateStudent, handleCreateStudentState] = usePostApiV1RegistrationRegisterStudentMutation()
    const [handleCreateEmployee, handleCreateEmployeeState] = usePostApiV1RegistrationRegisterEmployeeMutation()

    const [handleUpdateApprovement, handleUpdateApprovementState] = usePutApiV1AdminUpdateIsApprovedStatusMutation()

    const [validationErrors, setValidationErrors] = useState<
        Record<string, string | undefined>
    >({});

    const [isActual, setIsActual] = useState(false)

    const sendUpdateApprovement = (approved: boolean, user: UserDto) => {
        handleUpdateApprovement({ updateIsApprovedStatusRequestDto: { isApproved: approved, userId: user.id ?? "" } })
        setTimeout(() => {
            setIsActual(false)
        }, 2000)
    }

    useEffect(() => {
        if (!isActual) {
            getDataState({})
            setIsActual(true)
        }
    })

    const columns = useMemo<MRT_ColumnDef<UserDto>[]>(
        () => [
            {
                accessorKey: 'lastName',
                header: 'Фамилия',
                muiEditTextFieldProps: {
                    required: true,
                    error: !!validationErrors?.shortName,
                    helperText: validationErrors?.shortName,
                    //remove any previous validation errors when university focuses on the input
                    onFocus: () =>
                        setValidationErrors({
                            ...validationErrors,
                            shortName: undefined,
                        }),
                },
            },
            {
                accessorKey: 'firstName',
                header: 'Имя',
                muiEditTextFieldProps: {
                    required: true,
                    error: !!validationErrors?.name,
                    helperText: validationErrors?.name,
                    //remove any previous validation errors when university focuses on the input
                    onFocus: () =>
                        setValidationErrors({
                            ...validationErrors,
                            name: undefined,
                        }),
                    //optionally add validation checking for onBlur or onChange
                },
            },
            {
                accessorKey: 'middleName',
                header: 'Отчество',
                muiEditTextFieldProps: {
                    required: true,
                    error: !!validationErrors?.shortName,
                    helperText: validationErrors?.shortName,
                    //remove any previous validation errors when university focuses on the input
                    onFocus: () =>
                        setValidationErrors({
                            ...validationErrors,
                            shortName: undefined,
                        }),
                },
            },
            {
                accessorKey: 'approved',
                header: 'Статус',
                Cell: ({ cell }) => (
                    <div>
                        {cell.getValue<boolean>()
                            ? "Подтвержден"
                            : "Заблокирован"}
                    </div>
                ),
            }
        ],
        [validationErrors],
    );

    //CREATE action

    const handleCreateUserAdmin: MRT_TableOptions<RegisterAdminRequestDto>['onCreatingRowSave'] = async ({
        values,
        table,
    }) => {
        const newValidationErrors = validateUserAdmin(values);

        if (Object.values(newValidationErrors).some((error) => error)) {
            setValidationErrors(newValidationErrors);
            return;
        }

        setValidationErrors({});

        await handleCreateAdmin({
            registerAdminRequestDto: {
                firstName: values.firstName,
                middleName: values.middleName,
                lastName: values.lastName,
                userName: values.userName,
                password: values.password,
                email: values.email,
                birthday: values.birthday
            }
        });

        table.setCreatingRow(null); //exit creating mode

    }

    const handleCreateUserEmployee: MRT_TableOptions<RegisterEmployeeRequestDto>['onCreatingRowSave'] = async ({
        values,
        table,
    }) => {
        const newValidationErrors = validateUserEmployee(values);

        if (Object.values(newValidationErrors).some((error) => error)) {
            setValidationErrors(newValidationErrors);
            return;
        }

        setValidationErrors({});

        await handleCreateEmployee({
            registerEmployeeRequestDto: {
                firstName: values.firstName,
                middleName: values.middleName,
                lastName: values.lastName,
                userName: values.userName,
                password: values.password,
                email: values.email,
                birthday: values.birthday
            }
        });

        table.setCreatingRow(null); //exit creating mode
    };

    const handleCreateUserStudent: MRT_TableOptions<RegisterStudentRequestDto>['onCreatingRowSave'] = async ({
        values,
        table,
    }) => {
        const newValidationErrors = validateUserStudent(values);

        if (Object.values(newValidationErrors).some((error) => error)) {
            setValidationErrors(newValidationErrors);
            return;
        }

        setValidationErrors({});

        await handleCreateStudent({
            registerStudentRequestDto: {
                firstName: values.firstName,
                middleName: values.middleName,
                lastName: values.lastName,
                userName: values.userName,
                password: values.password,
                email: values.email,
                birthday: values.birthday
            }
        });

        table.setCreatingRow(null); //exit creating mode
    };

    return (
        <div className='w-full h-full items-center'>
            <MaterialReactTable
                table={useMaterialReactTable({
                    localization: MRT_Localization_RU,
                    columns,
                    data: dataState.data?.list?.items ?? [],
                    createDisplayMode: 'modal',
                    getRowId: (row) => row.id ?? "",
                    enableRowActions: true,
                    muiToolbarAlertBannerProps: dataState.isError
                        ? {
                            color: 'error',
                            children: 'Error loading data',
                        }
                        : undefined,
                    muiTableContainerProps: {
                        sx: {
                            minHeight: '500px',
                        },
                    },
                    onCreatingRowCancel: () => setValidationErrors({}),
                    onCreatingRowSave: () => {
                        switch (createUserRole) {
                            case 'ApplicationAdmin':
                                return handleCreateUserAdmin;
                            case 'Employee':
                                return handleCreateUserEmployee
                            case 'Student':
                                return handleCreateUserStudent
                        }
                    },
                    renderCreateRowDialogContent: ({ table, row, internalEditComponents }) => (
                        <>
                            <DialogTitle variant="h6">Регистрация нового пользователя</DialogTitle>
                            <Box sx={{ p: 0.1 }} ></Box>
                            <DialogContent
                                sx={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}
                            >
                                <FormControl fullWidth>
                                    <InputLabel id="user-role-label">Роль</InputLabel>
                                    <Select
                                        labelId="user-role-label"
                                        id="user-role-select"
                                        value={createUserRole}
                                        label="Роль"
                                        onChange={(e) => {
                                            switch (e.target.value) {
                                                case UserRoleIdDto.Student:
                                                    setCreateUserRole(UserRoleIdDto.Student);
                                                    break;
                                                case UserRoleIdDto.ApplicationAdmin:
                                                    setCreateUserRole(UserRoleIdDto.ApplicationAdmin);
                                                    break;
                                                case UserRoleIdDto.Employee:
                                                    setCreateUserRole(UserRoleIdDto.Employee);
                                                    break;
                                                default:
                                                    setCreateUserRole(UserRoleIdDto.None);
                                                    break;
                                            }
                                        }}
                                    >
                                        <MenuItem disabled value={UserRoleIdDto.None}>Не выбрана</MenuItem>
                                        <MenuItem value={UserRoleIdDto.Student}>Студент</MenuItem>
                                        <MenuItem value={UserRoleIdDto.ApplicationAdmin}>Администратор</MenuItem>
                                        <MenuItem value={UserRoleIdDto.Employee}>Сотрудник университета</MenuItem>
                                    </Select>
                                </FormControl>
                            </DialogContent>
                            <DialogActions>
                                <MRT_EditActionButtons variant="text" table={table} row={row} />
                            </DialogActions>
                        </>
                    ),
                    renderRowActions: ({ row, table }) => (
                        <Box sx={{ display: 'flex', gap: '1rem' }}>
                            {
                                row.getValue<Boolean>("approved")
                                    ? <Tooltip title="Заблокировать пользователя">
                                        <IconButton color="error" onClick={() => sendUpdateApprovement(false, row.original)}>
                                            <NotInterestedIcon />
                                        </IconButton>
                                    </Tooltip>
                                    : <Tooltip title="Активировать пользователя">
                                        <IconButton color="success" onClick={() => sendUpdateApprovement(true, row.original)}>
                                            <CheckCircleOutlineIcon />
                                        </IconButton>
                                    </Tooltip>
                            }
                        </Box>
                    ),
                    renderTopToolbarCustomActions: ({ table }) => (
                        <Button
                            variant="contained"
                            onClick={() => {
                                table.setCreatingRow(true); //simplest way to open the create row modal with no default values
                                //or you can pass in a row object to set default values with the `createRow` helper function
                                // table.setCreatingRow(
                                //   createRow(table, {
                                //     //optionally pass in default values for the new row, useful for nested data or other complex scenarios
                                //   }),
                                // );
                            }}
                        >
                            Зарегистрировать пользователя
                        </Button>
                    ),
                    state: {
                        isLoading: dataState.isLoading,
                        isSaving: handleCreateAdminState.isLoading || handleCreateEmployeeState.isLoading || handleCreateStudentState.isLoading || handleUpdateApprovementState.isLoading,
                        showAlertBanner: dataState.isError,
                        showProgressBars: dataState.isLoading,
                    },
                })} />
        </div>);
}

export default UserListPage