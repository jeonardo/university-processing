import LoginPage from 'src/features/auth/LoginPage';
import RegisterPage from 'src/features/auth/RegisterPage';
import NotFoundPage from 'src/features/NotFoundPage';
import PublicOnlyLayout from 'src/features/PublicOnlyLayout';

const PublicOnlyRoutes = {
  path: '/',
  element: <PublicOnlyLayout />,
  errorElement: <NotFoundPage />,
  children: [
    {
      path: 'signin',
      element: <LoginPage />
    },
    {
      path: 'signup',
      element: <RegisterPage />
    }
  ]
};

export default PublicOnlyRoutes;
