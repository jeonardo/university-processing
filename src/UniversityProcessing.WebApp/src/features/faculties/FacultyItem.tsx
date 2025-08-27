import React from 'react';
import { ListItem, ListItemText, Typography } from '@mui/material';
import { FacultiesGetFaculty } from 'src/api/backendApi';

interface FacultyItemProps<T> {
  item: T;
}

const FacultyItem: React.FC<FacultyItemProps<FacultiesGetFaculty>> = ({ item }) => {
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

export default FacultyItem;