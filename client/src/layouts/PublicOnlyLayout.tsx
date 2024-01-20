import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../common/authContext";

const PublicOnlyLayout: React.FC = () => {
    const { isAuthenticated } = useAuth();

    if (isAuthenticated)
        return <Navigate replace to={"/"} />;

    return <Outlet />;
}

export default PublicOnlyLayout;