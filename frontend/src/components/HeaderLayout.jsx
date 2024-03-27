import {Link, NavLink} from "react-router-dom";
import ReactLogo from "../images/logo192.png";
import React from "react";
import { useState, useEffect } from "react";
import "../styles/headerLayout.css";

export function HeaderLayout()
{
    const [register, setRegisterState] = useState(false);
    const [signedIn, setSignedInState] = useState(false);
    
    return (
        <header>
            <h1 align="center">Pet image store project microservices .NET Core + React</h1>
            <nav className="nav">
                <img
                    className="image-logo"
                    src={ReactLogo}
                    width="100px"
                    alt="React Logo"
                />
                <ul className="nav-items">
                    <NavLink to={"/prices"}><li>Pricing</li></NavLink>
                    <NavLink to={"/about"}><li>About</li></NavLink>
                    <NavLink to={"/contact"}><li>Contact</li></NavLink>
                </ul>
                <ul className="sign-buttons">
                    {register 
                        ? <Link to={"/login"}><button className={"sign-btn"}>Login</button></Link> 
                        : <NavLink to={"/register"}><button className={"sign-btn"}>Register</button></NavLink> }
                    {signedIn 
                        ? <NavLink to={"/user"}><button className={"sign-btn"}>User</button></NavLink>
                        : <NavLink to={"signIn"}><button className={"sign-btn"}>Sign In</button></NavLink> }
                </ul>
            </nav>
        </header>
    )
}