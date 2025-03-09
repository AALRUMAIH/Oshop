import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
 private productUrl = "http://localhost:5026/api/Products"
  constructor(private http: HttpClient) { }

  productPost(productsData: any): Observable<any> {
    
    return this.http.post(this.productUrl, productsData);
  }
  getProduct(): Observable<{ title: string; price: number; category: string; image: string }[]> {
    return this.http.get<{ title: string; price: number; category: string; image: string }[]>(this.productUrl);
  }

  getProductById(id: number): Observable<any> {
    return this.http.get<any>(`${this.productUrl}/${id}`);
  }
  updateProduct(id: number, productData: any): Observable<any> {
    return this.http.put(`${this.productUrl}/${id}`, productData);
  }
  
  deleteProduct(id: number): Observable<any> {
    return this.http.delete(`${this.productUrl}/${id}`);
  }
  
}
