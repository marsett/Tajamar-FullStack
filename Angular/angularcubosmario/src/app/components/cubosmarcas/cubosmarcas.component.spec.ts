import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CubosmarcasComponent } from './cubosmarcas.component';

describe('CubosmarcasComponent', () => {
  let component: CubosmarcasComponent;
  let fixture: ComponentFixture<CubosmarcasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CubosmarcasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CubosmarcasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
