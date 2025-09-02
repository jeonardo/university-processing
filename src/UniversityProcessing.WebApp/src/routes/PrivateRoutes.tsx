import FacultiesPage from 'src/features/faculties/FacultiesPage';
import FacultyPage from 'src/features/faculty/FacultyPage';
import PasswordChangePage from 'src/features/identity/PasswordChangePage';
import NotFoundPage from 'src/features/NotFoundPage';
import WelcomePage from 'src/features/WelcomePage';
import UsersProxyPage from 'src/features/users/UsersProxyPage';
import PrivateLayoutWrapper from 'src/features/components/PrivateLayoutWrapper';
import UsersLayout from 'src/features/users/components/UsersLayout';
import AdministratorsPage from 'src/features/users/AdministratorsPage';
import path from 'path';
import { element } from 'prop-types';
import DeaneriesPage from 'src/features/users/DeaneriesPage';

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
      path: 'users',
      element: <UsersLayout />,
      children: [
        {
          index: true,
          element: <UsersProxyPage />
        },
        {
          path: 'admins',
          element: <AdministratorsPage />
        },
        {
          path: 'deanery',
          element: <DeaneriesPage />
        }
      ]
    },
    {
      path: 'faculties',
      element: <FacultiesPage />
    },
    {
      path: 'faculties/:id',
      element: <FacultyPage />
    },
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
