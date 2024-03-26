import React from 'react';
import ReactDOM from 'react-dom/client';
import {Header} from './components/Header';
import {Footer} from './components/Footer';
import {Main} from './components/Main';
import './styles/style.css';

function Page() {
    return (
        <div>
            <Header/>
            <Main />
            <Footer/>
        </div>
    )
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <Page/>
    </React.StrictMode>
);