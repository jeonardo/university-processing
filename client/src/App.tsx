import { useEffect, useState } from 'react';
import './App.css';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import UserPage from './pages/UserPage';
import DefaultLayout from './layouts/DefaultLayout';
import Login from './pages/Login';
import Register from './pages/Register';
import ProtectedLayout from './layouts/ProtectedLayout';
import Home from './pages/HomePage';

const App: React.FC = () => (
    <BrowserRouter>
 <>
      <Router>
        <Route element={<DefaultLayout />}>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Route>
        <Route element={<ProtectedLayout />}>
          <Route path="/" element={<Home />} />
        </Route>
      </Router>
    </>
    </BrowserRouter>
);

export default App;

const App: React.FC = () => {
  return (
    <AuthProvider>
      <Routes>
        {/* Public routes */}
        <Route path="/login" element={<LoginPage />} />

        {/* Private route using PrivateRoute component */}
        <Route path="/" element={<PrivateRoute />}>
          <Route path="/account" element={<HomePage />} />
        </Route>
      </Routes>
    </AuthProvider>
  );
};

export default App;