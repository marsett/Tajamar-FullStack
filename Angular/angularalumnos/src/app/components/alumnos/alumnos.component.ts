import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Alumno } from '../../models/alumno';
import { ServiceAlumnos } from '../../services/service.alumnos';

@Component({
  selector: 'app-alumnos',
  templateUrl: './alumnos.component.html',
  styleUrl: './alumnos.component.css'
})
export class AlumnosComponent {
  public alumnos!: Array<Alumno>;
  constructor(
    private _service: ServiceAlumnos,
    private router: Router
  ){}

  cargarAlumnos() {
    this._service.getAlumnos().subscribe(response => {
      this.alumnos = response;
    })
  }

  cerrarSesion() {
    this._service.cerrarSesion();
    this.router.navigate(['/']);
  }

  ngOnInit(): void {
    this.cargarAlumnos();
  }
}
