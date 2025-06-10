import type React from 'react';
import { List, ListItem, ListItemText, Paper, Typography } from '@mui/material';

const CurrentDiplomaPeriod: React.FC = () => {
  // This data would typically come from an API
  const periodInfo = {
    name: 'Spring 2023',
    startDate: '2023-01-15',
    endDate: '2023-06-30',
    status: 'In Progress',
    importantDates: [
      { date: '2023-02-28', event: 'Supervisor Selection Deadline' },
      { date: '2023-03-31', event: 'Topic Submission Deadline' },
      { date: '2023-05-15', event: 'Proposal Submission Deadline' },
      { date: '2023-06-15', event: 'Final Defense' }
    ]
  };

  return (
    <div className="space-y-4">
      <Typography variant="h6" gutterBottom>
        Current Diploma Period
      </Typography>
      <Paper className="p-4 space-y-2">
        <Typography>
          <strong>Period:</strong> {periodInfo.name}
        </Typography>
        <Typography>
          <strong>Start Date:</strong> {periodInfo.startDate}
        </Typography>
        <Typography>
          <strong>End Date:</strong> {periodInfo.endDate}
        </Typography>
        <Typography>
          <strong>Status:</strong> {periodInfo.status}
        </Typography>
      </Paper>
      <Typography variant="h6" gutterBottom>
        Important Dates
      </Typography>
      <Paper>
        <List>
          {periodInfo.importantDates.map((item, index) => (
            <ListItem key={index} divider={index < periodInfo.importantDates.length - 1}>
              <ListItemText primary={item.event} secondary={item.date} />
            </ListItem>
          ))}
        </List>
      </Paper>
    </div>
  );
};

export default CurrentDiplomaPeriod;

