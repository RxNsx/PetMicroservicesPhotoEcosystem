import React, {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import data from "../data/users.json";

export default function UserDetails()
{
    const {id} = useParams();
    const [user, setUser] = useState(null);
    
    useEffect(() => {
        getUser();
    }, []);
    
    function getUser()
    {
        setUser(data.find(user => user.id === id));
    }
    
    return (
        <>
            {user 
            ? (
                <div className={"user-details"}>
                    <h3>{user.login}</h3>
                    <h3>{user.email}</h3>
                    <h3>{user.status}</h3>
                    <h3>{user.lastTimeOnline}</h3>
                </div>
            ) 
            : (
                <p>Loading user...</p>
            )}
        </>
    )


}