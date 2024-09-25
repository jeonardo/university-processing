import { createTheme } from "@mui/material";
import { enUS } from '@mui/x-date-pickers/locales';

const theme = createTheme(
    {
        palette: {
            primary: {
                main: '#1976d2',  // Primary color
            },
            secondary: {
                main: '#ff4081',  // Secondary color
            },
        },
        typography: {
            fontFamily: 'Roboto, Arial, sans-serif',
            h1: {
                fontSize: '2.5rem',
            },
            h2: {
                fontSize: '2rem',
            },
        },
    },
    enUS);

export default theme;