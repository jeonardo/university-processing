import React from "react";
import {Provider} from "react-redux";
import App from "./app";
import {store} from './core/store'
import {createRoot} from "react-dom/client";
import {BrowserRouter} from "react-router-dom";
import './index.css';

createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <BrowserRouter>
            <Provider store={store}>
                <App/>
            </Provider>
        </BrowserRouter>
    </React.StrictMode>,
)