import { Container } from "@mui/material"
import { Outlet } from "react-router-dom"
import RoleSwitchPanel from "./RoleSwitchPanel"
import { useUserRedirect } from "../hooks/useUserRedirectPath"

const UsersLayout = () => {
    const { availableRoles, routeRole } = useUserRedirect();
    return (
        <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
            <RoleSwitchPanel availableRoles={availableRoles} routeRole={routeRole} />
            <Outlet />
        </Container>
    )
}

export default UsersLayout