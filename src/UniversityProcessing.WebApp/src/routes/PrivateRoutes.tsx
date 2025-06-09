import LogoutPage from 'src/features/auth/LogoutPage';
import DepartmentListPage from 'src/features/TODO/departments/DepartmentListPage';
import DiplomaPeriodListPage from 'src/features/TODO/diplomaPeriods/DiplomaPeriodListPage';
import GroupListPage from 'src/features/TODO/groups/GroupListPage';
import MainPage from 'src/features/TODO/main/MainPage';
import NotFoundPage from 'src/features/TODO/notFound/NotFoundPage';
import SpecialtyListPage from 'src/features/TODO/specialties/SpecialtyListPage';
import UsersPage from 'src/features/TODO/admin/users/UsersPage';
import PrivateLayout from 'src/features/PrivateLayout';
import FacultiesPage from 'src/features/TODO/admin/faculties/FacultiesPage';
import SettingsPage from 'src/features/TODO/settings/SettingsPage';
import AdminRoutes from 'src/features/TODO/admin/AdminRoutes';

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
