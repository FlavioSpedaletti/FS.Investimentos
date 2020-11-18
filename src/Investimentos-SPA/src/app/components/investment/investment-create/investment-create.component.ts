import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Investment } from '../investment.model';
import { InvestmentService } from '../investment.service';

@Component({
  selector: 'app-investment-create',
  templateUrl: './investment-create.component.html',
  styleUrls: ['./investment-create.component.css']
})
export class InvestmentCreateComponent implements OnInit {

  investment: Investment = {
    nomePregao: 'teste',
    codigoNegociacao: 'test3',
    tipoRendaVariavel: 1,
    cnpj: '',
    site: ''
  };

  constructor(private investmentService: InvestmentService,
    private router: Router) { }

  ngOnInit(): void {
  }
  
  createInvestment(): void {
    this.investmentService.create(this.investment).subscribe(() => {
      this.investmentService.showMessage('Investimento criado com sucesso!');
      this.router.navigate(['/investments']);
    })
  }

  cancel() :void {
    this.router.navigate(['/investments']);
  }

}
