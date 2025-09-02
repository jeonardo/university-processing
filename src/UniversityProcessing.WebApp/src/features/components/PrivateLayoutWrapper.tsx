import { useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/core/hooks';
import { logout, setUser } from 'src/features/auth/auth.slice';
import { useEffect } from 'react';
import AppLoader from 'src/components/AppLoader';
import { useGetApiAuthInfoQuery } from 'src/api/backendApi';
import AccessBlocker from './AccessBlocker';
import PrivateLayout from 'src/features/components/PrivateLayout';

const PrivateLayoutWrapper: React.FC = () => {
  const authState = useAppSelector(state => state.auth);
  const dispatch = useAppDispatch();
  const nav = useNavigate();

  const { data, isSuccess, isError, isFetching, isLoading, isUninitialized } = useGetApiAuthInfoQuery(
    undefined,
    {
      refetchOnMountOrArgChange: true,
      pollingInterval: 5 * 60 * 1000
    });

  useEffect(() => {
    if (!authState.authorized)
      nav('/signin');
    if (isUninitialized || isFetching || isLoading)
      return;
    else if (isSuccess && data) {
      dispatch(setUser(data));
      return;
    }

  }, [isUninitialized, isFetching, isLoading, isSuccess, isError, data, authState.tokens?.accessToken]);

  if (isLoading)
    return <AppLoader />;

  if (!authState.user)
    return;

  if (!authState.user.approved || authState.user.blocked)
    return <AccessBlocker authState={authState} />;

  return <PrivateLayout />;
};

export default PrivateLayoutWrapper;