import { Component, OnInit } from '@angular/core';  // Import OnInit
import { Router } from '@angular/router';  // Import Router
import { StorageService } from '../services/storage.service';

@Component({
  selector: 'bs-navbar',
  standalone: false,
  templateUrl: './bs-navbar.component.html',
  styleUrls: ['./bs-navbar.component.scss']  // Fix: styleUrls was incorrectly written as styleUrl
})
export class BsNavbarComponent implements OnInit {
  username: string = '';

  constructor(private storageService: StorageService, private router: Router) {}  // Inject Router

  ngOnInit(): void {
    this.setUsername();
  }

 
  isLoggedIn(): boolean {
    return this.storageService.getItem('user') !== null;
  }


  setUsername(): void {
    const token = this.storageService.getItem('token'); 
  const user = this.storageService.getItem('user');  
  
  if (token && user) {
    const userInfo = JSON.parse(user);  
    this.username = userInfo.username;  
    console.log('Username:', this.username);
  } else {
    this.username = '';  
  }
  }

  

  
logout(): void {
    this.storageService.removeItem('token');  
    
  this.storageService.removeItem('user');  
  this.setUsername(); 
    this.router.navigate(['/login']);  
  }
}