import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-product',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './create-product.component.html'
})
export class CreateProductComponent implements OnInit {
  productForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      category: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      this.productService.createProduct(this.productForm.value).subscribe({
        next: (response) => {
          console.log('Product created successfully!', response);
        },
        error: (err) => {
          console.error('Failed to create product:', err);
        },
      });
    }
  }

  createProduct(): void {
    this.productService.createProduct(this.productForm.value).subscribe({
      next: (response) => {
        console.log('Product created:', response);
        this.router.navigate(['/products']);
      },
      error: (err) => {
        console.error('Failed to create product:', err);
      },
    });
  }
}