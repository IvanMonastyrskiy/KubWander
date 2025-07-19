import { Routes, Route } from 'react-router-dom';
import Menu from './components/Menu';
import Stats from './components/Stats';
import Profile from './pages/Profile';
import Home from './pages/Home';
import Region from './pages/Region';

export default function App() {
  return (
    <div className="app-container">
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/regionMap" element={<Region />} />
      </Routes>
    </div>
  );
}