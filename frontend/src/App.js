import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [pakiautomaadid, setPakiautomaadid] = useState([]);

    useEffect(() => {
        fetch("https://localhost:7175/ParcelMachine")
            .then(res => res.json())
            .then(json => setPakiautomaadid(json));
    }, []);


    return (
        <div>
            <div className="App">
                <p>Omniva pakiautomaatid</p>
                <select>
                    {pakiautomaadid.map(automaat =>
                        <option>
                            {automaat.NAME}
                        </option>)}
                </select>
            </div>
        </div>
    );
}

export default App;