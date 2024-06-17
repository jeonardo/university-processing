import { Navigate, Outlet, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "src/core/hooks";
import App from "src/app";
import AppBar from "./AppBar";
import SideBar from "./SideBar";
import { useEffect } from "react";
import { useGetApiV1IdentityInfoQuery } from "src/api/backendApi";
import { setUser } from "src/features/authentication/auth.slice";

const PrivateLayout: React.FC = () => {
    const dispatch = useAppDispatch()
    const { isSuccess, data } = useGetApiV1IdentityInfoQuery()

    if (isSuccess) {
        dispatch(setUser({
            approved: data?.approved,
            roleId: data?.roleId,
            userId: data?.userId
        }))
    }

    return (
        useAppSelector(state => state.auth.authorized)
            ? <div className="flex flex-col h-full w-full bg-[#f8f8f8]">
                <div className="fixed w-full h-[70px] z-50 bg-[#f8f8f8] shadow-lg items-center">
                    <AppBar />
                </div>
                <div className="flex pt-[70px] flex-row h-full w-full">
                    <div className="flex h-full w-full p-5">
                        <Outlet />
                    </div>
                </div>
            </div>
            : <Navigate replace to={"/signin"} />)
};

export default PrivateLayout;