import React, { Component } from 'react';
import axios from 'axios';
import Global from './Global';
import DetallesDoctor from './DetallesDoctor';

export default class Doctores extends Component {
    state = {
        doctores: [],
        doctorSeleccionado: null
    }

    loadDoctores = () => {
        var idHospital = this.props.idhospital;
        console.log("ID: " + idHospital)
        var request = "api/Doctores/DoctoresHospital/" + idHospital;
        var url = Global.apiDoctores + request;
        console.log(url);
        axios.get(url).then(response => {
            console.log("Leyendo servicio doctores");
            console.log("Response: " + response.data)
            this.setState({
                doctores: response.data
            })
        })
    }

    componentDidMount = () => {
        this.loadDoctores();
    }

    componentDidUpdate = (oldProps) => {
        // Nunca llamaremos a nada si no tenemos aquí un if
        if (this.props.idhospital != oldProps.idhospital) {
            this.loadDoctores();
        }
    }

    // mostrarDetalleDoctor = (idDoctor) => {
    //     this.setState({
    //         idDoctor: idDoctor
    //     })
    // }

    render() {
        return (
            <div>
                <h2>Doctores del hospital: {this.props.idhospital}</h2>
                <table className='table table-bordered'>
                    <thead>
                        <tr>
                            <th>Apellido</th>
                            <th>Detalles</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.doctores.map((doc, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{doc.apellido}</td>
                                        <td>
                                            <button onClick={() => this.setState({ doctorSeleccionado: doc })}>
                                                Detalles
                                            </button>
                                        </td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>
                {
                    this.state.doctorSeleccionado && (
                        <DetallesDoctor key={this.state.doctorSeleccionado.idDoctor} iddoctor={this.state.doctorSeleccionado.idDoctor} />
                    )
                }
            </div>
        )
    }
}
