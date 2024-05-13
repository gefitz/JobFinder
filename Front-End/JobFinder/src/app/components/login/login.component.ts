import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalLoginService } from 'src/app/Services/modal-login.service';
import { ApiService, ParametroEnvio } from 'src/app/Services/ApiService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formData!: FormGroup;
  parametroEnvio: ParametroEnvio = {endpoint: "", data: {}};
  constructor(public modal: ModalLoginService, private api: ApiService) { }

  ngOnInit(): void {
    this.formData = new FormGroup({
      Email: new FormControl('',Validators.required),
      Senha: new FormControl('',Validators.required)
    });
  }
  login(){
    const login = this.formData.value;
    this.parametroEnvio.endpoint = "Login/authentication?username="+ login.Email +"&password="+login.Senha;
    this.api.post(this.parametroEnvio).subscribe(
      (response) => {
        const tokenJson = JSON.parse(JSON.stringify(response));
        localStorage.setItem("token", tokenJson.token);
        localStorage.setItem("idUsuario", tokenJson.idUsuario);
        
      }
    )
  }

}
