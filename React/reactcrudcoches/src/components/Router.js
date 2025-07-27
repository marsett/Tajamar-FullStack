import React, { Component } from 'react';
import { BrowserRouter, Routes, Route, useParams } from 'react-router-dom';
import MenuNavegacion from './MenuNavegacion';
import Inicio from './Inicio';
import CrearCoche from './CrearCoche';
import DetalleCoche from './DetalleCoche';
import ActualizarCoche from './ActualizarCoche';

export default class Router extends Component {
    render() {
        function DetalleCocheElement() {
            let { idcoche } = useParams();
            console.log("ID DETALLES: " + idcoche)
            return (
                <DetalleCoche id={idcoche} />
            )
        }
        function ActualizarCocheElement() {
            let { idcoche, marca, modelo, conductor, imagen } = useParams();

            imagen = decodeURIComponent(imagen);

            console.log("ELEMENTOS UPDATE: " + idcoche, marca, modelo, conductor, imagen);
            return (
                <ActualizarCoche id={idcoche} marca={marca} modelo={modelo} conductor={conductor} imagen={imagen}></ActualizarCoche>
            )
        }
        return (
            <BrowserRouter>
                <MenuNavegacion />
                <Routes>
                    <Route path="/" element={<Inicio />}></Route>
                    <Route path="/crear" element={<CrearCoche />}></Route>
                    <Route path="/detalles/:idcoche" element={<DetalleCocheElement />}></Route>
                    <Route path="/actualizar/:idcoche/:marca/:modelo/:conductor/:imagen" element={<ActualizarCocheElement/>}></Route>
                </Routes>
            </BrowserRouter>
        )
    }
}
