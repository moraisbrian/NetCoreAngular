import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ConfiguracaoService } from '../configuracao.service';

@Component({
  selector: 'app-alterar-senha',
  templateUrl: './alterar-senha.component.html',
  styleUrls: ['./alterar-senha.component.css']
})
export class AlterarSenhaComponent implements OnDestroy {

  constructor(private configuracaoService: ConfiguracaoService) { }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  public subscription: Subscription = new Subscription();

  public carregando: boolean = false;
  public erro: boolean = false;
  public mensagem: string = '';
  public informacao: boolean = false;
  public dangerInfo: string;

  public novaSenhaForm = new FormGroup({
    "senhaAtual": new FormControl(null, [Validators.required]),
    "novaSenha": new FormControl(null, [Validators.required]),
    "confirmacao": new FormControl(null, [Validators.required])
  });

  public alterarSenha(): void {
    if (this.novaSenhaForm.valid) {
      if (this.novaSenhaForm.value.novaSenha === this.novaSenhaForm.value.confirmacao) {
        this.carregando = true;
        this.subscription = this.configuracaoService.alterarSenha(
          localStorage.getItem('usuario-id'),
          this.novaSenhaForm.value.senhaAtual,
          this.novaSenhaForm.value.novaSenha
        )
        .subscribe((result: any) => {
          this.carregando = false;
          if (result === true) {
            this.dangerInfo = 'info';
            this.mensagem = 'Senha alterada com sucesso!';
          } else if (result === false) {
            this.dangerInfo = 'danger';
            this.mensagem = 'Senha atual incorreta!';
          }
          this.informacao = true;
        }, (() => {
          this.carregando = false;
          this.dangerInfo = 'danger';
          this.mensagem = 'Erro ao alterar senha, tente novamente!';
          this.informacao = true;
        }));
      } else {
        this.dangerInfo = 'danger';
        this.mensagem = 'Nova senha e senha de confirmação são diferentes!'
        this.informacao = true;
      }
    }
    this.novaSenhaForm.reset();
  }
}
