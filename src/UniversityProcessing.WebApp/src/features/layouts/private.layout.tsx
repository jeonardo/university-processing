import { Outlet, useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/core/hooks';
import ResponsiveAppBar from './AppBar';
import { setUser } from 'src/features/identity/auth.slice';
import { useEffect } from 'react';
import { useGetApiV1IdentityInfoQuery } from 'src/api/backendApi';
import { Box, CircularProgress, Modal, Typography } from '@mui/material';

const PrivateLayout: React.FC = () => {
  const authState = useAppSelector(state => state.auth);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const { data, isSuccess } = useGetApiV1IdentityInfoQuery();

  useEffect(() => {
    if (!authState.authorized) [
      navigate('/signin')
    ];

    if (!authState.user && isSuccess) {
      dispatch(setUser({
        approved: data.approved,
        roleId: data.roleType,
        userId: data.userId
      }));
    }
  });

  // useEffect(() => {
  //     if (!user) {
  //         dispatch(setUser({
  //             approved: true,
  //             roleId: UserRoleIdDto.ApplicationAdmin,
  //             userId: "666",
  //             email: "user@example.com",
  //             userName: "JohnDoeSmith2000"
  //         }))
  //     }
  // })

  // if (!authState.authorized)
  //     return <Navigate replace to={"/signin"} /> 

  if (!authState.user) {
    return (
      <>
        <Modal open={true} onClose={() => {
        }} className="flex flex-col h-full w-full justify-center items-center text-center text-2xl font-bold">
          <Box sx={{ width: 400, padding: 7, bgcolor: 'white', margin: '100px auto' }}>
            <CircularProgress size="3rem" />
            <Typography sx={{ pt: 3 }}>Загрузка...</Typography>
          </Box>
        </Modal>
      </>
    );
  }

  if (!authState.user.approved) {
    return (
      <>
        <Modal open={true} onClose={() => {
        }} className="flex flex-col h-full w-full justify-center items-center text-center text-2xl font-bold">
          <Box sx={{ width: 400, padding: 7, bgcolor: 'white', margin: '100px auto' }}>
            <Typography>Отказано в доступе:<br /><br />Ваш аккаунт {authState.user.userName} проходит верификацию и еще
              не был подтвержден. Обратитесь к администратору.</Typography>
          </Box>
        </Modal>
      </>
    );
  }

  return (
    <div className="flex flex-col h-full w-full bg-[#f8f8f8]">
      <ResponsiveAppBar />
      <div className="flex h-full w-full p-5">
        <Outlet />
      </div>
    </div>
  );
};

export default PrivateLayout;