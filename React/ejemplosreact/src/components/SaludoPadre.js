import SaludoHijo from "./SaludoHijo";
function SaludoPadre() {
    // Necesitamos un método en este código para que el
    // hijo sea capaz de ejecutarlo
    const metodoPadre = (nombre) => {
        console.log("Yo soy tu padre, " + nombre);
    }
    return (
        <div>
            <h1 style={{ color: "red" }}>Saludo Padre</h1>
            {/* Desde props enviaremos el método del parent
                para que el hijo pueda realizar la llamada */}
            <SaludoHijo idhijo="1" metodoPadre={metodoPadre}></SaludoHijo>
            <SaludoHijo idhijo="2" metodoPadre={metodoPadre}></SaludoHijo>
            <SaludoHijo idhijo="3" metodoPadre={metodoPadre}></SaludoHijo>
        </div>
    )
}

export default SaludoPadre;