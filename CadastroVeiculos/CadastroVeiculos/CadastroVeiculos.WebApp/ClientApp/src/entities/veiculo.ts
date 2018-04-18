import { Proprietario } from "./proprietario";
import { VeiculoFoto } from "./veiculo-foto";

export class Veiculo {
    id: string;
    placa: string;
    renavam: string;
    proprietario: Proprietario;
    fotos: VeiculoFoto[];
}