import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TelaInicialPageComponent } from './tela-inicial-page/tela-inicial-page.component';
import { TelaPrincipalPageComponent } from './tela-principal-page/tela-principal-page.component';
import { NovoJogoPageComponent } from './novo-jogo-page/novo-jogo-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MochilaPageComponent } from './mochila-page/mochila-page.component';
import { RankPageComponent } from './rank-page/rank-page.component';
import { JogoExistentePageComponent } from './jogo-existente-page/jogo-existente-page.component';


const routes: Routes = [
  { path: '', component: TelaInicialPageComponent },
  //{ path: '', component: HomePageComponent },
  { path: 'tela-principal', component: TelaPrincipalPageComponent},
  { path: 'novo-jogo', component: NovoJogoPageComponent },
  { path: 'jogo-existente', component: JogoExistentePageComponent },
  { path: 'home', component: HomePageComponent },
  { path: 'mochila', component: MochilaPageComponent },
  { path: 'rank', component: RankPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
