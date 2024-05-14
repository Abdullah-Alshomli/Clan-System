import React, { useState, useEffect } from 'react';
import './App.css';

function App() {
    const [clans, setClans] = useState([]);
    const [selectedClan, setSelectedClan] = useState(null);

    useEffect(() => {
        fetchClans();
    }, []);

    const fetchClans = async () => {
        try {
            const response = await fetch("https://localhost:7231/api/Clan/Get");
            const data = await response.json();
            setClans(data);
        } catch (error) {
            console.error('Error fetching clans:', error);
        }
    };

    const [username] = useState('Guest');

    const handleJoinClan = (clan) => {
        // Perform joining clan logic here
        setSelectedClan(clan);
    };

    const customFunction1 = () => {
        // Define your custom function 1 here
    };

    const customFunction2 = () => {
        // Define your custom function 2 here
    };

    return (
        <div>
            <h1>Welcome, {username}!</h1>
            {selectedClan ? (
                <div>
                    <h2>You are a member of {selectedClan.name}</h2>
                    <p>Points: {selectedClan.points}</p>
                </div>
            ) : (
                <div>
                    <h2>You are not in a clan</h2>
                    <p>Please select a clan to join:</p>
                    <ul>
                        {clans.map((clan, index) => (
                            <li key={index}>
                                {clan.ClanName} - Points: {clan.Points}
                                <button onClick={() => handleJoinClan(clan)}>Join</button>
                            </li>
                        ))}
                    </ul>
                </div>
            )}

            {/* Space for custom functions */}
            <div>
                <h2>Custom Functions</h2>
                <button onClick={customFunction1}>Custom Function 1</button>
                <button onClick={customFunction2}>Custom Function 2</button>
            </div>
        </div>
    );
}

export default App;
