import { LockOutlined } from "@mui/icons-material";
import { Avatar } from "@mui/material";

const ProfilePage = () => {
    return (
        <>
            <Avatar sx={{ bgcolor: "primary.light" }}>
                <LockOutlined />
            </Avatar>
        </>)
}

export default ProfilePage;