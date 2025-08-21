import { Typography } from '@mui/material';

const AppLoader = () =>
  (
    <div className="min-h-screen flex flex-col items-center justify-center">
      <div className="animate-spin rounded-full h-32 w-32 border-b-2 border-primary"></div>
      <Typography sx={{ pt: 3 }}>Загрузка...</Typography>
    </div>
  );

export default AppLoader;