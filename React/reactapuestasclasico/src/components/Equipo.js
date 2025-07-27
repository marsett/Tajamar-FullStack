import React, { Component } from 'react';
import Global from '../Global';
import axios from 'axios';

export default class Inicio extends Component {
    state = {
        equipo: null
    }

    componentDidMount = () => {
        this.cargarEquipo(this.props.id);
    }

    componentDidUpdate(prevProps) {
        if (this.props.id !== prevProps.id) {
            this.cargarEquipo(this.props.id);
        }
    }

    cargarEquipo = (id) => {
        var url = Global.apiUrlEquiposApuestas + "api/Equipos/" + id;
        axios.get(url).then(response => {
            this.setState({
                equipo: response.data
            })
        })
    }

    render() {
        return (
            this.state.equipo &&
            (
                <div className="mt-4">
                    <h2>Detalles del equipo</h2>
                    <table className="table table-striped">
                        <tbody>
                            <tr>
                                <th>ID</th>
                                <td>{this.state.equipo.idEquipo}</td>
                            </tr>
                            <tr>
                                <th>Nombre</th>
                                <td>{this.state.equipo.nombre}</td>
                            </tr>
                            <tr>
                                <th>Imagen</th>
                                <td>
                                    <img
                                        src={this.state.equipo.imagen}
                                        alt={this.state.equipo.nombre}
                                        style={{ width: '150px', height: '150px' }}
                                    />
                                </td>
                            </tr>
                            <tr>
                                <th>Champions</th>
                                <td>{this.state.equipo.champions}</td>
                            </tr>
                            <tr>
                                <th>Web</th>
                                <td><a href={this.state.equipo.web} target="_blank" rel="noopener noreferrer">{this.state.equipo.web}</a></td>
                            </tr>
                            <tr>
                                <th>Descripción</th>
                                <td>{this.state.equipo.descripcion}</td>
                            </tr>
                            <tr>
                                <th>Finalista</th>
                                <td>{this.state.equipo.finalista}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            )

        )
    }
}
