import type React from 'react';
import { useState } from 'react';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  MenuItem,
  Paper,
  Select,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography
} from '@mui/material';

interface User {
  id: number;
  name: string;
  email: string;
  role: 'Admin' | 'Employee' | 'Student';
}

const UserManagement: React.FC = () => {
  const [users, setUsers] = useState<User[]>([
    { id: 1, name: 'John Doe', email: 'john@example.com', role: 'Admin' },
    { id: 2, name: 'Jane Smith', email: 'jane@example.com', role: 'Employee' },
    { id: 3, name: 'Alice Johnson', email: 'alice@example.com', role: 'Student' }
  ]);

  const [openDialog, setOpenDialog] = useState(false);
  const [editingUser, setEditingUser] = useState<User | null>(null);

  const handleOpenDialog = (user: User | null) => {
    setEditingUser(user || { id: Date.now(), name: '', email: '', role: 'Student' });
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setEditingUser(null);
  };

  const handleSaveUser = () => {
    if (editingUser) {
      const updatedUsers = editingUser.id
        ? users.map((u) => (u.id === editingUser.id ? editingUser : u))
        : [...users, editingUser];
      setUsers(updatedUsers);
      handleCloseDialog();
    }
  };

  const handleDeleteUser = (id: number) => {
    setUsers(users.filter((u) => u.id !== id));
  };

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <Typography variant="h6" gutterBottom>
          User Management
        </Typography>
        <Button variant="contained" color="primary" onClick={() => handleOpenDialog(null)}>
          Add New User
        </Button>
      </div>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Email</TableCell>
              <TableCell>Role</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {users.map((user) => (
              <TableRow key={user.id}>
                <TableCell>{user.name}</TableCell>
                <TableCell>{user.email}</TableCell>
                <TableCell>{user.role}</TableCell>
                <TableCell>
                  <Button onClick={() => handleOpenDialog(user)}>Edit</Button>
                  <Button onClick={() => handleDeleteUser(user.id)} color="secondary">
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Dialog open={openDialog} onClose={handleCloseDialog}>
        <DialogTitle>{editingUser?.id ? 'Edit User' : 'Add New User'}</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Name"
            type="text"
            fullWidth
            value={editingUser?.name || ''}
            onChange={(e) => setEditingUser((prev) => (prev ? { ...prev, name: e.target.value } : null))}
          />
          <TextField
            margin="dense"
            label="Email"
            type="email"
            fullWidth
            value={editingUser?.email || ''}
            onChange={(e) => setEditingUser((prev) => (prev ? { ...prev, email: e.target.value } : null))}
          />
          <Select
            fullWidth
            value={editingUser?.role || ''}
            onChange={(e) =>
              setEditingUser((prev) => (prev ? { ...prev, role: e.target.value as User['role'] } : null))
            }
          >
            <MenuItem value="Admin">Admin</MenuItem>
            <MenuItem value="Employee">Employee</MenuItem>
            <MenuItem value="Student">Student</MenuItem>
          </Select>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog}>Cancel</Button>
          <Button onClick={handleSaveUser} color="primary">
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default UserManagement;

