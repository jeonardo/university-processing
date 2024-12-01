import { Navigate, Outlet } from 'react-router-dom';
import { useAppSelector } from 'src/core/hooks';

const PublicOnlyLayout: React.FC = () => (
  useAppSelector(state => state.auth.authorized)
    ? <Navigate replace to={'/'} />
    : <Outlet />
);

export default PublicOnlyLayout;

// const PublicOnlyLayout: React.FC = () => {
//     const authState = useAppSelector(state => state.auth)
//     const navigate = useNavigate()

//     useEffect(() => {
//         if (authState.authorized) {
//             navigate("/")
//         }
//     })

//     return (<Outlet />)
// }

// export default PublicOnlyLayout;