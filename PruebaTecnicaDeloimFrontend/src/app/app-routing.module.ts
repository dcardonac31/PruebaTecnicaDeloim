import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './afiliado/pages/create/create.component';
import { EditComponent } from './afiliado/pages/edit/edit.component';
import { ReportDapperComponent } from './afiliado/pages/report-dapper/report-dapper.component';
import { ReportComponent } from './afiliado/pages/report/report.component';
import { ViewAfiliadoComponent } from './afiliado/pages/view-afiliado/view-afiliado.component';


const routes: Routes = [
  {
    path: '',
    component: CreateComponent,
    pathMatch: 'full'
  },
  {
    path: 'edit',
    component: EditComponent
  },
  {
    path: 'afiliado/:id',
    component: ViewAfiliadoComponent
  },
  {
    path: 'report',
    component: ReportComponent
  },
  {
    path: 'reportdapper',
    component: ReportDapperComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
]

@NgModule({
  imports: [
    RouterModule.forRoot( routes )
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule {}
