import PasswordChangePage from 'src/features/identity/PasswordChangePage';
import NotFoundPage from 'src/features/NotFoundPage';
import PrivateLayoutWrapper from 'src/features/PrivateLayoutWrapper';
import WelcomePage from 'src/features/WelcomePage';

const PrivateRoutes = {
  path: '/',
  element: <PrivateLayoutWrapper />,
  errorElement: <NotFoundPage />,
  children: [
    {
      path: '/',
      element: <WelcomePage />
    },
    {
      path: 'change-password',
      element: <PasswordChangePage />
    }
    //,
    // {
    //   path: 'faculties',
    //   element: <FacultiesPage />
    // },
    // {
    //   path: 'users',
    //   element: <UsersPage />
    // },
    // {
    //   path: 'periods',
    //   element: <PeriodsPage />
    // },
    // {
    //   path: 'settings',
    //   element: <SettingsPage />
    // },
    // {
    //   path: '/faculties',
    //   element: <FacultiesPage />
    // },
    // {
    //   path: '/departments',
    //   element: <DepartmentListPage />
    // },
    // {
    //   path: '/diplomaPeriods',
    //   element: <DiplomaPeriodListPage />
    // },
    // {
    //   path: '/specialties',
    //   element: <SpecialtyListPage />
    // },
    // {
    //   path: '/groups',
    //   element: <GroupListPage />
    // },
    // {
    //   path: '/users',
    //   element: <UsersPage />
    // }
  ]
};

export default PrivateRoutes;
