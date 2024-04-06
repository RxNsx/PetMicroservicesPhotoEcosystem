import React from 'react'
import '../../styles/modalwindow.css'
import RegisterForm from './RegisterForm.jsx'



export default function ModalWindow() {
    function close()
    {
        const modalWindow = document.getElementById('modal-window');
        modalWindow.style.display = 'none';
    }
    
    return (
        <>
            <div id="modal-window" className="modal">
                <div className="modal-content">
                    <div className="modal-header">
                        <button className="close" onClick={close}>&times;</button>
                        <h3>Регистрация</h3>
                    </div>
                    <div className="modal-body">
                        <RegisterForm/>
                    </div>
                    <div className="modal-footer">
                    </div>
                </div>
            </div>
        </>
    )
}