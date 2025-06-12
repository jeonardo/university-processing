import {
    Box, Typography
} from '@mui/material';


const WelcomePage = () => {

    const user = {
        name: "Иван Петров",
    };

    return (
        <Box sx={{ p: 2, maxWidth: 1200, mx: 'auto' }}>
            <Box sx={{ mb: 4 }}>
                <Typography variant="h5" sx={{ fontWeight: 700, mb: 1 }}>
                    Добро пожаловать, {user.name}! //TODO use real name
                </Typography>
                <Typography>
                    Здесь содержится ознакомительная информация для пользователя //TODO
                </Typography>
            </Box>
        </Box>
    );
};

export default WelcomePage;