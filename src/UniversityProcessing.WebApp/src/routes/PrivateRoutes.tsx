import LogoutPage from 'src/features/auth/LogoutPage';
import DepartmentListPage from 'src/features/TODO/departments/DepartmentListPage';
import DiplomaPeriodListPage from 'src/features/TODO/diplomaPeriods/DiplomaPeriodListPage';
import GroupListPage from 'src/features/TODO/groups/GroupListPage';
import NotFoundPage from 'src/features/notFound/NotFoundPage';
import SpecialtyListPage from 'src/features/TODO/specialties/SpecialtyListPage';
import UsersPage from 'src/features/admin/users/UsersPage';
import PrivateLayout from 'src/features/PrivateLayout';
import FacultiesPage from 'src/features/admin/faculties/FacultiesPage';
import SettingsPage from 'src/features/TODO/settings/SettingsPage';
import AdminRoutes from 'src/features/admin/AdminRoutes';
import WelcomePage from 'src/features/TODO/welcomePage/WelcomePage';

const PrivateRoutes = {
  path: '/',
  element: <PrivateLayout />,
  errorElement: <NotFoundPage />,
  children: [
    AdminRoutes,
    {
      path: 'settings',
      element: <SettingsPage />
    },
    {
      path: '/',
      element: <WelcomePage />
    },
    {
      path: '/faculties',
      element: <FacultiesPage />
    },
    {
      path: '/departments',
      element: <DepartmentListPage />
    },
    {
      path: '/diplomaPeriods',
      element: <DiplomaPeriodListPage />
    },
    {
      path: '/specialties',
      element: <SpecialtyListPage />
    },
    {
      path: '/groups',
      element: <GroupListPage />
    },
    {
      path: '/users',
      element: <UsersPage />
    },
    {
      path: '/logout',
      element: <LogoutPage />
    }
  ]
};

export default PrivateRoutes;
