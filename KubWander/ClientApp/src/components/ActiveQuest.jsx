import './ActiveQuest.css'
import { activeQuests } from '../data'

export default function ActiveQuest() {

    return (
        <div className="active-quest-container">
            <div className="active-quest-text">
                <p>Активные задания</p>
            </div>
            <div className="quest-container">

                {activeQuests.map((item, index) => (
                    <div className='active-quest' key={index}>
                        <img className='active-quest-img' src={item.img} alt={item.label} />
                        <p>{item.label}</p>
                    </div>
                ))}

            </div>
        </div>


    )
};
