import React from "react";
import ButtonLayout from "./ButtonLayout";
import {Link} from "react-router-dom";

export default function Card(props) {
    return (
            <div className="user-card">
                <h3 className="user-card-login">Login: {props.login}</h3>
                <h3 className="user-card-email">Email: {props.email}</h3>
                <div>
                    <Link to={`/user/${props.id}`}>
                        <ButtonLayout 
                            buttonText={"Посмотреть пользователя"}
                            colorClass={"btn-view"}
                        />
                    </Link>
                    <Link to={`/user/update/${props.id}`}>
                        <ButtonLayout 
                            buttonText={"Обновить данные пользователя"}
                            colorClass={"btn-update"}
                        />
                    </Link>
                    <ButtonLayout 
                        buttonText={"Удалить пользователя"} 
                        onClickFunction={props.delete} 
                        onClickFunctionParameter={props.id}
                        colorClass={"btn-delete"}
                    />
                </div>
            </div>
    )
}