import { regions } from '../data.js'
import { useSearchParams } from 'react-router-dom';

export default function(props){
    const [searchParams] = useSearchParams();
    const regionId = Number(searchParams.get('regionId')); 
    const region = regions.find(r => r.id === regionId);   

     if (!region) {
        return <div>Регион не найден</div>;
    }
    
    return(
        <div key={regions.id}>
            <h1>{region.title}</h1>
            <p>{region.content}</p>
            <div className='regionMap'>{region.svg}</div>
        </div>
    )
}