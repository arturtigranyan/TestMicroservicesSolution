import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', loadComponent: () => import('./auth/login/login.component').then(m => m.LoginComponent) },
  { path: 'register', loadComponent: () => import('./auth/register/register.component').then(m => m.RegisterComponent) },
  { path: 'products', loadComponent: () => import('./components/products/product-list/product-list.component').then(m => m.ProductListComponent) },
  { path: 'products/create', loadComponent: () => import('./components/products/create-product/create-product.component').then(m => m.CreateProductComponent) },
  { path: 'products/:id', loadComponent: () => import('./components/products/product-details/product-details.component').then(m => m.ProductDetailsComponent) },
  { path: 'orders/create', loadComponent: () => import('./components/orders/create-order/create-order.component').then(m => m.CreateOrderComponent) },
  { path: 'orders', loadComponent: () => import('./components/orders/order-list/order-list.component').then(m => m.OrderListComponent) },
  { path: 'profile', loadComponent: () => import('./components/profile/profile.component').then(m => m.ProfileComponent) },
];