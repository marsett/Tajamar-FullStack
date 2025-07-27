import React, { Component } from 'react';
import axios from 'axios';
import Global from './../Global';
import { Navigate, NavLink } from 'react-router-dom';

export default class CrearCoche extends Component {

    cajaIdCoche = React.createRef();
    cajaMarca = React.createRef();
    cajaModelo = React.createRef();
    cajaConductor = React.createRef();
    cajaImagen = React.createRef();

    state = {
        estado: false
    }

    insertarCoche = (e) => {
        e.preventDefault();
        let id = parseInt(this.cajaIdCoche.current.value);
        let marca = this.cajaMarca.current.value;
        let modelo = this.cajaModelo.current.value;
        let conductor = this.cajaConductor.current.value;
        let imagen = this.cajaImagen.current.value;
        let coche = {
            idCoche: id,
            marca: marca,
            modelo: modelo,
            conductor: conductor,
            imagen: imagen
        }
        let request = "api/Coches/InsertCoche";
        let url = Global.urlApiCoches + request;
        axios.post(url, coche).then(response => {
            console.log("Coche insertado");
            this.setState({
                estado: true
            })
        })
    }

    render() {
        if (this.state.estado == true) {
            return (
                <Navigate to="/"></Navigate>
            )
        } else {
            return (
                <div className="container mt-5">
                    <NavLink to="/" className="btn btn-primary mb-4">
                        <i className="bi bi-arrow-left"></i> Volver a Inicio
                    </NavLink>
                    <div className="card">
                        <div className="card-header">
                            <h3>Crear Nuevo Coche</h3>
                        </div>
                        <div className="card-body">
                            <form onSubmit={this.insertarCoche}>
                                <div className="form-group mb-3">
                                    <label htmlFor="idCoche" className="form-label">ID Coche</label>
                                    <input
                                        type="text"
                                        id="idCoche"
                                        ref={this.cajaIdCoche}
                                        className="form-control"
                                        placeholder="Introduce el ID del coche"
                                        required
                                    />
                                </div>

                                <div className="form-group mb-3">
                                    <label htmlFor="marca" className="form-label">Marca</label>
                                    <input
                                        type="text"
                                        id="marca"
                                        ref={this.cajaMarca}
                                        className="form-control"
                                        placeholder="Introduce la marca del coche"
                                        required
                                    />
                                </div>

                                <div className="form-group mb-3">
                                    <label htmlFor="modelo" className="form-label">Modelo</label>
                                    <input
                                        type="text"
                                        id="modelo"
                                        ref={this.cajaModelo}
                                        className="form-control"
                                        placeholder="Introduce el modelo del coche"
                                        required
                                    />
                                </div>

                                <div className="form-group mb-3">
                                    <label htmlFor="conductor" className="form-label">Conductor</label>
                                    <input
                                        type="text"
                                        id="conductor"
                                        ref={this.cajaConductor}
                                        className="form-control"
                                        placeholder="Introduce el nombre del conductor"
                                        required
                                    />
                                </div>

                                <div className="form-group mb-3">
                                    <label htmlFor="imagen" className="form-label">Imagen</label>
                                    <input
                                        type="text"
                                        id="imagen"
                                        ref={this.cajaImagen}
                                        className="form-control"
                                        placeholder="Introduce la URL de la imagen"
                                        required
                                    />
                                </div>

                                <button type="submit" className="btn btn-success">
                                    Insertar Coche
                                </button>
                            </form>
                        </div>
                    </div>
                </div>
            )
        }
    }
}
