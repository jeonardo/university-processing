import React, { useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, Stack, TextField } from '@mui/material';
import { ApiSpecialtiesCreateRequestDto } from 'src/api/backendApi';
import { useAppSelector } from 'src/core';

interface SpecialtyFormDialogProps {
  open: boolean;
  onClose: () => void;
  onSubmit: (data: ApiSpecialtiesCreateRequestDto) => void;
  isLoading?: boolean;
}

const SpecialtyFormDialog: React.FC<SpecialtyFormDialogProps> = ({ open, onClose, onSubmit, isLoading = false }) => {
  const [name, setName] = useState('');
  const [shortName, setShortName] = useState('');
  const [code, setCode] = useState('');

  const user = useAppSelector(state => state.auth.user);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({ name, shortName, code, departmentId: user?.departmentId ?? '' });
  };

  const handleClose = () => {
    setName('');
    setShortName('');
    setCode('');
    onClose();
  };

  return (
    <Dialog open={open} onClose={handleClose} maxWidth="sm" fullWidth>
      <DialogTitle>Создать специальность</DialogTitle>
      <form onSubmit={handleSubmit}>
        <DialogContent>
          <Stack spacing={2} sx={{ pt: 2 }}>
            <TextField
              label="Название"
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
              fullWidth
              disabled={isLoading}
            />
            <TextField
              label="Краткое название"
              value={shortName}
              onChange={(e) => setShortName(e.target.value)}
              required
              fullWidth
              disabled={isLoading}
            />
            <TextField
              label="Код"
              value={code}
              onChange={(e) => setCode(e.target.value)}
              required
              fullWidth
              disabled={isLoading}
            />

          </Stack>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} disabled={isLoading}>Отмена</Button>
          <Button type="submit" variant="contained" disabled={isLoading}>
            {isLoading ? 'Создание...' : 'Создать'}
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  );
};

export default SpecialtyFormDialog;






