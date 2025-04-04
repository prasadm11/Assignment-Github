import { Component, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode'; // For decoding JWT token
import { DatePipe } from '@angular/common'; 
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-user-loans',
  standalone: true,
  imports: [DatePipe,NgFor],
  templateUrl: './user-loans.component.html',
  styleUrls: ['./user-loans.component.css']
})
export class UserLoansComponent {
  loans: any[] = [];
  userId: string = '';

  private http = inject(HttpClient);

  constructor() {
    this.getUserIdFromToken();
    this.fetchUserLoans();
  }

  getUserIdFromToken() {
    const token = localStorage.getItem('token');

    if (!token) {
      console.error('No token found! Redirecting to login.');
      return;
    }

    try {
      const decodedToken: any = jwtDecode(token);
      this.userId = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    } catch (error) {
      console.error('Error decoding token:', error);
    }
  }

  fetchUserLoans() {
    const token = localStorage.getItem('token');
    const headers = { Authorization: `Bearer ${token}` };

    this.http.get<any[]>('https://localhost:7160/api/loans/user-loans', { headers }).subscribe(
      (response) => {
        console.log("User's Loans:", response);
        this.loans = response;
      },
      (error) => {
        console.error('Error fetching loans:', error);
      }
    );
  }
}
