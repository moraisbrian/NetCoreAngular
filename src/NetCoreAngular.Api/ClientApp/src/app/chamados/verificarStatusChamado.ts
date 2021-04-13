import { Situacao } from "../enums/chamados/situacao.enum";
import { Status } from "../enums/chamados/status.enum";

export default (ultimaInteracao: Date, tempoLimite: number, situacao: Situacao): Status => {
    if (situacao !== Situacao.Cancelado && situacao !== Situacao.Finalizado) {
        const agora = new Date();
        ultimaInteracao = new Date(ultimaInteracao);
        const tempoPassado = Math.floor((agora.valueOf() - ultimaInteracao.valueOf()) / 1000 / 60 / 60);
        const porcentageLimite = (tempoLimite * 30) / 100;

        if (tempoPassado >= tempoLimite) {
            return Status.atrasado;
        } else if (tempoPassado + porcentageLimite >= tempoLimite) {
            return Status.atencao;
        } else {
            return Status.normal;
        }
    } else {
        return Status.normal;
    }

}
