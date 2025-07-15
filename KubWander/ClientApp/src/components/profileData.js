import axios from 'axios';

export async function fetchProfileData() {
    const response = await axios.get('/api/Profile/users', {
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    });

    const data = response.data;

    return {
        nickname: data.User,
        description: data.Email,
        avatar: data.AvatarUrl,
        points: data.Points,
        quests: data.count_quests_user,
        photos: data.count_photos_user
    };
}
