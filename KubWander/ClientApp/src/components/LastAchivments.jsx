import './LastAchivments.css'

export default function LastAchivments() {

    return (
        <div className="last-achivment-container">
            <div className="last-achivment">
                <h2 className="achievement-title">Последние достижения</h2>
                <div className="columns-wrapper">
                    <div className="column left-column">
                        <div className="item">
                            <h3>Классника</h3>
                            <p>Посетить стадион Краснодар</p>
                        </div>
                        <div className="item">
                            <h3>Кубанский борщ</h3>
                            <p>Посетить ресторан *** и попробовать национальное блюдо</p>
                        </div>
                    </div>
                    <div className="column right-column">
                        <div className="item">
                            <h3>Классника</h3>
                            <p>01.03.2023</p>
                        </div>
                        <div className="item">
                            <h3>Кубанский борщ</h3>
                            <p>Посетить ресторан *** и попробовать национальное блюдо</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
};
