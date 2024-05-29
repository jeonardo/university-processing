import LoginPage from 'src/features/authentication/login.page';
import RegisterPage from 'src/features/authentication/register.page';
import PublicOnlyLayout from 'src/layouts/public.only.layout';

const PublicOnlyRoutes = {
  path: '/',
  element: <PublicOnlyLayout />,
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
