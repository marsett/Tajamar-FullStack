import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LibreriaComponent } from './components/libreria/libreria.component';
import { ComicComponent } from './components/comic/comic.component';
import { ServiceComics } from './services/service.comics';
import { ServicePersonas } from './services/service.persona';
import { PersonasapiComponent } from './components/personasapi/personasapi.component';
import { provideHttpClient } from '@angular/common/http';
import { PersonasstandaloneComponent } from './components/personasstandalone/personasstandalone.component';
import { MenuComponent } from './components/menu/menu.component';
import { ServiceCoches } from './services/service.coche';
import { CochesComponent } from './components/coches/coches.component';
import { PlantillafuncionsimpleComponent } from './components/plantillafuncionsimple/plantillafuncionsimple.component';
import { ServicePlantillas } from './services/service.plantillas';
import { PlantillafuncionmultipleComponent } from './components/plantillafuncionmultiple/plantillafuncionmultiple.component';

@NgModule({
  declarations: [
    AppComponent,
    LibreriaComponent,
    ComicComponent,
    PersonasapiComponent,
    MenuComponent,
    CochesComponent,
    PlantillafuncionsimpleComponent,
    PlantillafuncionmultipleComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    PersonasstandaloneComponent
  ],
  providers: [ServiceComics, ServicePersonas, provideHttpClient(), ServiceCoches, ServicePlantillas],
  bootstrap: [AppComponent]
})
export class AppModule { }
