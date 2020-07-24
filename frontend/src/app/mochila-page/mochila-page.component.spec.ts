import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MochilaPageComponent } from './mochila-page.component';

describe('MochilaPageComponent', () => {
  let component: MochilaPageComponent;
  let fixture: ComponentFixture<MochilaPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MochilaPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MochilaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
