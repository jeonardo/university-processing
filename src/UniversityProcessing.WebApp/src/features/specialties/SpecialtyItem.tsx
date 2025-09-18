import React from 'react';
import { Box, Chip, IconButton, ListItem, ListItemText, Typography } from '@mui/material';
import { Delete as DeleteIcon } from '@mui/icons-material';
import { SxProps, Theme } from '@mui/material/styles';
import { ApiSpecialtiesGetSpecialtyDto } from 'src/api/backendApi';

interface SpecialtyItemProps<T> {
  item: T;
  onClick?: (item: T) => void;
  onDelete?: (item: T) => void;
  sx?: SxProps<Theme>;
  className?: string;
}

const SpecialtyItem: React.FC<SpecialtyItemProps<ApiSpecialtiesGetSpecialtyDto>> = ({
                                                                                      item,
                                                                                      onClick,
                                                                                      onDelete,
                                                                                      sx,
                                                                                      className
                                                                                    }) => {
  const handleDeleteClick = (event: React.MouseEvent) => {
    event.stopPropagation();
    onDelete?.(item);
  };

  return (
    <ListItem
      key={item.id}
      className={`py-4 flex justify-between items-center ${className ?? ''}`}
      sx={sx}
      onClick={() => onClick?.(item)}
    >
      <ListItemText
        primary={
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <Typography variant="h6" component="span">
              {item.shortName}
            </Typography>
            <Chip
              label={item.code ?? 'Код'}
              size="small"
              color="primary"
              variant="outlined"
            />
          </Box>
        }
        secondary={
          <Typography variant="body2" color="text.secondary" component="span">
            {item.name}
          </Typography>
        }
      />
      {onDelete && (
        <IconButton
          onClick={handleDeleteClick}
          color="error"
          size="small"
          sx={{ ml: 1 }}
        >
          <DeleteIcon />
        </IconButton>
      )}
    </ListItem>
  );
};

export default SpecialtyItem;






