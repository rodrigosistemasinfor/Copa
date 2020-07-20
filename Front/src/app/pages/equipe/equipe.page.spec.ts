import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipePage } from './equipe.page';

describe('Equipe.PageComponent', () => {
  let component: EquipePage;
  let fixture: ComponentFixture<EquipePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EquipePage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EquipePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
