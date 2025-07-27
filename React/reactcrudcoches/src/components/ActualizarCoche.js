import React, { Component } from 'react';
import axios from 'axios';
import Global from '../Global';
import { Navigate, NavLink } from 'react-router-dom';

export default class ActualizarCoche extends Component {

    cajaId = React.createRef();
    cajaMarca = React.createRef();
    cajaModelo = React.createRef();
    cajaConductor = React.createRef();
    cajaImagen = React.createRef();

    state = {
        estado: false
    }

    actualizarCoche = (e) => {
        e.preventDefault();
        let id = parseInt(this.cajaId.current.value);
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

        let request = "api/Coches/UpdateCoche";
        let url = Global.urlApiCoches + request;
        axios.put(url, coche).then(response => {
            console.log("Actualizado");
            this.setState({
                estado: true
            })
        })
    }

    render() {
        if (this.state.estado === true) {
            return <Navigate to="/" />;
        } else {
            return (
                <div className="container mt-5">
                    <NavLink to="/" className="btn btn-primary mb-4">
                        <i className="bi bi-arrow-left"></i> Volver a Inicio
                    </NavLink>
                    <div className="card">
                        <div className="card-header">
                            <h3>Actualizar Coche</h3>
                        </div>
                        <div className="card-body">
                            <form onSubmit={this.actualizarCoche}>
                                <div className="form-group mb-3">
                                    <label htmlFor="idCoche" className="form-label">ID Coche</label>
                                    <input
                                        type="text"
                                        id="idCoche"
                                        ref={this.cajaId}
                                        defaultValue={this.props.id}
                                        className="form-control"
                                        disabled
                                    />
                                </div>

                                <div className="form-group mb-3">
                                    <label htmlFor="marca" className="form-label">Marca</label>
                                    <input
                                        type="text"
                                        id="marca"
                                        ref={this.cajaMarca}
                                        defaultValue={this.props.marca}
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
                                        defaultValue={this.props.modelo}
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
                                        defaultValue={this.props.conductor}
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
                                        defaultValue={this.props.imagen}
                                        className="form-control"
                                        placeholder="Introduce la URL de la imagen"
                                        required
                                    />
                                </div>

                                <button type="submit" className="btn btn-dark">
                                    Actualizar
                                </button>
                            </form>
                        </div>
                    </div>
                </div>
            );
        }
    }
}
