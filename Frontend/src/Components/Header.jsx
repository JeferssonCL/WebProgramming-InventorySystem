import React from 'react';
import '../css/header.css';

const Header = () => {
  return (
    <header className="app-header">
      <div>Mi Aplicación</div>
      <nav>
        <ul>
          <li><a href="/">Home</a></li>
          <li><a href="/about">About</a></li>
          <li><a href="/contact">Contact</a></li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;
