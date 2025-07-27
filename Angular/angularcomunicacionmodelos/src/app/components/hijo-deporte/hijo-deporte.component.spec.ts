import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HijoDeporteComponent } from './hijo-deporte.component';

describe('HijoDeporteComponent', () => {
  let component: HijoDeporteComponent;
  let fixture: ComponentFixture<HijoDeporteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HijoDeporteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HijoDeporteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
