import { Component, OnInit } from '@angular/core';
import { AfiliadoData, AfiliadoResponse } from '../../interfaces/afiliado.interface';
import { AfiliadoService } from '../../services/afiliado.service';

@Component({
  selector: 'app-report-dapper',
  templateUrl: './report-dapper.component.html',
  styles: [
  ]
})
export class ReportDapperComponent {

  anioNacimiento: number = 0;
  lugarNacimiento: string = '';
  errorBusqueda: boolean = false;
  afiliadoResponse: AfiliadoResponse[] = []
  afiliados : AfiliadoData[] = []


  constructor(private afiliadoService: AfiliadoService) { }

  buscar() {
    this.errorBusqueda = false;
    if(this.lugarNacimiento == '')
    {
      this.lugarNacimiento = ' ';
    }

    if(this.anioNacimiento < 1)
    {
      this.anioNacimiento = 0;
    }
    this.afiliadoService.getListAfiliadoDapper(this.lugarNacimiento,this.anioNacimiento)
        .subscribe( (afiliadoResponse) =>{
           this.afiliados = afiliadoResponse.data
        }, (err => {
          this.errorBusqueda = true;
        }))
  }


}
