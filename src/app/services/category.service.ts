import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'http://localhost:5026/api/category'; 

  constructor(private http: HttpClient) {}

  // Fetch categories from the API
  getCategories(): Observable<{ category: string }[]> {
    return this.http.get<{ category: string }[]>(this.apiUrl);
  }
}
