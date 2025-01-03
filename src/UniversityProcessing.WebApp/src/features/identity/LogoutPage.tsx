import { useAppDispatch } from 'src/core/hooks';
import { logout } from './auth.slice';

const LogoutPage = () => {
  const dispatch = useAppDispatch();
  dispatch(logout());
  return <></>;
};

export default LogoutPage;