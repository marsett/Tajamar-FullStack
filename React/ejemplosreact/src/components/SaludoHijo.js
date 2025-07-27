function SaludoHijo(props) {
    // Capturamos en una variable el método del Parent
    // que viene en props
    var ejecutarPadre = props.metodoPadre;
    var idhijo = props.idhijo;
    return (
        <div>
            <h1 style={{ color: "blue" }}>Saludo Hijo</h1>
            <button onClick={ () => ejecutarPadre('Luke' + idhijo) }>Llamar al Parent</button>
        </div>
    )
}

export default SaludoHijo;