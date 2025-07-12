import Header from "../components/Header"
import Menu from "../components/Menu"
import Map from "../components/Map"
import './Home.css'

export default function Home() {
    return (
        <div>
            <Header />
            <div className="content">
                <Menu />
                <Map />
            </div>
        </div>
    );
}
