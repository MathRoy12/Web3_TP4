import {Component} from '@angular/core';
import {HttpService} from "../http.service";
import {RegisterDTO} from "../RegisterDTO";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(public http: HttpService,
              public router: Router) {
  }

  async Submit() {
    let DTO = new RegisterDTO(this.email, this.password, this.confirmPassword);
    await this.http.SignUp(DTO);
    await this.router.navigate(["/Accueil"])
  }
}
