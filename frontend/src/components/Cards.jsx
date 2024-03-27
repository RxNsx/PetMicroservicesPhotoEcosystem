import React from "react";
import ButtonLayout from "./ButtonLayout";


export default function Card(props) {
    return (
        <div className="user-card">
            <h3 className="user-card-login">Login: {props.login}</h3>
            <h3 className="user-card-email">Email: {props.email}</h3>
            <ButtonLayout buttonText={"Посмотреть пользователя"} onClickFunction={null}/>
        </div>
    )
}