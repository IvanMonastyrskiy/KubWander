import { menuItems } from '../data';
import { Link, useLocation } from 'react-router-dom';
import ActiveTaks from "../components/ActiveTasks"
import './Menu.css';

export default function Menu() {
    const location = useLocation();

    return (
        <div className='sidebar'>
            {menuItems.map((item, index) => (
                <div key={index}>
                    <Link to={item.path} className={location.pathname === item.path ? 'active' : ''}>
                        <img className="icone_items" src={item.image} alt={item.page} />
                        <p className='menu-items'>{item.page}</p>
                    </Link>
                </div>
            ))}
            <ActiveTaks />
            
        </div>
    );
}