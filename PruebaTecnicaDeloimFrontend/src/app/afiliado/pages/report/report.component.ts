import { Component, OnInit } from '@angular/core';
import { AfiliadoData, AfiliadoResponse } from '../../interfaces/afiliado.interface';
import { AfiliadoService } from '../../services/afiliado.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
})
export class ReportComponent implements OnInit {

  hayError: boolean = false;
  afiliadoResponse: AfiliadoResponse[] = []
  afiliados : AfiliadoData[] = []
  page: number = 1;
  limit: number = 100;

  constructor(private afiliadoService: AfiliadoService) { }

  cargarData()
  {
    this.afiliadoService.getListAfiliado(this.page,this.limit)
    .subscribe( (afiliadoResponse) =>{
      this.afiliados = afiliadoResponse.data
   }, (err => {
     this.hayError = true;
   }))
  }

  ngOnInit(): void {
    this.cargarData()
  }


}
