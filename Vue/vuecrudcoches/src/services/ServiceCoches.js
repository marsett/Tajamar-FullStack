import Global from './../Global';
import Swal from 'sweetalert2';

export default class ServiceCoches {
    getCoches() {
        return new Promise(function (resolve) {
            let coches = [];
            let request = "api/Coches";
            let url = Global.urlApiCoches + request;

            fetch(url).then(response => {
                return response.json()
            }).then(data => {
                console.log("Leyendo coches...")
                coches = data;
                resolve(coches);
            })
        })
    }

    crearCoche(coche) {
        return new Promise(function (resolve) {
            let request = "api/coches/insertcoche";
            let url = Global.urlApiCoches + request;
            fetch(url, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(coche)
            }).then(response => response.json())
                .then(data => {
                    console.log("Coche creado...");
                    resolve(data);
                })
        })
    }

    encontrarCoche(id) {
        return new Promise(function (resolve) {
            let request = "api/coches/findcoche/" + id;
            let url = Global.urlApiCoches + request;
            let coche = {};

            fetch(url).then(response => {
                return response.json()
            }).then(data => {
                console.log("Leyendo coche por id...")
                coche = data;
                resolve(coche);
            })
        })
    }

    actualizarCoche(coche) {
        return new Promise(function (resolve) {
            let request = "api/coches/updatecoche";
            let url = Global.urlApiCoches + request;

            fetch(url, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(coche)
            })
                .then(data => {
                    console.log("Coche actualizado...");
                    resolve(data);
                })
        })
    }

    borrarCoche(id) {
        return new Promise(function (resolve) {
            Swal.fire({
                title: '¿Quieres borrar el coche?',
                text: '¡Es una acción irreversible!',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí, borrar!',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    let request = "api/coches/deletecoche/" + id;
                    let url = Global.urlApiCoches + request;

                    fetch(url).then(response => {
                        if (response.ok) {
                            console.log("Coche eliminado exitosamente...");
                            resolve();
                        }
                    })
                }
                else {
                    window.location.href = '/';
                }
            })
        })
    }
}