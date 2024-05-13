import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './components/cadastro/cadastro.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms'
import {HttpClientModule} from '@angular/common/http'
import { ApiService } from './Services/ApiService';
import { LoginComponent } from './components/login/login.component';
import { AreaUsuarioComponent } from './components/area-usuario/area-usuario.component';

@NgModule({
  declarations: [
    AppComponent,
    CadastroComponent,
    HomeComponent,
    LoginComponent,
    AreaUsuarioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
