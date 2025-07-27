import { Component, OnInit } from '@angular/core';
import { ServicePersonas } from '../../services/service.persona';
import { Persona } from '../../models/persona';

@Component({
  selector: 'app-personasapi',
  templateUrl: './personasapi.component.html',
  styleUrl: './personasapi.component.css'
})
export class PersonasapiComponent implements OnInit{
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
