import { Component, OnInit } from '@angular/core';
import { ServiceCubo } from '../../services/service.cubo';
import { Perfil } from '../../models/perfil';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrl: './perfil.component.css'
})
export class PerfilComponent implements OnInit{
  public perfil: Perfil = { 
    idUsuario: 0,
    nombre: '',
    email: '',
    pass: ''
  }
  constructor(
    private _service: ServiceCubo,
  ){}
  getPerfilUsuario() {
    this._service.getPerfilUsuario().subscribe(response => {
      this.perfil = response;
    })
  }
  ngOnInit(): void {
    this.getPerfilUsuario();
  }
  
}
