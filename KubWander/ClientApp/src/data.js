export const menuItems = [
  { page: "Вернуться на главную", path: '/', image: './public/gotohome.png'},
    { page: "Профиль", path: '/Profile', image: './public/gotohome.png' },
    { page: "Галерея", path: '', image: './public/gotohome.png' },
    { page: "Избранное", path: '', image: './public/gotohome.png' },
    { page: "Магазин", path: '', image: './public/gotohome.png' },
];

export const stats = [
    { key: "photos", label: "Сделано фото", image: './public/gallery_stat.png' },
    { key: "points", label: "KubCoins", image: './public/coins_stat.png' },
    { key: "quests", label: "Квестов выполнено", image: './public/quest_stat.png' },
    { key: "rank", label: "Звание", image: './public/adventurer_stat.png' }
];


export const mapConfig = {
    MinLatitude: 43.01,
    MaxLatitude: 47.00,
    MinLongitude: 36.20,
    MaxLongitude: 41.755,
    SVG_Width: 901,
    SVG_Height: 844
};

export const activeQuests = [
    { img: './public/avatar.png', label: "я не спою" },
    { img: './public/avatar.png', label: "я не спою" },
    { img: './public/avatar.png', label: "я не спою" },
    { img: './public/avatar.png', label: "я не спою" }
]