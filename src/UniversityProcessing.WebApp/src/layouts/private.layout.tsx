import { Navigate, Outlet } from "react-router-dom";
import { useAppSelector } from "src/core/hooks";

const PrivateLayout: React.FC = () => (
    useAppSelector(state => state.auth.authorized)
        ? <Outlet />
        : <Navigate replace to={"/signin"} />
);

export default PrivateLayout;