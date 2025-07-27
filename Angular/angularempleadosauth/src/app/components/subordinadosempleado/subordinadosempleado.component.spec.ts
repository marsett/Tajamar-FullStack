import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubordinadosempleadoComponent } from './subordinadosempleado.component';

describe('SubordinadosempleadoComponent', () => {
  let component: SubordinadosempleadoComponent;
  let fixture: ComponentFixture<SubordinadosempleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubordinadosempleadoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubordinadosempleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
