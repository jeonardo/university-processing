import { useAppSelector } from 'src/core/hooks';
import AdminPanelPage from './AdminPanelPage';
import StudentPanelPage from './StudentPanelPage';
import TeacherPanelPage from './TeacherPanelPage';
import { ContractsUserRoleType } from 'src/api/backendApi';

const MainPage = () => {
  const user = useAppSelector(state => state.auth.user);

  switch (user?.roleId) {
    case ContractsUserRoleType.ApplicationAdmin:
      return <AdminPanelPage />;
    case ContractsUserRoleType.Employee:
      return <TeacherPanelPage />;
    case ContractsUserRoleType.Student:
      return <StudentPanelPage />;
    default:
      return <div>Unauthorized</div>;
  }
};

export default MainPage;