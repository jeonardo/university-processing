import { useAuth } from "./authContext";
import { Navigate, Outlet } from 'react-router-dom';

const PrivateRoute = () => {
  const { isAuthenticated } = useAuth();

  if (isAuthenticated)
    return <Outlet />

  return <Navigate to="/login" />
};

export default PrivateRoute;