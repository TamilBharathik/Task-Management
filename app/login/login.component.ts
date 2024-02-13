import { Component } from '@angular/core';
import { TaskserviceService } from '../taskservice.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  Username: string = '';
  Password: string = '';
  errorMessage: string = '';

  constructor(private taskService:TaskserviceService ,private router:Router){}

  login(): void {
    this.taskService.login(this.Username, this.Password)
    .subscribe({
      next:(response)=>
      
      {
        console.log(response);
        this.router.navigate(['tlist']);
        
      },
     
      error: (error) => {
        console.error(error);
        if (error && error.error && error.error.message) {
          this.errorMessage = error.error.message;
        } else {
          this.errorMessage = 'Please check your Credentials';
        }
        
      }
    });
    // .subscribe(
    //   response => {
    //     console.log(response); 
    //     this.router.navigate(['tlist']);
    //   },
    //   error => {
    //     console.error(error); 
    //   }
    // );
     

    }
      
    
  }
