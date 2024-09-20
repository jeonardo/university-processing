import {createBrowserRouter} from 'react-router-dom';
import LoginRoutes from './PrivateRoutes';
import PublicOnlyRoutes from './PublicOnlyRoutes';
import PublicRoutes from './PublicRoutes';

const AppRouter = createBrowserRouter([LoginRoutes, PublicOnlyRoutes, PublicRoutes]);
export default AppRouter;
