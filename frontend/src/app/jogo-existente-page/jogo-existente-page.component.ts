import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataContextService } from '../services/data-context.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { Retorno } from '../model/Retorno';
import { PlayerCampaignDto } from '../model/PlayerCampaignDto';

@Component({
  selector: 'app-jogo-existente-page',
  templateUrl: './jogo-existente-page.component.html',
  styleUrls: ['./jogo-existente-page.component.css']
})
export class JogoExistentePageComponent implements OnInit {

  public playerCampaign = new PlayerCampaignDto();
  public form: FormGroup;
  public temErro: boolean = false;
  public erro: string;
  public campanhaId: string;

  constructor(private fb: FormBuilder, 
    private context: DataContextService, 
    private spinner: NgxSpinnerService,
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      campanhaid: ['', Validators.required]
    });

    this.form.get("campanhaid").valueChanges.subscribe(val => {
      this.campanhaId = val;
    })
  }

  submit(){
    this.spinner.show();
    console.log(this.form.value);
    var rl: Retorno = JSON.parse(sessionStorage.getItem("token"));
    this.playerCampaign.playerId = parseInt(rl.message);

    this.context.buscarCampanha(this.campanhaId).subscribe(data => {
      console.log(data);
      this.playerCampaign.campaignId = data.data.id;

      this.context.entrarNaCampanha(this.playerCampaign)
      .subscribe(
        (data: any) => {
          console.log(data);
          sessionStorage.setItem("campanha",JSON.stringify(data));
          this.spinner.hide();
          this.router.navigate(['home']);
        },
        (err) => {
          console.log(err.error);
          this.temErro = true;
          this.erro = err.error.message;
          this.spinner.hide();
        }
      );

    });
    
  }

}
