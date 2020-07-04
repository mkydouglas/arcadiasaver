import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaInicialPageComponent } from './tela-inicial-page.component';

describe('TelaInicialPageComponent', () => {
  let component: TelaInicialPageComponent;
  let fixture: ComponentFixture<TelaInicialPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TelaInicialPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TelaInicialPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
