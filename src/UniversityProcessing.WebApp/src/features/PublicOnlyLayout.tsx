import { Container } from '@mui/material';
import { Navigate, Outlet } from 'react-router-dom';
import { useAppSelector } from 'src/core/hooks';

const PublicOnlyLayout: React.FC = () => (
  useAppSelector(state => state.auth.authorized)
    ? <Navigate replace to={'/'} />
    : <Container
      className='flex items-center w-full h-full p-3'>
      <Outlet />
    </Container>
);

export default PublicOnlyLayout;