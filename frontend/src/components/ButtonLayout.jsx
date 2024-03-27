import React from "react";

export default function ButtonLayout({onClickFunction, buttonText}) {
    return (
        <button className={"user-btn"}  onClick={onClickFunction}>{buttonText}</button>
    )
}