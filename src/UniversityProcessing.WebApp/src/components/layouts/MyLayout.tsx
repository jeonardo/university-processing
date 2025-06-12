import React, { useState } from 'react';
import {
    AppBar,
    Toolbar,
    IconButton,
    Typography,
    Drawer,
    List,
    ListItem,
    ListItemIcon,
    ListItemText,
    CssBaseline,
    Box,
    Container,
    Avatar,
    Divider,
    Badge,
    Menu,
    MenuItem,
    ThemeProvider,
    createTheme,
    useMediaQuery,
    Paper,
    Grid,
    Button,
    Tabs,
    Tab,
    Card,
    CardContent,
    CardActions,
    Chip,
    Stack,
    LinearProgress,
    ListItemButton
} from '@mui/material';
import {
    Menu as MenuIcon,
    Dashboard as DashboardIcon,
    People as PeopleIcon,
    School as SchoolIcon,
    Assignment as AssignmentIcon,
    CalendarToday as CalendarIcon,
    Grade as GradeIcon,
    Notifications as NotificationsIcon,
    AccountCircle as AccountCircleIcon,
    ExitToApp as ExitToAppIcon,
    Description as DescriptionIcon,
    GroupWork as GroupWorkIcon,
    CheckCircle as CheckCircleIcon,
    Book as BookIcon
} from '@mui/icons-material';
import { deepPurple, amber, blue, green, pink, teal } from '@mui/material/colors';
import theme from 'src/theme';
import { Outlet } from 'react-router-dom';
import { Link } from 'react-router-dom';

// Типы для TypeScript
type UserRole = 'admin' | 'deanery' | 'departmentHead' | 'supervisor' | 'student' | 'commission';

interface User {
    id: string;
    name: string;
    email: string;
    role: UserRole;
    avatar?: string;
    faculty?: string;
    department?: string;
}

