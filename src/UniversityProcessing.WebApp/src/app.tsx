import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import LoginPage from './features/authentication/signin/SignInPage';
import SignUpPage from './features/authentication/signup/SignUpPage';
import Home from './features/home/HomePage';
import NotFound from './features/notFound/NotFoundPage';
import {Route, Routes} from 'react-router-dom';
import PublicOnlyLayout from './components/layouts/PublicOnlyLayout';
import PrivateLayout from './components/layouts/PrivateLayout';
import {useAppSelector} from './core/hooks';

const App: React.FC = () => {
    const isAuthenticated = useAppSelector(state => state.auth.isAuthenticated);
    ReadEnvironmentVariables();
    return (
        <Routes>

            <Route path="*" element={<NotFound/>}/>

            <Route element={<PublicOnlyLayout isAuthenticated={isAuthenticated}/>}>
                <Route path="/signin" element={<LoginPage/>}/>
                <Route path="/signup" element={<SignUpPage/>}/>
            </Route>

            <Route element={<PrivateLayout isAuthenticated={isAuthenticated}/>}>
                <Route path="/" element={<Home/>}/>
            </Route>

        </Routes>
    );
}

const ReadEnvironmentVariables = () => {
    const environment = import.meta.env;

    if (!environment.VITE_IS_DEVELOPMENT)
        return

    console.log("VITE_APP_TITLE", environment.VITE_APP_TITLE);
    console.log("VITE_IS_DEVELOPMENT", environment.VITE_IS_DEVELOPMENT);
    console.log("VITE_BACKEND_BASEURL", environment.VITE_BACKEND_BASEURL);
}

export default App;