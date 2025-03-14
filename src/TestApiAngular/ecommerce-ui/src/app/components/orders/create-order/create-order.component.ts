import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { OrderService } from '../../../services/order.service';
import { CreateOrderRequest } from '../../../models/create-order-request';

@Component({
  selector: 'app-create-order',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './create-order.component.html'
})
export class CreateOrderComponent implements OnInit {
  orderForm!: FormGroup; 

  constructor(private fb: FormBuilder, private orderService: OrderService) {}

  ngOnInit(): void {
    this.orderForm = this.fb.group({
      productId: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
    });
  }

  createOrder() {
    if (this.orderForm.invalid) return;

    const orderData: CreateOrderRequest = this.orderForm.value;

    this.orderService.createOrder(orderData).subscribe({
      next: (response) => console.log('Order Created:', response),
      error: (err) => console.error('Order Creation Failed:', err),
    });
  }
}
