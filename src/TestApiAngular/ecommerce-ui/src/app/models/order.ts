export interface Order {
    id: string;
    userId: string;
    createdAt: string;
    items: OrderItem[];
  }
  
  export interface OrderItem {
    productId: string;
    quantity: number;
    unitPrice: number;
  }
  
  export interface OrderRequest {
    userId: string;
    items: OrderItemRequest[];
  }
  
  export interface OrderItemRequest {
    productId: string;
    quantity: number;
    unitPrice: number;
  }