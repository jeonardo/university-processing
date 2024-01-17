// pkgs:
import { Fragment } from 'react';

// utils:
import './style.sass';

import Header from '../header/header.component';
import Footer from '../footer/footer.component';
import { LayoutInterface } from '../../common/interfaces/comps/layout.interface';

// comps:

// component>>>
const Layout: React.VFC<LayoutInterface> = ({ children, expanded }) => {
  return (
    <Fragment>
      <Header expanded={expanded} />
      {children}
      <Footer expanded={expanded} />
    </Fragment>
  );
};

export default Layout;