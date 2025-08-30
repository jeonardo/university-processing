import { ListItem, ListItemText } from '@mui/material';

interface GenericUserItemProps {
  item: any;
}

const GenericUserItem: React.FC<GenericUserItemProps> = ({ item }) => {
  const fullName = [item?.lastName, item?.firstName, item?.middleName].filter(Boolean).join(' ');
  const secondary = item?.position || item?.groupNumber || item?.email || '';

  return (
    <ListItem>
      <ListItemText primary={fullName || '—'} secondary={secondary} />
    </ListItem>
  );
};

export default GenericUserItem;





