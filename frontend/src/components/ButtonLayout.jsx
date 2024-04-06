import React from "react";
import "../styles/buttonLayout.css";

export default function ButtonLayout(props) {

    console.log(props.disabled);
    
    let handleClick;
    if(props.onClickFunction)
    {
        handleClick = () => {
            props.onClickFunction();
        }
    }
    
    if(props.onClickFunctionParameter)
    {
        handleClick = () => {
            props.onClickFunction(props.onClickFunctionParameter);
        }
    }
    
    return (
        <button 
            className={`btn ${props.colorClass ? props.colorClass : ''} ${props.btnClass ? props.btnClass : ''}`}
            disabled={props.disabled}
            onClick={handleClick}
        >
            {props.buttonText}
        </button>
    )
}