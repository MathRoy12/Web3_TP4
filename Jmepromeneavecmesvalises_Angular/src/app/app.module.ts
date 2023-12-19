import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {SignUpComponent} from './sign-up/sign-up.component';
import {RouterModule} from "@angular/router";
import {LogInComponent} from './log-in/log-in.component';
import { AccueilComponent } from './accueil/accueil.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {ElInterceptor} from "./el-interceptor.interceptor";
import {FormsModule} from "@angular/forms";
import { VoyageComponent } from './voyage/voyage.component';
import { MasonryComponent } from './masonry/masonry.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    LogInComponent,
    AccueilComponent,
    VoyageComponent,
    MasonryComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    RouterModule.forRoot([
      {path: '', redirectTo: '/Accueil', pathMatch: 'full'},
      {path: 'SignUp', component: SignUpComponent},
      {path: 'LogIn', component: LogInComponent},
      {path: 'Accueil', component: AccueilComponent},
      {path: 'Voyage/:id', component: VoyageComponent},
      {path: '**', redirectTo: '/Accueil', pathMatch: 'full'}
    ]),
    FormsModule,
    HttpClientModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass: ElInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
