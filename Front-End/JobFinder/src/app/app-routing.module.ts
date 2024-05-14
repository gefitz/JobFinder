import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CadastroComponent } from './components/cadastro/cadastro.component';
import { HomeComponent } from './components/home/home.component';
import { AreaUsuarioComponent } from './components/area-usuario/area-usuario.component';
import { LoginComponent } from './components/login/login.component';
import { authGuard } from './Services/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'cadastro', component: CadastroComponent},
  {path: 'areausuario', component:AreaUsuarioComponent, canActivate:[authGuard]},
  {path: 'login',component:LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
