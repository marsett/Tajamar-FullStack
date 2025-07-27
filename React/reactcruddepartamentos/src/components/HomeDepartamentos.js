import React, { Component } from 'react';
import axios from 'axios';
import Global from './Global';
import loadingimage from './../assets/images/loading.gif'
import { NavLink } from 'react-router-dom';

export default class HomeDepartamentos extends Component {

    state = {
        status: false,
        departamentos: []
    }

    loadDepartamentos = () => {
        let request = "api/Departamentos";
        let url = Global.apiUrlDepartamentos + request;
        axios.get(url).then(response => {
            console.log("Leyendo departamentos...");
            this.setState({
                departamentos: response.data,
                status: true
            })
        })
    }

    deleteDepartamento = (idDepartamento) => {
        let request = "api/departamentos/" + idDepartamento;
        let url = Global.apiUrlDepartamentos + request;
        axios.delete(url).then(response => {
            console.log("Borrado");
            this.loadDepartamentos();
        })
    }

    componentDidMount = () => {
        this.loadDepartamentos();
    }

    render() {
        if (this.state.status == false) {
            return (
                <img src={loadingimage} />
            )
        } else {
            return (
                <div>
                    <h1>Home Departamentos</h1>
                    <table className='table table-warning'>
                        <thead>
                            <tr>
                                <th>Id departamento</th>
                                <th>Nombre</th>
                                <th>Localidad</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.departamentos.map((departamento, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{departamento.numero}</td>
                                            <td>{departamento.nombre}</td>
                                            <td>{departamento.localidad}</td>
                                            <td>
                                                {/* <button className='btn btn-danger' onClick={() => {
                                                    this.deleteDepartamento(departamento.numero);
                                                }}>
                                                    Delete
                                                </button> */}
                                                <NavLink to={"/delete/" + departamento.numero} className='btn btn-danger'>Delete</NavLink>
                                                <NavLink to={"/detalles/" + departamento.numero} className='btn btn-info'>Detalles</NavLink>
                                                <NavLink to={"/update/" + departamento.numero + "/" + departamento.nombre + "/" + departamento.localidad} className='btn btn-success'>Update</NavLink>
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
