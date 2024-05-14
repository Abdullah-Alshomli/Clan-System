import { useState } from 'react';
import './App.css';

function App() {
    const [username] = useState('Guest');
    const [clanName, setClanName] = useState('Clan 1');
    const [clanPoints, setClanPoints] = useState(500);
    const [addPoints, setAddPoints] = useState('');
    const [subtractPoints, setSubtractPoints] = useState('');
    const [setPoints, setSetPoints] = useState('');
    const [currentContributions, setCurrentContributions] = useState([
        { user: 'User1', contribution: 50 },
        { user: 'User2', contribution: 30 },
        { user: 'User3', contribution: 20 }
    ]);

    const handleLeaveClan = () => {
        setClanName('');
        setClanPoints(0);
        setCurrentContributions([]);
    };

    const handleAddPoints = () => {
        setClanPoints(clanPoints + parseInt(addPoints));
    };

    const handleSubtractPoints = () => {
        setClanPoints(clanPoints - parseInt(subtractPoints));
    };

    const handleSetPoints = () => {
        setClanPoints(parseInt(setPoints));
    };

    const handleShowContributions = () => {
        // Logic to fetch and display current contributions
    };

    return (
        <div>
            {clanName ? (
                <div>
                    <h1>You are a part of {clanName}</h1>
                    <button onClick={handleLeaveClan}>Leave Clan</button>
                    <p>Clan Current Points: {clanPoints}</p>
                    <div>
                        <h2>Manage Clan Points</h2>
                        <input
                            type="number"
                            placeholder="Add Points"
                            value={addPoints}
                            onChange={(e) => setAddPoints(e.target.value)}
                        />
                        <button onClick={handleAddPoints}>Add Points</button>
                        <input
                            type="number"
                            placeholder="Subtract Points"
                            value={subtractPoints}
                            onChange={(e) => setSubtractPoints(e.target.value)}
                        />
                        <button onClick={handleSubtractPoints}>Subtract Points</button>
                        <input
                            type="number"
                            placeholder="Set Points"
                            value={setPoints}
                            onChange={(e) => setSetPoints(e.target.value)}
                        />
                        <button onClick={handleSetPoints}>Set Points</button>
                    </div>
                    <div>
                        <button onClick={handleShowContributions}>Show Current Contributions</button>
                    </div>
                </div>
            ) : (
                <div>
                    <h2>You are not in a clan</h2>
                    {/* Render clan list or invite button */}
                </div>
            )}
            <p>Logged in as: {username}</p>
        </div>
    );
}

export default App;
