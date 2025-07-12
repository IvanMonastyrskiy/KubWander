import './Profile.css'
import Menu from '../components/Menu';
import Stats from '../components/Stats';
import Miniprofile from '../components/Miniprofile';
import LastAchivments from '../components/LastAchivments';

export default function Profile() {
    return (
        <div className='menu-container'>
            <Menu />
            <Miniprofile />
            <main>

            </main>
            <Stats />
            <LastAchivments />

        </div>
    );
}
