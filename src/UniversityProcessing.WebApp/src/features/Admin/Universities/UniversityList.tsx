import React from 'react';
import { List, ListItem, ListItemText, Button, Typography, Box } from '@mui/material';
import { CommonGetUniversitiesUniversity } from 'src/api/backendApi';

interface UniversityListProps<T> {
  universities: T[];
  onDelete: (id: string) => void;
  isAdmin: boolean;
}

const UniversityList: React.FC<UniversityListProps<CommonGetUniversitiesUniversity>> = ({ universities, onDelete, isAdmin }) => {
  if (universities.length === 0) {
    return <Typography className="text-center py-4">No universities available.</Typography>;
  }

  return (
    <List className="divide-y divide-gray-200">
      {universities.map((university) => (
        <ListItem key={university.id} className="py-4 flex justify-between items-center">
          <ListItemText
            primary={university.name}
            secondary={
              <Typography variant="body2" color="text.secondary" component="span">
                {university.location}
              </Typography>
            }
          />
          {isAdmin && (
            <Button
              onClick={() => onDelete(university.id)}
              variant="contained"
              color="error"
              size="small"
            >
              Delete
            </Button>
          )}
        </ListItem>
      ))}
    </List>
  );
};

export default UniversityList;

