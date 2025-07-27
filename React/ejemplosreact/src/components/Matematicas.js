function Matematicas (props) {
    var numero = props.numero;
    var triplePadre = props.tripleNumero;
    const dobleNumero = () => {
        var doble = parseInt(numero) * 2;
        console.log("El doble es " + doble);
    }
    return (
        <div>
            <button onClick={dobleNumero}>Doble de {numero}</button>
            <button onClick = {() => triplePadre(numero)}>Triple de {numero}</button>
        </div>
    )
}

export default Matematicas;