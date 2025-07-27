import React, { Component } from 'react';
import { BrowserRouter, Route, Routes, useParams } from 'react-router-dom';
import TablaMultiplicar from './TablaMultiplicar';
import Home from './Home';
import NotFound from './NotFound';

export default class Router extends Component {
    render() {
        function TablaMultiplicarElement() {
            // Esta función nos servirá para capturar los
            // parámetros en una ruta. Para separar props
            // de params voy a llamar a nuestro
            // parámetroen ruta minumero
            var { minumero } = useParams();
            // Devolvemos el component tabla multiplicar
            // con su props de la variable numero
            return <TablaMultiplicar numero={minumero}/>
        }

        return (
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/tabla/:minumero" element={<TablaMultiplicarElement />} />
                    {/* Para las rutas que no existen debemos utilizar
                    un asterisco dentro del path y debe ser la última
                    etiqueta de <Routes> */}
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </BrowserRouter>
        )
    }
}
