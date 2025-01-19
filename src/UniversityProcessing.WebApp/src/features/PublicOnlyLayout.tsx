import { Container } from '@mui/material';
import { Navigate, Outlet } from 'react-router-dom';
import { useAppSelector } from 'src/core/hooks';

const PublicOnlyLayout: React.FC = () => (
  useAppSelector(state => state.auth.authorized)
    ? <Navigate replace to={'/'} />
    : <Container
      className="flex items-center justify-center w-full min-h-screen p-3">
      <Outlet />
    </Container>
);

export default PublicOnlyLayout;