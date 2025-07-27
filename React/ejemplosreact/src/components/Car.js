import { useState } from "react";
function Car(props) {
    // Vamos a crear una variable que nos permitirá
    // visualizar el estado del coche
    const [estado, setEstado] = useState(false);
    // Vamos a tener una variable para visualizar
    // la velocidad del coche
    const [velocidad, setVelocidad] = useState(0);
    // Creamos un objeto cuyas propiedades vendrán
    // definidas en la etiqueta del parent
    var coche = {
        marca: props.marca,
        modelo: props.modelo,
        velocidadMaxima: parseInt(props.velocidadmaxima),
        aceleracion: parseInt(props.aceleracion)
    }
    // Incluimos un método para comprobar el estado del
    // coche dependiendo de dicho estado, lo que haremos
    // será devolver código html
    const comprobarEstado = () => {
        if (estado == true) {
            return (
                <h1 style={{ color: "green" }}>Arrancando</h1>
            )
        } else {
            return (
                <h1 style={{ color: "red" }}>Detenido</h1>
            )
        }
    }
    // Creamos un método para cambiar la aceleración del coche
    const acelerarCoche = () => {
        if (estado == false) {
            alert("El coche está detenido");
            setVelocidad(0);
        } else {
            if (velocidad >= coche.velocidadMaxima) {
                // Ponemos la velocidad máxima
                setVelocidad(coche.velocidadMaxima);
            } else {
                // Cambiamos la velocidad junto a su aceleración
                setVelocidad(velocidad + coche.aceleracion);
            }
        }
    }
    return (
        <div>
            <h1 style={{ color: "blue" }}>Component Car: {coche.marca}, {coche.modelo}</h1>
            <h2 style={{ color: "fuchsia" }}>Velocidad actual: {velocidad} km/h</h2>
            <div>{comprobarEstado()}</div>
            <button onClick={() => {
                // Modificar el estado
                setEstado(!estado);
            }}>
                Arrancar/Detener
            </button>
            <button onClick={() => acelerarCoche()}>Acelerar coche</button>
        </div>
    )
}

export default Car;