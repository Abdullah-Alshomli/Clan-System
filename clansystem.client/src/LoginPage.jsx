import React, { useState, useEffect } from 'react';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import ClansHomePage from './ClansHomePage.jsx'

function App() {
    const [username, setUsername] = useState('');
    const [loggedIn, setLoggedIn] = useState(false);

    const handleLogin = async () => {
        try {
            const response = await fetch("https://localhost:7231/api/User/Check", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ username })
            });

            if (response.ok) {
                // Username exists in the database
                setLoggedIn(true);
            } else {
                // Username does not exist in the database
                console.error('Username does not exist');
                // You can show an error message to the user here
            }
        } catch (error) {
            console.error('Error logging in:', error);
            // Handle error - show error message to the user or retry login
        }
    };

    const handleUsernameChange = (event) => {
        setUsername(event.target.value);
    };

    if (loggedIn) {
        return (
            <div>
                <BrowserRouter>
                    <Routes>
                        <Route index element={ <ClansHomePage />} />
                    </Routes>
                </BrowserRouter>
            </div>
        );
    } else {
        return (
            <div>
                <h1>Login</h1>
                <input
                    type="text"
                    placeholder="Enter your username"
                    value={username}
                    onChange={handleUsernameChange}
                />
                <button onClick={handleLogin}>Login</button>
            </div>
        );
    }
}

export default App;
