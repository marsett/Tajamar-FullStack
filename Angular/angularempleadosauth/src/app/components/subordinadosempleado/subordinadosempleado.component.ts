import { Component } from '@angular/core';
import { ServiceEmpleados } from '../../services/service.empleados';
import { Empleado } from '../../models/empleado';

@Component({
  selector: 'app-subordinadosempleado',
  templateUrl: './subordinadosempleado.component.html',
  styleUrl: './subordinadosempleado.component.css'
})
export class SubordinadosempleadoComponent {
  public empleados!: Array<Empleado>;
  constructor(
    private _service: ServiceEmpleados,
  ){}

  cargarSubordinados() {
    this._service.getSubordinados().subscribe(response => {
      console.log("La respuesta Subordinados es: " + JSON.stringify(response))
      this.empleados = response;
    })
  }

  ngOnInit(): void {
    this.cargarSubordinados();
  }
}
