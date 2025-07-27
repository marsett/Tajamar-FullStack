import React, { Component } from 'react';
import axios from 'axios';
import Global from './Global';

export default class DetallesDoctor extends Component {

    state = {
        detalles: null
    }

    loadDetalles = () => {
        var id = this.props.iddoctor;
        var request = "api/Doctores/" + id;
        const url = Global.apiDoctores + request;

        axios.get(url).then(response => {
            console.log("Leyendo detalles")
            console.log(response.data)
            this.setState({
                detalles: response.data
            });

        });
    }

    componentDidMount = () => {
        this.loadDetalles();
    }

    componentDidUpdate = (oldProps) => {
        if (this.props.iddoctor !== oldProps.iddoctor) {
            this.loadDetalles();
        }
    }

    render() {
        return (
            <div>
                {this.state.detalles != null && (
                    <table className='table table-bordered'>
                        <thead>
                            <tr>
                                <th>Id Doctor</th>
                                <th>Apellido</th>
                                <th>Especialidad</th>
                                <th>Salario</th>
                                <th>Id Hospital</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>{this.state.detalles.idDoctor}</td>
                                <td>{this.state.detalles.apellido}</td>
                                <td>{this.state.detalles.especialidad}</td>
                                <td>{this.state.detalles.salario}</td>
                                <td>{this.state.detalles.idHospital}</td>
                            </tr>
                        </tbody>
                    </table>
                )}
                {this.state.detalles == null && <div>Cargando detalles...</div>}
            </div>
        )
    }
}
