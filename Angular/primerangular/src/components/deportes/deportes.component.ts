import { Component, OnInit, DoCheck } from "@angular/core";

@Component({
    selector: "app-deportes",
    templateUrl: "./deportes.component.html",
    styleUrl: "./deportes.component.css"
})

export class DeportesComponent {
    public numeros: Array<number>;
    public sports: Array<string>;

    constructor() {
        this.sports = ["Canicas", "Pádel", "Petanca", "Curling", "Dardos", "Fútbol", "Tenis"]
        this.numeros = [4, 5, 6, 7, 8, 9, 10];
    }
}