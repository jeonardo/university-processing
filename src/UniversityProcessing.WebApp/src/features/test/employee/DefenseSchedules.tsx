import type React from 'react';
import { useState } from 'react';
import {
  Button,
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
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';

interface DefenseSchedule {
  id: number;
  studentName: string;
  topicTitle: string;
  defenseDateTime: Date | null;
  location: string;
}

const DefenseSchedules: React.FC = () => {
  const [schedules, setSchedules] = useState<DefenseSchedule[]>([
    {
      id: 1,
      studentName: 'Alice Johnson',
      topicTitle: 'Machine Learning in Healthcare',
      defenseDateTime: null,
      location: ''
    },
    {
      id: 2,
      studentName: 'Bob Smith',
      topicTitle: 'Blockchain for Supply Chain Management',
      defenseDateTime: null,
      location: ''
    },
    {
      id: 3,
      studentName: 'Charlie Brown',
      topicTitle: 'Sustainable Energy Solutions',
      defenseDateTime: null,
      location: ''
    }
  ]);

  const handleDateTimeChange = (id: number, dateTime: Date | null) => {
    const updatedSchedules = schedules.map((schedule) =>
      schedule.id === id ? { ...schedule, defenseDateTime: dateTime } : schedule
    );
    setSchedules(updatedSchedules);
  };

  const handleLocationChange = (id: number, location: string) => {
    const updatedSchedules = schedules.map((schedule) => (schedule.id === id ? { ...schedule, location } : schedule));
    setSchedules(updatedSchedules);
  };

  const handleSubmit = () => {
    // Here you would typically send the schedules to your backend
    console.log('Submitted schedules:', schedules);
    // You might want to show a success message or handle errors here
  };

  return (
    <LocalizationProvider dateAdapter={AdapterDateFns}>
      <div className="space-y-4">
        <Typography variant="h6" gutterBottom>
          Defense Schedules
        </Typography>
        <TableContainer component={Paper}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Student Name</TableCell>
                <TableCell>Topic Title</TableCell>
                <TableCell>Defense Date & Time</TableCell>
                <TableCell>Location</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {schedules.map((schedule) => (
                <TableRow key={schedule.id}>
                  <TableCell>{schedule.studentName}</TableCell>
                  <TableCell>{schedule.topicTitle}</TableCell>
                  <TableCell>
                    <DateTimePicker
                      label="Defense Date & Time"
                      value={schedule.defenseDateTime}
                      onChange={(dateTime) => handleDateTimeChange(schedule.id, dateTime)}
                      renderInput={(params) => <TextField {...params} />}
                    />
                  </TableCell>
                  <TableCell>
                    <TextField
                      value={schedule.location}
                      onChange={(e) => handleLocationChange(schedule.id, e.target.value)}
                      placeholder="Enter location"
                    />
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <Button variant="contained" color="primary" onClick={handleSubmit}>
          Submit Defense Schedules
        </Button>
      </div>
    </LocalizationProvider>
  );
};

export default DefenseSchedules;

