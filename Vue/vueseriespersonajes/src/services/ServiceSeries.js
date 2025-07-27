import Global from './../Global';
import axios from 'axios';

export default class ServiceSeries {
    getSeries() {
        return new Promise(function (resolve) {
            let request = "api/series";
            let url = Global.urlApiSeriesPersonajes + request;
            let series = [];
            axios.get(url).then(response => {
                series = response.data;
                resolve(series);
            })
        })
    }

    cargarDetallesSerie(id) {
        return new Promise(function (resolve) {
            let request = "api/series/" + id;
            let url = Global.urlApiSeriesPersonajes + request;
            let serie = {};
            axios.get(url).then(response => {
                serie = response.data;
                console.log(serie);
                resolve(serie);
            })
        })
    }
}