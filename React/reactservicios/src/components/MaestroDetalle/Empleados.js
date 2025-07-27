import React, { Component } from 'react';
import axios from 'axios';
import Global from '../../Global';

// function GetParametroComponentCine() {
//     // Capturamos la variable o variables de ruta mediante
//     // desestructurar
//     let { idcine, otroparametro } = useParams();
//     // Una vez que tenemos los valores de la ruta,
//     // ya podemos dibujar la etiqueta del component cine
//     // con sus props
//     return <Cine idcine={idcine} otroprops={otroparametro}/>
// }

export default class Empleados extends Component {

    state = {
        empleados: []
    }

    loadEmpleados = () => {
        let idDepartamento = this.props.iddepartamento;
        var request = "api/Empleados/EmpleadosDepartamento/" + idDepartamento;
        var url = Global.urlApiEmpleados + request;
        axios.get(url).then(response => {
            this.setState({
                empleados: response.data
            })
        })
    }

    componentDidMount = () => {
        this.loadEmpleados();
    }

    // Recibimos las antiguas props (10)
    componentDidUpdate = (oldProps) => {
        // console.log("Dibujando component " + this.props.iddepartamento);
        // Si comparamos, podemos actualizar el dibujo solamente cuando
        // ha cambiado props (20)
        console.log("Old props: " + oldProps.iddepartamento);
        console.log("Current props: " + this.props.iddepartamento);
        // Solamente actualizaremos cuando props haya cambiado de valor
        if (oldProps.iddepartamento != this.props.iddepartamento) {
            this.loadEmpleados();
        }
    }

    render() {
        return (
            <div>
                <h1>Empleados Component</h1>
                <table border="1">
                    <thead>
                        <tr>
                            <th>Apellido</th>
                            <th>Oficio</th>
                            <th>Departamento</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.empleados.map((empleado, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{empleado.apellido}</td>
                                        <td>{empleado.oficio}</td>
                                        <td>{empleado.departamento}</td>
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
