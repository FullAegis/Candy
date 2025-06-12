import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { UserLogin, UserRegister, AuthResponse } from '../../models/auth.model'; // Models to be created

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = '/Auth'; // Replace with your actual API base URL if different

  constructor(private http: HttpClient) { }

  login(credentials: UserLogin): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/Login`, credentials).pipe(
      tap(response => this.storeToken(response.token))
    );
  }

  register(userInfo: UserRegister): Observable<any> {
    return this.http.post(`${this.apiUrl}/Register`, userInfo);
  }

  logout(): void {
    localStorage.removeItem('authToken');
    // Add any other cleanup like redirecting the user or notifying other parts of the app
  }

  private storeToken(token: string): void {
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    // Add more sophisticated token validation if needed (e.g., check expiration)
    return !!token;
  }
}
