import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenutablacomponentComponent } from './menutablacomponent.component';

describe('MenutablacomponentComponent', () => {
  let component: MenutablacomponentComponent;
  let fixture: ComponentFixture<MenutablacomponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MenutablacomponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenutablacomponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
