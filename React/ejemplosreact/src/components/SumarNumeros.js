import imagen from '../assets/images/Tejon.jpg';
import './SumarNumeros.css'

function SumarNumeros (props){
    const recibirNumeros = (numero1, numero2) => {
        //var suma = numero1 + numero2;
        var suma = parseInt(props.numero1) + parseInt(props.numero2);
        console.log(parseInt(props.numero1) + " + " + parseInt(props.numero2) + " = " + suma);
    }

    return (
        <div>
            <h1>Imagen y Sumas</h1>
            <img src={imagen}></img><br/>
            <button onClick={() => recibirNumeros(7,10)}>Sumar {props.numero1} + {props.numero2}</button>
            <button onClick={() => recibirNumeros(5,6)}>Sumar {props.numero1} + {props.numero2}</button>
        </div>
    )
}

export default SumarNumeros;