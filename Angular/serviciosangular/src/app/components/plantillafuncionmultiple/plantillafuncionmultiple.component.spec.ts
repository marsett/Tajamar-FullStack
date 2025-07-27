import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantillafuncionmultipleComponent } from './plantillafuncionmultiple.component';

describe('PlantillafuncionmultipleComponent', () => {
  let component: PlantillafuncionmultipleComponent;
  let fixture: ComponentFixture<PlantillafuncionmultipleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlantillafuncionmultipleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlantillafuncionmultipleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
