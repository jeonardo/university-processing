import { CssBaseline, ThemeProvider } from '@mui/material';
import { RouterProvider } from 'react-router-dom';
import AppRouter from './routes/AppRouter';
import theme from './theme';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import 'dayjs/locale/de';

const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale="de">
        {/* This resets CSS and applies MUI's baseline styles */}
        <CssBaseline />
        <RouterProvider router={AppRouter} />
      </LocalizationProvider>
    </ThemeProvider>
  );
};

export default App;