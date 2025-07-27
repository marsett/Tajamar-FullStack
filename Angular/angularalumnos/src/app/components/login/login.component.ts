import { Component, ViewChild, ElementRef } from '@angular/core';
import { ServiceAlumnos } from '../../services/service.alumnos';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { Login } from '../../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  @ViewChild("cajausuario") cajaUsuario!: ElementRef;
  @ViewChild("cajapassword") cajaPassword!: ElementRef;

  constructor(
    private _service: ServiceAlumnos,
    private _router: Router
  ) { }

  iniciarSesion() {
    let userName = this.cajaUsuario.nativeElement.value;
    let password = this.cajaPassword.nativeElement.value;

    let login = new Login(userName, password);
    this._service.postAuth(login).subscribe(response => {
      for (let key in response) {
        console.log("Valor: " + response[key]);
        if (response[key]) {
          this._service.setToken(response[key]);
          console.log("Token guardado");
          this._router.navigate(['/alumnos']);
        }
      }
    })
  }
}
