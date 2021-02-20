import React from 'react';
import '@fortawesome/fontawesome-free/css/all.min.css';

// Navbar
import { NavbarCustom, NavbarColor } from './components/navbar';

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
    </div>
  );
}

export default App;
