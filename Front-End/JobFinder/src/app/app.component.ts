import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  mostrarComponente: boolean = false
  title = 'JobFinder';
  constructor(private router: Router){}
  navegarParaCadastro() {
    // this.mostrarComponente = true;
    this.router.navigate(["/cadastro"])
  }
  navegarParaHome(){
    this.mostrarComponente = false;
  }
}
