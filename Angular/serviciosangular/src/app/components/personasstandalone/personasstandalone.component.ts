import { Component, OnInit } from '@angular/core';
import { ServicePersonas } from '../../services/service.persona';
import { Persona } from '../../models/persona';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-personasstandalone',
  templateUrl: './personasstandalone.component.html',
  styleUrl: './personasstandalone.component.css',
  standalone: true,
  imports: [NgFor, NgIf],
  providers: [ServicePersonas]
})
export class PersonasstandaloneComponent implements OnInit {
  public personas!: Array<Persona>;
  constructor(private _service: ServicePersonas) {
    this.personas = new Array<Persona>();
  }

  ngOnInit(): void {
    // this._service.getPersonas().subscribe(response => {
    //   console.log("Leyendo...");
    //   this.personas = response;
    // })
    this._service.getPersonasPromesa().then(response => {
      this.personas = response;
    })
  }
}
