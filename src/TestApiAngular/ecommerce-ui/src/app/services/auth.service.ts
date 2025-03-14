import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, EMPTY, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

export interface AuthResponse {
  token: string;
  expiration: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = `${environment.apiGatewayUrl}/api/users/auth`;

  constructor(private http: HttpClient) {}

  register(user: { username: string; email: string; password: string }): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/register`, user).pipe(
      tap(response => this.storeToken(response.token)),
      catchError(this.handleError)
    );
  }

  login(credentials: { email: string; password: string }): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(response => this.storeToken(response.token)),
      catchError(this.handleError)
    );
  }

  getProfile(): Observable<any> {
    return this.http.get(`${environment.apiGatewayUrl}/api/users/profile`).pipe(
      catchError(this.handleError)
    );
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  private storeToken(token: string): void {
    localStorage.setItem('token', token);
  }

  private handleError(error: any): Observable<never> {
    console.error('Auth Service Error:', error);
    return throwError(() => error);
  }
}