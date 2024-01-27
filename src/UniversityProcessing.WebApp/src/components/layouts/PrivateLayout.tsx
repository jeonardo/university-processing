import { Outlet } from "react-router-dom";
import { Navigate } from "react-router-dom";
import { Fragment } from "react";
import Header from "../header/header.component";
import Footer from "../footer/footer.component";

const PrivateLayout: React.FC<{ isAuthenticated: boolean }> = ({ isAuthenticated }) => (
  !isAuthenticated
    ? <Navigate replace to={"/signin"} />
    : <Fragment>
      <Header />
      <Outlet />
      <Footer />
    </Fragment>
);

export default PrivateLayout;