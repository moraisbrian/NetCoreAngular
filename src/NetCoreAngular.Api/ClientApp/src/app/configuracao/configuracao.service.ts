import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Franquia } from '../models/franquia.model';

@Injectable()
export class ConfiguracaoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'bearer ' + localStorage.getItem('token')
    })
  };

  public alterarSenha(usuarioId: string, senhaAntiga: string, senhaNova: string): Observable<any> {
    return this.http.post(
      this.baseUrl + 'usuario', 
      JSON.stringify({
        "usuarioId": usuarioId,
        "senhaAntiga": senhaAntiga,
        "senhaNova": senhaNova
      }),
      this.httpOptions
    );
  }

  public obterFranquias(usuarioId: string): Observable<Array<Franquia>> {
    return this.http.get<Array<Franquia>>(`${this.baseUrl}franquia/${usuarioId}`, this.httpOptions);
  }

}
