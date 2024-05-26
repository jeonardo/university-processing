import { Navigate, Outlet } from "react-router-dom";
import { Fragment } from "react";

const PrivateLayout: React.FC<{ isAuthenticated: boolean }> = ({ isAuthenticated }) => (
    !isAuthenticated
        ? <Navigate replace to={"/signin"} />
        : <Fragment>
            <Outlet />
        </Fragment>
);

export default PrivateLayout;