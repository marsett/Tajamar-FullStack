import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Cubo } from '../../models/cubo';
import { ServiceCubo } from '../../services/service.cubo';
import { Comentario } from '../../models/comentario';

@Component({
  selector: 'app-detallescubo',
  templateUrl: './detallescubo.component.html',
  styleUrl: './detallescubo.component.css'
})
export class DetallescuboComponent implements OnInit{
  public id!: number;
  public cubo: Cubo = { 
    idCubo: 0,
    nombre: '',
    modelo: '',
    marca: '',
    color: '',
    imagen: '',
    precio: 0,
    valoracion: 0,
  }
  public comentarios: Array<Comentario> = [];
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _service: ServiceCubo
  ){}
  ngOnInit(): void {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.id = parseInt(params["id"]);
      this._service.getCuboPorId(this.id).subscribe((result) => {
        this.cubo = result;
      });
      this._service.getComentariosCubo(this.id).subscribe((result) => {
        this.comentarios = result;
      });
    });
  }

}
