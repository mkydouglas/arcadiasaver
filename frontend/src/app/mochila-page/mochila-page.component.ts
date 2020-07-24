import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { DataContextService } from '../services/data-context.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { AddTeamDto } from '../model/AddTeamDto';
import { GetTeamsDto } from '../model/GetTeamsDto';
import { AddHeroDto } from '../model/AddHeroDto';
import { RetornoTeam } from '../model/RetornoTeam';
import { GetTeamDto } from '../model/GetTeam';

@Component({
  selector: 'app-mochila-page',
  templateUrl: './mochila-page.component.html',
  styleUrls: ['./mochila-page.component.css']
})
export class MochilaPageComponent implements OnInit {

  public form: FormGroup;

  private team = new AddTeamDto();
  private hero: AddHeroDto[] = [];
  private retornoTime: RetornoTeam;
  
  constructor(private fb: FormBuilder, 
    private context: DataContextService, 
    private spinner: NgxSpinnerService) {

     }

  ngOnInit(): void {
    this.form = this.fb.group({
      campanhaid: ['', Validators.required]
    });
    
    this.form = new FormGroup({
      nGuilda: new FormControl(),
      nHeroi1: new FormControl(''),
      carta1Heroi1: new FormControl(''),
      carta2Heroi1: new FormControl(''),
      carta3Heroi1: new FormControl(''),
      carta4Heroi1: new FormControl(''),
      mMortalHeroi1: new FormControl(''),
      nHeroi2: new FormControl(''),
      carta1Heroi2: new FormControl(''),
      carta2Heroi2: new FormControl(''),
      carta3Heroi2: new FormControl(''),
      carta4Heroi2: new FormControl(''),
      mMortalHeroi2: new FormControl(''),
      nHeroi3: new FormControl(''),
      carta1Heroi3: new FormControl(''),
      carta2Heroi3: new FormControl(''),
      carta3Heroi3: new FormControl(''),
      carta4Heroi3: new FormControl(''),
      mMortalHeroi3: new FormControl(''),
    });

    this.hero[0] = new AddHeroDto();
    this.hero[1] = new AddHeroDto();
    this.hero[2] = new AddHeroDto();

    var aux = sessionStorage.getItem('time');
    if (aux != null){
      var time:GetTeamsDto = JSON.parse(aux);
      this.BuscarTime(time.id);
    }

    this.form.get('nHeroi1').valueChanges.subscribe(val => this.hero[0].name = val);
    this.form.get('carta1Heroi1').valueChanges.subscribe(val => this.hero[0].card1 = val);
    this.form.get('carta2Heroi1').valueChanges.subscribe(val => this.hero[0].card2 = val);
    this.form.get('carta3Heroi1').valueChanges.subscribe(val => this.hero[0].card3 = val);
    this.form.get('carta4Heroi1').valueChanges.subscribe(val => this.hero[0].card4 = val);
    this.form.get('mMortalHeroi1').valueChanges.subscribe(val => this.hero[0].deathToken = val);
    this.form.get('nHeroi2').valueChanges.subscribe(val => this.hero[1].name = val);
    this.form.get('carta1Heroi2').valueChanges.subscribe(val => this.hero[1].card1 = val);
    this.form.get('carta2Heroi2').valueChanges.subscribe(val => this.hero[1].card2 = val);
    this.form.get('carta3Heroi2').valueChanges.subscribe(val => this.hero[1].card3 = val);
    this.form.get('carta4Heroi2').valueChanges.subscribe(val => this.hero[1].card4 = val);
    this.form.get('mMortalHeroi2').valueChanges.subscribe(val => this.hero[1].deathToken = val);
    this.form.get('nHeroi3').valueChanges.subscribe(val => this.hero[2].name = val);
    this.form.get('carta1Heroi3').valueChanges.subscribe(val => this.hero[2].card1 = val);
    this.form.get('carta2Heroi3').valueChanges.subscribe(val => this.hero[2].card2 = val);
    this.form.get('carta3Heroi3').valueChanges.subscribe(val => this.hero[2].card3 = val);
    this.form.get('carta4Heroi3').valueChanges.subscribe(val => this.hero[2].card4 = val);
    this.form.get('mMortalHeroi3').valueChanges.subscribe(val => this.hero[2].deathToken = val);
  }

  submit(){
    if (this.form.get('nGuilda').value == null){
      return;
    }

    this.spinner.show();

    this.team.name = this.form.get('nGuilda').value;
    this.context.addTeam(this.team).subscribe(data => {
      console.log(data);
      
      data.data.forEach(t => {
        if(t.name == this.form.get('nGuilda').value){
          var time = JSON.stringify(t);
          sessionStorage.setItem('time',time);          
        }
      });

      var times = sessionStorage.getItem('time');
      var time:GetTeamsDto = JSON.parse(times);

      // do{
      //   if(time.id != null){
      //     console.log("entrou");
      //   }
      //     console.log("saiu");
          
      // }while(time.id == null);

      // console.log("to aqui");
      
      this.hero.forEach(async h => {
        console.log(time.id);
        
        await this.context.addHero(h, time.id).subscribe(v => {
          console.log(v);
          
        },(err => {console.log(err);
        }));
      },
      (err) => {
        console.log(err);
  
      });

      this.spinner.hide();

    }
    );
  }

  BuscarTime(id: number){
    return this.context.getTeam(id).subscribe(rt => {
      this.preencheCampos(rt.data);
      
    });
  }

  preencheCampos(retorno: GetTeamDto){
    console.log(retorno);
    
    this.form.setValue(
      {
        nGuilda: retorno.name,
        nHeroi1: retorno.heros[0].name,
        carta1Heroi1: retorno.heros[0].card1,
        carta2Heroi1: retorno.heros[0].card2,
        carta3Heroi1: retorno.heros[0].card3,
        carta4Heroi1: retorno.heros[0].card4,
        mMortalHeroi1: retorno.heros[0].deathToken,
        nHeroi2: retorno.heros[1].name,
        carta1Heroi2: retorno.heros[1].card1,
        carta2Heroi2: retorno.heros[1].card2,
        carta3Heroi2: retorno.heros[1].card3,
        carta4Heroi2: retorno.heros[1].card4,
        mMortalHeroi2: retorno.heros[1].deathToken,
        nHeroi3: retorno.heros[2].name,
        carta1Heroi3: retorno.heros[2].card1,
        carta2Heroi3: retorno.heros[2].card2,
        carta3Heroi3: retorno.heros[2].card3,
        carta4Heroi3: retorno.heros[2].card4,
        mMortalHeroi3: retorno.heros[2].deathToken
      });
  }

}
