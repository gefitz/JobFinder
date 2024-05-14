import { Injectable } from '@angular/core';
import { ApiService, ParametroEnvio } from './ApiService';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private api: ApiService) { }
  private token: string | null = null;
  private readonly key = "JobFinder/2024/04"
  parametroEnvio: ParametroEnvio = {endpoint: "", data: {}};
  // Método para fazer login e armazenar o token
  login(tokenJson:any): void {
    this.api.post(this.parametroEnvio).subscribe(
      (response) => {
        const tokenJson = JSON.parse(JSON.stringify(response));
        localStorage.setItem("token", this.encryptToken(tokenJson.token));
        localStorage.setItem("idUsuario", tokenJson.idUsuario);
        
      }
    )
  }
  logout(): void {
    this.token = null;
    localStorage.removeItem('token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  getToken(): string | null {
    return this.decryptToken(localStorage.getItem('token')!);
  }
  encryptToken(token: string): string {
    return CryptoJS.AES.encrypt(token, this.key).toString();
  }

  decryptToken(encryptedToken: string): string {
    const bytes = CryptoJS.AES.decrypt(encryptedToken, this.key);
    return bytes.toString(CryptoJS.enc.Utf8);
  }
}
