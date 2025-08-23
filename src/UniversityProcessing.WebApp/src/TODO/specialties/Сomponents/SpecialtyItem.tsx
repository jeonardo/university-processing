import React from 'react';
import { ListItem, ListItemText, Typography } from '@mui/material';
import { CommonGetSpecialtiesSpecialty } from 'src/api/backendApi';

interface SpecialtyItemProps<T> {
  item: T;
}

const SpecialtyItem: React.FC<SpecialtyItemProps<CommonGetSpecialtiesSpecialty>> = ({ item }) => {
  return (
    <ListItem key={item.id} className="py-4 flex justify-between items-center">
      <ListItemText
        primary={item.name}
        secondary={
          <Typography variant="body2" color="text.secondary" component="span">
            {item.code}
          </Typography>
        }
      />
    </ListItem>);
};

export default SpecialtyItem;