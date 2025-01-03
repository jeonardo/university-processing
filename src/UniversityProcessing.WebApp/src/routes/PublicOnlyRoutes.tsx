import LoginPage from 'src/features/identity/login.page';
import RegisterPage from 'src/features/registration/RegisterPage';
import NotFoundPage from 'src/features/notFound/NotFoundPage';
import PublicOnlyLayout from 'src/features/layouts/public.only.layout';

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
