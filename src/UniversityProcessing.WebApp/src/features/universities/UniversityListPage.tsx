import { MRT_Localization_RU } from 'material-react-table/locales/ru';
import { UniversityCreateRequestDto, UniversityDto, UniversityDtoPagedList, UniversityListResponseDto, useDeleteApiV1UniversityDeleteMutation, useGetApiV1UniversityListQuery, usePostApiV1UniversityCreateMutation } from 'src/api/backendApi';

import { useEffect, useMemo, useState } from 'react';
import {
    MRT_EditActionButtons,
    MaterialReactTable,
    // createRow,
    type MRT_ColumnDef,
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
    Tooltip,
} from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import ValidationRules from 'src/core/ValidationRules';



function validateUniversity(university: UniversityCreateRequestDto) {
    return {
        name: !ValidationRules.validateRequired(university.name) ? 'First Name is Required' : '',
        shortName: !ValidationRules.validateRequired(university.shortName) ? 'Last Name is Required' : ''
    };
}

const UniversityListPage = () => {
    const dataState = useGetApiV1UniversityListQuery({})

    const [handleCreate, handleCreateState] = usePostApiV1UniversityCreateMutation()
    const [handleDelete, handleDeleteState] = useDeleteApiV1UniversityDeleteMutation()

    const [validationErrors, setValidationErrors] = useState<
        Record<string, string | undefined>
    >({});

    const columns = useMemo<MRT_ColumnDef<UniversityDto>[]>(
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
    const handleCreateUniversity: MRT_TableOptions<UniversityDto>['onCreatingRowSave'] = async ({
        values,
        table,
    }) => {
        const newValidationErrors = validateUniversity(values);
        if (Object.values(newValidationErrors).some((error) => error)) {
            setValidationErrors(newValidationErrors);
            return;
        }
        setValidationErrors({});

        await handleCreate({ universityCreateRequestDto: { name: values.name, shortName: values.shortName } });

        table.setCreatingRow(null); //exit creating mode
    };

    //DELETE action
    const openDeleteConfirmModal = async (row: MRT_Row<UniversityDto>) => {
        if (window.confirm('Are you sure you want to delete this university?')) {
            await handleDelete({ universityDeleteRequestDto: { id: row.original.id } })
        }
    };

    return (
        <div className='w-full h-full items-center'>
            <MaterialReactTable table={useMaterialReactTable({
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
                onCreatingRowSave: handleCreateUniversity,
                renderCreateRowDialogContent: ({ table, row, internalEditComponents }) => (
                    <>
                        <DialogTitle variant="h6">Регистрация нового университета</DialogTitle>
                        <DialogContent
                            sx={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}
                        >
                            {internalEditComponents} {/* or render custom edit components here */}
                        </DialogContent>
                        <DialogActions>
                            <MRT_EditActionButtons variant="text" table={table} row={row} />
                        </DialogActions>
                    </>
                ),
                renderRowActions: ({ row, table }) => (
                    <Box sx={{ display: 'flex', gap: '1rem' }}>
                        <Tooltip title="Delete">
                            <IconButton color="error" onClick={() => openDeleteConfirmModal(row)}>
                                <DeleteIcon />
                            </IconButton>
                        </Tooltip>
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
                        Создать
                    </Button>
                ),
                state: {
                    isLoading: dataState.isLoading,
                    isSaving: handleCreateState.isLoading || handleDeleteState.isLoading,
                    showAlertBanner: dataState.isError,
                    showProgressBars: dataState.isLoading,
                },
            })} />
        </div>);
}

export default UniversityListPage