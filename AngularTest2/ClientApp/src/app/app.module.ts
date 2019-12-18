import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './User/index/index.component';
import { AddUserComponent } from './User/add-user/add-user.component';
import { EditUserComponent } from './User/edit-user/edit-user.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import{DemoMaterialModule} from './DemoMaterialModule';


@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    AddUserComponent,
    EditUserComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    DemoMaterialModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'user/add-user', component: AddUserComponent },
      { path: 'user/edit-user', component: EditUserComponent },
      { path: 'user', component: IndexComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
