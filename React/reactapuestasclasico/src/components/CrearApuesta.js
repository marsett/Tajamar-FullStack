import React, { Component } from 'react';
import Global from '../Global';
import axios from 'axios';
import { Navigate } from 'react-router-dom';

export default class extends Component {

    cajaId = React.createRef();
    cajaUsuario = React.createRef();
    cajaResultado = React.createRef();
    cajaFecha = React.createRef();

    state = {
        estado: false
    }

    crearApuesta = (e) => {
        e.preventDefault();
        let id = parseInt(this.cajaId.current.value);
        let usuario = this.cajaUsuario.current.value;
        let resultado = this.cajaResultado.current.value;
        let fecha = this.cajaFecha.current.value;

        let apuesta = {
            idApuesta: id,
            usuario: usuario,
            resultado: resultado,
            fecha: fecha
        }

        let request = "api/Apuestas";
        let url = Global.apiUrlEquiposApuestas + request;
        axios.post(url, apuesta).then(response => {
            console.log("Apuesta insertada");
            this.setState({
                estado: true
            })
        })
    }

    render() {
        if (this.state.estado == true) {
            return (
                <Navigate to="/apuestas"></Navigate>
            )
        } else {
            return (
                <div>
                    <h2>Crear Nueva Apuesta</h2>
                    <form onSubmit={this.crearApuesta}>
                        <div>
                            <label>Id</label>
                            <input type="text" ref={this.cajaId} className='form-control' />
                        </div>
                        <div>
                            <label>Usuario:</label>
                            <input type="text" ref={this.cajaUsuario} className='form-control' />
                        </div>
                        <div>
                            <label>Resultado:</label>
                            <input type="text" ref={this.cajaResultado} className='form-control' />
                        </div>
                        <div>
                            <label>Fecha:</label>
                            <input type="text" ref={this.cajaFecha} className='form-control' />
                        </div>
                        <button className='btn btn-info' type="submit">Crear Apuesta</button>
                    </form>
                </div>
            )
        }
    }
}
