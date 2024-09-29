import {createBrowserRouter} from 'react-router-dom';
import PrivateRoutes from './PrivateRoutes';
import PublicOnlyRoutes from './PublicOnlyRoutes';
import PublicRoutes from './PublicRoutes';

const AppRouter = createBrowserRouter([PrivateRoutes, PublicOnlyRoutes, PublicRoutes]);
export default AppRouter;
