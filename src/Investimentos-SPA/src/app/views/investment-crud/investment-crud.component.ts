import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-investment-crud',
  templateUrl: './investment-crud.component.html',
  styleUrls: ['./investment-crud.component.css']
})
export class InvestmentCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
 
  navigateToInvestmentCreate(): void {
    this.router.navigate(['/investments/create']);
  }

}
