import { Box, Stack, minHeight } from "@mui/system";
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import NotificationsIcon from '@mui/icons-material/Notifications';
import { styled } from '@mui/material/styles';
import MuiDrawer from '@mui/material/Drawer';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Divider from '@mui/material/Divider';
import Badge from '@mui/material/Badge';
import { useState } from "react";
import { Avatar, Menu, MenuItem, Toolbar, Typography, IconButton } from "@mui/material";
import { Navigate, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "src/core/hooks";
import { logout } from "src/features/authentication/auth.slice";

const AppBar = () => {
    const nav = useNavigate();
    const dispatch = useAppDispatch();

    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

    const menuId = 'primary-search-account-menu';
    const isMenuOpen = Boolean(anchorEl);

    const handleProfileMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleMenuClose = () => {
        setAnchorEl(null);
    };

    return (
        <>
            <div className="flex h-full w-full flex-row px-3 justify-between items-center">
            https://mui.com/material-ui/react-app-bar/#app-bar-with-responsive-menu
                <Box sx={{ flexGrow: 1 }}>
                    <img src="logo.svg" alt="Logo" className="h-[60px]" />
                </Box>
                <IconButton
                    sx={{ borderRadius: 10, height: 50 }}
                    size="small"
                    edge="end"
                    aria-label="account of current user"
                    aria-controls={menuId}
                    aria-haspopup="true"
                    onClick={handleProfileMenuOpen}
                    color="inherit">
                    <Stack direction="row" spacing={2}>
                        <Typography
                            alignSelf={"center"}
                            component="h1"
                            variant="h6"
                            color="inherit"
                            noWrap
                            sx={{ flexGrow: 1 }}
                        >
                            SRRC
                        </Typography>
                        <Avatar sx={{ alignSelf: "center" }}>H</Avatar>
                    </Stack>
                </IconButton>
            </div>
            <Menu
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                }}
                id={menuId}
                keepMounted
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                }}
                open={isMenuOpen}
                onClose={handleMenuClose}
            >
                <MenuItem
                    onClick={() => {
                        handleMenuClose()
                        nav("profile")
                    }}>
                    Профиль
                </MenuItem>
                <MenuItem onClick={() => {
                    handleMenuClose()
                    nav("settings")
                }}>Настройки</MenuItem>
                <Divider />
                <MenuItem onClick={() => {
                    dispatch(logout())
                    handleMenuClose()
                    nav("signin")
                }}>Выйти из профиля</MenuItem>
            </Menu>
        </>
    )
}

export default AppBar;