import { Component } from "react";
import HijoDeporte from "./HijoDeporte";

class PadreDeportes extends Component {
    deportes = ["Fútbol", "Baloncesto", "Voleyball", "Tenis", "Hockey hierba"]
    // Necesitamos un método para dibujar el deporte hijo.
    // Recibiremos el deporte favorito seleccionado en
    // dicho método
    mostrarFavorito = (deporteSeleccionado) => {
        // Modificamos el deporte favorito de state
        this.setState({
            favorito: deporteSeleccionado
        })
    }
    // Creamos una variable state para mostrar el deporte seleccionado
    state = {
        favorito: ""
    }
    render() {
        return (
            <div>
                <h1 style={{ color: "red" }}>Padre deportes</h1>
                <h2 style={{ backgroundColor: "yellow" }}>Su deporte favorito es: {this.state.favorito}</h2>
                {
                    // Recorremos todos los deportes y dibujamos
                    // etiquetas hijo por cada uno
                    this.deportes.map((deporte, index) => {
                        return (
                            <HijoDeporte key={index} nombre={deporte} mostrarFavorito={this.mostrarFavorito}></HijoDeporte>
                        )
                    })
                }
            </div>
        )
    }
}

export default PadreDeportes;