import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public transactions: Transaction[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   
    http.get<Transaction[]>(baseUrl + 'transaction').subscribe(result => {
      this.transactions = result;     
    }, error => console.error(error));
    
  }
}

interface Transaction {
  trntype: string;
  dtposted: string;
  trnamt: number;
  memo: string;
}
