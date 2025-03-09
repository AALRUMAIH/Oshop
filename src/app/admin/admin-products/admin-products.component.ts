import { Component , ViewChild } from '@angular/core';
import {ProductsService} from '../../services/products.service';
import { Router } from '@angular/router'; 


@Component({
  selector: 'app-admin-products',
  standalone: false,
  templateUrl: './admin-products.component.html',
  styleUrl: './admin-products.component.scss'
})
export class AdminProductsComponent {

 
  products:any[]=[];
  filterProducts: any[] = [];
  first: number = 0;
  rows: number = 5;

  

constructor( private productService: ProductsService , private router: Router) {}

ngOnInit(): void {
  this.loadProducts(); 
  
}

loadProducts(): void {
  this.productService.getProduct().subscribe({
    next: (data) => {
      console.log('Products fetched:', data);
      this.products = data; 
      this.filterProducts = this.products;
    },
    error: (err) => {
      console.error('Error fetching products:', err);
    },
  });
}

filter(query: string): void {
if(query){
  this.filterProducts = this.products.filter((product) => {
    return product.title.toLowerCase().includes(query.toLowerCase());
  });
}else{
  this.filterProducts = this.products;
}

}



}
