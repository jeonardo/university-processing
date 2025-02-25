import LogoutPage from 'src/features/identity/LogoutPage';
import DepartmentListPage from 'src/features/departments/DepartmentListPage';
import DiplomaPeriodListPage from 'src/features/diplomaPeriods/DiplomaPeriodListPage';
import GroupListPage from 'src/features/groups/GroupListPage';
import MainPage from 'src/features/main/MainPage';
import NotFoundPage from 'src/features/notFound/NotFoundPage';
import SpecialtyListPage from 'src/features/specialties/SpecialtyListPage';
import UsersPage from 'src/features/admin/users/UsersPage';
import PrivateLayout from 'src/features/PrivateLayout';
import FacultiesPage from 'src/features/admin/faculties/FacultiesPage';
import SettingsPage from 'src/features/settings/SettingsPage';

const PrivateRoutes = {
  path: '/',
  element: <PrivateLayout />,
  errorElement: <NotFoundPage />,
  children: [
    {
      path: 'admin',
      children: []
    },
    {
      path: 'settings',
      element: <SettingsPage />
    },
    {
      path: '/',
      element: <MainPage />
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
