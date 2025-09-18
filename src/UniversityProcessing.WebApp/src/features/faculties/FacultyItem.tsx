import React from 'react';
import { ListItem, ListItemText, Typography } from '@mui/material';
import { SxProps, Theme } from '@mui/material/styles';
import { ApiFacultiesGetFacultyDto, useGetApiGroupsGetQuery } from 'src/api/backendApi';

interface FacultyItemProps<T> {
  item: T;
  onClick?: (item: T) => void;
  sx?: SxProps<Theme>;
  className?: string;
}

const FacultyItem: React.FC<FacultyItemProps<ApiFacultiesGetFacultyDto>> = ({ item, onClick, sx, className }) => {
  return (
    <ListItem
      key={item.id}
      className={`py-4 flex justify-between items-center ${className ?? ''}`}
      sx={sx}
      onClick={() => onClick?.(item)}
    >
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