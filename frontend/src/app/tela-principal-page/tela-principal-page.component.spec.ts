import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaPrincipalPageComponent } from './tela-principal-page.component';

describe('TelaPrincipalPageComponent', () => {
  let component: TelaPrincipalPageComponent;
  let fixture: ComponentFixture<TelaPrincipalPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TelaPrincipalPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TelaPrincipalPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
