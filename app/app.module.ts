import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { taskcreateComponent } from './taskcreate/taskcreate.component';
import { TasklistComponent } from './tasklist/tasklist.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TableModule } from 'primeng/table';
import { ImageModule } from 'primeng/image';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { DropdownModule } from 'primeng/dropdown';
import { DividerModule } from 'primeng/divider';


import { ButtonModule } from 'primeng/button';
import { taskediteComponent } from './taskedit/taskedit.component';
import { LoginComponent } from './login/login.component';
import { TemplatedrivenComponent } from './templatedriven/templatedriven.component';
import { DetailsComponent } from './details/details.component';


@NgModule({
  declarations: [
    AppComponent,
    taskcreateComponent,
    TasklistComponent,
    taskediteComponent,
    LoginComponent,
    TemplatedrivenComponent,
    DetailsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TableModule,
    ButtonModule, 
    FormsModule,
    ImageModule,
    FormsModule,
    ToastModule,
    ConfirmPopupModule,
    DropdownModule,
    DividerModule,
    FormsModule
    
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
