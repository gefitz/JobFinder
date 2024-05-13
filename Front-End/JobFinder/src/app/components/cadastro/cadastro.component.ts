import { Component, Input, OnInit } from '@angular/core';
import { CadastroModel} from 'src/app/Models/Cadastro.model';
import { Login } from 'src/app/Models/Login.model';
import { FormBuilder, FormControl,FormGroup, Validators } from "@angular/forms"
import { ApiService, ParametroEnvio } from 'src/app/Services/ApiService';
import { Cidade } from 'src/app/Models/Cidade.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  @Input() cadastroModel: CadastroModel |  null = null;
  formData!: FormGroup;
  estados! :Cidade[];
  cidades! : Cidade[];
  parametroEnvio: ParametroEnvio = {endpoint: "", data: {}};

  
  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
    this.formData = this.getFormCadastro(this.cadastroModel!);

    this.parametroEnvio!.endpoint = 'Cidade/estado';
    this.apiService.get(this.parametroEnvio).subscribe(
      (response)=>{
        this.estados = response;
      }
    )
  }
  enviarForm(){
    if(this.formData.valid){
       this.cadastroModel = this.formData.value;
      this.parametroEnvio.endpoint = 'Usuario';
      this.parametroEnvio.data = this.cadastroModel;
      this.apiService.post(this.parametroEnvio).subscribe(
        (response) =>{
          alert("sucesso");
        }
      )

    } else {
      
    }
  }
  filterCidade(event:any){
    this.parametroEnvio.endpoint = 'Cidade/cidade?sigla='+ event.value;
     this.apiService.post(this.parametroEnvio).subscribe(
      (response) => {
        this.cidades = response;
      }
     )
  }
  getFormCadastro(cadastro: CadastroModel): FormGroup{
        
    if(cadastro){
        return new FormGroup({
          nome: new FormControl(cadastro.Nome,Validators.required),
          sobrenome: new FormControl(cadastro.Sobrenome),
          cpf: new FormControl(cadastro.CPF,Validators.required),
          telefone:new FormControl(cadastro.Telefone,Validators.required),
          email:new FormControl(cadastro.Email,Validators.required),
          cep:new FormControl(cadastro.CEP,Validators.required),
          rua:new FormControl(cadastro.Rua,Validators.required),
          numero:new FormControl(cadastro.Numero,Validators.required),
          password: new FormControl(cadastro.Login!.password,Validators.required),
          confirmaSenha: new FormControl('', Validators.required),
          estado: new FormControl(cadastro.Cidade.estado,Validators.required),
          idCidade: new FormControl(cadastro.Cidade.idCidade,Validators.required)
        })
      } else {
        return new FormGroup({
          nome: new FormControl('', Validators.required),
          sobrenome: new FormControl(''),
          cpf: new FormControl('', Validators.required),
          telefone: new FormControl('', Validators.required),
          email: new FormControl('', Validators.required),
          cep: new FormControl('', Validators.required),
          rua: new FormControl('', Validators.required),
          numero: new FormControl('', Validators.required),
          password: new FormControl('',Validators.required),
          confirmaSenha: new FormControl('', Validators.required),
          estado: new FormControl('',Validators.required),
          idCidade: new FormControl('',Validators.required)
      })
    };
}

}
