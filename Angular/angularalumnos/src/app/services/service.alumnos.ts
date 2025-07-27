import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment.development";
import { Login } from "../models/login";

@Injectable()
export class ServiceAlumnos {
    constructor(private _http: HttpClient) {
        environment.token = localStorage.getItem('token') || '';
    }
    setToken(token: string) {
        environment.token = token;
        localStorage.setItem('token', token);
    }

    getToken(): string {
        return environment.token;
    }

    cerrarSesion() {
        environment.token = "";
        localStorage.removeItem("token");
        console.log("Sesión cerrada, token eliminado");
    }

    postAuth(objeto: Login): Observable<any> {
        let json = JSON.stringify(objeto);
        let header = new HttpHeaders();
        header = header.set("Content-type", "application/json");
        let request = "api/Auth/Login";
        let url = environment.apiUrl + request;
        return this._http.post(url, json, { headers: header });
    }

    getAlumnos(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Alumnos/AlumnosToken";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }
}