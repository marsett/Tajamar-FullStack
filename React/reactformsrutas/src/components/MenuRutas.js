import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';

export default class MenuRutas extends Component {
    render() {
        return (
            <div>
                <ul>
                    <li>
                        <NavLink to="/">Home</NavLink>
                    </li>
                    <li>
                        <NavLink to="/cine">Cine</NavLink>
                    </li>
                    <li>
                        <NavLink to="/musica">Música</NavLink>
                    </li>
                    <li>
                        <NavLink to="/collatz">Collatz</NavLink>
                    </li>
                    <li>
                        <NavLink to="/tabla">Tabla de Multiplicar</NavLink>
                    </li>
                    <li>
                        <NavLink to="/select">Tabla Select</NavLink>
                    </li>
                    <li>
                        <NavLink to="/seleccionmultiple">Selección Múltiple</NavLink>
                    </li>
                </ul>
            </div>
        )
    }
}
