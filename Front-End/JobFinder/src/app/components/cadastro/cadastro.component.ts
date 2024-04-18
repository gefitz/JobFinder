import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }
  enviarForm(formCadastro: any){
    console.log(formCadastro.get)
  }

}
