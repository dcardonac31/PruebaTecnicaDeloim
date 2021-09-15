import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { CreateComponent } from './pages/create/create.component';
import { EditComponent } from './pages/edit/edit.component';
import { ReportComponent } from './pages/report/report.component';
import { ReportDapperComponent } from './pages/report-dapper/report-dapper.component';
import { ViewAfiliadoComponent } from './pages/view-afiliado/view-afiliado.component';
import { AfiliadoTableComponent } from './components/afiliado-table/afiliado-table.component';
import { AlifeFileToBase64Module } from 'alife-file-to-base64';



@NgModule({
  declarations: [
    CreateComponent,
    EditComponent,
    ReportComponent,
    ReportDapperComponent,
    ViewAfiliadoComponent,
    AfiliadoTableComponent
  ],
  exports: [
    CreateComponent,
    EditComponent,
    ReportComponent,
    ReportDapperComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AlifeFileToBase64Module,
  ]
})
export class AfiliadoModule { }
