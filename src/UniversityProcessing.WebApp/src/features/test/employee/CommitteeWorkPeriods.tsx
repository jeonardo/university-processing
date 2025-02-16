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
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';

interface CommitteeWorkPeriod {
  id: number;
  committeeName: string;
  startDate: Date | null;
  endDate: Date | null;
}

const CommitteeWorkPeriods: React.FC = () => {
  const [workPeriods, setWorkPeriods] = useState<CommitteeWorkPeriod[]>([
    { id: 1, committeeName: 'Computer Science Committee', startDate: null, endDate: null },
    { id: 2, committeeName: 'Electrical Engineering Committee', startDate: null, endDate: null },
    { id: 3, committeeName: 'Mechanical Engineering Committee', startDate: null, endDate: null }
  ]);

  const handleDateChange = (id: number, field: 'startDate' | 'endDate', date: Date | null) => {
    const updatedWorkPeriods = workPeriods.map((period) => (period.id === id ? { ...period, [field]: date } : period));
    setWorkPeriods(updatedWorkPeriods);
  };

  const handleSubmit = () => {
    // Here you would typically send the work periods to your backend
    console.log('Submitted work periods:', workPeriods);
    // You might want to show a success message or handle errors here
  };

  return (
    <LocalizationProvider dateAdapter={AdapterDateFns}>
      <div className="space-y-4">
        <Typography variant="h6" gutterBottom>
          Committee Work Periods
        </Typography>
        <TableContainer component={Paper}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Committee Name</TableCell>
                <TableCell>Start Date</TableCell>
                <TableCell>End Date</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {workPeriods.map((period) => (
                <TableRow key={period.id}>
                  <TableCell>{period.committeeName}</TableCell>
                  <TableCell>
                    <DatePicker
                      label="Start Date"
                      value={period.startDate}
                      onChange={(date) => handleDateChange(period.id, 'startDate', date)}
                      renderInput={(params) => <TextField {...params} />}
                    />
                  </TableCell>
                  <TableCell>
                    <DatePicker
                      label="End Date"
                      value={period.endDate}
                      onChange={(date) => handleDateChange(period.id, 'endDate', date)}
                      renderInput={(params) => <TextField {...params} />}
                    />
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <Button variant="contained" color="primary" onClick={handleSubmit}>
          Submit Work Periods
        </Button>
      </div>
    </LocalizationProvider>
  );
};

export default CommitteeWorkPeriods;

