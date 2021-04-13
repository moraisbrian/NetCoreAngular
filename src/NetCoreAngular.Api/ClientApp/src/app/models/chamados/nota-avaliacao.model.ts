import { Chamado } from "./chamado.model";

export class NotaAvaliacao {
    public id: string;
    public identificacao: string;
    public chamados: Array<Chamado>;
}