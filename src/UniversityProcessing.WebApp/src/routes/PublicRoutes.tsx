import { Outlet } from 'react-router-dom';
import TestPage from 'src/features/test/TestPage';

const PublicRoutes = {
  path: '/',
  element: <Outlet />,
  children: [
    {
      path: 'test',
      element: <TestPage />
    }
  ]
};

export default PublicRoutes;
