import "../styles/userList.css";
import React, {useEffect, useState} from "react";
import data from "../data/users.json";
import UserCard from "./UserCard";

export default function UserList()
{
    const [users, setUsers] = useState([]);
    useEffect(() => {
        // fetchData();
        setUsers(data);
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
    
    function deleteUser(id)
    {
        setUsers(users.filter(user => user.id !== id));
    }

    return (
        <>
            {users
                ? (
                    <div className={"user-cards"}>
                        {users.map((user, index) => (
                            <UserCard key={user.id} delete={deleteUser} {...user}/>
                        ))}
                    </div>
                )
                : (
                    <p>Нет пользователей</p>
                )
            }
        </>
    )
}