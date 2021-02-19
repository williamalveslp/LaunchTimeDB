import React from 'react';
// MDBReact and Bootstrap
import '@fortawesome/fontawesome-free/css/all.min.css';
//import 'bootstrap-css-only/css/bootstrap.min.css';
//import 'mdbreact/dist/css/mdb.css';

// Navbar and Footer
import { NavbarCustom, NavbarColor } from './components/navbar';
import { Footer, FooterColor } from './components/footer';

import AppHeaderLinks from './App-headers-links';
import './App.css';
import Router from './routes';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <AppHeaderLinks />        
      </header>

      <NavbarCustom backgroundColor={NavbarColor.DARK} />

      <div className='containerBody'>
        <Router />
      </div>

    {/*   <Footer backgroundColor={FooterColor.BLUE} /> */}
    </div>
  );
}

export default App;
