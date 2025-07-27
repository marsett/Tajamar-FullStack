import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment.development";
import { Departamento } from "../models/departamento";

@Injectable()
export class ServiceDepartamentos {
    constructor(private _http: HttpClient) {

    }

    getDepartamentos(): Observable<any> {
        let request = "api/departamentos";
        let url = environment.apiUrlDepartamentos + request;
        return this._http.get(url);
    }

    // Voy a recibir directamente el objeto en el método de insertar
    insertDepartamento(departamento: Departamento): Observable<any> {
        // Esto es como jQuery, convertir un objeto a json
        let json = JSON.stringify(departamento);
        // Debemos indicar en la petición qué tipo de formato tiene el objeto a enviar
        let header = new HttpHeaders();
        header = header.set("Content-type", "application/json");
        let request = "api/departamentos";
        let url = environment.apiUrlDepartamentos + request;
        return this._http.post(url, json, { headers: header });
    }

    findDepartamento(idDepartamento: string): Observable<any> {
        let request = "api/departamentos/" + idDepartamento;
        let url = environment.apiUrlDepartamentos + request;
        return this._http.get(url);
    }

    updateDepartamento(departamento: Departamento): Observable<any> {
        let json = JSON.stringify(departamento);
        let header = new HttpHeaders().set("Content-type", "application/json");
        let request = "api/departamentos";
        let url = environment.apiUrlDepartamentos + request;
        return this._http.put(url, json, { headers: header });
    }

    deleteDepartamento(idDepartamento: string): Observable<any> {
        let request = "api/departamentos/" + idDepartamento;
        let url = environment.apiUrlDepartamentos + request;
        return this._http.delete(url);
    }
}