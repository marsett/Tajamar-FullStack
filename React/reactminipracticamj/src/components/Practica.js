import React, { Component } from 'react';
import axios from 'axios';

export default class Practica extends Component {
    urlApi = "https://apiejemplos.azurewebsites.net/";

    cajaNombreJugador = React.createRef();
    selectEquipos = React.createRef();

    state = {
        equipos: [],
        jugadores: []
    }

    cargarEquipos = () => {
        var request = "api/Equipos";
        var url = this.urlApi + request;
        axios.get(url).then(response => {
            response.data.map((equipo, index) => (
                this.state.equipos.push(equipo)
            ))
            this.setState({
                equipos: this.state.equipos
            })
        })
    }

    buscarJugadores = (e) => {
        e.preventDefault();
        let idEquipoSeleccionado = this.selectEquipos.current.value;
        var request = "api/Jugadores/JugadoresEquipos/" + idEquipoSeleccionado;
        var url = this.urlApi + request;
        axios.get(url).then(response => {
            this.setState({
                jugadores: response.data
            })
        })

    }

    buscarNombreJugador = (e) => {
        e.preventDefault();
        let nombreJugador = this.cajaNombreJugador.current.value;
        var request = "api/Jugadores/FindJugadores/" + nombreJugador;
        var url = this.urlApi + request;
        axios.get(url).then(response => {
            this.setState({
                jugadores: response.data
            })
        })
    }

    componentDidMount = () => {
        this.cargarEquipos();
    }

    render() {
        return (
            <div>
                <form onSubmit={this.buscarNombreJugador}>
                    <h1>Mini Práctica React</h1>
                    <label>Nombre jugador </label>
                    <input type="text" ref={this.cajaNombreJugador}></input>
                    <button type="submit">Buscar por NOMBRE</button>
                </form>
                <hr />
                <form onSubmit={this.buscarJugadores}>
                    <label>Seleccione un equipo</label>
                    <select ref={this.selectEquipos}>
                        {
                            this.state.equipos.map((equipo, index) => {
                                return (<option key={index} value={equipo.idEquipo}>{equipo.nombre}</option>)
                            })
                        }
                    </select>
                    <button type="submit">Buscar Jugadores</button>
                </form>
                {
                    this.state.jugadores.length > 0 &&
                    (
                        <table border="1">
                            <thead>
                                <tr>
                                    <th>Imagen</th>
                                    <th>Nombre</th>
                                    <th>Posición</th>
                                    <th>País</th>
                                    <th>Fecha nacimiento</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.jugadores.map((jugador, index) => {
                                        return (
                                            <tr key={index}>
                                                <td>
                                                    <img src={jugador.imagen} style={{ width: "150px", height: "150px" }}></img>
                                                </td>
                                                <td>{jugador.nombre}</td>
                                                <td>{jugador.posicion}</td>
                                                <td>{jugador.pais}</td>
                                                <td>{jugador.fechaNacimiento}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    )
                }
            </div>
        )
    }
}
