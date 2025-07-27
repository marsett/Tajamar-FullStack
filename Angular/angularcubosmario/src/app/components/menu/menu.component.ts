import { Component, OnInit } from '@angular/core';
import { ServiceCubo } from '../../services/service.cubo';
import { Cubo } from '../../models/cubo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit{
  public marcas!: string;
  constructor(
    public _service: ServiceCubo,
    private router: Router
  ){}
  cargarMarcas() {
    this._service.getMarcasCubos().subscribe(response => {
      this.marcas = response;
    })
  }
  logout() {
    this._service.logout();
    
    this.router.navigate(['/login']);
  }
  ngOnInit(): void {
    this.cargarMarcas();
  }
  
}
