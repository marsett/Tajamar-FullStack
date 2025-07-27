import React, { Component } from 'react'

export default class Collatz extends Component {
    // Necesitamos un objeto caja para recuperar el dato
    cajaNumero = React.createRef();
    state = {
        secuencia: []
    }
    
    formulario = (e) => {
        e.preventDefault();
        let numero = parseInt(this.cajaNumero.current.value);
        const nuevaSecuencia = []
        // Si se quiere añadir el número de la secuencia
        // nuevaSecuencia.push(numero);
        while (numero !== 1) {
            if (numero % 2 === 0) {
                numero = numero / 2;
            } else {
                numero = (numero * 3) + 1;
            }
            nuevaSecuencia.push(numero);
        }
        this.setState({
            secuencia: nuevaSecuencia
        })
    }
    
    render() {
        return (
            <div>
                <h1>Conjetura de Collatz</h1>
                <form onSubmit={this.formulario}>
                    <label>Número de la secuencia</label>
                    <input type="text" ref={this.cajaNumero}></input>
                    <button>Ver secuencia</button>
                </form>
                {
                    this.state.secuencia.length > 0 &&
                    (
                        <ul>
                            {
                                this.state.secuencia.map((num, index) => (
                                    <li key={index}>{num}</li>
                                ))
                            }
                        </ul>
                    )
                }
            </div>
        )
    }
}