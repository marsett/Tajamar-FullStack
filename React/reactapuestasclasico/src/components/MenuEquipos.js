import React, { Component } from 'react';
import { NavLink } from 'react-router-dom';
import './MenuEquipos.css';
import Global from '../Global';
import axios from 'axios';

export default class MenuEquipos extends Component {

    state = {
        equipos: [],
        equipoSeleccionado: null
    }

    cargarEquipos = () => {
        var request = "api/Equipos";
        var url = Global.apiUrlEquiposApuestas + request;
        axios.get(url).then(response => {
            response.data.map((equipo, index) => (
                this.state.equipos.push(equipo)
            ))
            this.setState({
                equipos: this.state.equipos
            })
        })
    }

    componentDidMount = () => {
        this.cargarEquipos();
    }

    seleccionarEquipo = (equipo) => {
        this.setState({
            equipoSeleccionado: equipo
        })
    }

    render() {
        return (
            <div>
                {/* <!-- Navbar --> */}
                <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                    {/* <!-- Container wrapper --> */}
                    <div className="container-fluid">
                        {/* <!-- Navbar brand --> */}
                        <a className="navbar-brand" href="#">Equipos</a>

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
                                            <i className="fas fa-home fa-lg mb-1"></i>
                                        </div>
                                        Inicio
                                    </NavLink>
                                </li>
                                <li className="nav-item dropdown text-center mx-2 mx-lg-1">
                                    <a className="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown"
                                        aria-expanded="false">
                                        <div>
                                            <i className="fas fa-users fa-lg mb-1"></i>
                                        </div>
                                        Equipos
                                    </a>
                                    <ul className="dropdown-menu dropdown-menu-dark" aria-labelledby="navbarDropdown" ref={this.listaEquipos}>
                                        {
                                            this.state.equipos.map((equipo, index) => {
                                                return (
                                                    <li key={index} value={equipo.idEquipo} className="dropdown-item" onClick={() => this.seleccionarEquipo(equipo)}>
                                                        <NavLink
                                                            to={"/equipo/" + equipo.idEquipo}
                                                            className="nav-link"
                                                            onClick={() => this.seleccionarEquipo(equipo)}
                                                        >
                                                            {equipo.nombre}
                                                        </NavLink>
                                                    </li>
                                                )
                                            })
                                        }
                                    </ul>
                                </li>
                                <li className="nav-item text-center mx-2 mx-lg-1">
                                    <NavLink className="nav-link active" aria-current="page" to="/apuestas">
                                        <div>
                                            <i className="fas fa-coins fa-lg mb-1"></i>
                                        </div>
                                        Apuestas
                                    </NavLink>
                                </li>
                            </ul>
                            {/* <!-- Left links --> */}

                            {/* <!-- Right links --> */}
                            {/* <form className="d-flex input-group w-auto ms-lg-3 my-3 my-lg-0">
                                <input type="search" className="form-control" placeholder="Buscar" aria-label="Search" />
                                <button className="btn btn-primary" type="button" data-mdb-ripple-color="dark">
                                    Buscar
                                </button>
                            </form> */}
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
