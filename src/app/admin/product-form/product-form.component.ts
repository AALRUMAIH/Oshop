import { Component } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { ActivatedRoute, Router } from '@angular/router';
import {ProductsService} from '../../services/products.service'
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-product-form',
  standalone: false,
  
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.scss'
})
export class ProductFormComponent {
  categories: { category: string }[] = [];
  selectedCategory: string | null = null; 
  productId: number | null = null;
 
  product = {
   
    title: '',
    price: 0, 
    category: '',
    image: '' 
  };
  

  constructor(private categoryService: CategoryService,
     private productService: ProductsService , 
     private router: Router,
    private route : ActivatedRoute) {
      
    }

  ngOnInit(): void {
    this.loadCategories();
    this.loadProduct(); 
    
  }

  saveProduct() {
    console.log('Product:', this.product);
    if (this.productId != null) {
      
    this.productService.updateProduct(this.productId, this.product).subscribe(
      (response) => {
        alert('Product updated successfully.');
        this.router.navigate(['admin/products']);
      },
      (error) => {
        console.error('Update failed:', error);
        alert('Update failed. Please try again.');
      }
    );
   }else{
        this.productService.productPost(this.product).subscribe(
      (response) => {
        console.log(response);
        alert('The pruduct added successfully.');
        console.log(response);
       this.router.navigate(['admin/products']);  
      },
      (error) => {
        console.error('Registration failed:', error);
        alert('Please try again.');
      }
    );}
  }  
  
  loadCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (data) => {
        console.log(data);
        this.categories = data; 
      },
      error: (err) => {
        console.error('Error fetching categories:', err); 
      },
    });
  }

  loadProduct(): void {
    let productId = this.route.snapshot.paramMap.get('id');
    if (productId !== null) {
      this.productId= +productId;
      console.log("This is the id of product" + productId);
    }
     
    if (productId) {
      this.productService.getProductById(+productId).pipe(take(1)).subscribe({
        next: (data) => {
          this.product = data; 
          console.log('Product fetched:', data);
          
        },
        error: (err) => {
          console.error('Error fetching product:', err);
        }
      });
    }
  }

  deleteProducts(): void {
    if(!confirm('Are you sure you want to delete this product?')) return;
    if (this.productId !== null) {
      this.productService.deleteProduct(this.productId).subscribe(
        (response) => {
          alert('Product deleted successfully.');
          this.router.navigate(['admin/products']);
        },
        (error) => {
          console.error('Delete failed:', error);
          alert('Delete failed. Please try again.');
        }
      );
    }
  
 
}}






 

 
  
  
 