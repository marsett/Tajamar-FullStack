import React, { Component } from 'react'

export default class TablaMultiplicar extends Component {
    cajaNumero = React.createRef();
    state = {
        array: []
    }
    formulario = (e) => {
        e.preventDefault();
        let numero = parseInt(this.cajaNumero.current.value);
        var nuevoArray = []

        for (let i = 0; i <= 10; i++) {
            nuevoArray.push({
                operacion: numero + "*" + i,
                resultado: numero * i
            })
            // Otra solución sería hacer el push
            // con las td directamente, y en el map
            // únicamente hacer return de 'fila'
        }

        this.setState({
            array: nuevoArray
        })
    }
    render() {
        return (
            <div>
                <h1>Tabla de Multiplicar</h1>
                <form onSubmit={this.formulario}>
                    <label>Número</label>
                    <input type="text" ref={this.cajaNumero}></input>
                    <button>Ver tabla</button>
                </form>
                <table>
                    <thead>
                        <tr>
                            <th>Operación</th>
                            <th>Resultado</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.array.map((fila, index) => (
                                <tr key={index}>
                                    <td>{fila.operacion}</td>
                                    <td>{fila.resultado}</td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>
        )
    }
}