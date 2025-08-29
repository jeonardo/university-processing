import { ListItem, ListItemText } from '@mui/material';
import { UsersGetDeaneriesDeanery } from 'src/api/backendApi';
import { namingTools } from 'src/core/namingTools';
import { VerificationControl } from '../components';

interface Props {
  item: UsersGetDeaneriesDeanery;
}

export default function DeaneryUserItem({ item }: Props) {
  const fullName = namingTools.fullName(item);
  const secondary = item?.position || '';

  return (
    <ListItem>
      <ListItemText primary={fullName || '—'} secondary={secondary} />
      <VerificationControl userId={item.id!} isApproved={item.approved ?? false} />
    </ListItem>
  );
}


