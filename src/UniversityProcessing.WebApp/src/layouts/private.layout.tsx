import { Navigate, Outlet } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "src/core/hooks";
import ResponsiveAppBar from "./AppBar";
import { useGetApiV1IdentityInfoQuery, useGetApiV1RegistrationGetAvailableUniversityPositionsQuery, useLazyGetApiV1IdentityInfoQuery } from "src/api/backendApi";
import { setUser } from "src/features/authentication/auth.slice";
import { useEffect } from "react";

const PrivateLayout: React.FC = () => {
    const isAuthorized = useAppSelector(state => state.auth.authorized)

    if (!isAuthorized)
        return <Navigate replace to={"/signin"} />

    const user = useAppSelector(state => state.auth.user)


    //TODO specific hook error     Error: Invalid hook call. Hooks can only be called inside of the body of a function component. This could happen for one of the following reasons:
    // 1. You might have mismatching versions of React and the renderer (such as React DOM)
    // 2. You might be breaking the Rules of Hooks
    // 3. You might have more than one copy of React in the same app
    // const { data, isSuccess } = useGetApiV1IdentityInfoQuery()

    // const dispatch = useAppDispatch()

    // useEffect(() => {
    //     if (user && isSuccess && data) {
    //         dispatch(setUser({
    //             approved: data.approved,
    //             roleId: data.roleId,
    //             userId: data.userId
    //         }))
    //     }
    // }, [user, isSuccess, data, dispatch])

    return (
        <div className="flex flex-col h-full w-full bg-[#f8f8f8]">
            <ResponsiveAppBar />
            <div className="flex h-full w-full p-5">
                <Outlet />
            </div>
        </div>
    )
};

export default PrivateLayout;