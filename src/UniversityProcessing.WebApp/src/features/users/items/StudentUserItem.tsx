import { ListItem, ListItemText } from '@mui/material';
import { UsersGetStudentsStudent } from 'src/api/backendApi';
import { namingTools } from 'src/core/namingTools';
import { VerificationControl } from '../components';

interface Props {
  item: UsersGetStudentsStudent;
}

export default function StudentUserItem({ item }: Props) {
  const fullName = namingTools.fullName(item);

  return (
    <ListItem>
      <ListItemText primary={fullName || '—'} />
      <VerificationControl userId={item.id!} isApproved={item.approved ?? false} />
    </ListItem>
  );
}


