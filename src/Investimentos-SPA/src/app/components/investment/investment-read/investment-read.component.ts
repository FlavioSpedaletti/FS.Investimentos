import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { Investment } from '../investment.model';
import { InvestmentService } from '../investment.service';

@Component({
  selector: 'app-investment-read',
  templateUrl: './investment-read.component.html',
  styleUrls: ['./investment-read.component.css']
})
export class InvestmentReadComponent implements AfterViewInit, OnInit {

  investments: Investment[];
  displayedColumns = ['id', 'nomePregao', 'codigoNegociacao', 'tipoRendaVariavel', 'cnpj', 'site'];

  @ViewChild(MatTable) table: MatTable<Investment>;

  constructor(private investmentService: InvestmentService) { }

  ngOnInit(): void {
    this.investmentService.read().subscribe(investments => {
      this.investments = investments;
      this.table.dataSource = this.investments;
    })
  }

  ngAfterViewInit() {
    // this.dataSource.sort = this.sort;
    // this.dataSource.paginator = this.paginator;
    //this.table.dataSource = this.investments;
  }

}
