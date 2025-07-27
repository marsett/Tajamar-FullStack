import React, { Component } from 'react';
import { BrowserRouter, Routes, Route, useParams } from 'react-router-dom';
import MenuHospitales from './MenuHospitales';
import Home from './Home';
import Doctores from './Doctores';
import CreateHospital from './CreateHospital';
import Hospitales from './Hospitales';

export default class Router extends Component {
    render() {
        function DoctoresElement() {
            var { idhospital } = useParams();
            return <Doctores idhospital={idhospital}></Doctores>
        }
        return (
            <BrowserRouter>
                <MenuHospitales></MenuHospitales>
                <Routes>
                    <Route path="/" element={<Home></Home>} />
                    <Route path="/doctores/:idhospital" element={<DoctoresElement></DoctoresElement>}></Route>
                    <Route path="/create" element={<CreateHospital></CreateHospital>}></Route>
                    <Route path="/hospitales" element={<Hospitales></Hospitales>}/>
                </Routes>
            </BrowserRouter>
        )
    }
}
