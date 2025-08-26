import { Box, Container, Paper, Typography } from '@mui/material';
import { useAppSelector } from 'src/core/hooks';
import SchoolIcon from '@mui/icons-material/School';


const WelcomePage = () => {
  const authState = useAppSelector(state => state.auth);
  return (
    <Container maxWidth="md" className="py-8">
      <Paper
        elevation={4}
        className="p-6 mb-6 rounded-xl shadow-lg"
      >
        <Box display="flex" alignItems="center" gap={2}>
          <SchoolIcon fontSize="large" />
          <Typography variant="h5" className="font-bold">
            Добро пожаловать!
          </Typography>
        </Box>
        <Typography variant="body1" className="pt-4">
          Рады видеть вас в системе дипломного проектирования. Успехов в работе, {authState.user?.firstName} {authState.user?.lastName}!
        </Typography>
      </Paper>
    </Container>
  );
};

export default WelcomePage;