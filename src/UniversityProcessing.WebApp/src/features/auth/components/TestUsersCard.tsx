import React from 'react';
import { Box, Button, Card, CardContent, CardHeader, Grid, Typography } from '@mui/material';

// Define TypeScript interface for test users
interface TestUser {
  username: string;
  password: string;
  role: string;
  info: string;
}

interface TestUsersCardProps {
  isLoading: boolean;
  handleTestLogin: (username: string, password: string) => void;
}


const TestUsersCard: React.FC<TestUsersCardProps> = ({
                                                       isLoading,
                                                       handleTestLogin
                                                     }) => {
  const testUsers: TestUser[] = [
    { username: 'test_admin', password: 'test_admin', role: 'admin', info: 'some info' },
    { username: 'test_student', password: 'test_student', role: 'student', info: 'some info' },
    { username: 'test_teacher', password: 'test_teacher', role: 'teacher', info: 'some info' }
  ];

  return (
    <Card sx={{
      flex: 1,
      maxWidth: '800px', // MUI uses px values instead of max-w-2xl
      mx: 'auto' // Center horizontally
    }}>
      <CardHeader
        subheader={
          <Typography
            variant="body2"
            color="text.secondary"
            textAlign="center"
          >
            Для демонстрации системы используйте тестовые аккаунты
          </Typography>
        }
        sx={{ textAlign: 'center' }}
      />

      <CardContent>
        <Grid container spacing={3}>
          {testUsers.map((user) => (
            <Grid item xs={12} md={6} key={user.username}>
              <Box
                sx={{
                  border: 1,
                  borderColor: 'divider',
                  borderRadius: 1,
                  p: 1,
                  height: '100%',
                  '&:hover': {
                    backgroundColor: 'action.hover'
                  }
                }}
              >
                <Box
                  display="flex"
                  justifyContent="space-between"
                  mb={2}
                >
                  <div>
                    <Typography variant="subtitle1" fontWeight="medium">
                      {user.username}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                      {user.role}
                    </Typography>
                  </div>
                </Box>

                <Button
                  variant="contained"
                  fullWidth
                  size="small"
                  onClick={() => handleTestLogin(user.username, user.password)}
                  disabled={isLoading}
                  sx={{
                    mt: 'auto'
                  }}
                >
                  {isLoading ? 'Вход...' : 'Войти'}
                </Button>
              </Box>
            </Grid>
          ))}
        </Grid>
      </CardContent>
    </Card>
  );
};

export default TestUsersCard;