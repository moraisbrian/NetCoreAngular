import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router'
import { Subscription } from 'rxjs';
import { ConfiguracaoService } from '../configuracao/configuracao.service';
import { Franquia } from '../models/franquia.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  providers: [ ConfiguracaoService ]
})
export class NavMenuComponent implements OnInit, OnDestroy {

  constructor(private router: Router, private configuracaoService: ConfiguracaoService) { }

  @ViewChild('collapse', { static: true }) private collapse: ElementRef;
  public esconderBotaoCancelar: boolean = true;
  public franquias: Franquia[] = [];
  private subscription: Subscription = new Subscription();
  public exibirMensagemErro: boolean = false;
  public nomeUsuario: string = 'Configurações';

  public franquiaForm: FormGroup = new FormGroup({
    "franquia": new FormControl(null, [Validators.required])
  });

  ngOnInit() {
    if (localStorage.getItem('franquia-atual') !== '') {
      this.nomeUsuario = `${localStorage.getItem('usuario')} / ${localStorage.getItem('franquia-atual')}`;
    } else {
      this.nomeUsuario = localStorage.getItem('usuario');
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  public verificarFranquia() {
    if (localStorage.getItem('franquias-temporario') && localStorage.getItem('franquias-temporario') !== null) {
      this.franquias = JSON.parse(localStorage.getItem('franquias-temporario'));
    } else {
      this.subscription = this.configuracaoService.obterFranquias(localStorage.getItem('usuario-id'))
        .subscribe((result: Franquia[]) => {
          this.franquias = result;
          localStorage.setItem('franquias-temporario', JSON.stringify(result));
        });
    }

    if (localStorage.getItem('franquia-atual') !== null && localStorage.getItem('franquia-atual-id') !== null) {
      if (localStorage.getItem('franquia-atual') !== '' && localStorage.getItem('franquia-atual-id') !== '') {
        this.esconderBotaoCancelar = false;
      } else {
        this.esconderBotaoCancelar = true;
      }
    } else {
      this.esconderBotaoCancelar = true;
    }
  }

  public atualizarNomeFranquia() {
    this.nomeUsuario = `${localStorage.getItem('usuario')} / ${localStorage.getItem('franquia-atual')}`;
  }

  public escolherFranquia() {
    if (this.franquiaForm.valid) {
      const franquia = this.franquias.find(franquia => franquia.id == this.franquiaForm.value.franquia);
      if (franquia !== null) {
        this.nomeUsuario = `${localStorage.getItem('usuario')} / ${franquia.nome}`;
        
        localStorage.setItem('franquia-atual', franquia.nome);
        localStorage.setItem('franquia-atual-id', franquia.id);
        document.getElementById('btnCloseModal').click();
        
        if (this.router.url === '/chamado-lista') {
          document.getElementById('btnPesquisarChamados').click();
        }

        this.exibirMensagemErro = false;
      } else {
        this.exibirMensagemErro = true;
      }
    }
  }

  public fecharMenu(): void {
    if (this.collapse.nativeElement.getAttribute('aria-expanded').valueOf() === 'true') {
      this.collapse.nativeElement.click();
    }
  }

  public sair(): void {
    localStorage.clear();
    this.router.navigate(['/']);
  }
}
