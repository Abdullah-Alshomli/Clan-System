import { useState } from 'react';
import './App.css';

function ClanContributionPage() {
    const [username] = useState('Ali');
    const [clanName] = useState('Clan 1');
    const [currentContributions] = useState([
        { user: 'Ali', contribution: 100 },
        { user: 'Abdullah', contribution: 500 },
        { user: 'Mohamed', contribution: 220 }
    ]);

    const handleCloseWeb = () => {
        window.close();
    };

    return (
        <div>
            <h1>Current Contributions for {clanName}</h1>
            <ul>
                {currentContributions.map((contribution, index) => (
                    <li key={index}>
                        User Name: {contribution.user} - Current Points: {contribution.contribution}
                    </li>
                ))}
            </ul>
            <button onClick={handleCloseWeb}>Close Web</button>
            <p>Logged in as: {username}</p>
        </div>
    );
}

export default ClanContributionPage;