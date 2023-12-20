import {Injectable} from '@angular/core';
import {RegisterDTO} from "./RegisterDTO";
import {lastValueFrom} from "rxjs";
import {HttpClient, HttpHandler} from "@angular/common/http";
import {LoginDTO} from "./LoginDTO";
import {getDTO, ShareDTO, Voyage} from "./Voyage";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  public domain: string = 'https://localhost:7023/';

  constructor(public http:HttpClient) {
  }

  async SignUp(DTO:RegisterDTO):Promise<void>{
    let res = await lastValueFrom(this.http.post<any>(this.domain + 'api/Users/Register', DTO))
    localStorage["token"] = res.token;
  }

  async LogIn(DTO:LoginDTO):Promise<void>{
    let res = await lastValueFrom(this.http.post<any>(this.domain + 'api/Users/Login', DTO))
    localStorage["token"] = res.token;
  }

  async GetAllVoyages():Promise<Voyage[]>{
    let res :Voyage[] = await lastValueFrom(this.http.get<Voyage[]>(this.domain + "api/Voyages"));
    return res;
  }

  async GetVoyageById(id:number):Promise<getDTO>{
    let res :getDTO = await lastValueFrom(this.http.get<getDTO>(this.domain + "api/Voyages/" + id.toString()));
    return res;
  }

  async CreerNouveauVoyage(voyage:Voyage,formDate:FormData){
    let res:Voyage = await lastValueFrom(this.http.post<Voyage>(this.domain + "api/Voyages", voyage));
    let res2 = await lastValueFrom(this.http.post(this.domain + "api/Couvertures/" + res.id.toString(), formDate));
    return res;
  }

  async delete(id:number){
    await lastValueFrom(this.http.delete(this.domain + "api/Couvertures/" + id.toString()))
    await lastValueFrom(this.http.delete(this.domain + "api/Voyages/" + id.toString()))
  }

  async share(DTO:ShareDTO){
    await lastValueFrom(this.http.put(this.domain + "api/Voyages/" + DTO.id.toString(),DTO))
  }

  async editCouverture(formDate:FormData,voyageId:number){
    await lastValueFrom(this.http.put(this.domain + "api/Couvertures/" + voyageId.toString(), formDate));
  }

  async ajoutPhoto(formDate:FormData,voyageId:number){
    await lastValueFrom(this.http.post(this.domain + "api/Photos/" + voyageId.toString(), formDate));
  }

  async deletePhoto(id:number){
    await lastValueFrom(this.http.delete(this.domain + "api/Photos/" + id.toString()))
  }
}
