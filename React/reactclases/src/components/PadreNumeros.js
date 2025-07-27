import { Component } from "react";
import HijoNumero from "./HijoNumero";

class PadreNumeros extends Component {
    state = {
        numeros: [3, 7, 9],
        suma: 0
    }
    
    nuevoNumero = () => {
        var numero = parseInt(Math.random() * 100) + 1;
        this.state.numeros.push(numero);
        this.setState({
            numeros: this.state.numeros
        })
    }

    mostrarSuma = (numero) => {
        this.setState({
            suma: this.state.suma + numero
        })
    }

    render() {
        return (
            <div>
                <h1>Padre Numeros</h1>
                <h2>Suma: {this.state.suma}</h2>
                <button onClick={this.nuevoNumero}>Nuevo</button>
                {
                    this.state.numeros.map((numero, index) => {
                        return (
                            <HijoNumero key={index} numero={numero} mostrarSuma={this.mostrarSuma}></HijoNumero>
                        )
                    })
                }
            </div>
        )
    }
}

export default PadreNumeros;