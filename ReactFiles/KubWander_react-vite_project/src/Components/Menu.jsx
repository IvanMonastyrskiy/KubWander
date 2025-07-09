import {menuItems} from '../data'
import './Menu.css'

export default function Menu() {
  return (
   
      <div className='sidebar'>
        {menuItems.map((item) => (
          <div>
            <a href={item.path}><p className='menu-items'>{item.page}</p></a>
          </div>
        ))}
      </div>
      )};