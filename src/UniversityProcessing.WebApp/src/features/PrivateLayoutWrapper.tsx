import { Navigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'src/core/hooks';
import { logout, setUser } from 'src/features/auth/auth.slice';
import { Component, useEffect, useState } from 'react';
import AppLoader from 'src/components/AppLoader';
import { useGetApiAuthInfoQuery, useLazyGetApiAuthInfoQuery } from 'src/api/backendApi';
import AccessBlocker from './AccessBlocker';
import PrivateLayout from 'src/features/PrivateLayout';

const PrivateLayoutWrapper: React.FC = () => {
  const authState = useAppSelector(state => state.auth);
  const dispatch = useAppDispatch();
  const { data, isLoading, isSuccess, isError } = useGetApiAuthInfoQuery(undefined, { refetchOnMountOrArgChange: true, pollingInterval: 300000 });

  useEffect(() => {
    if (isSuccess) {
      dispatch(setUser(data));
    }
    else if (!isLoading)
      dispatch(logout());
  });

  if (isLoading) {
    return <AppLoader />
  }

  if (!isLoading && isError) {
    return <Navigate to="/signin" />
  }

  if (!authState.user?.approved || authState.user.blocked) {
    return <AccessBlocker authState={authState} />
  }

  return <PrivateLayout />
};

export default PrivateLayoutWrapper;