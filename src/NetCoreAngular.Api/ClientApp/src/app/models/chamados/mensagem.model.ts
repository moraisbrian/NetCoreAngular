import { Chamado } from "./chamado.model";
import { Usuario } from "../usuario.model";

export class Mensagem {
    public id: string;
    public dataCriacao: Date;
    public usuario: Usuario;
    public chamado: Chamado;
    public conteudo: string;
    public chamadoId: string;
    public usuarioId: string;
}