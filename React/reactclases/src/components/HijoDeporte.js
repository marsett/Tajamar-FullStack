import { Component } from "react";

class HijoDeporte extends Component {
    // Quiero visualizar el deporte favorito
    // seleccionarFavorito = () => {
    //     this.setState({
    //         mensaje: "Su deporte favorito es: " + this.props.nombre
    //     })
    // }
    // state = {
    //     mensaje: ""
    // }
    seleccionarFavorito = () => {
        // Capturamos el deporte seleccionado en props
        var deporte = this.props.nombre;
        // Realizamos la llamada al padre enviando el deporte
        this.props.mostrarFavorito(deporte);
    }
    render (){
        return (
            <div>
                <h2 style={{color: "blue"}}>{this.props.nombre}</h2>
                {/* <h4>{this.state.mensaje}</h4> */}
                <button onClick={this.seleccionarFavorito}>Seleccionar favorito</button>
            </div>
        )
    }
}

export default HijoDeporte;