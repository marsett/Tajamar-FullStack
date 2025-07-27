import Global from "@/Global";
import axios from "axios";

export default class ServiceCubos {
    constructor() {
        this.isLoggedIn = this.checkIfLoggedIn();
    }
    checkIfLoggedIn() {
        return !!localStorage.getItem('token');
    }
    setToken(token) {
        Global.token = token;
        localStorage.setItem('token', token);
        this.isLoggedIn = true;
        console.log("Token actualizado:", token);
    }

    getToken() {
        if (!Global.token) {
            Global.token = localStorage.getItem("token");
        }
        console.log("Token recuperado:", Global.token);
        return Global.token;
    }

    cerrarSesion() {
        Global.token = "";
        localStorage.removeItem("token");
        this.isLoggedIn = false;
        alert("Sesión cerrada");
        this.$router.push("/");
    }

    getCubos() {
        return new Promise(function (resolve) {
            let request = "api/Cubos";
            let url = Global.apiUrl + request;
            let cubos = [];
            axios.get(url).then(response => {
                cubos = response.data;
                resolve(cubos);
            })
        })
    }

    getMarcasCubos() {
        return new Promise(function (resolve) {
            let request = "api/Cubos/Marcas";
            let url = Global.apiUrl + request;
            let marcas = [];
            axios.get(url).then(response => {
                marcas = response.data;
                resolve(marcas);
            })
        })
    }

    getCubosMarcas(marca) {
        return new Promise(function (resolve) {
            let request = "api/Cubos/CubosMarca/" + marca;
            let url = Global.apiUrl + request;
            let cubos = [];
            axios.get(url).then(response => {
                cubos = response.data;
                console.log("CUbos marcas servicio: " + cubos);
                resolve(cubos);
            })
        })
    }

    getCuboPorId(id) {
        return new Promise(function (resolve) {
            let request = "api/Cubos/" + id;
            let url = Global.apiUrl + request;
            let cubo = {};
            axios.get(url).then(response => {
                cubo = response.data;
                console.log("Cubo servicio: " + cubo);
                resolve(cubo);
            })
        })
    }

    getComentariosCubo(id) {
        return new Promise(function (resolve) {
            console.log("ID Come: " + id)
            let request = "api/ComentariosCubo/GetComentariosCubo/" + id;
            let url = Global.apiUrl + request;
            let comentario = [];
            axios.get(url).then(response => {
                comentario = response.data;
                console.log("Comentario cubo servicio: " + comentario);
                resolve(comentario);
            })
        })
    }

    postAuth(login) {
        return new Promise(function (resolve) {
            let request = "api/Manage/Login";
            let url = Global.apiUrl + request;
            axios.post(url, login).then(response => {
                resolve(response);
            })
        })
    }

    getPerfilUsuario() {
        return new Promise((resolve) => {
            let request = "api/Manage/PerfilUsuario";
            let url = Global.apiUrl + request;
            let perfil = {};
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                perfil = response.data;
                resolve(perfil);
            })
        })
    }

    getCompras() {
        return new Promise((resolve) => {
            let request = "api/Compra/ComprasUsuario";
            let url = Global.apiUrl + request;
            let compras = [];
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                compras = response.data;
                resolve(compras);
            })
        })
    }

    insertPedido(id) {
        return new Promise((resolve) => {
            let request = "api/Compra/InsertarPedido/" + id;
            let url = Global.apiUrl + request;
            console.log("Url pedidos: " + url);
            axios.post(url, null, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                console.log("Pedido insertado");
                resolve(response);
            })
        })
    }
}