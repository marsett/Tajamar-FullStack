import { Component } from "react";

class HijoNumero extends Component {
    sumarNumero = () => {
        var numero = parseInt(this.props.numero);
        this.props.mostrarSuma(numero);
    }
    render() {
        return (
            <div>
                <h2>El número es {this.props.numero}</h2>
                <button onClick={this.sumarNumero}>Sumar {this.props.numero}</button>
            </div>
        )
    }
}

export default HijoNumero;