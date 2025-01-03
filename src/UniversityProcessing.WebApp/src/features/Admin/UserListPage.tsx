import { useEffect, useMemo, useState } from 'react';
import { Box, IconButton, Tooltip } from '@mui/material';
import NotInterestedIcon from '@mui/icons-material/NotInterested';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import { useLazyGetApiAdminUsersGetUsersQuery, usePutApiAdminUsersUpdateApprovalMutation } from 'src/api/backendApi';

type Pagination = {
  pageIndex: number;
  pageSize: number;
}

const UserListPage = () => {
  const [pagination, setPagination] = useState<Pagination>({
    pageIndex: 0,
    pageSize: 25
  });

  const [getTableData, tableData] = useLazyGetApiAdminUsersGetUsersQuery({ pollingInterval: 50000 });
  const [handleUpdateApprovement, handleUpdateApprovementState] = usePutApiAdminUsersUpdateApprovalMutation();
  const [isActualTableData, setIsActualTableData] = useState(false);

  const sendUpdateApprovement = (approved: boolean, user: any) => {
    handleUpdateApprovement({ adminUsersUpdateApprovalRequest: { isApproved: approved, userId: user.id ?? '' } });
    setTimeout(() => {
      setIsActualTableData(false);
    }, 1500);
  };

  useEffect(() => {
    if (isActualTableData) {
      return;
    }
    //TODO getTableData({ pageNumber: pagination.pageIndex + 1, pageSize: pagination.pageSize });
    setIsActualTableData(true);
  }, [pagination, isActualTableData, handleUpdateApprovementState]);

  return (
    <div className="w-full h-full items-center">
      <Box sx={{ display: 'flex', gap: '1rem' }}>
        {
          true
            ? <Tooltip title="Заблокировать пользователя">
              {/* //TODO */}
              <IconButton color="error" onClick={() => sendUpdateApprovement(false, null)}>
                <NotInterestedIcon />
              </IconButton>
            </Tooltip>
            : <Tooltip title="Активировать пользователя">
              {/* //TODO */}
              <IconButton color="success" onClick={() => sendUpdateApprovement(true, null)}>
                <CheckCircleOutlineIcon />
              </IconButton>
            </Tooltip>
        }
      </Box>
    </div>
  );
};

export default UserListPage;