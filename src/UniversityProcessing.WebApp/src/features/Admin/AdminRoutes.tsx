import FacultiesPage from "./faculties/FacultiesPage";
import PeriodsPage from "./periods/PeriodsPage";
import UsersPage from "./users/UsersPage";

const AdminRoutes = {
    path: '/admin',
    children: [
      {
        path: '/faculties',
        element: <FacultiesPage />
      },
      {
        path: '/users',
        element: <UsersPage />
      },
      {
        path: '/periods',
        element: <PeriodsPage />
      }
    ]
  };
  
  export default AdminRoutes;
  