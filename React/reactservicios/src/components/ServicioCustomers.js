import React, { Component } from 'react'
// Lo primero es utilizar la libería de axios
import axios from 'axios';
import Global from '../Global';

export default class ServicioCustomers extends Component {
    // Necesitamos la URL y el request de acceso al servicio
    urlCustomers = Global.urlApiCustomers;

    // Necesitamos una variable en state para almacenar los clientes
    state = {
        customers: []
    }

    // Necesitaremos recuperar los clientes con axios. La pregunta
    // es cuándo queremos hacerlo
    loadCustomers = () => {
        console.log("Antes del servicio");
        let request = "customers.json";
        axios.get(this.urlCustomers + request).then(response => {
            console.log("Leyendo servicio");
            this.setState({
                customers: response.data.results
            })
        })
        console.log("Después del servicio");
    }

    // Vamos a cargar los datos en el método inicial de la página.
    // Lo haremos solamente una vez que será al iniciar el component

    componentDidMount = () => {
        console.log("Creando component");
        this.loadCustomers();
    }

    render() {
        return (
            <div>
                <h1>Servicio API Customers</h1>
                <button onClick={this.loadCustomers}>
                    Cargar Clientes API
                </button>
                {
                    this.state.customers.map((cliente, index) => {
                        return (
                            <h3 style={{color: "blue"}} key={index}> {cliente.contactName}</h3>
                        )
                    })
                }
            </div>
        )
    }
}
