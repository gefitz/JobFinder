import { HttpClient, HttpClientModule, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn:"root"
})
export class ApiService{
    url : string = 'https://localhost:7287/api/';
    constructor(private http: HttpClient){
    }

    get(parametroEnvio: ParametroEnvio): Observable<any[]>{
        console.log(parametroEnvio.endpoint);
        const urlFinal = this.url + parametroEnvio.endpoint;
        return this.http.get<any[]>(urlFinal);
    }
    post(parametroEnvio: ParametroEnvio): Observable<any[]>{
        const urlFinal = this.url + parametroEnvio.endpoint;
        const headers = new HttpHeaders({'Content-Type':'application/json'});

        if(Object.keys(parametroEnvio.data).length > 0){

            return this.http.post<any[]>(urlFinal,parametroEnvio.data, {headers})
        }else{
            return this.http.post<any[]>(urlFinal,{headers});
        }
    }
}

export interface ParametroEnvio{
    endpoint?:string;
    data: any;
}