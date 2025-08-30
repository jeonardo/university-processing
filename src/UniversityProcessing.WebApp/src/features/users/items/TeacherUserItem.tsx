import React from 'react';
import { ListItem, ListItemText } from '@mui/material';
import { UsersGetTeachersTeacher } from 'src/api/backendApi';
import { namingTools } from 'src/core/namingTools';
import { VerificationControl } from '../components';

interface Props {
  item: UsersGetTeachersTeacher;
}

const TeacherUserItem = React.memo(({ item }: Props) => {
  const fullName = React.useMemo(() => namingTools.fullName(item), [item]);
  const secondary = React.useMemo(() => item?.position || '', [item?.position]);

  return (
    <ListItem>
      <ListItemText primary={fullName || '—'} secondary={secondary} />
      <VerificationControl userId={item.id!} isApproved={item.approved ?? false} />
    </ListItem>
  );
});

TeacherUserItem.displayName = 'TeacherUserItem';

export default TeacherUserItem;


