import { createBrowserRouter } from 'react-router-dom';
import LoginRoutes from './PrivateRoutes';
import PublicOnlyRoutes from './PublicOnlyRoutes';

const AppRouter = createBrowserRouter([LoginRoutes, PublicOnlyRoutes]);
export default AppRouter;
