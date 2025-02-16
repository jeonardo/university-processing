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

interface TopicRequest {
  id: number;
  studentName: string;
  supervisorName: string;
  topicTitle: string;
  status: 'Pending' | 'Approved' | 'Rejected';
}

const TopicApproval: React.FC = () => {
  const [requests, setRequests] = useState<TopicRequest[]>([
    {
      id: 1,
      studentName: 'Alice Johnson',
      supervisorName: 'Dr. John Doe',
      topicTitle: 'Machine Learning in Healthcare',
      status: 'Pending'
    },
    {
      id: 2,
      studentName: 'Bob Smith',
      supervisorName: 'Prof. Jane Smith',
      topicTitle: 'Blockchain for Supply Chain Management',
      status: 'Pending'
    },
    {
      id: 3,
      studentName: 'Charlie Brown',
      supervisorName: 'Dr. Michael Johnson',
      topicTitle: 'Sustainable Energy Solutions',
      status: 'Pending'
    }
  ]);

  const [openDialog, setOpenDialog] = useState(false);
  const [selectedRequest, setSelectedRequest] = useState<TopicRequest | null>(null);
  const [comment, setComment] = useState('');

  const handleApprove = (request: TopicRequest) => {
    setSelectedRequest(request);
    setOpenDialog(true);
  };

  const handleReject = (request: TopicRequest) => {
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
        Topic Approval
      </Typography>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Student Name</TableCell>
              <TableCell>Supervisor Name</TableCell>
              <TableCell>Topic Title</TableCell>
              <TableCell>Status</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {requests.map((request) => (
              <TableRow key={request.id}>
                <TableCell>{request.studentName}</TableCell>
                <TableCell>{request.supervisorName}</TableCell>
                <TableCell>{request.topicTitle}</TableCell>
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
        <DialogTitle>{selectedRequest?.status === 'Approved' ? 'Approve' : 'Reject'} Topic Request</DialogTitle>
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

export default TopicApproval;

