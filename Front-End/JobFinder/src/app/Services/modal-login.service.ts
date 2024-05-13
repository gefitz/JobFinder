import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModalLoginService {
  modalAberta:boolean = false;
  constructor() { }
  FecharModal(){
this.modalAberta = false;
  }
  AbrirModal(){
    this.modalAberta = true;
  }
}
