import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoPage } from './resultado.page';

describe('Equipe.PageComponent', () => {
  let component: ResultadoPage;
  let fixture: ComponentFixture<ResultadoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultadoPage  ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultadoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
