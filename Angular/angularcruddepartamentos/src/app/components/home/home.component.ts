import { Component, OnInit } from '@angular/core';
import { ServiceDepartamentos } from '../../services/service.departamento';
import { Departamento } from '../../models/departamento';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public departamentos!: Array<Departamento>;
  constructor(private _service: ServiceDepartamentos) {

  }

  loadDepartamentos(): void {
    this._service.getDepartamentos().subscribe(response => {
      this.departamentos = response;
    })
  }

  ngOnInit(): void {
    this.loadDepartamentos();
  }

  deleteDepartamento(id: number): void {
    this._service.deleteDepartamento(id.toString()).subscribe(response => {
      this.loadDepartamentos();
    })
  }
}
