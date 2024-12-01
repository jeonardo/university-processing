import * as React from 'react';
import Grid from '@mui/material/Grid';
import { ButtonBase, Card, CardContent, Container, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const arr = [
  ['Университеты', 'Просмотр и регистрация новых университетов', '/universities', 1],
  ['Факультеты', 'Просмотр и регистрация новых факультетов', '/faculties', 2],
  ['Кафедры', 'Просмотр и регистрация новых кафедр', '/departments', 3],
  ['Группы', 'Просмотр и регистрация новых групп', '/groups', 4],
  ['Специальности', 'Просмотр и регистрация новых специальностей', '/specialties', 5],
  ['Сессии', 'Просмотр и регистрация новых сессий', '/diplomaPeriods', 6],
  ['Пользователи', 'Просмотр и утверждение новых пользователей', '/users', 7]
];


const AdminPanelPage = () => {
  const navigate = useNavigate();
  return (
    <Container maxWidth="lg">
      <Grid container spacing={2}>
        {
          arr.map((el) => (
            <Grid item key={el[3] as number} xs={12} sm={6} md={4} lg={3}>
              <ButtonBase onClick={() => navigate(el[2] as string)}>
                <Card sx={{ height: 120, width: 250 }}>
                  <CardContent>
                    <Typography gutterBottom variant="h5" component="div">
                      {el[0]}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                      {el[1]}
                    </Typography>
                  </CardContent>
                </Card>
              </ButtonBase>
            </Grid>
          ))
        }
      </Grid>
    </Container>
  );
};

export default AdminPanelPage;