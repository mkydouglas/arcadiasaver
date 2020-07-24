import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JogoExistentePageComponent } from './jogo-existente-page.component';

describe('JogoExistentePageComponent', () => {
  let component: JogoExistentePageComponent;
  let fixture: ComponentFixture<JogoExistentePageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JogoExistentePageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JogoExistentePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
