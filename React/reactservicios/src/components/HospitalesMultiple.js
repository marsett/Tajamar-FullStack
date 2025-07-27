import React, { Component } from 'react'
import Trabajadores from './Trabajadores';
import axios from 'axios';
import Global from '../Global';

export default class HospitalesMultiple extends Component {
    selectHospital = React.createRef();

    state = {
        hospitales: [],
        hospitalesSeleccionados: []
    }

    loadHospitales = () => {
        let request = "api/Hospitales";
        let url = Global.urlEjemplos + request;
        axios.get(url).then(response => {
            console.log("Leyendo hospitales...");
            this.setState({
                hospitales: response.data
            })
        })
    }

    componentDidMount = () => {
        this.loadHospitales();
    }

    getHospitalesSeleccionados = (e) => {
        e.preventDefault();
        let aux = [];
        let options = this.selectHospital.current.options;
        for (var opt of options) {
            if (opt.selected == true) {
                aux.push(opt.value);
            }
        }
        this.setState({
            hospitalesSeleccionados: aux
        })
    }

    render() {
        return (
            <div>
                <h1>Hospitales Múltiple</h1>
                <form>
                    <select ref={this.selectHospital} className='form-control' size='5' multiple>
                        {
                            this.state.hospitales.map((hospitales, index) => {
                                return (
                                    <option key={index} value={hospitales.idHospital}>{hospitales.nombre}</option>
                                )
                            })
                        }
                    </select>
                    <button onClick={this.getHospitalesSeleccionados} className='btn btn-info'>Mostrar trabajadores</button>
                </form>
                {
                    this.state.hospitalesSeleccionados.length != 0 &&
                    <Trabajadores idhospitales={this.state.hospitalesSeleccionados} />
                }
            </div>
        )
    }
}
