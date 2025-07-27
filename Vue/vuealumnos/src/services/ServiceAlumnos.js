import Global from "@/Global";
import axios from "axios";

export default class ServiceAlumnos {
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
        return new Promise(function (resolve) {
            let request = "api/Auth/Login";
            let url = Global.apiUrl + request;
            axios.post(url, login).then(response => {
                resolve(response);
            })
        })
    }

    getAlumnosToken() {
        return new Promise((resolve) => {
            let request = "api/Alumnos/AlumnosToken";
            let url = Global.apiUrl + request;
            let alumnos = [];
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                alumnos = response.data;
                resolve(alumnos);
            })
        })
    }

    getCursosToken() {
        return new Promise((resolve) => {
            let request = "api/Alumnos/CursosToken";
            let url = Global.apiUrl + request;
            let cursos = [];
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                cursos = response.data;
                resolve(cursos);
            })
        })
    }

    getAlumnosPorCurso(id) {
        return new Promise((resolve) => {
            let request = "api/Alumnos/FiltrarCursoToken/" + id;
            let url = Global.apiUrl + request;
            let alumnos = [];
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                alumnos = response.data;
                resolve(alumnos);
            })
        })
    }

    getFiltrarAlumno(id) {
        return new Promise((resolve) => {
            let request = "api/Alumnos/FindAlumnoToken/" + id;
            let url = Global.apiUrl + request;
            let alumno = {};
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                alumno = response.data;
                resolve(alumno);
            })
        })
    }

    insertAlumno(alumno) {
        return new Promise((resolve) => {
            let request = "api/Alumnos/InsertAlumnoToken";
            let url = Global.apiUrl + request;
            axios.post(url, alumno, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                console.log("Alumno insertado");
                resolve(response);
            })
        })
    }

    updateAlumno(alumno) {
        return new Promise((resolve) => {
            let request = "api/Alumnos/UpdateAlumnoToken";
            let url = Global.apiUrl + request;
            axios.put(url, alumno, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                console.log("Alumno actualizado");
                resolve(response);
            })
        })
    }

    deleteAlumno(id) {
        return new Promise((resolve) => {
            let request = "api/Alumnos/DeleteAlumnoToken/" + id;
            let url = Global.apiUrl + request;
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                console.log("Deleted alumno");
                resolve(response);
            })
        })
    }

    updateState(id, state) {
        var resultado = false;
        if(state == 0) {
            resultado = true;
        }
        return new Promise((resolve) => {
            let request = "api/Alumnos/UpdateStateToken/" + id + "/" + resultado;
            let url = Global.apiUrl + request;
            console.log("URL final:", url);
            axios.get(url, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + this.getToken()
                }
            }).then(response => {
                console.log("Estado alumno actualizado");
                resolve(response);
            })
        })
    }
}