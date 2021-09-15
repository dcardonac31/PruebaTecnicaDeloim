import { Component, OnInit } from '@angular/core';
import { AfiliadoService } from '../../services/afiliado.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styles: [
  ]
})
export class CreateComponent implements OnInit {

  type = "file";
  files: any;
  rawFiles: any;

  response: any;

  guardadoExitoso: boolean = false;
  guardadoError: boolean = false;

  afiliadoNombre:  string;
  fechaNacimiento: Date;
  lugarNacimiento: string;
  fotoBase64: string;
  peso: number;


  constructor(private afiliadoService: AfiliadoService) { }

  ngOnInit(): void {
    this.clearControl();
  }

  onFileChanges(files) {
    this.fotoBase64 = this.files[0].base64;
  }

  guardar()
  {
    const afiliadoData = {
      afiliadoNombre: this.afiliadoNombre,
      fechaNacimiento: this.fechaNacimiento,
      lugarNacimiento: this.lugarNacimiento,
      peso: this.peso,
      fotoBase64: this.fotoBase64
    }

    this.afiliadoService.post(afiliadoData)
      .subscribe(
        afiliadoResponse =>{
          this.clearControl();
          this.guardadoExitoso = true;
        },
        error =>{
          this.guardadoError = true;
        });

  }

  clearControl() {
    this.afiliadoNombre = '';
    this.fechaNacimiento = null;
    this.lugarNacimiento = '';
    this.peso = 0;
    this.fotoBase64 = '';
  }

}
