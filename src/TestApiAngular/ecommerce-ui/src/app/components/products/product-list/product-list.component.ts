import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Product } from '../../../models/product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, RouterModule], 
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: (products: Product[]) => (this.products = products),
      error: (err) => console.error('Error loading products:', err),
    });
  }
}
