import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimerComponent } from './../components/primercomponent/primer.component';
import { HooksAngular } from '../components/hooksangular/hooksangular.component';
import { DeportesComponent } from '../components/deportes/deportes.component';
import { FormsBindingComponent } from '../components/formsbinding/formsbinding.component';
import { SumarNumerosComponent } from '../components/sumarnumeros/sumarnumeros.component';
import { PruebaComponent } from './components/prueba/prueba.component';
import { TablamultiplicarComponent } from './components/tablamultiplicar/tablamultiplicar.component';


@NgModule({
  declarations: [
    AppComponent,
    PrimerComponent,
    HooksAngular,
    DeportesComponent,
    FormsBindingComponent,
    SumarNumerosComponent,
    PruebaComponent,
    TablamultiplicarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
