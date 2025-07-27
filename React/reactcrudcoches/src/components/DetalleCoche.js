import React, { Component } from 'react';
import axios from 'axios';
import Global from './../Global';
import gifcargando from './../assets/images/gifcargando.gif';
import { NavLink } from 'react-router-dom';

export default class DetalleCoche extends Component {

    state = {
        coche: null
    }

    encontrarCoche = () => {
        let request = "api/Coches/FindCoche/" + this.props.id;
        let url = Global.urlApiCoches + request;
        axios.get(url).then(response => {
            console.log("Detalles coche");
            this.setState({
                coche: response.data
            })
        })
    }

    componentDidMount = () => {
        this.encontrarCoche();
    }

    render() {
        return (
            <div className="container mt-5">
                <NavLink to="/" className="btn btn-primary mb-4">
                    <i className="bi bi-arrow-left"></i> Volver a Inicio
                </NavLink>
                {
                    this.state.coche ?
                        (
                            <div className="card">
                                <div className="card-header">
                                    <h3>Detalles del Coche</h3>
                                </div>
                                <div className="card-body">
                                    <ul className='list-group list-group-flush'>
                                        <li className='list-group-item'><strong>Id Coche:</strong> {this.state.coche.idCoche}</li>
                                        <li className='list-group-item'><strong>Marca:</strong> {this.state.coche.marca}</li>
                                        <li className='list-group-item'><strong>Modelo:</strong> {this.state.coche.modelo}</li>
                                        <li className='list-group-item'><strong>Conductor:</strong> {this.state.coche.conductor}</li>
                                        <li className='list-group-item'>
                                            <strong>Imagen:</strong><br />
                                            <img src={this.state.coche.imagen} alt="Imagen coche" className="img-fluid mt-2" style={{ maxWidth: '250px', height: 'auto' }} />
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        ) :
                        (
                            <div className="d-flex justify-content-center">
                                <img src={gifcargando} alt="Cargando..." />
                            </div>
                        )
                }
            </div>
        )
    }
}
