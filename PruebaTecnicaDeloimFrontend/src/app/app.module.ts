import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AfiliadoModule } from './afiliado/afiliado.module';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AlifeFileToBase64Module } from 'alife-file-to-base64';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AlifeFileToBase64Module,
    AppRoutingModule,
    HttpClientModule,
    AfiliadoModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
