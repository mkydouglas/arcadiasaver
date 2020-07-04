import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataContextService } from '../services/data-context.service';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-tela-login',
  templateUrl: './tela-login.component.html',
  styleUrls: ['./tela-login.component.css']
})
export class TelaLoginComponent implements OnInit {
  
  public form: FormGroup;

  constructor(private fb: FormBuilder, private context: DataContextService, private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      Login: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  submit(){
    this.spinner.show();
    console.log(this.form.value);
    
    this.context.authenticate(this.form.value)
    .subscribe(
      (data: any) => {
        //this.busy = false;
        this.spinner.hide();
      },
      (err) => {
        console.log(err);
        //this.busy = false;
      }
    );
  }

}
