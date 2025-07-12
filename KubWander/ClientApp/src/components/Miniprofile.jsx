import './Miniprofile.css'
export default function Miniprofile() {
    return (
        <div className="mini-profile-container">
            <img className="avatar" src='./public/avatar.png' />
            <button className="change_avatar_button">
                <img className="change_avatar_img" src="./public/change-ava.png" alt="Сменить аватар" />
            </button>

            <div className="nickname">Nickname</div>
            <div className="description">Description</div>

            <div className="profile-info-line"></div>
            <div className="profile-info-line"></div>

            <button className="confirm_button">Сохранить</button>
        </div>
    )
}
