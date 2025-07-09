// Menu.js
import { menuItems } from '../data';
import { Link } from 'react-router-dom';
import './Menu.css';

export default function Menu() {
  return (
    <div className='sidebar'>
      {menuItems.map((item, index) => (
        <div key={index}>
          <Link to={item.path}>
            <p className='menu-items'>{item.page}</p>
          </Link>
        </div>
      ))}
    </div>
  );
}