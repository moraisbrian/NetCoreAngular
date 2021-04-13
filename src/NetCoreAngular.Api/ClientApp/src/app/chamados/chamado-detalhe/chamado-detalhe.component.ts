import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ChamadoService } from '../chamado.service';
import { Observable, Subscription } from 'rxjs';
import { Assunto } from 'src/app/models/chamados/assunto.model';
import { Chamado } from 'src/app/models/chamados/chamado.model';
import { Departamento } from 'src/app/models/chamados/departamento.model';
import { NotaAvaliacao } from 'src/app/models/chamados/nota-avaliacao.model';
import { Prioridade } from 'src/app/models/chamados/prioridade.model';
import { Usuario } from 'src/app/models/usuario.model';
import { Situacao } from 'src/app/enums/chamados/situacao.enum';
import { Status } from '../../enums/chamados/status.enum';
import verificarStatus from '../verificarStatusChamado';
import getLocalDate from '../../shared/getLocalDate';

@Component({
  selector: 'app-chamado-detalhe',
  templateUrl: './chamado-detalhe.component.html',
  styleUrls: ['./chamado-detalhe.component.css']
})
export class ChamadoDetalheComponent implements OnInit, OnDestroy {

  constructor(private route: ActivatedRoute, private chamadoService: ChamadoService) { }

  private subscriptions: Subscription = new Subscription();

  public mensagemAcao: string = '';
  public acaoBotaoMensagem: string = '';

  public statusChamado: Status = Status.normal;
  public finalizado: boolean = false;
  public cancelado: boolean = false;
  public encerrado: boolean = false;
  public avaliado: boolean = false;
  public usuarioCliente: boolean;
  public chamadoId: string;
  public atendentes: Usuario[] = [];

  public notas$: Observable<NotaAvaliacao[]>;
  public prioridades$: Observable<Prioridade[]>;

  public chamado: Chamado;
  public protocolo: string;
  public dataUltimaInteracao: Date;
  public dataAbertura: Date;
  public assunto: Assunto;
  public situacao: number;
  public prioridadeId: string;
  public clienteId: string;
  public cliente: Usuario;
  public atendenteId: string;
  public departamento: Departamento;
  public avaliacaoId: string;
  public observacoes: string;
  public franquiaNome: string;

  ngOnInit(): void {
    this.subscriptions.add(this.route.params.subscribe((params: Params) => {
      this.chamadoId = params.id;
      this.chamadoService.obterChamadoPorId(params.id)
        .then((result: Chamado) => {
          this.encerrado = result.situacao === Situacao.Finalizado || result.situacao === Situacao.Cancelado;
          this.finalizado = result.situacao === Situacao.Finalizado;
          this.cancelado = result.situacao === Situacao.Cancelado;
          this.avaliado = result.notaAvaliacaoId !== null;
          this.usuarioCliente = localStorage.getItem('usuario-id') === result.clienteId;
          this.chamado = result;
          this.protocolo = result.protocolo;
          this.dataUltimaInteracao = result.dataUltimaInteracao;
          this.dataAbertura = result.dataAbertura;
          this.assunto = result.assunto;
          this.situacao = result.situacao;
          this.prioridadeId = result.prioridadeId;
          this.clienteId = result.clienteId;
          this.cliente = result.cliente;
          this.atendenteId = result.atendenteId;
          this.departamento = result.departamento;
          this.avaliacaoId = result.notaAvaliacaoId;
          this.observacoes = result.observacoesEncerramento;
          this.statusChamado = verificarStatus(this.dataUltimaInteracao, this.chamado.prioridade.tempoLimiteAtendimento, this.chamado.situacao);
          this.franquiaNome = result.franquia.nome;
        })
        .then(() => {
          this.notas$ = this.chamadoService.obterNotas();
          this.prioridades$ = this.chamadoService.obterPrioridades();

          this.subscriptions.add(this.chamadoService.obterUsuariosPorDepartamento(this.departamento.id)
            .subscribe((result: Usuario[]) => {
              this.atendentes = result.filter(usuario => {
                return usuario.id !== this.chamado.clienteId;
              });
            }));
        });
    }));
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  public mensagemAdicionada(event: Event): void {
    if (event) {

      this.dataUltimaInteracao = getLocalDate();

      if ((this.chamado.situacao === Situacao.AguardandoRespostaCliente || this.chamado.situacao === Situacao.IniciandoChamado) && this.clienteId === localStorage.getItem('usuario-id')) {
        this.chamado.situacao = Situacao.AguardandoRespostaAtendente;
        this.situacao = Situacao.AguardandoRespostaAtendente;
      } else if ((this.chamado.situacao === Situacao.AguardandoRespostaAtendente || this.chamado.situacao === Situacao.IniciandoChamado) && this.atendenteId === localStorage.getItem('usuario-id')) {
        this.chamado.situacao = Situacao.AguardandoRespostaCliente;
        this.situacao = Situacao.AguardandoRespostaCliente;
      }

      this.salvarModificacoes();
    }
  }

  private salvarModificacoes(): void {
    this.chamado.atendenteId = this.atendenteId;
    this.chamado.prioridadeId = this.prioridadeId;
    this.chamado.status = this.statusChamado;

    if (this.finalizado && this.avaliacaoId) {
      this.chamado.notaAvaliacaoId = this.avaliacaoId;
      this.chamado.observacoesEncerramento = this.observacoes;
      this.avaliado = true;
    }
    
    this.subscriptions.add(this.chamadoService.atualizarChamado(this.chamadoId, this.chamado)
      .subscribe());
  }

  public trocarMensagem(event: Event): void {
    this.acaoBotaoMensagem = (<HTMLInputElement>event.target).value;
    if (this.acaoBotaoMensagem === 'cancelar') {
      this.mensagemAcao = 'Deseja realmente cancelar o chamado?';
    } else if (this.acaoBotaoMensagem === 'finalizar') {
      this.mensagemAcao = 'Deseja realmente encerrar o chamado?';
    } else {
      this.salvarModificacoes();
      this.mensagemAcao = 'Chamado salvo com sucesso!';
    }
  }

  public encerrarCancelarChamado(event: Event): void {
    const operacao = (<HTMLInputElement>event.target).value;
    if (operacao === 'finalizar') {
      this.chamado.situacao = Situacao.Finalizado;
      this.situacao = Situacao.Finalizado;
      this.finalizado = true;
    } else {
      this.chamado.situacao = Situacao.Cancelado;
      this.situacao = Situacao.Cancelado;
      this.cancelado = true;
    }

    this.dataUltimaInteracao = getLocalDate();
    this.chamado.dataUltimaInteracao = this.dataUltimaInteracao;
    this.encerrado = true;
    this.statusChamado = Status.encerrado;
    this.salvarModificacoes();
  }
}
