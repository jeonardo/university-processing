import React from 'react';
import { ListItem, ListItemText } from '@mui/material';
import { CommonGetGroupsGroup } from 'src/api/backendApi';

interface GroupItemProps<T> {
  item: T;
}

const GroupItem: React.FC<GroupItemProps<CommonGetGroupsGroup>> = ({ item }) => {
  return (
    <ListItem key={item.id} className="py-4 flex justify-between items-center">
      <ListItemText
        primary={`Группа номер ${item.number}`}
      />
    </ListItem>);
};

export default GroupItem;