import React, { Component } from 'react';
import Global from '../Global';
import axios from 'axios';
import { NavLink } from 'react-router-dom';

export default class VerApuestas extends Component {

    state = {
        apuestas: [],
        estado: false
    }

    verApuestas = () => {
        let request = "api/Apuestas";
        let url = Global.apiUrlEquiposApuestas + request;
        axios.get(url).then(response => {
            console.log("Leyendo apuestas...");
            this.setState({
                apuestas: response.data,
                estado: true
            })
        })
    }

    borrarApuesta = (idApuesta) => {
        let request = "api/Apuestas/" + idApuesta;
        let url = Global.apiUrlEquiposApuestas + request;
        axios.delete(url).then(response => {
            console.log("Apuesta borrada");
            this.verApuestas();
            this.setState({
                estado: true
            })
        })
    }

    componentDidMount = () => {
        this.verApuestas();
    }

    render() {
        if (this.state.status == false) {
            return (
                <p>Sin Apuestas</p>
            )
        } else {
            return (
                <div>
                    <h1>Bet 365</h1>
                    <NavLink to={"/crearapuesta"} className='btn btn-danger'>Crear Apuesta</NavLink>
                    <table className='table table-warning'>
                        <thead>
                            <tr>
                                <th>Id apuesta</th>
                                <th>Usuario</th>
                                <th>Resultado</th>
                                <th>Fecha</th>
                                <td>Acciones</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.apuestas.map((apuesta, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{apuesta.idApuesta}</td>
                                            <td>{apuesta.usuario}</td>
                                            <td>{apuesta.resultado}</td>
                                            <td>{apuesta.fecha}</td>
                                            <td>
                                                <button className='btn btn-danger' onClick={() => this.borrarApuesta(apuesta.idApuesta)}>Borrar</button>
                                            </td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                </div>
            )
        }

    }
}
