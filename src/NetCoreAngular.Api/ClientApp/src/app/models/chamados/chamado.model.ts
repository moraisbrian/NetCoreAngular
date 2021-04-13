import { Assunto } from "./assunto.model";
import { Departamento } from "./departamento.model";
import { Mensagem } from "./mensagem.model";
import { NotaAvaliacao } from "./nota-avaliacao.model";
import { Prioridade } from "./prioridade.model";
import { Usuario } from "../usuario.model";
import { Franquia } from "../franquia.model";

export class Chamado {
    public id: string;
    public protocolo: string;
    public dataUltimaInteracao: Date;
    public dataAbertura: Date;
    public empresa: string;
    public situacao: number;
    public status: number;
    public assuntoId: string;
    public assunto: Assunto;
    public mensagens: Array<Mensagem>;
    public notaAvaliacao: NotaAvaliacao;
    public notaAvaliacaoId: string;
    public observacoesEncerramento: string;
    public departamentoId: string;
    public departamento: Departamento;
    public prioridadeId: string;
    public prioridade: Prioridade;
    public clienteId: string;
    public cliente: Usuario;
    public atendenteId: string;
    public atendente: Usuario;
    public mensagemInicial: string;
    public franquiaId: string;
    public franquia: Franquia;
}