import LoginPage from 'src/features/identity/LoginPage';
import RegisterPage from 'src/features/identity/RegisterPage';
import NotFoundPage from 'src/features/notFound/NotFoundPage';
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
