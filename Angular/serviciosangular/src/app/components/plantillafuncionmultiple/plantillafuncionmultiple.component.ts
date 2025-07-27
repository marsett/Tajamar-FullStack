import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Plantilla } from '../../models/plantilla';
import { ServicePlantillas } from '../../services/service.plantillas';

@Component({
  selector: 'app-plantillafuncionmultiple',
  templateUrl: './plantillafuncionmultiple.component.html',
  styleUrl: './plantillafuncionmultiple.component.css'
})
export class PlantillafuncionmultipleComponent {
  @ViewChild("selectfunciones") selectFuncion!: ElementRef;
  public empleados: Array<Plantilla>;
  public funciones!: Array<string>;
  public funcionesSeleccionadas: Array<string>;

  constructor(private _service: ServicePlantillas) {
    this.empleados = new Array<Plantilla>();
    this.funcionesSeleccionadas = new Array<string>();
  }

  mostrarPlantilla(): void {
    let aux = new Array<string>();

    for (var option of this.selectFuncion.nativeElement.options) {
      if (option.selected == true) {
        aux.push(option.value);
      }
    }

    this.funcionesSeleccionadas = aux;
    this._service.getPlantillaFunciones(this.funcionesSeleccionadas).subscribe(response => {
      this.empleados = response;
    });
  }

  ngOnInit(): void {
    this._service.getFunciones().subscribe(response => {
      this.funciones = response;
    });

  }
}
