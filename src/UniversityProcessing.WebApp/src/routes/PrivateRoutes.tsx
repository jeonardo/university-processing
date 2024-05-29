import ProfilePage from "src/features/profile/profile.page";
import PrivateLayout from "src/layouts/private.layout";

const PrivateRoutes = {
  path: '/',
  element: <PrivateLayout />,
  children: [
    {
      path: '',
      element: <ProfilePage />
    }
  ]
};

export default PrivateRoutes;
