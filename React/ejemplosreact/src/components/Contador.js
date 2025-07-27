// Para poder utilizar useState debemos hacer un import de react
import { useState } from "react";
function Contador() {
    // Declaramos una variable de tipo state y
    // en la creación le indicamos el tipo de dato
    const [numero, setNumero] = useState(0);
    const sumarContador = () => {
        // Para modificar el valor de una variable de tipo state,
        // se utiliza setVariable();
        setNumero(numero + 1);
    }
    return (
        <div>
            <h1 style={{ color: "blue" }}>Ejemplo Contador State</h1>
            <h2 style={{ color: "red" }}>Contador {numero}</h2>
            <button onClick={() => sumarContador()}>Sumar contador</button>
            <button onClick={() => {
                setNumero(numero - 1);
            }}>
                Restar contador
            </button>
        </div>
    )
}

export default Contador;