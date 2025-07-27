function Metodos() {
    // Nos declaramos un método para mostrar un mensaje por consola
    const mostrarMensaje = () => {
        console.log("Botón pulsado!!");
    }

    return (
        <div>
            <h1>Ejemplo métodos React</h1>
            {mostrarMensaje()}
            <button onClick= { () => mostrarMensaje()}>
                Pulsa el botón
            </button>
        </div>
    )
}

export default Metodos;