import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AutenticacaoGuardService } from './auth/autenticacao-guard.service';
import { ChamadoDetalheComponent } from './chamados/chamado-detalhe/chamado-detalhe.component';
import { ChamadoListaComponent } from './chamados/chamado-lista/chamado-lista.component';
import { AlterarSenhaComponent } from './configuracao/alterar-senha/alterar-senha.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [ AutenticacaoGuardService ] },
  { path: 'chamado-detalhe/:id', component: ChamadoDetalheComponent, canActivate: [ AutenticacaoGuardService ] },
  { path: 'chamado-lista', component: ChamadoListaComponent, canActivate: [ AutenticacaoGuardService ] },
  { path: 'alterar-senha', component: AlterarSenhaComponent, canActivate: [ AutenticacaoGuardService ]},
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
  providers: [ AutenticacaoGuardService ]
})
export class AppRoutingModule { }
