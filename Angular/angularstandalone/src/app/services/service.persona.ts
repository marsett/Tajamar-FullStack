import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class ServicePersonas {
    // Para las peticiones API viene un objeto llamado
    // HttpClient que nos permitirá realizar las peticiones
    constructor(private _http: HttpClient) {

    }

    getPersonas(): Observable<any> {
        let urlApiPersonas = "https://servicioapipersonasmvcpgs.azurewebsites.net/api/personas";
        // Tenemos dos formas de realizar la funcionalidad de devolución de datos
        // 1) Igual que en Vue, creando una promesa por encima de este método
        // 2) Devolver directamente la petición para que sea el component quien se subscriba
        return this._http.get(urlApiPersonas);
    }

    getPersonasPromesa(): Promise<any> {
        let urlApiPersonas = "https://servicioapipersonasmvcpgs.azurewebsites.net/api/personas";
        let promise = new Promise((resolve) => {
            this._http.get(urlApiPersonas).subscribe((response) => {
                resolve(response);
            })
        });
        return promise;
    }
}