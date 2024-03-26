import {useEffect, useState} from "react";

export function Main() {
    const [users, setUsers] = useState([]);
    useEffect(() => {
        fetchData();
    }, []);
    
    function fetchData() {
        const response = fetch("api/users", { method: "GET" })
            .then(response => {
                if (!response.ok) {
                    console.log(response.status);
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
    
    return (
        <>
            <div>
                <h1>UserList</h1>
                <ul>
                    {users.map((user, index) => (
                          <li key={user.id}>
                              <p>ID: {user.id}</p>
                              <p>Login: {user.login}</p>
                              <p>Email: {user.email}</p>
                              <p>Status: {user.status}</p>
                              <p>Last TIme Online: {user.lastTimeOnline}</p>
                          </li>      
                        ))
                    }
                </ul>
            </div>
        </>
    )
}