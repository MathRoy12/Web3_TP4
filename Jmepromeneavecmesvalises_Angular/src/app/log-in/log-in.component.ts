import { Component } from '@angular/core';
import {HttpService} from "../http.service";
import {Router} from "@angular/router";
import {RegisterDTO} from "../RegisterDTO";
import {LoginDTO} from "../LoginDTO";

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent {
  email: string = '';
  password: string = '';

  constructor(public http: HttpService,
              public router: Router) {
  }

  async Submit() {
    let DTO = new LoginDTO(this.email, this.password);
    await this.http.LogIn(DTO);
    await this.router.navigate(["/Accueil"])
  }
}
