import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Plantilla } from '../../models/plantilla';
import { ServicePlantillas } from '../../services/service.plantillas';

@Component({
  selector: 'app-plantillafuncionsimple',
  templateUrl: './plantillafuncionsimple.component.html',
  styleUrl: './plantillafuncionsimple.component.css'
})
export class PlantillafuncionsimpleComponent implements OnInit{
  @ViewChild("selectfuncion") selectFuncion!: ElementRef;
  public plantillas: Array<Plantilla>;
  public funciones!: Array<string>;

  constructor(private _service: ServicePlantillas) {
    this.plantillas = new Array<Plantilla>();
  }

  mostrarPlantilla() {
    let funcion = this.selectFuncion.nativeElement.value;
    this._service.getPlantillaFuncion(funcion).subscribe(response => {
      this.plantillas = response;
    });
  }

  ngOnInit(): void {
    this._service.getFunciones().subscribe(response => {
      this.funciones = response;
    });
    
  }

}
