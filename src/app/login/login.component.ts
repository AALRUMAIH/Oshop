import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: false,
  
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  
  user = {
    email: '',
    password: ''
  };
  
  constructor(private authService: AuthService , private router: Router) {}
  
  onLogin() {
    console.log('User:', this.user);
    this.authService.login(this.user).subscribe(
      (response) => { 
        alert('Login successful!'); 
        localStorage.setItem('token', response.token);  
        localStorage.setItem('user', JSON.stringify(response.user)); 
         this.router.navigate(['']);  
      },
      (error) => {
        console.error('Login failed:', error);
        alert('Login failed. Please try again.');
      }
    );
  }
  
}
