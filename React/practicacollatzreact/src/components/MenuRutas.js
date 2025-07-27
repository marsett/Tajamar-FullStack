import React, { Component } from 'react'

export default class MenuRutas extends Component {
    render() {
        return (
            <div>
                <ul id="menurutas">
                    <li>
                        <a href="/">Home</a>
                    </li>
                    <li>
                        <a href="/collatz/7">Conjetura de Collatz</a>
                    </li>
                    <li>
                        <a href="/sinruta">Sin ruta</a>
                    </li>
                </ul>
            </div>
        )
    }
}
