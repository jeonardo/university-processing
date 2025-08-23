import { Outlet } from 'react-router-dom';

const PublicRoutes = {
  path: '/',
  element: <Outlet />,
  children: []
};

export default PublicRoutes;
