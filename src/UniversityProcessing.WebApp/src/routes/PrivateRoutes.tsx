import FacultiesPage from 'src/features/faculties/FacultiesPage';
import FacultyPage from 'src/features/faculties/FacultiesPage';
import PasswordChangePage from 'src/features/identity/PasswordChangePage';
import NotFoundPage from 'src/features/NotFoundPage';
import PrivateLayoutWrapper from 'src/features/PrivateLayoutWrapper';
import AdministratorsPage from 'src/features/users/AdministratorsPage';
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
    },
    {
      path: 'administrators',
      element: <AdministratorsPage />
    },
    {
      path: 'faculties',
      element: <FacultiesPage />
    }
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
    // }
  ]
};

export default PrivateRoutes;
