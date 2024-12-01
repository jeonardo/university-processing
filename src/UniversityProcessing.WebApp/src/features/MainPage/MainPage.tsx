import { UserRoleIdDto } from 'src/api/backendApi';
import { useAppSelector } from 'src/core/hooks';
import AdminPanelPage from './AdminPanelPage';
import StudentPanelPage from './StudentPanelPage';
import TeacherPanelPage from './TeacherPanelPage';

const MainPage = () => {
  const user = useAppSelector(state => state.auth.user);

  switch (user?.roleId) {
    case UserRoleIdDto.ApplicationAdmin:
      return <AdminPanelPage />;
    case UserRoleIdDto.Employee:
      return <TeacherPanelPage />;
    case UserRoleIdDto.Student:
      return <StudentPanelPage />;
    default:
      return <div>Unauthorized</div>;
  }
};

export default MainPage;