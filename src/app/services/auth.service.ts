import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = 'http://localhost:5026/api/User'; // Update to your backend API URL

  constructor(private http: HttpClient) {}
 
  // Sign up method
  
  signUp(userData: any): Observable<any> {
    
    return this.http.post(`${this.baseUrl}/signup`, userData);
  }

  // Login method
  login(credentials: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/login`, credentials); // POST /api/user/login
  }
}
