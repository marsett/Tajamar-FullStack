import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListaproductosComponent } from './components/listaproductos/listaproductos.component';
import { MenuComponent } from './components/menu/menu.component';
import { HomeComponent } from './components/home/home.component';
import { HijococheComponent } from './components/hijocoche/hijocoche.component';
import { PadrecochesComponent } from './components/padrecoches/padrecoches.component';
import { PadreDeportesComponent } from './components/padre-deportes/padre-deportes.component';
import { HijoDeporteComponent } from './components/hijo-deporte/hijo-deporte.component';

@NgModule({
  declarations: [
    AppComponent,
    ListaproductosComponent,
    MenuComponent,
    HomeComponent,
    HijococheComponent,
    PadrecochesComponent,
    PadreDeportesComponent,
    HijoDeporteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
