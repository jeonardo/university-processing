import { MRT_Localization_RU } from 'material-react-table/locales/ru';

import { useEffect, useMemo, useState } from 'react';
import {
  MaterialReactTable,
  type MRT_ColumnDef,
  MRT_PaginationState,
  MRT_Updater,
  useMaterialReactTable
} from 'material-react-table';
import { Box, IconButton, Tooltip } from '@mui/material';
import NotInterestedIcon from '@mui/icons-material/NotInterested';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import {
  useLazyGetApiV1AdminGetUsersQuery,
  usePutApiV1AdminUpdateIsApprovedStatusMutation,
  UserDto
} from 'src/api/backendApi';


type Pagination = {
  pageIndex: number;
  pageSize: number;
}

const UserListPage = () => {
  const [pagination, setPagination] = useState<Pagination>({
    pageIndex: 0,
    pageSize: 25
  });

  const [getTableData, tableData] = useLazyGetApiV1AdminGetUsersQuery({ pollingInterval: 50000 });
  const [handleUpdateApprovement, handleUpdateApprovementState] = usePutApiV1AdminUpdateIsApprovedStatusMutation();
  const [isActualTableData, setIsActualTableData] = useState(false);

  const sendUpdateApprovement = (approved: boolean, user: UserDto) => {
    handleUpdateApprovement({ updateIsApprovedStatusRequestDto: { isApproved: approved, userId: user.id ?? '' } });
    setTimeout(() => {
      setIsActualTableData(false);
    }, 1500);
  };

  useEffect(() => {
    if (isActualTableData) {
      return;
    }
    getTableData({ pageNumber: pagination.pageIndex + 1, pageSize: pagination.pageSize });
    setIsActualTableData(true);
  }, [pagination, isActualTableData, handleUpdateApprovementState]);

  const onPaginationChanged = (update: MRT_Updater<MRT_PaginationState>) => {
    setPagination(update);
    setIsActualTableData(false);
  };

  const columns = useMemo<MRT_ColumnDef<UserDto>[]>(
    () => [
      {
        accessorKey: 'id',
        header: 'ID',
        Cell: ({ cell }) => (
          <Tooltip title={`Идентификатор: ${cell.getValue<string>()}`}>
            <div>{cell.getValue<string>()}</div>
          </Tooltip>
        )
      },
      {
        accessorKey: 'lastName',
        header: 'Фамилия'
      },
      {
        accessorKey: 'firstName',
        header: 'Имя'
      },
      {
        accessorKey: 'middleName',
        header: 'Отчество'
      },
      {
        accessorKey: 'approved',
        header: 'Статус',
        Cell: ({ cell }) => (
          <div>
            {cell.getValue<boolean>()
              ? 'Подтвержден'
              : 'Заблокирован'}
          </div>
        )
      }
    ], []
  );

  return (
    <div className="w-full h-full items-center">
      <MaterialReactTable
        table={useMaterialReactTable({
          manualPagination: true,
          onPaginationChange: onPaginationChanged,
          state: {
            pagination: pagination,
            isLoading: tableData.isLoading,
            isSaving: handleUpdateApprovementState.isLoading,
            showAlertBanner: tableData.isError,
            showProgressBars: tableData.isLoading,
            columnVisibility: { id: false }
          },
          pageCount: 111,
          rowCount: tableData.data?.list?.totalCount ?? 0,
          localization: MRT_Localization_RU, //tableData.data?.list?.currentPage ?? 0,
          columns,
          data: tableData.data?.list?.items ?? [],
          getRowId: (row) => row.id ?? '',
          enableRowActions: true,
          enableHiding: false,
          muiToolbarAlertBannerProps: tableData.isError
            ? {
              color: 'error',
              children: 'Error loading data'
            }
            : undefined,
          renderRowActions: ({ row }) => (
            <Box sx={{ display: 'flex', gap: '1rem' }}>
              {
                row.getValue<Boolean>('approved')
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
          )
        })}
      />
    </div>
  );
};

export default UserListPage;