import React from 'react';
import ReactDOM from 'react-dom/client';
import './globals.css';
import { Footer } from './components/footer/';
import { Header } from '@/components/header/';
import Home from './pages/home/home';
import { Wrapper } from '@/components/wrapper/';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Wrapper>
      <Header />
      <Home />
      <Footer />
    </Wrapper>
  </React.StrictMode>
);
