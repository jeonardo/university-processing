import { CssBaseline, StyledEngineProvider } from '@mui/material';
import { RouterProvider } from 'react-router-dom';
import AppRouter from './routes/AppRouter';

const App: React.FC = () => {
    return (
        <StyledEngineProvider injectFirst>
            <CssBaseline />
            <RouterProvider router={AppRouter} />
        </StyledEngineProvider>
    );
}

export default App;