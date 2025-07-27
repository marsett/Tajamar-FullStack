import React, { Component } from 'react'

export default class Collatz extends Component {

    state = {
        secuencia: []
    }

    generarSecuencia = () => {
        let num = parseInt(this.props.numero);
        const nuevaSecuencia = []
        while (num !== 1) {
            if (num % 2 === 0) {
                num = num / 2;
            } else {
                num = (num * 3) + 1;
            }
            nuevaSecuencia.push(num);
        }
        this.setState({
            secuencia: nuevaSecuencia
        })
    }

    componentDidMount = () => {
        this.generarSecuencia();
    }

    render() {
        return (
            <div>
                <h1>Collatz Component</h1>
                <h3>Número de la conjetura: {this.props.numero}</h3>
                <ul>
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
                </ul>
            </div>
        )
    }
}
