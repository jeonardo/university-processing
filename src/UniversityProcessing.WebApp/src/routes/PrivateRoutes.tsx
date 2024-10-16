import UserSettingsPage from "src/features/UserSettings/UserSettingsPage";
import SignoutPage from "src/features/authentication/signout.page";
import AdminPanelPage from "src/features/MainPage/AdminPanelPage";
import DepartmentListPage from "src/features/departments/DepartmentListPage";
import DiplomaPeriodListPage from "src/features/diplomaPeriods/DiplomaPeriodListPage";
import FacultyListPage from "src/features/faculties/FacultyListPage";
import GroupListPage from "src/features/groups/GroupListPage";
import MainPage from "src/features/MainPage/MainPage";
import NotFoundPage from "src/features/notFound/NotFoundPage";
import ProfilePage from "src/features/profile/profile.page";
import SpecialtyListPage from "src/features/specialties/SpecialtyListPage";
import UniversityListPage from "src/features/universities/UniversityListPage";
import UserListPage from "src/features/users/UserListPage";
import PrivateLayout from "src/layouts/private.layout";

const PrivateRoutes = {
    path: '/',
    element: <PrivateLayout />,
    errorElement: <NotFoundPage />,
    children: [
        {
            path: 'profile',
            element: <ProfilePage />
        },
        {
            path: 'settings',
            element: <UserSettingsPage />
        },
        {
            path: '/',
            element: <MainPage />
        },
        {
            path: '/umt',
            element: <AdminPanelPage />
        },
        {
            path: '/universities',
            element: <UniversityListPage />
        },
        {
            path: '/faculties',
            element: <FacultyListPage />
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
            element: <UserListPage />
        },
        {
            path: '/signout',
            element: <SignoutPage />
        }
    ]
};

export default PrivateRoutes;
