import { CategoryService } from './../services/category.service';
import { ProductsService } from './../services/products.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  standalone: false,
  
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  categories: { category: string }[] = [];
  constructor(private productService: ProductsService, private categoryService: CategoryService,) { this.loadProducts(); this.loadCategories(); }
  products : any[] = [];
  filteredProducts: any[] = [];
  selectedCategory: string = '';

  loadProducts(): void {
    this.productService.getProduct().subscribe({
      next: (data) => {
        console.log('Products fetched:', data);
        this.products = data; 
        this.filteredProducts = data;
       
      },
      error: (err) => {
        console.error('Error fetching products:', err);
      },
    });
  }


  loadCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (data) => {
         
        this.categories = data; 
      },
      error: (err) => {
        console.error('Error fetching categories:', err); 
      },
    });
  }
  filterByCategory(category: string): void {
    this.selectedCategory = category;
    if (category) {
      this.filteredProducts = this.products.filter(
        (product) => product.category === category
      );
    } else {
      this.filteredProducts = this.products; // Reset to all products if no category is selected
    }
  }

  addToCart(product : any): void {
    this.cartService.addToCart(product);
  }
}
