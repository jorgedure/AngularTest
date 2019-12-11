import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { AutofocusModule } from 'angular-autofocus-fix';
//import { NavMenuComponent } from './nav-menu/nav-menu.component';
//import { HomeComponent } from './home/home.component';
//import { CounterComponent } from './counter/counter.component';
//import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';
import{DemoMaterialModule} from './DemoMaterialModule';
import { TodoItemComponent } from './components/todo-item/todo-item.component'
@NgModule({
  declarations: [
    AppComponent,
    //NavMenuComponent,
    //HomeComponent,
    //CounterComponent,
    //FetchDataComponent,
    TodoListComponent,
    TodoItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    AutofocusModule,
    DemoMaterialModule ,
    RouterModule.forRoot([
      { path: '', component: TodoListComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
      //{ path: 'components/todo-list', component: TodoListComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
