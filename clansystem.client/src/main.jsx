import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
//import Test from './Test.jsx'
import ClansHomePage from './ClansHomePage.jsx'
import LoginPage from './LoginPage.jsx'
import ClanPage from './ClanPage.jsx'
import ClanContributionPage from './ClanContributionPage.jsx'


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
        <ClanContributionPage />
  </React.StrictMode>,
)
