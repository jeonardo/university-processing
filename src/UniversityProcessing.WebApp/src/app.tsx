import { CssBaseline, ThemeProvider } from '@mui/material';
import { RouterProvider, Routes } from 'react-router-dom';
import AppRouter from './routes/AppRouter';
import theme from './theme';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import 'dayjs/locale/de';
import { SnackbarProvider } from 'notistack';
import MyLayout from './components/layouts/MyLayout';

const App: React.FC = () => {
  return (
    <SnackbarProvider
      maxSnack={3}
      autoHideDuration={3000}
      anchorOrigin={{
        vertical: 'top',
        horizontal: 'right'
      }}>
      <ThemeProvider theme={theme}>
        <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale="de">
          <CssBaseline />
          <RouterProvider router={AppRouter} />
        </LocalizationProvider>
      </ThemeProvider>
    </SnackbarProvider>
  );
};

export default App;