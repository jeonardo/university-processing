import { Box, Typography } from '@mui/material';
import { useAppSelector } from 'src/core/hooks';


const WelcomePage = () => {
  const authState = useAppSelector(state => state.auth);
  return (
    <Box sx={{ p: 2, maxWidth: 1200, mx: 'auto' }}>
      <Box sx={{ mb: 4 }}>
        <Typography>
          Добро пожаловать, {authState.user?.firstName} {authState.user?.lastName}!
        </Typography>
      </Box>
    </Box>
  );
};

export default WelcomePage;