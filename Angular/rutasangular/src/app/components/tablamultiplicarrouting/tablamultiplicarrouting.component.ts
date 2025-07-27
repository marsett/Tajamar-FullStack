import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-tablamultiplicarrouting',
  templateUrl: './tablamultiplicarrouting.component.html',
  styleUrl: './tablamultiplicarrouting.component.css'
})
export class TablamultiplicarroutingComponent implements OnInit{
  public numero!: number;
  public tabla: Array<number>;

  constructor(private _activeRoute: ActivatedRoute) {
    this.tabla = new Array<number>();
  }

  ngOnInit(): void {
    this._activeRoute.params.subscribe((parametros: Params) => {
      if (parametros['numero'] != null) {
        this.numero = parseInt(parametros['numero']);
        this.tabla = [];
        for (let i = 0; i < 10; i++) {
          let resultado = this.numero * i;
          this.tabla.push(resultado);
        }
      }
    })
  }

}