// Основной компонент приложения
const MyLayout: React.FC = () => {
    const [mobileOpen, setMobileOpen] = useState(false);
    const [user] = useState<User>({
        id: '1',
        name: 'Иванов П.С.',
        email: 'ivanov@university.ru',
        role: 'student',
        faculty: 'Информационные технологии',
        department: 'Программная инженерия'
    });

    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

    const isMobile = useMediaQuery(theme.breakpoints.down('sm'));

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const handleMenuOpen = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    // Меню навигации
    const menuItems = [
        { text: 'Главная', icon: <DashboardIcon />, path: '/' },
        { text: 'Пользователи', icon: <PeopleIcon />, path: '/admin/users', roles: ['admin'] }
        // ,
        // { text: 'Факультеты', icon: <SchoolIcon />, path: '/faculties', roles: ['admin'] },
        // { text: 'Дипломные проекты', icon: <AssignmentIcon />, path: '/projects', roles: ['admin', 'deanery', 'departmentHead', 'supervisor', 'student'] },
        // { text: 'График защит', icon: <CalendarIcon />, path: '/schedule', roles: ['admin', 'deanery', 'departmentHead', 'commission'] },
        // { text: 'Оценки', icon: <GradeIcon />, path: '/grades', roles: ['commission', 'deanery'] },
        // { text: 'ГЭК', icon: <GroupWorkIcon />, path: '/commissions', roles: ['admin', 'deanery', 'departmentHead'] },
        // { text: 'Темы работ', icon: <BookIcon />, path: '/topics', roles: ['departmentHead', 'supervisor'] }
    ];

    // Фильтрация пунктов меню по роли пользователя
    const filteredMenuItems = menuItems;
    // .filter(item =>
    //     !item.roles || item.roles.includes(user.role)
    // );

    // Верхняя панель
    const renderAppBar = () => (
        <AppBar position="fixed" sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}>
            <Toolbar>
                <IconButton
                    color="inherit"
                    edge="start"
                    onClick={handleDrawerToggle}
                    sx={{ mr: 2, display: { sm: 'none' } }}
                >
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" noWrap component="div" sx={{ flexGrow: 1 }}>
                    Дипломное проектирование
                </Typography>

                <IconButton color="inherit" onClick={handleMenuOpen}>
                    <Avatar
                        sx={{ width: 32, height: 32, bgcolor: pink[500] }}
                        src={user.avatar}
                    >
                        {user.name.charAt(0)}
                    </Avatar>
                </IconButton>
            </Toolbar>
        </AppBar>
    );

    // Боковое меню
    const renderDrawer = () => (
        <Drawer
            variant={isMobile ? 'temporary' : 'permanent'}
            open={mobileOpen}
            onClose={handleDrawerToggle}
            ModalProps={{ keepMounted: true }}
            sx={{
                width: 240,
                flexShrink: 0,
                '& .MuiDrawer-paper': {
                    width: 240,
                    boxSizing: 'border-box',
                    borderRight: 'none',
                    boxShadow: '0 0 20px rgba(0,0,0,0.05)'
                },
            }}
        >
            <Toolbar />
            <Box sx={{ p: 2, textAlign: 'center' }}>
                <Typography variant="h6" color="primary">
                    {user.faculty}
                </Typography>
                <Typography variant="body2" color="textSecondary">
                    {user.department}
                </Typography>
            </Box>
            <Divider />

            <List>
                {filteredMenuItems.map((item) => (
                    <ListItemButton key={item.text} component={Link} to={item.path}>
                        <ListItemIcon sx={{ color: 'primary.main' }}>{item.icon}</ListItemIcon>
                        <ListItemText primary={item.text} />
                    </ListItemButton>
                ))}
            </List>

            <Divider sx={{ mt: 'auto' }} />
            <List>
                <ListItemButton >
                    <ListItemIcon><ExitToAppIcon /></ListItemIcon>
                    <ListItemText primary="Выйти" />
                </ListItemButton>
            </List>
        </Drawer>
    );

    // Меню пользователя
    const renderUserMenu = () => (
        <Menu
            anchorEl={anchorEl}
            open={Boolean(anchorEl)}
            onClose={handleClose}
            PaperProps={{
                elevation: 0,
                sx: {
                    width: 280,
                    borderRadius: 2,
                    boxShadow: '0 4px 20px rgba(0,0,0,0.12)',
                    mt: 1.5
                }
            }}
        >
            <Box sx={{ p: 2 }}>
                <Stack direction="row" spacing={2} alignItems="center">
                    <Avatar sx={{ width: 56, height: 56, bgcolor: pink[500] }} src={user.avatar}>
                        {user.name.charAt(0)}
                    </Avatar>
                    <Box>
                        <Typography variant="subtitle1" fontWeight={600}>{user.name}</Typography>
                        <Typography variant="body2" color="textSecondary">{user.email}</Typography>
                        <Chip
                            label={user.role === 'student' ? 'Студент' : 'Сотрудник'}
                            size="small"
                            sx={{ mt: 0.5, bgcolor: teal[50], color: teal[700] }}
                        />
                    </Box>
                </Stack>
            </Box>
            <Divider />
            <MenuItem onClick={handleClose}>
                <ListItemIcon><AccountCircleIcon fontSize="small" /></ListItemIcon>
                <ListItemText>Мой профиль</ListItemText>
            </MenuItem>
            <MenuItem onClick={handleClose}>
                <ListItemIcon><SettingsIcon /></ListItemIcon>
                <ListItemText>Настройки</ListItemText>
            </MenuItem>
            <Divider />
            <MenuItem onClick={handleClose}>
                <ListItemIcon><ExitToAppIcon fontSize="small" /></ListItemIcon>
                <ListItemText>Выйти из системы</ListItemText>
            </MenuItem>
        </Menu>
    );

    // Основной контент
    const renderMainContent = () => (
        <Box component="main" sx={{ flexGrow: 1, py: 10 }}>
            <Outlet />
        </Box>
    );

    return (
        <Box sx={{ display: 'flex' }}>
            {renderAppBar()}
            {renderDrawer()}
            {renderMainContent()}
            {renderUserMenu()}
        </Box>
    );
};

// Иконка настроек (временная реализация)
const SettingsIcon = () => (
    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
        <circle cx="12" cy="12" r="3"></circle>
        <path d="M19.4 15a1.65 1.65 0 0 0 .33 1.82l.06.06a2 2 0 0 1 0 2.83 2 2 0 0 1-2.83 0l-.06-.06a1.65 1.65 0 0 0-1.82-.33 1.65 1.65 0 0 0-1 1.51V21a2 2 0 0 1-2 2 2 2 0 0 1-2-2v-.09A1.65 1.65 0 0 0 9 19.4a1.65 1.65 0 0 0-1.82.33l-.06.06a2 2 0 0 1-2.83 0 2 2 0 0 1 0-2.83l.06-.06a1.65 1.65 0 0 0 .33-1.82 1.65 1.65 0 0 0-1.51-1H3a2 2 0 0 1-2-2 2 2 0 0 1 2-2h.09A1.65 1.65 0 0 0 4.6 9a1.65 1.65 0 0 0-.33-1.82l-.06-.06a2 2 0 0 1 0-2.83 2 2 0 0 1 2.83 0l.06.06a1.65 1.65 0 0 0 1.82.33H9a1.65 1.65 0 0 0 1-1.51V3a2 2 0 0 1 2-2 2 2 0 0 1 2 2v.09a1.65 1.65 0 0 0 1 1.51 1.65 1.65 0 0 0 1.82-.33l.06-.06a2 2 0 0 1 2.83 0 2 2 0 0 1 0 2.83l-.06.06a1.65 1.65 0 0 0-.33 1.82V9a1.65 1.65 0 0 0 1.51 1H21a2 2 0 0 1 2 2 2 2 0 0 1-2 2h-.09a1.65 1.65 0 0 0-1.51 1z"></path>
    </svg>
);

export default MyLayout;