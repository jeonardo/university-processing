import {MRT_Localization_RU} from 'material-react-table/locales/ru';

import {useMemo, useState} from 'react';
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
    IconButton,
    InputLabel,
    MenuItem,
    Select,
    Tooltip,
} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import {
    RegisterAdminRequestDto,
    RegisterEmployeeRequestDto,
    RegisterStudentRequestDto,
    useDeleteApiV1IdentityDeleteMutation,
    useGetApiV1UserGetListQuery,
    usePostApiV1IdentityRegisterAdminMutation,
    usePostApiV1IdentityRegisterEmployeeMutation,
    usePostApiV1IdentityRegisterStudentMutation,
    UserDto,
    UserRoleIdDto
} from 'src/api/backendApi';
import {Switch} from 'src/core/Switch';

function validateUserAdmin(university: RegisterAdminRequestDto) {
    return {
        // name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        // shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

function validateUserStudent(university: RegisterStudentRequestDto) {
    return {
        // name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        // shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

function validateUserEmployee(university: RegisterEmployeeRequestDto) {
    return {
        // name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        // shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

const UserListPage = () => {
    const dataState = useGetApiV1UserGetListQuery({})

    const [createUserRole, setCreateUserRole] = useState<UserRoleIdDto>('None')
    const userRoles = ['None', 'ApplicationAdmin', 'Employee', 'Student'];
    const isUserRole = (x: any): x is UserRoleIdDto => userRoles.includes(x);

    const [handleCreateAdmin, handleCreateAdminState] = usePostApiV1IdentityRegisterAdminMutation()
    const [handleCreateStudent, handleCreateStudentState] = usePostApiV1IdentityRegisterStudentMutation()
    const [handleCreateEmployee, handleCreateEmployeeState] = usePostApiV1IdentityRegisterEmployeeMutation()

    const [handleDelete, handleDeleteState] = useDeleteApiV1IdentityDeleteMutation()

    const [validationErrors, setValidationErrors] = useState<
        Record<string, string | undefined>
    >({});

    const columns = useMemo<MRT_ColumnDef<UserDto>[]>(
        () => [
            {
                accessorKey: 'name',
                header: 'Name',
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
                accessorKey: 'shortName',
                header: 'Short name',
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

        //await handleCreateAdmin({ registerAdminRequestDto: { name: values.name, shortName: values.shortName } });

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

        // await handleCreateEmployee({ registerEmployeeRequestDto: { name: values.name, shortName: values.shortName } });

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

        //await handleCreateStudent({ registerStudentRequestDto: { name: values.name, shortName: values.shortName } });

        table.setCreatingRow(null); //exit creating mode
    };

    //DELETE action
    const openDeleteConfirmModal = async (row: MRT_Row<UserDto>) => {
        if (window.confirm('Are you sure you want to delete this university?')) {
            await handleDelete({userDeleteRequestDto: {id: row.original.id}})
        }
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
                    renderCreateRowDialogContent: ({table, row, internalEditComponents}) => (
                        <>
                            <DialogTitle variant="h6">Регистрация нового университета</DialogTitle>
                            <DialogContent
                                sx={{display: 'flex', flexDirection: 'column', gap: '1rem'}}
                            >
                                <InputLabel id="create-user-role-label">Роль нового пользователя</InputLabel>
                                <Select
                                    labelId="create-user-role-label"
                                    id="create-user-role-select"
                                    value={createUserRole}
                                    onChange={(value) => {
                                        const newRole = value.target.value
                                        if (isUserRole(newRole))
                                            setCreateUserRole(newRole)
                                    }}
                                >
                                    <MenuItem value="None">
                                        <em>Не выбран</em>
                                    </MenuItem>
                                    <MenuItem value={'ApplicationAdmin'}>Администратор</MenuItem>
                                    <MenuItem value={'Employee'}>Сотрудник университета</MenuItem>
                                    <MenuItem value={'Student'}>Студент</MenuItem>
                                </Select>
                                <Switch condition={createUserRole}>
                                    <Switch.Case when={'ApplicationAdmin'}>
                                        <div className="case-item">ApplicationAdmin</div>
                                    </Switch.Case>
                                    <Switch.Case when={'Employee'}>
                                        <div className="case-item">Employee</div>
                                    </Switch.Case>
                                    <Switch.Case when={'Student'}>
                                        <div className="case-item">Student</div>
                                    </Switch.Case>
                                </Switch>
                                {/* {internalEditComponents} or render custom edit components here */}
                            </DialogContent>
                            <DialogActions>
                                <MRT_EditActionButtons variant="text" table={table} row={row}/>
                            </DialogActions>
                        </>
                    ),
                    renderRowActions: ({row, table}) => (
                        <Box sx={{display: 'flex', gap: '1rem'}}>
                            <Tooltip title="Delete">
                                <IconButton color="error" onClick={() => openDeleteConfirmModal(row)}>
                                    <DeleteIcon/>
                                </IconButton>
                            </Tooltip>
                        </Box>
                    ),
                    renderTopToolbarCustomActions: ({table}) => (
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
                            Создать
                        </Button>
                    ),
                    state: {
                        isLoading: dataState.isLoading,
                        isSaving: handleCreateAdminState.isLoading || handleCreateEmployeeState.isLoading || handleCreateStudentState.isLoading || handleDeleteState.isLoading,
                        showAlertBanner: dataState.isError,
                        showProgressBars: dataState.isLoading,
                    },
                })}/>
        </div>);
}

export default UserListPage