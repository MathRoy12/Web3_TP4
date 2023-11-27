import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {

    constructor(public router: Router) {
    }

    async SignUp() {
        await this.router.navigate(["/SignUp"])
    }

    async LogIn() {
        await this.router.navigate(["/LogIn"])
    }

    async NomClick() {
        await this.router.navigate(["/Accueil"])
    }

    Disconnect() {
        localStorage.removeItem("token");
        location.reload();
    }

    protected readonly localStorage = localStorage;
}
