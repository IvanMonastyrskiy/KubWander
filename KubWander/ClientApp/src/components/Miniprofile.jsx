import { useEffect, useState } from 'react';
import './Miniprofile.css'
import { fetchProfileData } from '../components/profileData';
export default function Miniprofile() {
    const [user, setUser] = useState(null);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const profile = await fetchProfileData();
                setUser(profile);
                setError(null);
            } catch (error) {
                setError('Ошибка при получении данных: ' + error.message);
                console.error('Ошибка при получении данных:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <div className="mini-profile-container">
            <img className="avatar" src={user?.avatar || './public/avatar.png'} alt="Avatar" />
            <button className="change_avatar_button">
                <img className="change_avatar_img" src="./public/change-ava.png" alt="Сменить аватар" />
            </button>
            {error && <div className="error-message">{error}</div>}
            {user && (
                <>
                    <div className="nickname">{user.nickname}</div>
                    <div className="email">{user.description}</div>
                </>
            )}
            <div className="profile-info-line"></div>
            <div className="profile-info-line"></div>
            <button className="confirm_button">Сохранить</button>
        </div>
    )
}
