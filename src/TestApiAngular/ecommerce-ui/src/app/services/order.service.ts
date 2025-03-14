import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  private apiGatewayUrl = 'http://localhost:5000/api/orders';

  constructor(private http: HttpClient) {}

  createOrder(order: any): Observable<any> {
    return this.http.post(`${this.apiGatewayUrl}`, order);
  }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiGatewayUrl}`);
  }

  getOrderById(orderId: string): Observable<Order> {
    return this.http.get<Order>(`${this.apiGatewayUrl}/${orderId}`);
  }

  getUserOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiGatewayUrl}/user-orders`);
  }

  deleteOrder(orderId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiGatewayUrl}/${orderId}`);
  }

  updateOrder(orderId: string, order: any): Observable<Order> {
    return this.http.put<Order>(`${this.apiGatewayUrl}/${orderId}`, order);
  }
}