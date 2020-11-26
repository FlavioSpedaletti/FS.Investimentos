import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { Investment } from './investment.model';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {

  baseUrl = 'https://localhost:5001/api/ativorendavariavel';

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string): void {
    this.snackBar.open(msg, '', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    });
  }

  create(investment: Investment): Observable<Investment> {
    return this.http.post<Investment>(this.baseUrl, investment);
  }

  read(): Observable<Investment[]> {
    return this.http.get<Investment[]>(this.baseUrl);
  }
}
