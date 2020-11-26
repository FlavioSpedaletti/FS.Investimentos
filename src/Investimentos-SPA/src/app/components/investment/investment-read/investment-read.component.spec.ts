import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentReadComponent } from './investment-read.component';

describe('InvestmentReadComponent', () => {
  let component: InvestmentReadComponent;
  let fixture: ComponentFixture<InvestmentReadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestmentReadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestmentReadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
