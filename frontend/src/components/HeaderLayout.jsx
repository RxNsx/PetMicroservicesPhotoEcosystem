import {NavLink} from "react-router-dom";
import ReactLogo from "../images/logo192.png";
import React, {useState} from "react";
import "../styles/headerLayout.css";
import Profile from "./Profile";

export function HeaderLayout()
{
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
                <Profile />
            </nav>
        </header>
    )
}