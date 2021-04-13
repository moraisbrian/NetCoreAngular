import { Component, ElementRef, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ChamadoService } from '../chamado.service';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { Assunto } from 'src/app/models/chamados/assunto.model';
import { Chamado } from 'src/app/models/chamados/chamado.model';
import { Prioridade } from 'src/app/models/chamados/prioridade.model';
import verificarStatus from '../verificarStatusChamado';

@Component({
  selector: 'app-chamado-lista',
  templateUrl: './chamado-lista.component.html',
  styleUrls: ['./chamado-lista.component.css']
})
export class ChamadoListaComponent implements OnInit, OnDestroy {

  constructor(private chamadoService: ChamadoService, private router: Router) { }

  @ViewChild('fecharModalNovoChamado', { static: true }) fecharModal: ElementRef;
  @ViewChild('inputArquivos', { static: true }) private inputArquivos: ElementRef;

  public assuntos$: Observable<Assunto[]>;
  public prioridades$: Observable<Prioridade[]>;

  public subscriptions: Subscription = new Subscription();

  public carregandoChamados: boolean = false;
  public adicionarChamadoClick: boolean = false;

  public chamados: Chamado[] = [];

  public pesquisaForm = new FormGroup({
    "pesquisa": new FormControl(null)
  });

  public chamadoForm: FormGroup = new FormGroup({
    "assunto": new FormControl(null, [Validators.required]),
    "prioridade": new FormControl(null, [Validators.required]),
    "mensagem": new FormControl(null, [Validators.required, Validators.minLength(6)])
  });

  public anexos: File[] = [];

  ngOnInit() {
    this.listarChamados();
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }

  public adicionarChamado(): void {
    if (this.chamadoForm.valid) {
      this.adicionarChamadoClick = true;
      const chamado = new Chamado();
      chamado.assuntoId = this.chamadoForm.value.assunto;
      chamado.clienteId = localStorage.getItem('usuario-id');
      chamado.prioridadeId = this.chamadoForm.value.prioridade;
      chamado.mensagemInicial = this.chamadoForm.value.mensagem;
      chamado.franquiaId = localStorage.getItem('franquia-atual-id');

      if (this.anexos.length > 0) {
        this.chamadoService.adicionarChamado(chamado)
          .toPromise()
          .then((chamado: Chamado) => {
            this.chamadoService.uploadAnexoMensagem(this.anexos, chamado.mensagens[0].id)
              .toPromise()
              .then(() => {
                this.limparCampos();
                this.listarChamados();
                this.fecharModal.nativeElement.click();
              });
          });
      } else {
        this.subscriptions.add(this.chamadoService.adicionarChamado(chamado)
          .subscribe(() => {
            this.limparCampos();
            this.listarChamados();
            this.fecharModal.nativeElement.click();
          }));
      }
    }
  }

  public adicionarAnexo(files: File[]): void {
    this.anexos = files;
  }

  public limparCampos(): void {
    this.chamadoForm.reset();
    this.anexos = [];
    this.inputArquivos.nativeElement.value = null;
  }

  public abrirChamado(chamdoId: string): void {
    this.router.navigate(['chamado-detalhe/' + chamdoId])
  }

  private obterChamados(): Promise<void> {
    return this.chamadoService.obterChamados()
      .toPromise()
      .then((result: Chamado[]) => {
        return result.filter(chamado => chamado.cliente.id === localStorage.getItem('usuario-id'));
      })
      .then((result: Chamado[]) => {
        return result.filter(chamado => chamado.franquiaId === localStorage.getItem('franquia-atual-id'));
      })
      .then((result: Chamado[]) => {
        this.chamados = result.sort((a, b) => +new Date(a.dataAbertura) - +new Date(b.dataAbertura))
          .map(chamado => {
            chamado.status = verificarStatus(
              chamado.dataUltimaInteracao,
              chamado.prioridade.tempoLimiteAtendimento,
              chamado.situacao
            );
            return chamado;
          });
        this.carregandoChamados = false;
      });
  }

  public listarChamados(): void {
    this.carregandoChamados = true;
    this.obterChamados();
  }

  public exibirNovoChamado(): void {
    this.adicionarChamadoClick = false;
    this.assuntos$ = this.chamadoService.obterAssuntos();
    this.prioridades$ = this.chamadoService.obterPrioridades();
  }

  public pesquisar(): void {
    this.carregandoChamados = true;
    let pesquisa = <string>this.pesquisaForm.value.pesquisa;
    this.pesquisaForm.reset();

    this.obterChamados()
      .then(() => {
        if (pesquisa) {
          pesquisa = pesquisa.trim().toLowerCase();

          const porProtocolo = this.chamados
            .filter(chamado => {
              if (chamado.protocolo.toLowerCase().search(pesquisa) !== -1)
                return chamado;
            });

          const porAssunto = this.chamados
            .filter(chamado => {
              if (chamado.assunto) {
                if (chamado.assunto.identificacao.toLowerCase().search(pesquisa) !== -1)
                  return chamado;
              }
            });

          const porPrioridade = this.chamados
            .filter(chamado => {
              if (chamado.prioridade.identificacao.toLowerCase().search(pesquisa) !== -1)
                return chamado;
            });

          const porCliente = this.chamados
            .filter(chamado => {
              if (chamado.cliente) {
                if (chamado.cliente.nome.toLowerCase().search(pesquisa) !== -1)
                  return chamado;
              }
            });

          const porAtendente = this.chamados
            .filter(chamado => {
              if (chamado.atendente) {
                if (chamado.atendente.nome.toLowerCase().search(pesquisa) !== -1)
                  return chamado;
              }
            });

          const porDepartamento = this.chamados
            .filter(chamado => {
              if (chamado.departamento) {
                if (chamado.departamento.identificacao.toLowerCase().search(pesquisa) !== -1)
                  return chamado;
              }
            });

          this.chamados = [];

          this.chamados = porProtocolo.concat(
            porAssunto,
            porPrioridade,
            porCliente,
            porAtendente,
            porDepartamento
          );
        }
      });
  }
}
