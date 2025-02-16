import type React from 'react';
import { useState } from 'react';
import { Box, Paper, Tab, Tabs, Typography } from '@mui/material';
import SupervisorApproval from './employee/SupervisorApproval';
import TopicApproval from './employee/TopicApproval';
import GradeManagement from './employee/GradeManagement';
import CommitteeWorkPeriods from './employee/CommitteeWorkPeriods';
import DefenseSchedules from './employee/DefenseSchedules';

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

const EmployeeDashboard: React.FC = () => {
  const [tabValue, setTabValue] = useState(0);

  const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
    setTabValue(newValue);
  };

  return (
    <div className="space-y-4">
      <Typography variant="h4" gutterBottom>
        Employee Dashboard
      </Typography>
      <Paper className="p-4">
        <Tabs value={tabValue} onChange={handleTabChange} aria-label="employee dashboard tabs">
          <Tab label="Supervisor Approval" />
          <Tab label="Topic Approval" />
          <Tab label="Grade Management" />
          <Tab label="Committee Work Periods" />
          <Tab label="Defense Schedules" />
        </Tabs>
        <TabPanel value={tabValue} index={0}>
          <SupervisorApproval />
        </TabPanel>
        <TabPanel value={tabValue} index={1}>
          <TopicApproval />
        </TabPanel>
        <TabPanel value={tabValue} index={2}>
          <GradeManagement />
        </TabPanel>
        <TabPanel value={tabValue} index={3}>
          <CommitteeWorkPeriods />
        </TabPanel>
        <TabPanel value={tabValue} index={4}>
          <DefenseSchedules />
        </TabPanel>
      </Paper>
    </div>
  );
};

export default EmployeeDashboard;

