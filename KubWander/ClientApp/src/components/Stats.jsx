import { stats } from '../data'
import './Stats.css'

export default function Stats() {

    return (

        <section className="stats-section">
            <div className="stats-grid">
                {stats.map((stat) => (
                    <div className="stat-card">
                        <div className="stat-label">{stat.label}</div>
                        <div><img className="stat-image" src={stat.image}></img></div>
                        <div className="stat-value">{stat.value}</div>
                    </div>
                ))}
            </div>
        </section>
    )
};