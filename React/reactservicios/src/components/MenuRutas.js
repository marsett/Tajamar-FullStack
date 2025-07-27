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
                        <a href="/tabla/7">Tabla multiplicar</a>
                    </li>
                    <li>
                        <a href="/tabla/9">Tabla multiplicar</a>
                    </li>
                    <li>
                        <a href="/noexisto">Sin ruta</a>
                    </li>
                </ul>
            </div>
        )
    }
}
