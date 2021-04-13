import { Departamento } from "./chamados/departamento.model";

export class Usuario {
    public id: string;
    public nome: string;
    public senha: string;
    public email: string;
    public departamento: Departamento;
    public departamentoId: string;
}