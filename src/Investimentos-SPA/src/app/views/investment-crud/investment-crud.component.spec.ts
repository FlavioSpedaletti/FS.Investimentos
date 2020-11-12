import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentCrudComponent } from './investment-crud.component';

describe('ProductCrudComponent', () => {
  let component: InvestmentCrudComponent;
  let fixture: ComponentFixture<InvestmentCrudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvestmentCrudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestmentCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
