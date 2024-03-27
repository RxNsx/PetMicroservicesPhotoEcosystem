import "../styles/userList.css";
import React, {useEffect, useState} from "react";
import data from "../data/users.json";
import Card from "./Cards";

export default function UserList()
{
    const [users, setUsers] = useState([]);
    useEffect(() => {
        // fetchData();
        getData();
    }, []);

    function fetchData() {
        const response = fetch("http://userservice:8080/api/users",
            {
                method: "GET",
                headers: { "Content-Type": "application/json" }
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            })
            .then(users => {
                console.log(users);
                setUsers(users)
            })
            .catch(error => {
                console.error('Fetch failed:', error);
            });
    }

    function getData()
    {
        setUsers(data);
    }

    if(users && users.length > 0)
    {
        return (
            <>
                <div className={"user-cards"}>
                    {users.map((user, index) => (
                        <Card key={user.id} {...user}/>
                    ))}
                </div>
            </>
        )
    }
    return (
        <>
            <h3>Нет пользователей</h3>
        </>
    )
}