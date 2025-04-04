import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:7160/api/Auth'; 

  constructor(private http: HttpClient, private router: Router) {}

  /** User Login */
  login(credentials: any): Observable<any> {
    return new Observable(observer => {
      this.http.post<{ token: string }>(`${this.apiUrl}/login`, credentials).subscribe({
        next: (response) => {
          const token = response.token;
          localStorage.setItem('token', token);

          
          const decodedToken: any = jwtDecode(token);
          const userRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
          
          
          localStorage.setItem('userRole', userRole);

          
          if (userRole === 'Admin') {
            this.router.navigate(['/admin-dashboard']);
          } else {
            this.router.navigate(['/user-dashboard']);
          }

          observer.next(response);
          observer.complete();
        },
        error: (err) => {
          observer.error(err);
        }
      });
    });
  }

  
  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  
  logout(): void {
    localStorage.removeItem('token'); 
    localStorage.removeItem('userRole'); // Remove stored role
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  
  getUserRole(): string | null {
    return localStorage.getItem('userRole');
  }

  
  isAuthenticated(): boolean {
    const token = this.getToken();
    return token !== null && !this.isTokenExpired(token);
  }

  
  getUserDetails(): any {
    const token = this.getToken();
    if (token) {
      try {
        return jwtDecode(token);
      } catch (error) {
        console.error('Invalid token', error);
      }
    }
    return null;
  }

  
  private isTokenExpired(token: string): boolean {
    try {
      const decoded: any = jwtDecode(token);
      if (!decoded.exp) {
        return true;
      }
      const expirationDate = new Date(decoded.exp * 1000);
      return expirationDate < new Date();
    } catch (error) {
      return true;
    }
  }

  updateUser(userId: string, updatedUser: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/update/${userId}`, updatedUser, {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.getToken()}`,
        'Content-Type': 'application/json'
      })
    });
  }
  
}
