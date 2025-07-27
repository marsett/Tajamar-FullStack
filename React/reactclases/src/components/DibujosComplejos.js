import { Component } from "react";

class DibujosComplejos extends Component {

    // Vamos a dibujar una serie de números en formato
    // html utilizando un array con <li>
    dibujarNumeros = () => {
        // Declaramos un array para almacenar el dibujo
        var lista = [];
        // Vamos a realizar un bucle para rellenar números dinámicos
        for (var i = 1; i <= 7; i++) {
            var numero = parseInt(Math.random() * 100) + 1;
            // Mediante el método push del array iremos rellenando
            // el código html
            lista.push(<li key={i}>{numero}</li>);
        }
        return lista;
    }

    render() {
        return (
            <div>
                <h1>Dibujos Complejos</h1>
                <ul>
                    {this.dibujarNumeros()}
                </ul>
            </div>
        )
    }
}

export default DibujosComplejos;