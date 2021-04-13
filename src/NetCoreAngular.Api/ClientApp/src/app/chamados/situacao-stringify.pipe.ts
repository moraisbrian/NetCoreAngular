import { Pipe, PipeTransform } from '@angular/core';
import { Situacao } from '../enums/chamados/situacao.enum';

@Pipe({
  name: 'situacaoStringify'
})
export class SituacaoStringifyPipe implements PipeTransform {

  transform(situacao: number): string {
    let resultado: string;

    switch (situacao) {
      case Situacao.IniciandoChamado:
        resultado = 'Iniciando Chamado';
        break;
      case Situacao.AguardandoRespostaAtendente : 
        resultado = 'Aguardando Resposta do Atendente';
        break;
      case Situacao.AguardandoRespostaCliente : 
        resultado = 'Aguardando Resposta do Cliente';
        break;
      case Situacao.Cancelado : 
        resultado = 'Cancelado';
        break;
      case Situacao.Finalizado :
        resultado = 'Finalizado';
        break;
     }

     return resultado;
  }

}
