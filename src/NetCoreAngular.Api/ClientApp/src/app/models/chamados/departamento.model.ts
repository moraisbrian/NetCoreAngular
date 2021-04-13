import { Assunto } from "./assunto.model";
import { Usuario } from "../usuario.model";

export class Departamento {
    public id: string;
    public identificacao: string;
    public assuntos: Array<Assunto>;
    public usuarios: Array<Usuario>;
}