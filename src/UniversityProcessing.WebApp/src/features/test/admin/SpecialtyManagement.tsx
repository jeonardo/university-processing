import type React from 'react';
import { useState } from 'react';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography
} from '@mui/material';

interface Specialty {
  id: number;
  name: string;
  code: string;
}

const SpecialtyManagement: React.FC = () => {
  const [specialties, setSpecialties] = useState<Specialty[]>([
    { id: 1, name: 'Computer Science', code: 'CS' },
    { id: 2, name: 'Electrical Engineering', code: 'EE' },
    { id: 3, name: 'Mechanical Engineering', code: 'ME' }
  ]);

  const [openDialog, setOpenDialog] = useState(false);
  const [editingSpecialty, setEditingSpecialty] = useState<Specialty | null>(null);

  const handleOpenDialog = (specialty: Specialty | null) => {
    setEditingSpecialty(specialty || { id: Date.now(), name: '', code: '' });
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setEditingSpecialty(null);
  };

  const handleSaveSpecialty = () => {
    if (editingSpecialty) {
      const updatedSpecialties = editingSpecialty.id
        ? specialties.map((s) => (s.id === editingSpecialty.id ? editingSpecialty : s))
        : [...specialties, editingSpecialty];
      setSpecialties(updatedSpecialties);
      handleCloseDialog();
    }
  };

  const handleDeleteSpecialty = (id: number) => {
    setSpecialties(specialties.filter((s) => s.id !== id));
  };

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <Typography variant="h6" gutterBottom>
          Specialty Management
        </Typography>
        <Button variant="contained" color="primary" onClick={() => handleOpenDialog(null)}>
          Add New Specialty
        </Button>
      </div>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Code</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {specialties.map((specialty) => (
              <TableRow key={specialty.id}>
                <TableCell>{specialty.name}</TableCell>
                <TableCell>{specialty.code}</TableCell>
                <TableCell>
                  <Button onClick={() => handleOpenDialog(specialty)}>Edit</Button>
                  <Button onClick={() => handleDeleteSpecialty(specialty.id)} color="secondary">
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Dialog open={openDialog} onClose={handleCloseDialog}>
        <DialogTitle>{editingSpecialty?.id ? 'Edit Specialty' : 'Add New Specialty'}</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Name"
            type="text"
            fullWidth
            value={editingSpecialty?.name || ''}
            onChange={(e) => setEditingSpecialty((prev) => (prev ? { ...prev, name: e.target.value } : null))}
          />
          <TextField
            margin="dense"
            label="Code"
            type="text"
            fullWidth
            value={editingSpecialty?.code || ''}
            onChange={(e) => setEditingSpecialty((prev) => (prev ? { ...prev, code: e.target.value } : null))}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog}>Cancel</Button>
          <Button onClick={handleSaveSpecialty} color="primary">
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default SpecialtyManagement;

