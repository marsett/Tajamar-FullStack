import React, { Component } from 'react';
import { BrowserRouter, Routes, Route, useParams } from 'react-router-dom';
import MenuEquipos from './MenuEquipos';
import VerApuestas from './VerApuestas';
import Equipo from './Equipo';
import CrearApuesta from './CrearApuesta';

export default class Router extends Component {
    render() {
        function EquipoComponentElement() {
            let { id } = useParams();
            return (
                <Equipo id={id} />
            )
        }
        return (
            <BrowserRouter>
                <MenuEquipos />
                <Routes>
                    <Route path="/equipo/:id" element={<EquipoComponentElement />} />
                    <Route path="/apuestas" element={<VerApuestas />}></Route>
                    <Route path="/crearapuesta" element={<CrearApuesta />}></Route>
                </Routes>
            </BrowserRouter>
        )
    }
}
