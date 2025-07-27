import { Component, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-tablamultiplicar',
  templateUrl: './tablamultiplicar.component.html',
  styleUrl: './tablamultiplicar.component.css'
})
export class TablamultiplicarComponent {
  @ViewChild("cajanumero") cajaNumeroRef!: ElementRef;
  // public tabla: { 
  //   operacion: string; 
  //   resultado: number 
  // }[] = [];
  public tabla: Array<number>;
  public numero: number;
  constructor() {
    this.tabla = new Array<number>();
    this.numero = 0;
  }

  mostrarTabla(): void {
    this.tabla = [];
    this.numero = this.cajaNumeroRef.nativeElement.value;
    for (let i = 0; i <= 10; i++) {
      //let operacion = num + "*" + i
      let resultado = this.numero * i;
      //this.tabla.push({ operacion, resultado });
      this.tabla.push(resultado);
    }
  }
}
