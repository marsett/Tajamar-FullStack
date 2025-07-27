import { Component, ViewChild, ElementRef } from '@angular/core';
import { Login } from '../../models/login';
import { Router } from '@angular/router';
import { ServiceCubo } from '../../services/service.cubo';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  @ViewChild("cajaemail") cajaEmail!: ElementRef;
  @ViewChild("cajapassword") cajaPassword!: ElementRef;
  public isLoggedIn: boolean = false;

  constructor(
    private _service: ServiceCubo,
    private _router: Router
  ) { }
  iniciarSesion() {
    let email = this.cajaEmail.nativeElement.value;
    let password = this.cajaPassword.nativeElement.value;

    let login = new Login(email, password);
    this._service.postAuth(login).subscribe(response => {
      for (let key in response) {
        console.log("Valor: " + response[key]);
        if (response[key]) {
          this._service.setToken(response[key]);
          console.log("Token guardado");
          this.isLoggedIn = true;
          this._router.navigate(['/perfil']);
        }
      }
    })
  }
}
