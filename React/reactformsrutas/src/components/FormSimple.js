import React, { Component } from 'react'

export default class FormSimple extends Component {
    // Necesitamos declarar variables de referencia
    // para cada control dentro de React
    cajaNombre = React.createRef();
    cajaEdad = React.createRef();

    state = {
        user: null
    }

    // Para procesar la petición necesitamos un
    // método que reciba Event(e)
    peticionForm = (e) => {
        // La primera línea siempre será detener
        // la propagación del evento (submit)
        e.preventDefault();
        console.log("Petición lista");
        var nombre = this.cajaNombre.current.value;
        var edad = parseInt(this.cajaEdad.current.value);
        this.setState({
            user: {
                nombre: nombre,
                edad: edad
            }
        })
    }

    render() {
        return (
            <div>
                <h1>Formulario simple React</h1>
                {
                    this.state.user &&
                    (
                        <h2 style={{ color: "blue" }}>
                            Nombre: {this.state.user.nombre} <br/>
                            Edad: {this.state.user.edad}
                        </h2>
                    )
                }
                <form onSubmit={this.peticionForm}>
                    <label>Nombre: </label>
                    <input type="text" ref={this.cajaNombre}></input><br />
                    <label>Edad: </label>
                    <input type="text" ref={this.cajaEdad}></input><br />
                    <button>Enviar datos</button>
                </form>
            </div>
        )
    }
}
