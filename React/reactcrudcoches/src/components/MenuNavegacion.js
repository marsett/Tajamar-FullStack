import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';
import './MenuNavegacion.css';

export default class MenuNavegacion extends Component {
    render() {
        return (
            <div>
                {/* <!-- Navbar --> */}
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    {/* <!-- Container wrapper --> */}
                    <div className="container-fluid">
                        {/* <!-- Navbar brand --> */}
                        <a className="navbar-brand" href="#">CRUD Coches</a>

                        {/* <!-- Toggle button --> */}
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                            data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                            aria-label="Toggle navigation">
                            <i className="fas fa-bars text-light"></i>
                        </button>

                        {/* <!-- Collapsible wrapper --> */}
                        <div className="collapse navbar-collapse" id="navbarSupportedContent">
                            {/* <!-- Left links --> */}
                            <ul className="navbar-nav me-auto d-flex flex-row mt-3 mt-lg-0">
                                <li className="nav-item text-center mx-2 mx-lg-1">
                                    <NavLink className="nav-link active" aria-current="page" to="/">
                                        <div>
                                            <i className="fas fa-tachometer-alt fa-lg mb-1"></i>
                                        </div>
                                        Inicio
                                    </NavLink>
                                </li>
                                <li className="nav-item text-center mx-2 mx-lg-1">
                                    <NavLink className="nav-link" to="/crear">
                                        <div>
                                            <i className="fas fa-plus fa-lg mb-1"></i>
                                        </div>
                                        Crear coche
                                    </NavLink>
                                </li>
                                {/* <li className="nav-item dropdown text-center mx-2 mx-lg-1">
                                    <a className="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown"
                                        aria-expanded="false">
                                        <div>
                                            <i className="fas fa-cog fa-lg mb-1"></i>
                                        </div>
                                        Configuración
                                    </a>
                                    <ul className="dropdown-menu dropdown-menu-dark" aria-labelledby="navbarDropdown">
                                        <li><a className="dropdown-item" href="#">Perfil</a></li>
                                        <li><a className="dropdown-item" href="#">Preferencias</a></li>
                                        <li>
                                            <hr className="dropdown-divider" />
                                        </li>
                                        <li>
                                            <a className="dropdown-item" href="#">Cerrar sesión</a>
                                        </li>
                                    </ul>
                                </li> */}
                            </ul>
                            {/* <!-- Left links --> */}

                            {/* <!-- Right links --> */}
                            <form className="d-flex input-group w-auto ms-lg-3 my-3 my-lg-0">
                                <input type="search" className="form-control" placeholder="Buscar" aria-label="Search" />
                                <button className="btn btn-primary" type="button" data-mdb-ripple-color="dark">
                                    Buscar
                                </button>
                            </form>
                            {/* <!-- Right links --> */}
                        </div>
                        {/* <!-- Collapsible wrapper --> */}
                    </div>
                    {/* <!-- Container wrapper --> */}
                </nav>
                {/* <!-- Navbar --> */}
            </div>
        )
    }
}
