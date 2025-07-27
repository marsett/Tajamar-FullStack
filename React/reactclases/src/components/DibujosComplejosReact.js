import { Component } from "react";

class DibujosComplejosReact extends Component {
    // En state tendremos un conjunto de nombres
    state = {
        nombres: ["Mario", "Jarfaiter", "Arce", "Policvrpo", "Kaños", "Jeros"]
    }

    generarNombre = () => {
        this.state.nombres.push("Izi Draro");
        // Actualizamos state
        this.setState({
            nombres: this.state.nombres
        })
    }

    render() {
        return (
            <div>
                <h1>Dibujos complejos react Collection</h1>
                <button onClick={this.generarNombre}>Generar nombre</button>
                <button onClick={() => this.generarNombre()}>Generar nombre</button>
                {
                    // Esto es código React, es diferente al código JS.
                    // Es código lógico con sintaxis JSX y debe contener
                    // un return
                    this.state.nombres.map((name, index) => {
                        // Este código nunca debe estar vacío.
                        // Siempre tiene que devolver un return
                        return (
                            <h1 key={index}>{name}</h1>
                        )
                    })
                }
            </div>
        )
    }
}

export default DibujosComplejosReact;