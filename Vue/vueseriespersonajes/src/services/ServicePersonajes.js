import Global from './../Global';
import axios from 'axios';

export default class ServicePersonajes {
    cargarPersonajes(idSerie) {
        return new Promise(function (resolve) {
            let request = "api/series/personajesserie/" + idSerie;
            let url = Global.urlApiSeriesPersonajes + request;
            let personajes = [];
            axios.get(url).then(response => {
                personajes = response.data;
                console.log(personajes);
                resolve(personajes);
            })
        })
    }

    crearPersonaje(personaje) {
        return new Promise(function (resolve) {
            let request = "api/personajes";
            let url = Global.urlApiSeriesPersonajes + request;
            axios.post(url, personaje).then(response => {
                resolve(response);
            })
        })
    }

    getPersonajes() {
        return new Promise(function (resolve) {
            let request = "api/personajes";
            let url = Global.urlApiSeriesPersonajes + request;
            let personajes = [];
            axios.get(url).then(response => {
                personajes = response.data;
                resolve(personajes);
            })
        })
    }

    actualizarPersonaje(personaje, serie) {
        return new Promise((resolve) => {
            let request = "api/personajes/" + personaje.idPersonaje + "/" + serie.idSerie
            const url = Global.urlApiSeriesPersonajes + request;
            axios.put(url).then(response => resolve(response))
        });
    }

}