import React, {useEffect, useRef, useState} from "react";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faCheck, faInfoCircle, faTimes} from "@fortawesome/free-solid-svg-icons";
import ButtonLayout from "../ButtonLayout";

const USER_REGEX = /^[a-zA-Z][a-zA-Z0-9-_.]{3,23}$/
const PASSWORD_REGEX = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%]).{8,24}$/;
const EMAIL_REGEX = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/



export default function RegisterForm()
{
    const userRef = useRef();
    const errRef = useRef();

    const [userName, setUser] = useState('');
    const [validName, setValidName] = useState(false);
    const [userFocus, setUserFocus] = useState(false);

    const [password, setPassword] = useState('');
    const [validPassword, setValidPassword] = useState(false);
    const [passwordFocus, setPasswordFocus] = useState(false);

    const [confirmPassword, setConfirmPassword] = useState('');
    const [validConfirmPassword, setValidConfirmPassword] = useState(false);
    const [confirmPasswordFocus, setConfirmPasswordFocus] = useState(false);

    const [email, setEmail] = useState('');
    const [validEmail, setValidEmail] = useState(false);
    const [emailFocus, setEmailFocus] = useState(false);

    const [errMessage, setErrMessage] = useState('');
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        userRef.current.focus();
    }, [])

    useEffect(() => {
        const result = USER_REGEX.test(userName);
        setValidName(result);
    }, [userName])

    useEffect(() => {
        const result = PASSWORD_REGEX.test(password);
        setValidPassword(result);
        if(password && confirmPassword) {
            const passwordMatch = password === confirmPassword;
            setValidConfirmPassword(passwordMatch);
        }
    }, [password, confirmPassword])

    useEffect(() => {
        const result = EMAIL_REGEX.test(email);
        setValidEmail(result);
    }, [email])

    useEffect(() => {
        setErrMessage('');
    }, [userName, password, confirmPassword])

    function register()
    {
        //TODO: Отправка запроса на регистрацию пользователя
        //result
        //setSuccess = true -> Продолжаем пользоваться сайтом
        return true;
    }
    
    return (
        <section>
            <p ref={errRef} className={errMessage ? "errmsg" : "offscreen"} aria-live="assertive">
                {errMessage}
            </p>
            <form className="register-form">
                <label htmlFor={userName}>
                    Имя пользователя: <br/>
                    <span className={validName ? "valid" : "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                    <span className={validName || !userName ? "hide" : "invalid"}>
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                </label>
                <input
                    type="text"
                    id={"username"}
                    ref={userRef}
                    autoComplete={"off"}
                    onChange={(e) => {
                        setUser(e.target.value);
                    }}
                    required
                    aria-invalid={validName ? "false" : "true"}
                    aria-describedby="uidnote"
                    onFocus={() => setUserFocus(true)}
                    onBlur={() => setUserFocus(false)}
                />
                <p id={"uinode"} className={userFocus && userName && !validName ? "instructions" : "offscreen"}>
                    Некорректное имя пользователя
                </p>

                <label htmlFor={password}>
                    Пароль: <br/>
                    <span className={validPassword ? "valid" : "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                    <span className={validPassword || !password ? "hide" : "invalid"}>
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                </label>
                <input
                    type="password"
                    id={"password"}
                    ref={userRef}
                    autoComplete={"off"}
                    onChange={(e) => {
                        setPassword(e.target.value);
                    }}
                    required
                    aria-invalid={validPassword ? "false" : "true"}
                    aria-describedby="uidnote"
                    onFocus={() => setPasswordFocus(true)}
                    onBlur={() => setPasswordFocus(false)}
                />
                <p id={"uinode"} className={passwordFocus && password && !validPassword ? "instructions" : "offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/> <br/>
                    Некорректный пароль: <br/>
                    1. Пароль должен содержать 1 строчный символ <br/>
                    2. Пароль должен содержать 1 заглавный символ <br/>
                    3. Пароль должен содержать 1 цифру <br/>
                    4. Пароль должен содержать 1 специальный символ <br/>
                </p>

                <label htmlFor={confirmPassword}>
                    Подтверждение пароля: <br/>
                    <span className={validConfirmPassword ? "valid" : "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                    <span className={validConfirmPassword || !password ? "hide" : "invalid"}>
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                </label>
                <input
                    type="password"
                    id={"confirm-password"}
                    ref={userRef}
                    autoComplete={"off"}
                    onChange={(e) => {
                        setConfirmPassword(e.target.value);
                    }}
                    required
                    aria-invalid={validConfirmPassword ? "false" : "true"}
                    aria-describedby="uidnote"
                    onFocus={() => setConfirmPasswordFocus(true)}
                    onBlur={() => setConfirmPasswordFocus(false)}
                />
                <p id={"uinode"}
                   className={confirmPasswordFocus && confirmPassword && !validConfirmPassword ? "instructions" : "offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/> <br/>
                    Пароли должны совпадать
                </p>

                <label htmlFor={email}>
                    Почта:
                    <span className={validEmail ? "valid" : "hide"}>
                    <FontAwesomeIcon icon={faCheck} />
                </span>
                    <span className={validEmail || !email ? "hide" : "invalid"}>
                    <FontAwesomeIcon icon={faTimes} />
                </span>
                </label>
                <input
                    type="email"
                    id={"email"}
                    ref={userRef}
                    autoComplete={"off"}
                    onChange={(e) => {
                        setEmail(e.target.value);
                    }}
                    required
                    aria-invalid={validEmail ? "false" : "true"}
                    aria-describedby="uidnote"
                    onFocus={() => setEmailFocus(true)}
                    onBlur={() => setEmailFocus(false)}
                />
                <p id={"uinode"} className={emailFocus && email && !validEmail ? "instructions" : "offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/> <br/>
                    Некорректный адрес почты
                </p>

                <ButtonLayout disabled={!validName || !validPassword || !validEmail}
                              btnClass={"register-btn"}
                              buttonText={"Зарегистрироваться"}
                              onClickFunction={register}
                />
            </form>
        </section>
    )
}