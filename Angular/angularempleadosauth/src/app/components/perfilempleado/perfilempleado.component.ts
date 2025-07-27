import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ServiceEmpleados } from '../../services/service.empleados';
import { Empleado } from '../../models/empleado';

@Component({
  selector: 'app-perfilempleado',
  templateUrl: './perfilempleado.component.html',
  styleUrl: './perfilempleado.component.css'
})
export class PerfilempleadoComponent implements OnInit{
  public empleado!: Empleado;
  constructor(
    private _service: ServiceEmpleados,
  ){}


  cargarPerfil() {
    this._service.getPerfilEmpleado().subscribe(response => {
      console.log("La respuesta es: " + JSON.stringify(response))
      this.empleado = response;
    })
  }

  ngOnInit(): void {
    this.cargarPerfil();
  }

}
