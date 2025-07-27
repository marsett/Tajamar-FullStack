import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablamultiplicarroutingComponent } from './tablamultiplicarrouting.component';

describe('TablamultiplicarroutingComponent', () => {
  let component: TablamultiplicarroutingComponent;
  let fixture: ComponentFixture<TablamultiplicarroutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TablamultiplicarroutingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TablamultiplicarroutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
