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

interface Faculty {
  id: number;
  name: string;
  dean: string;
}

const FacultyManagement: React.FC = () => {
  const [faculties, setFaculties] = useState<Faculty[]>([
    { id: 1, name: 'Faculty of Science', dean: 'Dr. John Doe' },
    { id: 2, name: 'Faculty of Engineering', dean: 'Prof. Jane Smith' },
    { id: 3, name: 'Faculty of Arts', dean: 'Dr. Michael Johnson' }
  ]);

  const [openDialog, setOpenDialog] = useState(false);
  const [editingFaculty, setEditingFaculty] = useState<Faculty | null>(null);

  const handleOpenDialog = (faculty: Faculty | null) => {
    setEditingFaculty(faculty || { id: Date.now(), name: '', dean: '' });
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setEditingFaculty(null);
  };

  const handleSaveFaculty = () => {
    if (editingFaculty) {
      const updatedFaculties = editingFaculty.id
        ? faculties.map((f) => (f.id === editingFaculty.id ? editingFaculty : f))
        : [...faculties, editingFaculty];
      setFaculties(updatedFaculties);
      handleCloseDialog();
    }
  };

  const handleDeleteFaculty = (id: number) => {
    setFaculties(faculties.filter((f) => f.id !== id));
  };

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <Typography variant="h6" gutterBottom>
          Faculty Management
        </Typography>
        <Button variant="contained" color="primary" onClick={() => handleOpenDialog(null)}>
          Add New Faculty
        </Button>
      </div>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Dean</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {faculties.map((faculty) => (
              <TableRow key={faculty.id}>
                <TableCell>{faculty.name}</TableCell>
                <TableCell>{faculty.dean}</TableCell>
                <TableCell>
                  <Button onClick={() => handleOpenDialog(faculty)}>Edit</Button>
                  <Button onClick={() => handleDeleteFaculty(faculty.id)} color="secondary">
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Dialog open={openDialog} onClose={handleCloseDialog}>
        <DialogTitle>{editingFaculty?.id ? 'Edit Faculty' : 'Add New Faculty'}</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Name"
            type="text"
            fullWidth
            value={editingFaculty?.name || ''}
            onChange={(e) => setEditingFaculty((prev) => (prev ? { ...prev, name: e.target.value } : null))}
          />
          <TextField
            margin="dense"
            label="Dean"
            type="text"
            fullWidth
            value={editingFaculty?.dean || ''}
            onChange={(e) => setEditingFaculty((prev) => (prev ? { ...prev, dean: e.target.value } : null))}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog}>Cancel</Button>
          <Button onClick={handleSaveFaculty} color="primary">
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default FacultyManagement;

