import React from "react";
import "../styles/buttonLayout.css";

export default function ButtonLayout({onClickFunction, onClickFunctionParameter, colorClass, buttonText}) {

    let handleClick;
    if(onClickFunction)
    {
        handleClick = () => {
            onClickFunction(onClickFunctionParameter);
        }
    }
    
    return (
        <button className={`user-btn ${colorClass}`} onClick={handleClick}>{buttonText}</button>
    )
}