import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ServiceDepartamentos } from '../../services/service.departamento';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Departamento } from '../../models/departamento';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit {
  @ViewChild("cajaid") cajaId!: ElementRef;
  @ViewChild("cajanombre") cajaNombre!: ElementRef;
  @ViewChild("cajalocalidad") cajaLocalidad!: ElementRef;
  public departamento!: Departamento;

  constructor(
    private _service: ServiceDepartamentos,
    private _activeRoute: ActivatedRoute,
    private _router: Router
  ) {
    this.departamento = new Departamento(0, '', ''); 
  }

  updateDepartamento(): void {
    let id = parseInt(this.cajaId.nativeElement.value);
    let nom = this.cajaNombre.nativeElement.value;
    let loc = this.cajaLocalidad.nativeElement.value;
    let editDepartamento = new Departamento(id, nom, loc);
    this._service.updateDepartamento(editDepartamento).subscribe(response => {
      this._router.navigate(["/"]);
    });
  }

  ngOnInit(): void {
    this._activeRoute.params.subscribe((params: Params) => {
      let id = params["id"];
      this._service.findDepartamento(id).subscribe(response => {
        this.departamento = response;
      });
    });
  }
}
