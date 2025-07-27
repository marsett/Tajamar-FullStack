import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-numerodoble',
  templateUrl: './numerodoble.component.html',
  styleUrl: './numerodoble.component.css'
})
export class NumerodobleComponent implements OnInit {
  // Esta variable nada que ver con el param
  public numero!: number;
  public doble!: number;

  constructor(private _activeRoute: ActivatedRoute, private _router: Router) {

  }

  goToHome(): void {
    this._router.navigate(["/"]);
  }

  redirect(num: number): void {
    // Nos vamos a llamar a nosotros mismos enviando en la ruta el
    // parámetro del número recibido
    this._router.navigate(["/numerodoble", num]);
  }

  ngOnInit(): void {
    // Aquí debemos subscribirnos a los parámetros que puedan
    // venir en una ruta
    this._activeRoute.params.subscribe((parametros: Params) => {
      // Dentro de params se recuperan los parámetros por su nombre
      // con la siguiente sintaxis: params['PARAMETER NAME']
      // En este ejemplo, el parámetro será opcional, por lo que
      // vamos a preguntar antes de asignar
      if (parametros['numero'] != null) {
        // Los parámetros son string
        this.numero = parseInt(parametros['numero']);
        this.doble = this.numero * 2;
      }
    })
  }
}
