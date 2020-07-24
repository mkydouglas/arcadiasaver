import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataContextService } from '../services/data-context.service';
import { NgxSpinnerService } from "ngx-spinner";
import { Router } from '@angular/router';

@Component({
  selector: 'app-tela-login',
  templateUrl: './tela-login.component.html',
  styleUrls: ['./tela-login.component.css']
})
export class TelaLoginComponent implements OnInit {
  
  public form: FormGroup;
  public temErro: boolean = false;
  public erro: string;

  constructor(private fb: FormBuilder, 
    private context: DataContextService, 
    private spinner: NgxSpinnerService,
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      Login: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  submit(){
    this.spinner.show();
    console.log(`Dados do Formulário: ${this.form.value}`);

    var rl = JSON.parse(sessionStorage.getItem("RL"));

    if(rl.registrar){
      this.context.registrar(this.form.value)
      .subscribe(
        (data) => {
          console.log(`Retorno Cadastro: ${data}`);        
          this.spinner.hide();
          this.temErro = true;
          this.erro = data.message;
        },
        (err) => {
          console.log(`erro cadastro: ${err.error}`);
          this.temErro = true;
          this.erro = err.error.message;
          this.spinner.hide();
        }
      );
    } else {
      this.context.logar(this.form.value)
      .subscribe(
        (data) => {
          console.log(`retorno login: ${data}`);
          sessionStorage.setItem("token", JSON.stringify(data)); 
          this.spinner.hide();
          this.router.navigate(['tela-principal']);  
        },
        (err) => {
          console.log(`erro login: ${err.error}`);
          this.temErro = true;
          this.erro = err.error.message;
          this.spinner.hide();
        }
      );
    }
    
    
  }

}
