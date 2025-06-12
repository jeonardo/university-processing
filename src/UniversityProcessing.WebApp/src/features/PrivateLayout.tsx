import { Navigate, Outlet } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/core/hooks';
import { setUser } from 'src/features/auth/auth.slice';
import { useEffect } from 'react';
import AppLoader from 'src/components/AppLoader';
import { useGetApiAuthInfoQuery } from 'src/api/backendApi';
import AccessBlocker from './AccessBlocker';
import MyLayout from 'src/components/layouts/MyLayout';

const PrivateLayout: React.FC = () => {
  const authState = useAppSelector(state => state.auth);
  const dispatch = useAppDispatch();
  const { data, isLoading, isSuccess } = useGetApiAuthInfoQuery();

  useEffect(() => {
    if (!authState.user && isSuccess) {
      dispatch(setUser(data));
    }
  });

  if (isLoading) {
    return (<AppLoader />);
  }

  if (!isSuccess || !authState.user) {
    return <Navigate to="/signin" />;
  }

  if (!authState.user.approved || authState.user.blocked) {
    return (
      <AccessBlocker authState={authState} />
    );
  }

  return (
    <MyLayout />
  );
};

export default PrivateLayout;