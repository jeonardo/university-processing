import React from "react";
import { Provider } from "react-redux";
import App from "./App";
import { store } from './redux/store'
import './index.css'
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import { AuthProvider } from "./common/authContext";

createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <AuthProvider>
      <BrowserRouter>
        <Provider store={store}>
          <App />
        </Provider>
      </BrowserRouter>
    </AuthProvider>
  </React.StrictMode>,
)