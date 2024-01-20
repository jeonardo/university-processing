import { Outlet } from "react-router-dom";
import { Navigate } from "react-router-dom";
import { NavLink } from "react-router-dom";
import { useAuth } from "../common/authContext";

const PrivateLayout: React.FC = () => {
  const { isAuthenticated } = useAuth();

  if (!isAuthenticated)
    return <Navigate replace to={"/login"} />;

  return (
    <div className='min-h-screen flex flex-col'>
      <header className='bg-gray-200 text-black sticky top-0 h-14 flex justify-center items-center font-semibold uppercase'>
        Cloudinary Actions
      </header>
      <div className='flex flex-col md:flex-row flex-1'>
        <aside className='bg-gray-100 w-full md:w-60'>
          <nav>
            <ul>
              <li className='m-2' key="Somewhere">
                <NavLink to={"somewhere"} >
                  <p className={'text-black'}>{"Somewhere"}</p>
                </NavLink>
              </li>
            </ul>
          </nav>
        </aside>
        <main className={'flex-1'}>
          <Outlet />
        </main>
      </div>
    </div>
  );
};

export default PrivateLayout;