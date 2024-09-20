import {Navigate, Outlet} from "react-router-dom";
import {useAppDispatch, useAppSelector} from "src/core/hooks";
import ResponsiveAppBar from "./AppBar";
import {useGetApiV1IdentityInfoQuery} from "src/api/backendApi";
import {setUser} from "src/features/authentication/auth.slice";

const PrivateLayout: React.FC = () => {
    const dispatch = useAppDispatch()
    const {isSuccess, data} = useGetApiV1IdentityInfoQuery()

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
                <ResponsiveAppBar/>
                <div className="flex h-full w-full p-5">
                    <Outlet/>
                </div>
            </div>
            : <Navigate replace to={"/signin"}/>)
};

export default PrivateLayout;