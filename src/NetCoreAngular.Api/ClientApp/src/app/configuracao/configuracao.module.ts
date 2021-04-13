import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';
import { ConfiguracaoService } from './configuracao.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AlterarSenhaComponent } from './alterar-senha/alterar-senha.component';

@NgModule({
  imports: [
    CommonModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [
    AlterarSenhaComponent
  ],
  providers: [
    ConfiguracaoService
  ]
})
export class ConfiguracaoModule { }
