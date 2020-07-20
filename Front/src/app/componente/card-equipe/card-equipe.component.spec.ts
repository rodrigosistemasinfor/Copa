import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardEquipeComponent } from './card-equipe.component';

describe('CardEquipeComponent', () => {
  let component: CardEquipeComponent;
  let fixture: ComponentFixture<CardEquipeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardEquipeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardEquipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
