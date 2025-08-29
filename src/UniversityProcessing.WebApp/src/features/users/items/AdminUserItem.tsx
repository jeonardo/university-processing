import { ListItem, ListItemText } from '@mui/material';
import { UsersGetAdminsAdmin } from 'src/api/backendApi';
import { namingTools } from 'src/core/namingTools';
import { VerificationControl } from '../components';

interface Props {
  item: UsersGetAdminsAdmin;
}

export default function AdminUserItem({ item }: Props) {
  const fullName = namingTools.fullName(item);

  return (
    <ListItem>
      <ListItemText primary={fullName || '—'} />
      <VerificationControl userId={item.id!} isApproved={item.approved ?? false} />
    </ListItem>
  );
}


