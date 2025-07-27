import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { Comic } from '../../models/comic';
import { ServiceComics } from '../../services/service.comics';

@Component({
  selector: 'app-libreria',
  templateUrl: './libreria.component.html',
  styleUrl: './libreria.component.css',
})
export class LibreriaComponent implements OnInit {
  public comics!: Array<Comic>;
  public mensaje!: string;

  @ViewChild("cajatitulo") cajatitulo!: ElementRef;
  @ViewChild("cajaimagen") cajaimagen!: ElementRef;
  @ViewChild("cajapie") cajapie!: ElementRef;

  public comicCreado!: Comic;

  seleccionarFavoritoPadre(event: any): void {
    this.mensaje = "Tu cómic favorito es: " + event.titulo;
    console.log("Dato: " + event.titulo);
  }

  crearComic(): void {
    let titulo = this.cajatitulo.nativeElement.value;
    let imagen = this.cajaimagen.nativeElement.value;
    let pie = this.cajapie.nativeElement.value;

    this.comicCreado = new Comic(
      titulo,
      imagen,
      pie
    )

    this.comics.push(this.comicCreado);
  }

  constructor(
    private _service: ServiceComics
  ) {}

  ngOnInit(): void {
    this.comics = this._service.getComics();
  }
}
