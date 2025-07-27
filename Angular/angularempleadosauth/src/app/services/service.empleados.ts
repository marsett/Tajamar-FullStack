import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment.development";
import { Login } from "../models/login";

@Injectable()
export class ServiceEmpleados {
    //private token!: string;

    constructor(private _http: HttpClient) {
        //this.token = localStorage.getItem('token') || '';
        environment.token = localStorage.getItem('token') || '';
    }

    setToken(token: string) {
        //this.token = token;
        environment.token = token;
        localStorage.setItem('token', token);
    }

    getToken(): string {
        //return this.token;
        return environment.token;
    }

    postAuth(objeto: Login): Observable<any> {
        let json = JSON.stringify(objeto);
        let header = new HttpHeaders();
        header = header.set("Content-type", "application/json");
        let request = "Auth/Login";
        let url = environment.apiUrl + request;
        return this._http.post(url, json, { headers: header });
    }

    getPerfilEmpleado(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/empleados/perfilempleado";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    getSubordinados(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/empleados/subordinados";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }
}