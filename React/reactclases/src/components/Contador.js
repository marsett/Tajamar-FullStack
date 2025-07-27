// Debemos importar Component para la herencia
import { Component } from "react";

// Podemos declarar métodos fuera de la clase.
// Dichos métodos no pueden utilizar nada del Component
// y se declaran con function
function metodoExterno() {
    console.log("Function externa de la clase");
}

class Contador extends Component {
    // Las variables y los métodos se declaran fuera del render
    // y no se utilizan palabras clave como var, let o const
    numero = 1;

    // Los métodos de declaran directamente aquí
    incrementarNumero = () => {
        // Para poder acceder a las variables de la clase
        // debemos utilizar la palabra clave this
        this.numero = this.numero + 1;
        console.log("Valor de número: " + this.numero);
    }

    // Vamos a declarar una variable de estado que tendrá
    // el valor de props
    state = {
        valor: parseInt(this.props.inicio)
    }

    // Creamos un método para cambiar el valor del state
    incrementarValorState = () => {
        // Para modificar los elementos que tengamos dentro
        // de state se utiliza setState con un JSON del objeto con
        // las variables que deseemos modificar. Las variables
        // que no modifiquemos no cambiarán
        this.setState({
            valor: this.state.valor + 1
        });
    }

    render() {
        return (
            <div>
                <h1>Class Component Contador</h1>
                <h2 style={{ color: "blue" }}>Inicio del contador: {this.props.inicio}</h2>
                <h2 style={{ color: "red" }}>Valor del state: {this.state.valor}</h2>
                {/* La llamada a los métodos es más sencilla, no necesitamos lambda
                ni tampoco se utilizan paréntesis */}
                <button onClick={this.incrementarValorState}>Incrementar state</button>
                {/* Vamos a utilizar una función anónima para
                llamar a un método */}
                <button onClick={() => {
                    // Si deseamos llamar a un método de la clase,
                    // se utiliza la palabra this
                    this.incrementarNumero();
                    // Si deseamos llamar a un método externo del
                    // component no utilizamos this
                    metodoExterno();
                }}>
                    Incrementar número
                </button>
            </div>
        )
    }
}

export default Contador;