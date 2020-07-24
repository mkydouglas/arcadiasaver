import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaInicialPageComponent } from './tela-inicial-page/tela-inicial-page.component';
import { TelaPrincipalPageComponent } from './tela-principal-page/tela-principal-page.component';
import { NovoJogoPageComponent } from './novo-jogo-page/novo-jogo-page.component';
import { TelaLoginComponent } from './tela-login/tela-login.component';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './home-page/home-page.component';
import { MochilaPageComponent } from './mochila-page/mochila-page.component';
import { RankPageComponent } from './rank-page/rank-page.component';
import { JogoExistentePageComponent } from './jogo-existente-page/jogo-existente-page.component';
import { RodapeComponent } from './rodape/rodape.component';

@NgModule({
  declarations: [
    AppComponent,
    TelaInicialPageComponent,
    TelaPrincipalPageComponent,
    NovoJogoPageComponent,
    TelaLoginComponent,
    HomePageComponent,
    MochilaPageComponent,
    RankPageComponent,
    JogoExistentePageComponent,
    RodapeComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatIconModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxSpinnerModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
