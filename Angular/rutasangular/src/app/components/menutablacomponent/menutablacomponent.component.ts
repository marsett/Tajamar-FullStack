import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menutablacomponent',
  templateUrl: './menutablacomponent.component.html',
  styleUrl: './menutablacomponent.component.css'
})
export class MenutablacomponentComponent implements OnInit {
  public aleatorios: Array<number>;

  constructor() {
    this.aleatorios = new Array<number>();
  }

  ngOnInit(): void {
    this.aleatorios = [];
    for (let i = 0; i < 5; i++) {
      let num = Math.floor((Math.random() * 100) + 1);
      this.aleatorios.push(num);
    }
  }

}
