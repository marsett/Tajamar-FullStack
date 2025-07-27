import React, { Component } from 'react';
import axios from 'axios';
import Global from './Global';
import { NavLink } from 'react-router-dom';

export default class MenuDepartamentos extends Component {
    render() {
        return (
            <div>
                <nav className="navbar navbar-expand-sm navbar-dark bg-dark" aria-label="Third navbar example">
                    <div className="container-fluid">
                        <a className="navbar-brand" href="#">Departamentos</a>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample03" aria-controls="navbarsExample03" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>

                        <div className="collapse navbar-collapse" id="navbarsExample03">
                            <ul className="navbar-nav me-auto mb-2 mb-sm-0">
                                <li className="nav-item">
                                    <NavLink to="/" className="nav-link active" aria-current="page">
                                        Home
                                    </NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/create">New Departamento</NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/departamentos">Departamentos</NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/detalles">Detalles</NavLink>
                                </li>
                                <li className="nav-item dropdown">
                                    <a className="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown" aria-expanded="false">Departamentos</a>
                                    <ul className="dropdown-menu">
                                        {
                                            
                                        }
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        )
    }
}
