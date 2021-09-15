export interface AfiliadoResponse {
  status:         boolean;
  httpStatusCode: number;
  message:        string;
  data:           AfiliadoData[];
}

export interface AfiliadoData {
  afiliadoID:      number;
  afiliadoNombre:  string;
  fechaNacimiento: Date;
  lugarNacimiento: string;
  foto:            string;
  fotoBase64:      string;
  peso:            number;
}
