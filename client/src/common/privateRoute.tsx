import { useAuth } from "./applicationContext";
import { Navigate, Outlet } from 'react-router-dom';

const PrivateRoute = () => {
  const { isAuthenticated } = useAuth();

  if (isAuthenticated)
    return <Outlet />

  return <Navigate to="/login" />
};

export default PrivateRoute;