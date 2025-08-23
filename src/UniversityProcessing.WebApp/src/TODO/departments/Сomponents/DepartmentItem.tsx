import React from 'react';
import { ListItem, ListItemText, Typography } from '@mui/material';
import { CommonGetDepartmentsDepartment } from 'src/api/backendApi';

interface DepartmentItemProps<T> {
  item: T;
}

const DepartmentItem: React.FC<DepartmentItemProps<CommonGetDepartmentsDepartment>> = ({ item }) => {
  return (
    <ListItem key={item.id} className="py-4 flex justify-between items-center">
      <ListItemText
        primary={item.shortName}
        secondary={
          <Typography variant="body2" color="text.secondary" component="span">
            {item.name}
          </Typography>
        }
      />
    </ListItem>);
};

export default DepartmentItem;