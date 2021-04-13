import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {ArquivoChamado } from '../models/chamados/arquivo-chamado.model';
import { Assunto } from '../models/chamados/assunto.model';
import { Chamado } from '../models/chamados/chamado.model';
import { Departamento } from '../models/chamados/departamento.model';
import { Mensagem } from '../models/chamados/mensagem.model';
import { NotaAvaliacao } from '../models/chamados/nota-avaliacao.model';
import { Prioridade } from '../models/chamados/prioridade.model';
import { Usuario } from '../models/usuario.model';

@Injectable()
export class ChamadoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'bearer ' + localStorage.getItem('token')
    })
  };

  public obterChamados(): Observable<Array<Chamado>> {
    return this.http.get<Array<Chamado>>(this.baseUrl + 'chamado', this.httpOptions);
  }

  public obterChamadoPorId(id: string): Promise<Chamado> {
    return this.http.get<Chamado>(`${this.baseUrl}chamado/${id}`, this.httpOptions).toPromise();
  }

  public obterAssuntos(): Observable<Array<Assunto>> {
    return this.http.get<Array<Assunto>>(this.baseUrl + 'assunto', this.httpOptions);
  }

  public obterDepartamentos(): Observable<Array<Departamento>> {
    return this.http.get<Array<Departamento>>(this.baseUrl + 'departamento', this.httpOptions);
  }

  public obterAssuntosPorDepartamento(departamentoId: string): Observable<Array<Assunto>> {
    return this.http.get<Array<Assunto>>(`${this.baseUrl}assunto/${departamentoId}`, this.httpOptions);
  }

  public obterUsuariosPorDepartamento(departamentoId: string): Observable<Array<Usuario>> {
    return this.http.get<Array<Usuario>>(`${this.baseUrl}usuario/${departamentoId}`, this.httpOptions);
  }

  public obterNotas(): Observable<Array<NotaAvaliacao>> {
    return this.http.get<Array<NotaAvaliacao>>(this.baseUrl + 'notaavaliacao', this.httpOptions);
  }

  public obterMensagensChamado(chamadoId: string): Observable<Array<Mensagem>> {
    return this.http.get<Array<Mensagem>>(`${this.baseUrl}mensagem/${chamadoId}`, this.httpOptions);
  }

  public adicionarMensagem(mensagem: Mensagem): Observable<string> {
    return this.http.post<string>(this.baseUrl + 'mensagem', JSON.stringify(mensagem), this.httpOptions);
  }

  public obterPrioridades(): Observable<Array<Prioridade>> {
    return this.http.get<Array<Prioridade>>(this.baseUrl + 'prioridade', this.httpOptions);
  }

  public adicionarChamado(chamado: Chamado): Observable<Chamado> {
    return this.http.post<Chamado>(this.baseUrl + 'chamado', JSON.stringify(chamado), this.httpOptions);
  }

  public atualizarChamado(id: string, chamado: Chamado): Observable<any> {
    return this.http.put(`${this.baseUrl}chamado/${id}`, JSON.stringify(chamado), this.httpOptions);
  }

  public uploadAnexoMensagem(files: File[], mensagemId: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + localStorage.getItem('token')
      })
    };

    const formData = new FormData();

    for (let file of files) {
      formData.append(file.name, file);
    }  

    const upload = new HttpRequest('POST', `${this.baseUrl}arquivochamado/${mensagemId}`, formData, httpOptions);
    return this.http.request(upload);
  }

  public obterAnexosMensagem(mensagemId: string): Observable<ArquivoChamado[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + localStorage.getItem('token')
      })
    };

    return this.http.get<ArquivoChamado[]>(`${this.baseUrl}arquivochamado/${mensagemId}`, httpOptions);
  }
}
