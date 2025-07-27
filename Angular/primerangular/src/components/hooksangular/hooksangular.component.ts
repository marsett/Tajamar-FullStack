import { Component, OnInit, DoCheck } from "@angular/core";

@Component ({
    selector: "hooks-angular",
    templateUrl: "./hooksangular.component.html"
})

export class HooksAngular implements OnInit {
    public mensaje: string;

    constructor() {
        console.log("Soy el constructor de Hooks Angular");
        this.mensaje = "Soy Hooks en Angular";
    }

    cambiarMensaje(): void {
        this.mensaje = "Cambiando en un CLICK!!!";
    }

    ngOnInit(): void {
        console.log("Soy el método NgOnInit");
    }

    ngDoCheck(): void {
        console.log("Ejecutando método ngDoCheck");
    }
}