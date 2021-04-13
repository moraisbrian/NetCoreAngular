import { Chamado } from "./chamado.model";
import { Departamento } from "./departamento.model";

export class Assunto {
    public id: string;
    public identificacao: string;
    public chamados: Array<Chamado>;
    public departamentoId: string;
    public departamento: Departamento;
}