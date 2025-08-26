import { Container } from '@mui/material';
import { useEffect } from 'react';
import { Outlet, useNavigate } from 'react-router-dom';
import { useAppSelector } from 'src/core/hooks';

const PublicOnlyLayout: React.FC = () => {
  const nav = useNavigate();
  const authState = useAppSelector(state => state.auth);
  useEffect(() => {
    if (authState.authorized) {
      nav('/');
    }
  }, [authState.authorized]);
  return (
    <Container className="flex items-center justify-center w-full min-h-screen p-3">
      <Outlet />
    </Container>);
};

export default PublicOnlyLayout;