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

interface SupervisorRequest {
  id: number;
  professorName: string;
  department: string;
  maxStudents: number;
  status: 'Pending' | 'Approved' | 'Rejected';
}

const SupervisorApproval: React.FC = () => {
  const [requests, setRequests] = useState<SupervisorRequest[]>([
    { id: 1, professorName: 'Dr. John Doe', department: 'Computer Science', maxStudents: 5, status: 'Pending' },
    {
      id: 2,
      professorName: 'Prof. Jane Smith',
      department: 'Electrical Engineering',
      maxStudents: 4,
      status: 'Pending'
    },
    {
      id: 3,
      professorName: 'Dr. Michael Johnson',
      department: 'Mechanical Engineering',
      maxStudents: 3,
      status: 'Pending'
    }
  ]);

  const [openDialog, setOpenDialog] = useState(false);
  const [selectedRequest, setSelectedRequest] = useState<SupervisorRequest | null>(null);
  const [comment, setComment] = useState('');

  const handleApprove = (request: SupervisorRequest) => {
    setSelectedRequest(request);
    setOpenDialog(true);
  };

  const handleReject = (request: SupervisorRequest) => {
    setSelectedRequest(request);
    setOpenDialog(true);
  };

  const handleConfirm = () => {
    if (selectedRequest) {
      const updatedRequests = requests.map((req) =>
        req.id === selectedRequest.id ? { ...req, status: selectedRequest.status } : req
      );
      setRequests(updatedRequests);
      setOpenDialog(false);
      setSelectedRequest(null);
      setComment('');
    }
  };

  return (
    <div className="space-y-4">
      <Typography variant="h6" gutterBottom>
        Supervisor Approval
      </Typography>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Professor Name</TableCell>
              <TableCell>Department</TableCell>
              <TableCell>Max Students</TableCell>
              <TableCell>Status</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {requests.map((request) => (
              <TableRow key={request.id}>
                <TableCell>{request.professorName}</TableCell>
                <TableCell>{request.department}</TableCell>
                <TableCell>{request.maxStudents}</TableCell>
                <TableCell>{request.status}</TableCell>
                <TableCell>
                  {request.status === 'Pending' && (
                    <>
                      <Button onClick={() => handleApprove({ ...request, status: 'Approved' })} color="primary">
                        Approve
                      </Button>
                      <Button onClick={() => handleReject({ ...request, status: 'Rejected' })} color="secondary">
                        Reject
                      </Button>
                    </>
                  )}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Dialog open={openDialog} onClose={() => setOpenDialog(false)}>
        <DialogTitle>{selectedRequest?.status === 'Approved' ? 'Approve' : 'Reject'} Supervisor Request</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            id="comment"
            label="Comment"
            type="text"
            fullWidth
            variant="outlined"
            value={comment}
            onChange={(e) => setComment(e.target.value)}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDialog(false)}>Cancel</Button>
          <Button onClick={handleConfirm} color="primary">
            Confirm
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default SupervisorApproval;

