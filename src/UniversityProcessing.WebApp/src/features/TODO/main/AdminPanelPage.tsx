import { ButtonBase, Card, CardContent, Container, Grid2, Typography } from '@mui/material';
import { Link } from 'react-router-dom';
import { useLocation, useNavigate } from 'react-router-dom';

const arr = [
  ['Факультеты', 'Просмотр и регистрация новых факультетов', '/faculties', 1],
  ['Пользователи', 'Просмотр и утверждение новых администраторов', '/users', 2],
  ['Учебные периоды', 'Просмотр создание новых учебных периодов', '/', 2]
  // ['Кафедры', 'Просмотр и регистрация новых кафедр', '/departments', 3],
  // ['Группы', 'Просмотр и регистрация новых групп', '/groups', 4],
  // ['Специальности', 'Просмотр и регистрация новых специальностей', '/specialties', 5],
  // ['Сессии', 'Просмотр и регистрация новых сессий', '/diplomaPeriods', 6],
  // ['Пользователи', 'Просмотр и утверждение новых пользователей', '/users', 7],
];

//TODO const Breadcrumbs = () => {
//   const location = useLocation();
//   const pathnames = location.pathname.split('/').filter((x) => x);

//   return (
//     <div style={{ marginBottom: '20px' }}>
//       <Link to="/">Home</Link>
//       {pathnames.map((name, index) => {
//         const routeTo = `/${pathnames.slice(0, index + 1).join('/')}`;
//         const isLast = index === pathnames.length - 1;
//         return isLast ? (
//           <span key={name}> / {name}</span>
//         ) : (
//           <span key={name}>
//             {' '}
//             / <Link to={routeTo}>{name}</Link>
//           </span>
//         );
//       })}
//     </div>
//   );
// };

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