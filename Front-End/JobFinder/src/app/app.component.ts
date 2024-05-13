import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ModalLoginService } from './Services/modal-login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  abrirModal: boolean = true;
  title = 'JobFinder';

  constructor(private router: Router, public modalLogin:ModalLoginService){}

  AbrirModal(): void{
    this.abrirModal = true;
  }
}
