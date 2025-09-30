import FacultiesPage from 'src/features/faculties/FacultiesPage';
import FacultyPage from 'src/features/faculty/FacultyPage';
import PasswordChangePage from 'src/features/identity/PasswordChangePage';
import NotFoundPage from 'src/features/NotFoundPage';
import WelcomePage from 'src/features/WelcomePage';
import UsersProxyPage from 'src/features/users/UsersProxyPage';
import PrivateLayoutWrapper from 'src/features/components/PrivateLayoutWrapper';
import UsersLayout from 'src/features/users/components/UsersLayout';
import AdministratorsPage from 'src/features/users/AdministratorsPage';
import TeachersPage from 'src/features/users/TeachersPage';
import StudentsPage from 'src/features/users/StudentsPage';
import DeaneriesPage from 'src/features/users/DeaneriesPage';
import DepartmentsPage from 'src/features/departments/DepartmentsPage';
import DepartmentPage from 'src/features/department/DepartmentPage';
import { PeriodsPage } from 'src/features/periods/PeriodsPage';
import GroupsPage from 'src/features/groups/GroupsPage';
import SpecialtiesPage from 'src/features/specialties/SpecialtiesPage';
import DiplomaProcessesPage from 'src/features/diploma-processes/DiplomaProcessesPage';
import DiplomaProcessLayout from 'src/features/diploma-processes/layout/DiplomaProcessLayout';
import DiplomaCommitteesPage from 'src/features/diploma-processes/pages/DiplomaCommitteesPage';
import DiplomaSessionsPage from 'src/features/diploma-processes/pages/DiplomaSessionsPage';
import DiplomaDiplomasPage from 'src/features/diploma-processes/pages/DiplomaDiplomasPage';
import DiplomaGroupsPage from 'src/features/diploma-processes/pages/DiplomaGroupsPage';
import DiplomaTeachersPage from 'src/features/diploma-processes/pages/DiplomaTeachersPage';

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
        },
        {
          path: 'teachers',
          element: <TeachersPage />
        },
        {
          path: 'students',
          element: <StudentsPage />
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
    {
      path: '/departments',
      element: <DepartmentsPage />
    },
    {
      path: 'departments/:id',
      element: <DepartmentPage />
    },
    {
      path: 'periods',
      element: <PeriodsPage />
    },
    {
      path: 'groups',
      element: <GroupsPage />
    },
    {
      path: 'specialties',
      element: <SpecialtiesPage />
    },
    {
      path: 'diploma-processes',
      element: <DiplomaProcessesPage />
    }
    ,
    {
      path: 'diploma-processes/:id',
      element: <DiplomaProcessLayout />,
      children: [
        { index: true, element: <DiplomaCommitteesPage /> },
        { path: 'committees', element: <DiplomaCommitteesPage /> },
        { path: 'sessions', element: <DiplomaSessionsPage /> },
        { path: 'diplomas', element: <DiplomaDiplomasPage /> },
        { path: 'groups', element: <DiplomaGroupsPage /> },
        { path: 'teachers', element: <DiplomaTeachersPage /> }
      ]
    }
  ]
};

export default PrivateRoutes;
