import Global from "@/Global";
import axios from "axios";


export default class ServiceEmpleados {

    setToken(token) {
        Global.token = token;
        localStorage.setItem('token', token);
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
        console.log("Sesión cerrada, token eliminado");
    }

    postAuth(login) {
        return new Promise((resolve) => {
            let request = "Auth/Login";
            let url = Global.apiUrl + request;
            axios.post(url, login).then(response => {
                resolve(response);
            })
        })
    }

    getPerfilEmpleado() {
        return new Promise((resolve) => {
            let request = "api/empleados/perfilempleado";
            let url = Global.apiUrl + request;
            let empleado = {};
            axios.get(url, {
                headers: {
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                empleado = response.data;
                resolve(empleado);
            });
        });
    }

    getSubordinados() {
        return new Promise((resolve) => {
            let request = "api/empleados/subordinados";
            let url = Global.apiUrl + request;
            let empleados = [];
            axios.get(url, {
                headers: {
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                empleados = response.data;
                resolve(empleados);
            })
        })
    }
}