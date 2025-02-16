import type React from 'react';
import { useState } from 'react';
import { Box, Paper, Tab, Tabs, Typography } from '@mui/material';
import UserManagement from './admin/UserManagement';
// import SpecialtyManagement from "./admin/SpecialtyManagement"
import DepartmentManagement from './admin/DepartmentManagement';
import FacultyManagement from './admin/FacultyManagement';
// import UniversityManagement from "./admin/UniversityManagement"
// import StudyGroupManagement from "./admin/StudyGroupManagement"
// import DiplomaPeriodManagement from "./admin/DiplomaPeriodManagement"
// import CommitteeManagement from "./admin/CommitteeManagement"
// import RestrictionManagement from "./admin/RestrictionManagement"

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

const AdminDashboard: React.FC = () => {
  const [tabValue, setTabValue] = useState(0);

  const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
    setTabValue(newValue);
  };

  return (
    <div className="space-y-4">
      <Typography variant="h4" gutterBottom>
        Administrator Dashboard
      </Typography>
      <Paper className="p-4">
        <Tabs
          value={tabValue}
          onChange={handleTabChange}
          aria-label="admin dashboard tabs"
          variant="scrollable"
          scrollButtons="auto"
        >
          <Tab label="Users" />
          <Tab label="Specialties" />
          <Tab label="Departments" />
          <Tab label="Faculties" />
          <Tab label="Universities" />
          <Tab label="Study Groups" />
          <Tab label="Diploma Periods" />
          <Tab label="Committees" />
          <Tab label="Restrictions" />
        </Tabs>
        <TabPanel value={tabValue} index={0}>
          <UserManagement />
        </TabPanel>
        {/* <TabPanel value={tabValue} index={1}>
          <SpecialtyManagement />
        </TabPanel> */}
        <TabPanel value={tabValue} index={2}>
          <DepartmentManagement />
        </TabPanel>
        <TabPanel value={tabValue} index={3}>
          <FacultyManagement />
        </TabPanel>
        {/* <TabPanel value={tabValue} index={4}>
          <UniversityManagement />
        </TabPanel>
        <TabPanel value={tabValue} index={5}>
          <StudyGroupManagement />
        </TabPanel>
        <TabPanel value={tabValue} index={6}>
          <DiplomaPeriodManagement />
        </TabPanel>
        <TabPanel value={tabValue} index={7}>
          <CommitteeManagement />
        </TabPanel>
        <TabPanel value={tabValue} index={8}>
          <RestrictionManagement />
        </TabPanel> */}
      </Paper>
    </div>
  );
};

export default AdminDashboard;

