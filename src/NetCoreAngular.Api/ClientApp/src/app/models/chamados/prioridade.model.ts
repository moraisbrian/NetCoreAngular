import { Chamado } from "./chamado.model";

export class Prioridade {
    public id: string;
    public identificacao: string;
    public tempoLimiteAtendimento: number;
    public chamados: Array<Chamado>;
}