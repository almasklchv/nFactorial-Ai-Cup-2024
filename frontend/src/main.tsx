import React from 'react';
import ReactDOM from 'react-dom/client';
import './globals.css';
import Home from './pages/home/home';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import Generate from './pages/generate/generate';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />
  },
  {
    path: '/generate',
    element: <Generate />
  }
])

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
