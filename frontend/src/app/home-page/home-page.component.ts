import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataContextService } from '../services/data-context.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { RetornoCampanha } from '../model/RetornoCampanha';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  campanha: RetornoCampanha;
  nps: any[] = [];
  public form: FormGroup;

  constructor(private fb: FormBuilder, 
    private context: DataContextService, 
    private spinner: NgxSpinnerService,
    private router: Router) 
  {
    this.campanha = JSON.parse(sessionStorage.getItem("campanha"));
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      vencedor: ['', Validators.required],
      menosMortes: ['', Validators.required],
      maisMoedas: ['', Validators.required],
      ganhouRecompensa: ['', Validators.required],
      ganhouTitulo: ['', Validators.required],
    });
    this.form.get("vencedor").valueChanges.subscribe(val => {
      console.log(val);
      
    });
    console.log(this.campanha.data);
      
  }

  ngAfterViewInit(){
    
  }

}
