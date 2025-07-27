import React, { Component } from 'react';
import axios from 'axios';
import Global from '../Global';

export default class Trabajadores extends Component {

    cajaIncremento = React.createRef();

    state = {
        trabajadores: [],
        mensaje: ""
    }

    incrementarSalario = () => {
        let incremento = this.cajaIncremento.current.value;
        let request = "/api/trabajadores/updatesalariotrabajadoreshospitales" + 
        "?incremento=" + incremento + "&" + this.state.mensaje;
        let url = Global.urlEjemplos + request;

        axios.put(url).then(response => {
            console.log("Actualizando salario");
            this.loadTrabajadores();
        })
    }

    loadTrabajadores = () => {
        // Recuperar todos los ids de hospital
        let idsHospitales = this.props.idhospitales;
        if (idsHospitales.length != 0) {
            let data = "";
            for (var id of idsHospitales) {
                data += "idhospital=" + id + "&";
            }
            // Eliminamos el último carácter del string
            data = data.substring(0, data.length - 1);
            this.setState({
                mensaje: data
            })
            // Podemos realizar la petición al servicio
            let request = "api/trabajadores/trabajadoreshospitales?" + data;
            let url = Global.urlEjemplos + request;
            axios.get(url).then(response => {
                console.log("Leyendo trabajadores...");
                this.setState({
                    trabajadores: response.data
                })
            })
        }
    }

    componentDidMount = () => {
        this.loadTrabajadores();
    }

    componentDidUpdate = (oldProps) => {
        if (oldProps.idhospitales != this.props.idhospitales) {
            this.loadTrabajadores();
        }
    }

    render() {
        return (
            <div>
                {/* <h1>{this.state.mensaje}</h1> */}
                <h1 style={{ color: "fuchsia" }}>Trabajadores</h1>
                <table className='table table-bordered'>
                    <thead>
                        <tr>
                            <th>Apellido</th>
                            <th>Oficio</th>
                            <th>Salario</th>
                            <th>Id hospital</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.trabajadores.map((trabajador, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{trabajador.apellido}</td>
                                        <td>{trabajador.oficio}</td>
                                        <td>{trabajador.salario}</td>
                                        <td>{trabajador.idHospital}</td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>
                <h5 style={{ color: "blue" }}>{this.state.mensaje}</h5>
                <label>Nuevo salario</label>
                <input type="text" ref={this.cajaIncremento}></input>
                <button onClick={this.incrementarSalario}>Incrementar</button>
            </div>
        )
    }
}
