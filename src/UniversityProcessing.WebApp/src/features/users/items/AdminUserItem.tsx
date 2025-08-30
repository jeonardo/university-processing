import React from 'react';
import { ListItem, ListItemText } from '@mui/material';
import { UsersGetAdminsAdmin } from 'src/api/backendApi';
import { namingTools } from 'src/core/namingTools';
import { VerificationControl } from '../components';

interface Props {
  item: UsersGetAdminsAdmin;
}

const AdminUserItem = React.memo(({ item }: Props) => {
  const fullName = React.useMemo(() => namingTools.fullName(item), [item]);

  return (
    <ListItem>
      <ListItemText primary={fullName || '—'} />
      <VerificationControl userId={item.id!} isApproved={item.approved ?? false} />
    </ListItem>
  );
});

AdminUserItem.displayName = 'AdminUserItem';

export default AdminUserItem;


