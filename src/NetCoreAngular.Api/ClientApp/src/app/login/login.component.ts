import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import getLocalDate from '../shared/getLocalDate';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [ AuthService ]
})
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private authService: AuthService, private router: Router) { }

  private subscripition: Subscription = new Subscription();

  public carregando: boolean = false;
  public erro: boolean = false;

  public loginForm: FormGroup = new FormGroup({
    "usuario": new FormControl(null, [ Validators.required ]),
    "senha": new FormControl(null, [ Validators.required ])
  });

  ngOnInit() {
    if (localStorage.getItem('token') && localStorage.getItem('expiracao-token')) {
      const expiracao = new Date(localStorage.getItem('expiracao-token'));

      const agora = getLocalDate();
      if (expiracao > agora) {
        this.router.navigate(['home']);
      } else {
        localStorage.clear();
      }
    }
  }

  ngOnDestroy() {
    this.subscripition.unsubscribe();
  }

  public autenticar(): void {
    this.carregando = true;
    this.erro = false;
    this.subscripition = this.authService.autenticar(this.loginForm.value.usuario, this.loginForm.value.senha)
      .subscribe((result: any) => {
        if (result.token) {
          localStorage.setItem('usuario', result.usuario);
          localStorage.setItem('usuario-id', result.usuarioId);
          localStorage.setItem('usuario-email', result.usuarioEmail);
          localStorage.setItem('usuario-departamento', result.usuarioDepartamento);
          localStorage.setItem('token', result.token);
          localStorage.setItem('expiracao-token', result.expiracaoToken);
          localStorage.setItem('franquia-atual', '');
          localStorage.setItem('franquia-atual-id', '');
          this.router.navigate(['home']);
        }
      }, () => {
        this.carregando = false;
        this.erro = true;
        this.loginForm.reset();
      });
  }
}
