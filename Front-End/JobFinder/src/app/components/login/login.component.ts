import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalLoginService } from 'src/app/Services/modal-login.service';
import { AuthenticationService } from 'src/app/Services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formData!: FormGroup;
  constructor(public modal: ModalLoginService, private auth: AuthenticationService) { }

  ngOnInit(): void {
    this.formData = new FormGroup({
      Email: new FormControl('',Validators.required),
      Senha: new FormControl('',Validators.required)
    });
  }
  login(){
    const login = this.formData.value;
    this.auth.login(login);
  }

}
