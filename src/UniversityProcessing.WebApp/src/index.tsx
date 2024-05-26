import React from "react";
import { Provider } from "react-redux";
import App from "./app";
import { store } from './core/store'
import { createRoot } from "react-dom/client";
import './index.css';
import { CssBaseline } from "@mui/material";

createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <CssBaseline />
        <Provider store={store}>
            <App />
        </Provider>
    </React.StrictMode>,
)