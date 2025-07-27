import React, { Component } from 'react'

export default class SeleccionMultiple extends Component {
    selectMultiple = React.createRef();
    state = {
        seleccionados: ""
    }
    mostrarMultiples = (e) => {
        e.preventDefault();
        // Dentro de un select múltiple tenemos un array
        // con todas las options
        let options = this.selectMultiple.current.options;
        let datos = "";
        // Cada objeto option dentro del array contiene un
        // atributo para saber si está seleccionado: selected
        // value, text
        for (var option of options) {
            if (option.selected == true) {
                datos += option.value;
            }
        }
        // Modificamos el state del render()
        this.setState({
            seleccionados: datos
        })
    }
    render() {
        return (
            <div>
                <h1>Selección Múltiple Forms</h1>
                <h2 style={{ color: "blue" }}>{this.state.seleccionados}</h2>
                <form onSubmit={this.mostrarMultiples}>
                    <select size="10" multiple ref={this.selectMultiple}>
                        <option>Elemento 1</option>
                        <option>Elemento 2</option>
                        <option>Elemento 3</option>
                        <option>Elemento 4</option>
                    </select>
                    <button>
                        Mostrar seleccionados
                    </button>
                </form>
            </div>
        )
    }
}