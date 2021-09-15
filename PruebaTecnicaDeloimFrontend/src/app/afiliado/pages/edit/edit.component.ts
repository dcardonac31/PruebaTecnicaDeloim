import { Component, OnInit } from '@angular/core';
import { AfiliadoData, AfiliadoResponse } from '../../interfaces/afiliado.interface';
import { AfiliadoService } from '../../services/afiliado.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styles: [
  ]
})
export class EditComponent implements OnInit  {

  type = "file";
  files: any;
  rawFiles: any;

  errorBusqueda: boolean = false;
  guardadoExitoso: boolean = false;
  guardadoError: boolean = false;
  afiliadoResponse: AfiliadoResponse[] = [];
  afiliadoData : AfiliadoData;

  afiliadoId: number;
  fotoBase64: string;




  constructor(private afiliadoService: AfiliadoService) { }



  ngOnInit(): void {
    this.clearControl()
  }

  onFileChanged(files) {
    this.fotoBase64 = this.files[0].base64;
  }


  buscar() {
    this.errorBusqueda = false;

    this.afiliadoService.getAfiliadoById(this.afiliadoId)
    .subscribe( (response) =>{
       this.afiliadoData = response;
       this.fotoBase64 = this.afiliadoData.fotoBase64;
    }, (err => {
      this.errorBusqueda = true;
    }))

}

editar() {
  const afiliadoData = {
    afiliadoID:  this.afiliadoId,
    afiliadoNombre: this.afiliadoData.afiliadoNombre,
    fechaNacimiento: this.afiliadoData.fechaNacimiento,
    lugarNacimiento: this.afiliadoData.lugarNacimiento,
    peso: this.afiliadoData.peso,
    fotoBase64: this.fotoBase64
  }

  this.afiliadoService.put(this.afiliadoId,afiliadoData)
    .subscribe(
      afiliadoResponse =>{
        console.log(afiliadoResponse);
        this.clearControl()
        this.guardadoExitoso = true;
      },
      error =>{
        this.guardadoError = true;
      });
}

eliminar() {

  this.afiliadoService.delete(this.afiliadoId)
    .subscribe(
      afiliadoResponse =>{
        console.log(afiliadoResponse);
        this.clearControl()
        this.guardadoExitoso = true;
      },
      error =>{
        this.guardadoError = true;
      });
}

clearControl() {
  this.afiliadoId = 0;
  this.afiliadoData.afiliadoNombre = '';
  this.afiliadoData.fechaNacimiento = null;
  this.afiliadoData.lugarNacimiento = '';
  this.afiliadoData.peso = 0;
  this.fotoBase64 = '';
}

  }

