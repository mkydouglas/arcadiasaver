import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoJogoPageComponent } from './novo-jogo-page.component';

describe('NovoJogoPageComponent', () => {
  let component: NovoJogoPageComponent;
  let fixture: ComponentFixture<NovoJogoPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovoJogoPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoJogoPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
