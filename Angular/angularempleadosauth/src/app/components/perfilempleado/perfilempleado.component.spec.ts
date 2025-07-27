import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilempleadoComponent } from './perfilempleado.component';

describe('PerfilempleadoComponent', () => {
  let component: PerfilempleadoComponent;
  let fixture: ComponentFixture<PerfilempleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PerfilempleadoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PerfilempleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
