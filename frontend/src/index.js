import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from "react-router-dom"
import './styles/index.css';
import {HeaderLayout} from "./components/HeaderLayout";
import {MainLayout} from "./components/MainLayout";
import {FooterLayout} from "./components/FooterLayout";
import About from "./components/About";

function Page() {
    return (
        <div>
            <HeaderLayout/>
            <MainLayout />
            <FooterLayout/>
        </div>
    )
}

function App()
{
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Page />} />
                <Route path="/about" element={<About />} />
            </Routes>
        </BrowserRouter>
    )
}

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
    //COLORSCHEME https://colorscheme.ru/#3Yc1Que5lW9ho
    <App />
);

