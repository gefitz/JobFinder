import { FormBuilder, FormControl,FormGroup, Validators } from "@angular/forms"
import { Cidade } from "./Cidade.model"
import { Login } from "./Login.model"
export interface CadastroModel {
    Nome: string,
    Sobrenome: string,
    CPF: string,
    Telefone:string,
    Email:string,
    CEP:string,
    Rua:string,
         Numero:string
         Login: Login | null,
         Cidade: Cidade
}
export class Cadastro{
    getModel(model: CadastroModel): CadastroModel{
        
        return model;
    }
}