import { Component, Input, OnInit } from '@angular/core';
import { AfiliadoResponse, AfiliadoData } from '../../interfaces/afiliado.interface';

@Component({
  selector: 'app-afiliado-table',
  templateUrl: './afiliado-table.component.html',
  styleUrls: ['./afiliado-table.component.css']
})
export class AfiliadoTableComponent implements OnInit {

@Input() afiliados: AfiliadoData[] = []

  constructor() { }

  ngOnInit(): void {
  }

}
