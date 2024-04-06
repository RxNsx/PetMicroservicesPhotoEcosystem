import React, {useState} from "react";
import {Link} from "react-router-dom";
import ButtonLayout from "./ButtonLayout";
import '../styles/profile.css';

export default function Profile() {
    const [signedIn, setSignState] = useState(false);
    
    function signIn()
    {
        //TODO: Сделать вход по JWT токену
        const modalWindow = document.getElementById('modal-window');
        modalWindow.style.display = 'block';
        setSignState(true);
    }
    
    function logout()
    {
        //TODO: Сделать выход + удаление токена
        setSignState(false);
    }
    
    function register()
    {
        const modalWindow = document.getElementById('modal-window');
        modalWindow.style.display = 'block';
        //TODO: Сделать регистрацию
    }
    
    return (
        <>
            <div className="profile-buttons">
                {signedIn
                    ?
                    (<>
                        <div className={"profile-link"}>
                            <Link to={"/user"}>
                                <ButtonLayout
                                    buttonText={"Профиль"}
                                    colorClass={"btn-profile"}/>
                            </Link>
                        </div>
                        <ButtonLayout
                            buttonText={"Выйти"}
                            colorClass={"btn-logout"}
                            onClickFunction={logout}/>
                    </>)
                    :
                    (<>
                        <ButtonLayout
                            buttonText={"Войти"}
                            colorClass={"btn-login"}
                            onClickFunction={signIn}/>
                        <ButtonLayout
                            buttonText={"Зарегистрироваться"}
                            colorClass={"btn-register"}
                            onClickFunction={register}/>
                    </>)
                }
            </div>
        </>
    )
}