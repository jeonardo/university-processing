import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import Login from './pages/Login';
import Register from './pages/Register';
import Home from './pages/HomePage';
import './App.css';
import NotFound from './pages/not-found/notfound.page';
import { Routes, Route } from 'react-router-dom';
import PublicOnlyLayout from './layouts/PublicOnlyLayout';
import PublicLayout from './layouts/PublicLayout';
import PrivateLayout from './layouts/PrivateLayout';
import { useAuth } from './common/authContext';

const App: React.FC = () => {
  const { isAuthenticated } = useAuth();
  return (
      <Routes>

        <Route path="*" element={<NotFound />} />

        <Route element={<PublicOnlyLayout isAuthenticated={isAuthenticated} />} >
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Route>

        <Route element={<PublicLayout />} >
          <Route path="/" element={<Home />} />
        </Route>

        <Route element={<PrivateLayout isAuthenticated={isAuthenticated} />} >
          <Route path="/home" element={<Home />} />
        </Route>

      </Routes >
  );
}

export default App;