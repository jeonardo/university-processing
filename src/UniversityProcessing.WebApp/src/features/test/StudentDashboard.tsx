import type React from 'react';
import { useState } from 'react';
import { Box, Paper, Tab, Tabs, Typography } from '@mui/material';
import CurrentDiplomaPeriod from './student/CurrentDiplomaPeriod';
import SupervisorTopicSelection from './student/SupervisorTopicSelection';
import ProposalSubmission from './student/ProposalSubmission';

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && <Box sx={{ p: 3 }}>{children}</Box>}
    </div>
  );
}

const StudentDashboard: React.FC = () => {
  const [tabValue, setTabValue] = useState(0);

  const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
    setTabValue(newValue);
  };

  return (
    <div className="space-y-4">
      <Typography variant="h4" gutterBottom>
        Student Dashboard
      </Typography>
      <Paper className="p-4">
        <Tabs value={tabValue} onChange={handleTabChange} aria-label="student dashboard tabs">
          <Tab label="Current Period" />
          <Tab label="Supervisor & Topic" />
          <Tab label="Proposal" />
        </Tabs>
        <TabPanel value={tabValue} index={0}>
          <CurrentDiplomaPeriod />
        </TabPanel>
        <TabPanel value={tabValue} index={1}>
          <SupervisorTopicSelection />
        </TabPanel>
        <TabPanel value={tabValue} index={2}>
          <ProposalSubmission />
        </TabPanel>
      </Paper>
    </div>
  );
};

export default StudentDashboard;

