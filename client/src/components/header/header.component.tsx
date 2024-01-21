// pkgs:
import { FC, VFC, useState } from 'react';
import { Container } from 'react-bootstrap';
import { Link, NavLink, useLocation } from 'react-router-dom';

// component>>>
const Header: FC = () => {
  // preConfigured hooks:
  const location = useLocation();

  // mobile || side menu, you might need to create a redux slice
  const [isSideMenuOpened, setIsSideMenuOpened] = useState<boolean>(false);

  return (
    // depending on {expanded} so wether to view a default header or the minimal one.
    <header className="default-header">
      <Container style={{ height: `inherit` }}>
        <div className="header-wrapper">
          <section className="left-wing">
            <div className="logo">
              <Link to="/"></Link>
            </div>
          </section>
          <section className="right-wing">
            {/* routes for example or any thing else */}
            routes
          </section>
        </div>
      </Container>
    </header>
  );
};

export default Header;