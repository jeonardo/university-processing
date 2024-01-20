import { Navigate, Outlet } from "react-router-dom";
import { IAuthState } from "./authState";

const PublicOnlyLayout: React.FC<IAuthState> = ({ isAuthenticated }: IAuthState) => (
    isAuthenticated
        ? <Navigate replace to={"/"} />
        : <Outlet />
);

export default PublicOnlyLayout;