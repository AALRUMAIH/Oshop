import { Component } from '@angular/core';

@Component({
  selector: 'app-product-filter',
  standalone: false,
  
  templateUrl: './product-filter.component.html',
  styleUrl: './product-filter.component.scss'
})
export class ProductFilterComponent {
  selectedCategory: string = '';
  
}
