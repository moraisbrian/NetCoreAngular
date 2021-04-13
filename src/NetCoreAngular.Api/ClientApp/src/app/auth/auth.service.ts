import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public autenticar(usuario: string, senha: string): Observable<any> {
    return this.http.post(this.baseUrl + 'auth', 
      JSON.stringify({
        "usuario": usuario,
        "senha": senha
      }), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
}
