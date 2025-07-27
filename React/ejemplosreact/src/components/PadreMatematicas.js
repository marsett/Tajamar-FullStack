import Matematicas from "./Matematicas";
function PadreMatematicas () {
    const tripleNumero = (numero) => {
        var triple = parseInt(numero) * 3;
        console.log("El triple es " + triple);
    }
    return (
        <div>
            <h1>Padre Matématicas</h1>
            <Matematicas numero="7" tripleNumero={tripleNumero}></Matematicas>
        </div>
    )
}

export default PadreMatematicas;