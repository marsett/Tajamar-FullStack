import React, { Component } from 'react';
import axios from 'axios';
import Global from '../Global';

export default class BuscadorCoches extends Component {
    urlApi = Global.urlApiCoches;
    cajaMarca = React.createRef();

    state = {
        coches: [],
        cochesOriginales: []
    }

    loadCoches = () => {
        console.log("Antes del servicio");
        let request = "webresources/coches";
        axios.get(this.urlApi + request).then(response => {
            console.log("Leyendo servicio");
            console.log(response.data)
            this.setState({
                coches: response.data,
                cochesOriginales: response.data
            })
        })
        console.log("Después del servicio");
    }

    buscarCoche = () => {
        let marca = this.cajaMarca.current.value;
        var nuevoArray = []
        // var cochesFiltrados = this.state.cochesOriginales.filter(coche => coche.marca == marca);
        this.state.cochesOriginales.map((coche, index) => {
            if (coche.marca == marca) {
                nuevoArray.push(coche)
            }
        })
        this.setState({
            coches: nuevoArray
        })
    }

    componentDidMount = () => {
        console.log("Creando component");
        this.loadCoches();
    }

    render() {
        return (
            <div>
                <h1>Buscador Coches</h1>
                <label>Introduzca marca: </label>
                <input type="text" ref={this.cajaMarca} />
                <button onClick={this.buscarCoche}>
                    Buscar coches
                </button>
                <table border="1" className="table table-dark">
                    <thead>
                        <tr>
                            <th>Coche</th>
                            <th>Conductor</th>
                            <th>Imagen</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.coches.map((coche, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{coche.marca} {coche.modelo}</td>
                                        <td>{coche.conductor}</td>
                                        <td>
                                            <img src={coche.imagen} style={{ width: "200px", height: "150px" }}></img>
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