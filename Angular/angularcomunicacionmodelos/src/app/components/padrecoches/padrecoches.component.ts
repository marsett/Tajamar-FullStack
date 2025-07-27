import { Component } from '@angular/core';
import { Coche } from '../../models/coche';

@Component({
  selector: 'app-padrecoches',
  templateUrl: './padrecoches.component.html',
  styleUrl: './padrecoches.component.css'
})
export class PadrecochesComponent {
  public coches: Array<Coche>;

  constructor() {
    this.coches = [
      new Coche("Ford", "Mustang", 0, 25, false),
      new Coche("Volkswagen", "Escarabajo", 0, 10, false),
      new Coche("Lamborghini", "Diablo", 0, 35, false),
    ]
  }
}
