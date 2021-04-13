import { Usuario } from "./usuario.model";

export class Franquia {
    public id: string;
    public nome: string;
    public cnpj: string;
    public ativo: boolean;
    public usuarios: Array<Usuario>
}