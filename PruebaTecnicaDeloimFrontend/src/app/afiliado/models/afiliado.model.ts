import { AfiliadoData } from '../interfaces/afiliado.interface';

export class Afiliado implements AfiliadoData {

  constructor(
    public afiliadoID:  number,
    public afiliadoNombre:  string,
    public fechaNacimiento: Date,
    public lugarNacimiento: string,
    public foto: string,
    public fotoBase64: string,
    public peso: number,
    ) {}
}
