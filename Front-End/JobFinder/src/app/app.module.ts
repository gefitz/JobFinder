import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './components/cadastro/cadastro.component';
import { HomeComponent } from './components/home/home.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms'
import {HttpClientModule,HTTP_INTERCEPTORS} from '@angular/common/http'
import { LoginComponent } from './components/login/login.component';
import { AreaUsuarioComponent } from './components/area-usuario/area-usuario.component';
import { AuthIntercerptorService } from './Services/auth-intercerptor.service';

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
  providers: [    {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthIntercerptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
