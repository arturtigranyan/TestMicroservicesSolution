import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Product } from '../models/product';

@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = `${environment.apiGatewayUrl}/api/products`;

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<Product[]>(`${this.apiUrl}`);
  }

  getProductById(id: number) {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  getProductDetails(id: string) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createProduct(product: { name: string; description: string; price: number; stock: number }) {
    return this.http.post(`${environment.apiGatewayUrl}/api/products`, product);
  }
  
}