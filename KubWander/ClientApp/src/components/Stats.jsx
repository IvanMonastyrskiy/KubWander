import { stats } from '../data'
import './Stats.css'
import { useEffect, useState } from 'react';
import { fetchProfileData } from '../components/profileData';

export default function Stats() {
    const [profile, setProfile] = useState(null);


    useEffect(() => {
        const getStats = async () => {
            try {
                const data = await fetchProfileData();
                setProfile(data);
            } catch (error) {
                console.error('Ошибка получения статистики:', error);
            }
        };

        getStats();
    }, []);
    if (!profile) {
        return <div className="stats-section">Загрузка статистики...</div>;
    }
    const dynamicValues = {
        photos: profile.photos,
        points: profile.points,
        quests: profile.quests,
        rank: profile.points >= 100 ? 'Путешественник' : 'Новичок'
    };
    return (

        <section className="stats-section">
            <div className="stats-grid">
                {stats.map((stat, index) => (
                    <div className="stat-card" key={index}>
                        <div className="stat-label">{stat.label}</div>
                        <div><img className="stat-image" src={stat.image}></img></div>
                        <div className="stat-value">{dynamicValues[stat.key]}</div>
                    </div>
                ))}
            </div>
        </section>
    )
};