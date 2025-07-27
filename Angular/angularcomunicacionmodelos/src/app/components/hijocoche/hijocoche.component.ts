import { Component, Input } from '@angular/core';
import { Coche } from '../../models/coche';

@Component({
  selector: 'app-hijocoche',
  templateUrl: './hijocoche.component.html',
  styleUrl: './hijocoche.component.css'
})
export class HijococheComponent {
  @Input() car!: Coche;
  public mensaje: string;

  constructor() {
    this.mensaje = "";
  }

  comprobarEstado(): boolean {
    if (this.car.estado == false) {
      this.mensaje = "El coche está apagado";
      this.car.velocidad = 0;
      return false;
    } else {
      this.mensaje = "El coche está encendido";
      return true;
    }
  }

  encenderCoche(): void {
    this.car.estado = !this.car.estado;
    this.comprobarEstado();
  }

  acelerarCoche(): void {
    if (this.comprobarEstado() == false) {
      alert("¿Dónde vas? ¡El coche está apagado!");
    } else {
      this.car.velocidad = this.car.velocidad + this.car.aceleracion;
    }
  }
}
