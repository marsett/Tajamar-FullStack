function Saludo(props) {
    // Esto es código JS, podemos declarar múltiples variables
    var dato = "Mañana es viernes...";
    // var nombre = props.nombre;
    // var edad = props.edad;
    const { nombre, edad } = props;
    return (
        <div>
            <h1>React en Juernes</h1>
            <h2>Dato objetivo: {dato}</h2>
            <h3>Su nombre es {nombre} y su edad es {edad}</h3>
        </div>
    )
}

export default Saludo;