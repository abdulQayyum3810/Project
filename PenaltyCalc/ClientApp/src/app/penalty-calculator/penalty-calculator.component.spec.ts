import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PenaltyCalculatorComponent } from './penalty-calculator.component';

describe('PenaltyCalculatorComponent', () => {
  let component: PenaltyCalculatorComponent;
  let fixture: ComponentFixture<PenaltyCalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PenaltyCalculatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PenaltyCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
