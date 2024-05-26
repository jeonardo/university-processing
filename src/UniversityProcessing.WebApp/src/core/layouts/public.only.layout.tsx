import {Navigate, Outlet} from "react-router-dom";

const PublicOnlyLayout: React.FC<{ isAuthenticated: boolean }> = ({isAuthenticated}) => (
    isAuthenticated
        ? <Navigate replace to={"/"}/>
        : <Outlet/>
);

export default PublicOnlyLayout;