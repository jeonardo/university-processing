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

interface Department {
  id: number;
  name: string;
  code: string;
}

const DepartmentManagement: React.FC = () => {
  const [departments, setDepartments] = useState<Department[]>([
    { id: 1, name: 'Computer Science Department', code: 'CSD' },
    { id: 2, name: 'Electrical Engineering Department', code: 'EED' },
    { id: 3, name: 'Mechanical Engineering Department', code: 'MED' }
  ]);

  const [openDialog, setOpenDialog] = useState(false);
  const [editingDepartment, setEditingDepartment] = useState<Department | null>(null);

  const handleOpenDialog = (department: Department | null) => {
    setEditingDepartment(department || { id: Date.now(), name: '', code: '' });
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setEditingDepartment(null);
  };

  const handleSaveDepartment = () => {
    if (editingDepartment) {
      const updatedDepartments = editingDepartment.id
        ? departments.map((d) => (d.id === editingDepartment.id ? editingDepartment : d))
        : [...departments, editingDepartment];
      setDepartments(updatedDepartments);
      handleCloseDialog();
    }
  };

  const handleDeleteDepartment = (id: number) => {
    setDepartments(departments.filter((d) => d.id !== id));
  };

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <Typography variant="h6" gutterBottom>
          Department Management
        </Typography>
        <Button variant="contained" color="primary" onClick={() => handleOpenDialog(null)}>
          Add New Department
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
            {departments.map((department) => (
              <TableRow key={department.id}>
                <TableCell>{department.name}</TableCell>
                <TableCell>{department.code}</TableCell>
                <TableCell>
                  <Button onClick={() => handleOpenDialog(department)}>Edit</Button>
                  <Button onClick={() => handleDeleteDepartment(department.id)} color="secondary">
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Dialog open={openDialog} onClose={handleCloseDialog}>
        <DialogTitle>{editingDepartment?.id ? 'Edit Department' : 'Add New Department'}</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Name"
            type="text"
            fullWidth
            value={editingDepartment?.name || ''}
            onChange={(e) => setEditingDepartment((prev) => (prev ? { ...prev, name: e.target.value } : null))}
          />
          <TextField
            margin="dense"
            label="Code"
            type="text"
            fullWidth
            value={editingDepartment?.code || ''}
            onChange={(e) => setEditingDepartment((prev) => (prev ? { ...prev, code: e.target.value } : null))}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog}>Cancel</Button>
          <Button onClick={handleSaveDepartment} color="primary">
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default DepartmentManagement;

