import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment.development";
import { Login } from "../models/login";

@Injectable()
export class ServiceCubo {
    public isLoggedIn: boolean = this.checkIfLoggedIn();
    constructor(private _http: HttpClient) {
        environment.token = localStorage.getItem('token') || '';
    }
    setToken(token: string) {
        environment.token = token;
        localStorage.setItem('token', token);
        this.isLoggedIn = true;
    }

    getToken(): string {
        return environment.token;
    }

    logout() {
        localStorage.removeItem('token');
        environment.token = '';
        this.isLoggedIn = false;
        alert("Sesión cerrada con éxito");
    }

    checkIfLoggedIn(): boolean {
        return !!localStorage.getItem('token');
    }

    getCubos(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Cubos";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    getMarcasCubos(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Cubos/Marcas";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    getCubosMarcas(marca: string): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Cubos/CubosMarca/" + marca;
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    getCuboPorId(id: number): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Cubos/" + id;
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    getComentariosCubo(id: number): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/ComentariosCubo/GetComentariosCubo/" + id;
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    postAuth(objeto: Login): Observable<any> {
        let json = JSON.stringify(objeto);
        let header = new HttpHeaders();
        header = header.set("Content-type", "application/json");
        let request = "api/Manage/Login";
        let url = environment.apiUrl + request;
        return this._http.post(url, json, { headers: header });
    }

    getPerfilUsuario(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Manage/PerfilUsuario";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    getCompras(): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Compra/ComprasUsuario";
        let url = environment.apiUrl + request;
        return this._http.get(url, { headers: header });
    }

    insertPedido(id: number): Observable<any> {
        let header = new HttpHeaders();
        const token = this.getToken();
        header = header.set("Authorization", "Bearer " + token);
        let request = "api/Compra/InsertarPedido/" + id;
        let url = environment.apiUrl + request;
        return this._http.post(url, null, { headers: header });
    }


}