import ReactLogo from "../images/logo192.png";
import React from "react";

export function Header()
{
    return (
        <header>
            <h1>Reasons I'm excited to learn React</h1>
            <nav className="nav">
                <img
                    className="image-logo"
                    src={ReactLogo}
                    width="100px"
                    alt="React Logo"
                />
                <ul className="nav-items">
                    <li>Pricing</li>
                    <li>About</li>
                    <li>Contact</li>
                </ul>
            </nav>
        </header>
    )
}