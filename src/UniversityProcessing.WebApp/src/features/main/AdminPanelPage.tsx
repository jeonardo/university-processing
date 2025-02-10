import { ButtonBase, Card, CardContent, Container, Grid2, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const arr = [
  ['Университеты', 'Просмотр и регистрация новых университетов', '/universities', 1],
  ['Факультеты', 'Просмотр и регистрация новых факультетов', '/faculties', 2],
  ['Кафедры', 'Просмотр и регистрация новых кафедр', '/departments', 3],
  ['Группы', 'Просмотр и регистрация новых групп', '/groups', 4],
  ['Специальности', 'Просмотр и регистрация новых специальностей', '/specialties', 5],
  ['Сессии', 'Просмотр и регистрация новых сессий', '/diplomaPeriods', 6],
  ['Пользователи', 'Просмотр и утверждение новых пользователей', '/users', 7],
  ['Test', 'Test Test Test', '/test', 8]
];


const AdminPanelPage = () => {
  const navigate = useNavigate();
  return (
    <Container maxWidth="lg">
      <Grid2 container spacing={3} justifyContent={'center'}>
        {
          arr.map((el, index) => (
            <Grid2 component="div" key={index}>
              <ButtonBase onClick={() => navigate(el[2] as string)}>
                <Card sx={{ height: 120, width: 300 }}>
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
            </Grid2>
          ))
        }
      </Grid2>
    </Container>
  );
};

export default AdminPanelPage;