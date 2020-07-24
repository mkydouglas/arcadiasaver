import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataContextService } from '../services/data-context.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { Retorno } from '../model/Retorno';
import { CampanhaDto } from '../model/CampanhaDto';
import { PlayerCampaignDto } from '../model/PlayerCampaignDto';

@Component({
  selector: 'app-novo-jogo-page',
  templateUrl: './novo-jogo-page.component.html',
  styleUrls: ['./novo-jogo-page.component.css']
})
export class NovoJogoPageComponent implements OnInit {

  campanhas = [
    {name: 'Arcadia Quest'},
    {name: 'Arcadia Quest: Inferno'},
    {name: 'Beyond the grave'},
    {name: 'Pets'},
    {name: 'Riders'},
  ];

  public novaCampanha = new CampanhaDto();
  public form: FormGroup;
  public submitted = false;
  public playerCampaignDto = new PlayerCampaignDto();
  

  constructor(private fb: FormBuilder, 
    private context: DataContextService, 
    private spinner: NgxSpinnerService,
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      fcampanha: ['', Validators.required],
      fqtdJog: ['', Validators.required]
    });
    
    this.form.get("fcampanha").valueChanges.subscribe(val => {
      this.novaCampanha.name = val;
      
    });

    this.form.get("fqtdJog").valueChanges.subscribe(val => {
      this.novaCampanha.numberOfPlayers = val;
      
    });
    
  }

  async onSubmit(){
    this.submitted = true;
    if(this.form.invalid){
      return;
    }

    this.spinner.show();
    this.novaCampanha.campaignId = ""+Math.floor(Math.random() * 65536);
    console.log(this.novaCampanha);
    var aux: Retorno = JSON.parse(sessionStorage.getItem("token"));
    var playerId = parseInt(aux.message);
    
    await this.context.addCampanha(this.novaCampanha, playerId).subscribe(
      data => {
        console.log(data);
        sessionStorage.setItem("campanha",JSON.stringify(data));
        this.spinner.hide();
        this.router.navigate(["home"]);
    },(err) => {
        console.log(err.error);
        // this.temErro = true;
        // this.erro = err.error.message;
        this.spinner.hide();
      }
    );

    // this.context.EntrarCampanha(this.obj).subscribe(data => {
    //   console.log(data);
      
    //   this.spinner.hide();
    //   this.router.navigate(["home"]);
    // },(err) => {
    //   console.log(err.error);
    //   // this.temErro = true;
    //   // this.erro = err.error.message;
    //   this.spinner.hide();
    // });

  }

  onReset(){
    this.submitted = false;
    this.form.reset();
  }

}
