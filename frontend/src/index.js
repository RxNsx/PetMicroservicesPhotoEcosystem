import React from 'react';
import ReactDOM from 'react-dom/client';
import {BrowserRouter, Route, Routes} from "react-router-dom"
import './styles/index.css';
import {HeaderLayout} from "./components/HeaderLayout";
import {MainLayout} from "./components/MainLayout";
import {FooterLayout} from "./components/FooterLayout";
import About from "./components/About";
import UserDetails from "./components/UserDetails";
import ModalWindow from "./components/modals/ModalWindow";

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
        <>
            <ModalWindow />
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Page />} />
                    <Route path="/about" element={<About />} />
                    <Route path="/user/:id" element={<UserDetails />} />
                </Routes>
            </BrowserRouter>
        </>
    )
}

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
    //COLORSCHEME https://colorscheme.ru/#3Yc1Que5lW9ho
    <App />
);

