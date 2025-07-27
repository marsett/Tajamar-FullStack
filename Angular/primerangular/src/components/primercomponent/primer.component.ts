import { Component } from "@angular/core";

// Un component tendrá una declaración de su contenido
@Component({
    // Debemos de declarar el nombre del component.
    // En Angular, se suelen llamar mediante guión
    selector: 'primer-component',
    // Como no vamos a tener html (vista) como template,
    // vamos a escribir directamente el código html aquí
    templateUrl: './primer.component.html',
    styleUrls: ["./primer.component.css"]
})

// Todo component debe ser declarado como una clase.
// Dicho nombre de clase se utilizará dentro de app.module.ts
export class PrimerComponent {
    // Aquí declararemos las variables que deseemos.
    // Dichas variables son con tipado.
    public titulo: string;
    public descripcion: string;
    public anyo: number;
    // En Angular tenemos un constructor para iniciar las variables
    // o recuperarlas de algún sitio.
    constructor() {
        // Aquí para acceder a las propiedades de una clase,
        // se utiliza la palabra this
        this.titulo = "Miércoles";
        this.descripcion = "Hoy no llueve";
        this.anyo = 2024;
    }
    title = 'primerangular';
}