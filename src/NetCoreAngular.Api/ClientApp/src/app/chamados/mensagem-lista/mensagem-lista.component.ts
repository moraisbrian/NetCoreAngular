import { Component, OnInit, Input, Output, EventEmitter, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChamadoService } from '../chamado.service';
import { Mensagem } from 'src/app/models/chamados/mensagem.model';
import { ArquivoChamado } from 'src/app/models/chamados/arquivo-chamado.model';

@Component({
  selector: 'app-mensagem-lista',
  templateUrl: './mensagem-lista.component.html',
  styleUrls: ['./mensagem-lista.component.css']
})
export class MensagemListaComponent implements OnInit, OnDestroy {

  constructor(private chamadoService: ChamadoService) { }

  private subscripitions: Subscription = new Subscription();

  @Input() chamadoId: string;
  @Input() chamadoEncerrado: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() mensagemAdicionada: EventEmitter<boolean> = new EventEmitter<boolean>();
  @ViewChild('inputArquivos', { static: true }) private inputArquivos: ElementRef;

  public mensagemConteudo: string = '';
  public mensagemAnexos: File[] = [];

  public mensagens: Array<Mensagem> = new Array<Mensagem>();

  public conteudoDetalhe: string = '';
  public dataDetalhe: Date;
  public usuarioDetalhe: string = '';
  public anexosDetalhe: ArquivoChamado[] = [];

  public carregandoAnexos: boolean = false;

  ngOnInit() {
    this.carregarMensagens();
  }

  downloadFile(arquivo: ArquivoChamado) {
    const binaryString = window.atob(arquivo.conteudoByte);
    const binaryLen = binaryString.length;
    const bytes = new Uint8Array(binaryLen);
    for (let i = 0; i < binaryLen; i++) {
      const ascii = binaryString.charCodeAt(i);
      bytes[i] = ascii;
    }

    const blob = new Blob([bytes]);
    const link = document.createElement('a');
    link.hidden = true;
    link.href = window.URL.createObjectURL(blob);
    link.download = arquivo.nome;
    link.click();
  }

  ngOnDestroy() {
    this.subscripitions.unsubscribe();
  }

  public adicionarAnexos(files: File[]): void {
    this.mensagemAnexos = files;
  }

  public adicionarMensagem(): void {
    if (this.mensagemConteudo.length >= 6) {
      const novaMensagem = new Mensagem();
      novaMensagem.conteudo = this.mensagemConteudo;
      novaMensagem.chamadoId = this.chamadoId;
      novaMensagem.usuarioId = localStorage.getItem('usuario-id');

      if (this.mensagemAnexos !== null && this.mensagemAnexos.length > 0) {
        this.chamadoService.adicionarMensagem(novaMensagem)
          .toPromise()
          .then((mensagemId: string) => {
            this.chamadoService.uploadAnexoMensagem(this.mensagemAnexos, mensagemId)
              .toPromise()
              .then(() => {
                this.limparMensagem();
                this.carregarMensagens();
                this.mensagemAdicionada.emit(true);
              });
          });
      } else {
        this.subscripitions.add(this.chamadoService.adicionarMensagem(novaMensagem)
          .subscribe(() => {
            this.limparMensagem();
            this.carregarMensagens();
            this.mensagemAdicionada.emit(true);
          }));
      }
    }
  }

  public limparMensagem(): void {
    this.mensagemConteudo = '';
    this.mensagemAnexos = null;
    this.inputArquivos.nativeElement.value = null;
  }

  public exibirDetalheMensagem(event: Event): void {
    this.carregandoAnexos = true;
    const mensagemId = (<HTMLInputElement>event.target).value;
    const mensagem = this.mensagens.find(mensagem => mensagem.id === mensagemId);
    this.conteudoDetalhe = mensagem.conteudo || '';
    this.dataDetalhe = mensagem.dataCriacao;
    this.usuarioDetalhe = mensagem.usuario.nome || '';
    this.subscripitions.add(this.chamadoService.obterAnexosMensagem(mensagemId)
      .subscribe((result: ArquivoChamado[]) => {
        this.anexosDetalhe = result;
        this.carregandoAnexos = false;
      }));
  }

  private carregarMensagens(): void {
    this.subscripitions.add(this.chamadoService.obterMensagensChamado(this.chamadoId)
      .subscribe((result: Array<Mensagem>) => this.mensagens = result
        .sort((a, b) => +new Date(b.dataCriacao) - +new Date(a.dataCriacao))));
  }
}
