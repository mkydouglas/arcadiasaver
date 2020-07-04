import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tela-inicial-page',
  templateUrl: './tela-inicial-page.component.html',
  styleUrls: ['./tela-inicial-page.component.css']
})
export class TelaInicialPageComponent implements OnInit {

  clicado = false;

  obj = {
    registrar:true,
    login:true
  }

  constructor() { }

  ngOnInit(): void {
  }

  mostraLogin(val: string){
    if(val == "registrar")
      this.obj.login = !this.obj.login;
    else
      this.obj.registrar = !this.obj.registrar;

    this.clicado = !this.clicado;
    
    var aux = JSON.stringify(this.obj);
    sessionStorage.setItem("RL", aux);
  }

}
