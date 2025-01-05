import React, { useState } from 'react';
import { TextField, Button, Box, Typography } from '@mui/material';

interface AddUniversityFormProps {
  onSubmit: (name: string, location: string) => void;
}

const AddUniversityForm: React.FC<AddUniversityFormProps> = ({ onSubmit }) => {
  const [name, setName] = useState('');
  const [location, setLocation] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(name, location);
    setName('');
    setLocation('');
  };

  return (
    <Box component="form" onSubmit={handleSubmit} className="mb-6 bg-gray-100 p-4 rounded-lg">
      <Typography variant="h6" className="mb-4">Add New University</Typography>
      <Box className="flex flex-col md:flex-row gap-4">
        <TextField
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="University Name"
          variant="outlined"
          size="small"
          required
          className="flex-grow"
        />
        <TextField
          value={location}
          onChange={(e) => setLocation(e.target.value)}
          placeholder="Location"
          variant="outlined"
          size="small"
          required
          className="flex-grow"
        />
        <Button type="submit" variant="contained" color="primary">
          Add University
        </Button>
      </Box>
    </Box>
  );
};

export default AddUniversityForm;

