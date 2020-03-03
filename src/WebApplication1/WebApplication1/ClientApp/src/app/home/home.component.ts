
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  private arquivos;
  private baseUrl: string
  private http: HttpClient;
  public transactions: Transaction[];
  public total: number;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;

  }

  public handleFileInput(files: FileList) {
    this.arquivos = files.item(0);
  }

  public enviarArquivos() {   
   
    const formData = new FormData();
    formData.append('fileKey', this.arquivos, this.arquivos.name);
    this.http.post<Transaction[]>(this.baseUrl + 'uploadofx', formData).subscribe(result => {
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

