import './../App.css';

function DobleNumero() {
    const numeroDoble = (numero) => {
        var doble = numero * 2;
        console.log(doble);
    }

    var ejemplo = "Soy una variable de jueves";

    const cambiarVariable = () => {
        console.log("Valor antes: " + ejemplo);
        ejemplo = "He cambiado de valor!!";
        console.log("Valor después: " + ejemplo);
    }

    var miEstilo = {
        color: "blue",
        backgroundColor: "yellow"
    }

    return (
        <div className = 'App'>
            <h1 style={miEstilo}>Ejemplo métodos parámetros</h1>
            <h2 style={{color: "red"}}>{ejemplo}</h2>
            <button onClick={() => cambiarVariable()}>Cambiar valor Ejemplo</button>
            <button onClick={() => numeroDoble(7)}>Doble 7</button>
            <button onClick={() => numeroDoble(199)}>Doble 199</button>
        </div>
    )
}

export default DobleNumero;