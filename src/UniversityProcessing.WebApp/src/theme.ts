import { createTheme } from '@mui/material';
import { ruRU } from '@mui/x-date-pickers/locales';

const theme = createTheme({
  palette: {
    primary: {
      main: '#1976d2'  // Primary color
    },
    secondary: {
      main: '#ff4081'  // Secondary color
    }
  },
  typography: {
    fontFamily: 'Roboto, Arial, sans-serif',
    h1: {
      fontSize: '2.5rem'
    },
    h2: {
      fontSize: '2rem'
    }
  },
  components: {
    MuiAppBar: {
      styleOverrides: {
        root: {
          boxShadow: '0 2px 10px rgba(0,0,0,0.05)'
        }
      }
    }
  }
}, ruRU);

export default theme;