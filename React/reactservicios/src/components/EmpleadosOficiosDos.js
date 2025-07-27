import React, { Component } from 'react';
import axios from 'axios';
import Global from '../Global';

export default class EmpleadosOficios extends Component {
    selectOficio = React.createRef();

    state = {
        empleados: [],
        oficios: [],
        empleadosFiltrados: []
    }

    buscarEmpleados = () => {
        let request = "api/empleados";
        var url = Global.urlApiEmpleados + request;
        axios.get(url).then(response => {
            console.log(response.data);
            this.setState({
                empleados: response.data
            }, () => {
                this.buscarOficios();
            });
        });
    }

    filtrarEmpleados = () => {
        const selectOficio = this.selectOficio.current.value;

        const empleadosFiltrados = this.state.empleados.filter(empleado =>
            empleado.oficio === selectOficio
        );

        this.setState({
            empleadosFiltrados
        });
    }

    buscarOficios = () => {
        const oficiosSacados = [];
        this.state.empleados.forEach((empleado) => {
            if (empleado.oficio && !oficiosSacados.includes(empleado.oficio)) {
                oficiosSacados.push(empleado.oficio);
            }
        });
        this.setState({
            oficios: oficiosSacados,
            empleadosFiltrados: []
        });
    }

    componentDidMount = () => {
        this.buscarEmpleados();
    }

    render() {
        return (
            <div>
                <h1>Empleados Oficios</h1>
                <form>
                    <label>Selecciona el oficio</label>
                    <select ref={this.selectOficio} onChange={this.filtrarEmpleados}>
                        {this.state.oficios.map((oficio, index) => (
                            <option key={index} value={oficio}>{oficio}</option>
                        ))}
                    </select>
                </form>
                <ul>
                    {this.state.empleadosFiltrados.map((empleado, index) => (
                        <li key={index}>{empleado.apellido} - {empleado.oficio}</li>
                    ))}
                </ul>
            </div>
        );
    }
}
