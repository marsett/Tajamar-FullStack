import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class ServicePlantillas {
    constructor(private _http: HttpClient) {

    }
    getFunciones(): Observable<any> {
        let request = "api/Plantilla/Funciones";
        let url = environment.urlApiPlantillas + request;
        return this._http.get(url);
    }

    getPlantillaFuncion(funcion: string): Observable<any> {
        let request = "api/Plantilla/PlantillaFuncion/" + funcion;
        let url = environment.urlApiPlantillas + request;
        return this._http.get(url);
    }

    getPlantillaFunciones(funciones: Array<string>): Observable<any> {
        let data = "";
        for(var funcion of funciones) {
            data += "funcion=" + funcion + "&";
        }
        // Eliminamos & de la última posición
        data = data.substring(0, data.length - 1);
        let request = "api/plantilla/plantillafunciones?" + data;
        let url = environment.urlApiPlantillas + request;
        return this._http.get(url);
    }
}