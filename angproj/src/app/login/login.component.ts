import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  loginform!: FormGroup;

  get username() {
    return this.loginform.get('username');
  }
  get password() {
    return this.loginform.get('password');
  }


  constructor(private fb: FormBuilder) {
    
  }

  ngOnInit() {
    this.loginform = this.fb.group({
      username: ['', [Validators.required, Validators.pattern(/^[a-zA-Z]*$/)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
   
  }

  onSubmit() {
  }
}
