import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TelaInicialPageComponent } from './tela-inicial-page/tela-inicial-page.component';
import { TelaPrincipalPageComponent } from './tela-principal-page/tela-principal-page.component';
import { NovoJogoPageComponent } from './novo-jogo-page/novo-jogo-page.component';


const routes: Routes = [
  { path: '', component: TelaInicialPageComponent },
  { path: 'tela-principal', component: TelaPrincipalPageComponent},
  { path: 'novo-jogo', component: NovoJogoPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
