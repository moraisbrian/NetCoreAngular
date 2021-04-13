import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

import { ChamadoListaComponent } from './chamado-lista/chamado-lista.component';
import { ChamadoDetalheComponent } from './chamado-detalhe/chamado-detalhe.component';
import { ChamadoService } from './chamado.service';
import { MensagemListaComponent } from './mensagem-lista/mensagem-lista.component';
import { SituacaoStringifyPipe } from './situacao-stringify.pipe';
import { TextSubstringPipe } from '../shared/text-substring.pipe';

@NgModule({
  declarations: [
    ChamadoListaComponent, 
    ChamadoDetalheComponent, 
    MensagemListaComponent, 
    SituacaoStringifyPipe,
    TextSubstringPipe
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    TextSubstringPipe
  ],
  providers: [
    ChamadoService
  ]
})
export class ChamadosModule { }
