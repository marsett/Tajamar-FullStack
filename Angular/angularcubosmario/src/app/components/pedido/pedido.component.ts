import { Component, OnInit } from '@angular/core';
import { Cubo } from '../../models/cubo';
import { ServiceCubo } from '../../services/service.cubo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrl: './pedido.component.css'
})
export class PedidoComponent implements OnInit {
  public cubos!: Array<Cubo>;
  public idSeleccionado: number = 1;
  constructor(
    private _service: ServiceCubo,
    private router: Router
  ) { }
  cargarCubos() {
    this._service.getCubos().subscribe(response => {
      this.cubos = response;
    })
  }
  insertPedido(): void {
    if (this.idSeleccionado) {
      this._service.insertPedido(this.idSeleccionado).subscribe((result) => {
        this.router.navigate(['/compras']);
      },
      );
    }
  }
  ngOnInit(): void {
    this.cargarCubos();
  }
}
