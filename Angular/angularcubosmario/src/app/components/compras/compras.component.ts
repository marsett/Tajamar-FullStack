import { Component, OnInit } from '@angular/core';
import { ServiceCubo } from '../../services/service.cubo';
import { Compra } from '../../models/compra';

@Component({
  selector: 'app-compras',
  templateUrl: './compras.component.html',
  styleUrl: './compras.component.css'
})
export class ComprasComponent implements OnInit{
  public compras!: Array<Compra>;
  constructor(
    private _service: ServiceCubo,
  ){}
  getCompras() {
    this._service.getCompras().subscribe(response => {
      this.compras = response;
    })
  }
  ngOnInit(): void {
    this.getCompras();
  }

}
