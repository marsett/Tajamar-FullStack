import React, { Component } from 'react';
import axios from 'axios';
import Global from './../Global';
import gifcargando from './../assets/images/gifcargando.gif';
import { NavLink } from 'react-router-dom';
import Swal from 'sweetalert2';

export default class Inicio extends Component {
    state = {
        estado: false,
        coches: []
    }

    cargarCoches = () => {
        let request = "api/Coches";
        let url = Global.urlApiCoches + request;
        axios.get(url).then(response => {
            console.log("Leyendo coches...");
            this.setState({
                estado: true,
                coches: response.data
            })
        })
    }

    borrarCoche = (idCoche) => {
        let request = "api/Coches/DeleteCoche/" + idCoche;
        let url = Global.urlApiCoches + request;

        Swal.fire({
            title: "¿Estás seguro?",
            text: "¡No podrás revertir esto!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sí, bórralo"
        }).then((result) => {
            if (result.isConfirmed) {
                axios.delete(url).then(response => {
                    console.log("Coche borrado");
                    this.cargarCoches();

                    Swal.fire({
                        title: "¡Borrado!",
                        text: "El coche ha sido borrado correctamente.",
                        icon: "success"
                    });
                });
            }
        });
    }

    componentDidMount = () => {
        this.cargarCoches();
    }

    render() {
        if (this.state.estado == false) {
            return (
                <div className="d-flex justify-content-center">
                    <img src={gifcargando} style={{width: '150px', height: '150px'}} alt="Cargando..." />
                </div>
            )
        } else {
            return (
                <div className="container mt-5">
                    <h1 className="display-4 text-center mb-5">Inicio Coches</h1>
                    <table className='table table-striped table-hover table-bordered'>
                        <thead className='table-dark'>
                            <tr>
                                <th>Id Coche</th>
                                <th>Marca</th>
                                <th>Modelo</th>
                                <th>Conductor</th>
                                <th>Imagen</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.coches.map((coche, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{coche.idCoche}</td>
                                            <td>{coche.marca}</td>
                                            <td>{coche.modelo}</td>
                                            <td>{coche.conductor}</td>
                                            <td>
                                                <img src={coche.imagen} style={{ width: "200px", height: "150px" }} alt="Imagen coche" className="img-thumbnail" />
                                            </td>
                                            <td>
                                                {/* <NavLink to={"/borrar/" + coche.idCoche} className='btn btn-danger'>Borrar</NavLink> */}
                                                <button
                                                    onClick={() => this.borrarCoche(coche.idCoche)}
                                                    className='btn btn-danger me-2'>
                                                    <i className="bi bi-trash"></i> Borrar
                                                </button>
                                                <NavLink to={"/detalles/" + coche.idCoche} className='btn btn-info me-2'><i className="bi bi-info-circle"></i> Detalles</NavLink>
                                                {/* <NavLink to={"/actualizar/" + coche.idCoche + "/" + coche.marca + "/" + coche.modelo + "/" + coche.conductor + "/" + coche.imagen} className='btn btn-success'>Actualizar</NavLink> */}
                                                <NavLink
                                                    to={`/actualizar/${coche.idCoche}/${coche.marca}/${coche.modelo}/${coche.conductor}/${encodeURIComponent(coche.imagen)}`}
                                                    className='btn btn-success'>
                                                    <i className="bi bi-pencil"></i> Actualizar
                                                </NavLink>
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
