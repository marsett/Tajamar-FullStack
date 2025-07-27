import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Cubo } from '../../models/cubo';
import { ServiceCubo } from '../../services/service.cubo';

@Component({
  selector: 'app-cubosmarcas',
  templateUrl: './cubosmarcas.component.html',
  styleUrl: './cubosmarcas.component.css'
})
export class CubosmarcasComponent implements OnInit{
  public marca!: string;
  public cubos!: Array<Cubo>;
  constructor(
    private _activatedRoute: ActivatedRoute,
    private _service: ServiceCubo
  ){}
  ngOnInit(): void {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.marca = params["marca"];
      this._service.getCubosMarcas(this.marca).subscribe((result) => {
        this.cubos = result;
      })
    });
    
  }
  
}
