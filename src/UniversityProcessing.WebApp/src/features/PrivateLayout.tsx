import { Outlet, useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/core/hooks';
import ResponsiveAppBar from './AppBar';
import { logout, setUser } from 'src/features/auth/auth.slice';
import { useEffect } from 'react';
import { Box, Button, Modal, Typography } from '@mui/material';
import AppLoader from 'src/components/AppLoader';
import { useGetApiAuthInfoQuery } from 'src/api/backendApi';

const PrivateLayout: React.FC = () => {
  const authState = useAppSelector(state => state.auth);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const { data, isSuccess } = useGetApiAuthInfoQuery();
  const handleLogout = () => dispatch(logout());

  useEffect(() => {
    if (!authState.authorized) [
      navigate('/signin')
    ];

    if (!authState.user && isSuccess) {
      dispatch(setUser({
        approved: data.approved,
        role: data.roleType,
        userId: data.userId
      }));
    }
  });

  // useEffect(() => {
  //     if (!user) {
  //         dispatch(setUser({
  //             approved: true,
  //             roleId: UserRoleIdDto.Admin,
  //             userId: "666",
  //             email: "user@example.com",
  //             userName: "JohnDoeSmith2000"
  //         }))
  //     }
  // })

  // if (!authState.authorized)
  //     return <Navigate replace to={"/signin"} /> 

  if (!authState.user) {
    return (<AppLoader />);
  }

  if (!authState.user.approved) {
    return (
      <Modal open={true} onClose={() => {
      }} className="flex flex-col h-full w-full justify-center items-center text-center text-2xl font-bold">
        <Box
          sx={{ width: 400, padding: 7, bgcolor: 'white', margin: '100px auto' }}>
          <Typography className="pb-3">Отказано в доступе:<br /><br />Ваш аккаунт {authState.user.userName} не прошел
            верификацию. Обратитесь к администратору.</Typography>
          <Button
            fullWidth
            variant="contained"
            onClick={handleLogout}
          >
            <span>Выйти</span>
          </Button>
        </Box>
      </Modal>
    );
  }

  return (
    <div className="flex flex-col min-h-screen w-full bg-[#f8f8f8]">
      <ResponsiveAppBar />
      <div className="flex h-full w-full p-5">
        <Outlet />
      </div>
    </div>
  );
};

export default PrivateLayout;