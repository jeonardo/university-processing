import LoginPage from 'src/features/authentication/login.page';
import RegisterPage from 'src/features/authentication/RegisterPage';
import NotFoundPage from 'src/features/notFound/NotFoundPage';
import PublicOnlyLayout from 'src/layouts/public.only.layout';

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
