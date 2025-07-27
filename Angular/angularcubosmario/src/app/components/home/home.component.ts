import { Component, OnInit } from '@angular/core';
import { ServiceCubo } from '../../services/service.cubo';
import { Cubo } from '../../models/cubo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  public cubos!: Array<Cubo>;
  constructor(
    private _service: ServiceCubo,
  ){}
  cargarCubos() {
    this._service.getCubos().subscribe(response => {
      this.cubos = response;
    })
  }
  ngOnInit(): void {
    this.cargarCubos();
  }
}
