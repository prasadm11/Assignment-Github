import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {
  books: any[] = [];
  userEmail: string = '';
  userRole: string = '';

  constructor(public router: Router, private http: HttpClient) {}

  ngOnInit() {
    this.getUserDetails();
    this.fetchBooks();
  }

  getUserDetails() {
    const token = localStorage.getItem('token');
    if (token) {
      try {
        const decodedToken: any = jwtDecode(token);
        this.userEmail = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] || 'Unknown';
        this.userRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] || 'User';
      } catch (error) {
        console.error('Error decoding token:', error);
      }
    } else {
      this.router.navigate(['/login']);
    }
  }

  

  fetchBooks() {
    const token = localStorage.getItem('token');

    if (!token) {
      this.router.navigate(['/login']);
      return;
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });

    this.http.get<any[]>('https://localhost:7160/api/books/getallbooks', { headers }).subscribe({
      next: (data) => {
        this.books = data;
      },
      error: (error) => {
        console.error('Error fetching books:', error);
        if (error.status === 401) {
          alert('Session expired. Please login again.');
          this.router.navigate(['/login']);
        }
      }
    });
  }

  navigateToCreateBooking() {
    this.router.navigate(['/create-booking']);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
