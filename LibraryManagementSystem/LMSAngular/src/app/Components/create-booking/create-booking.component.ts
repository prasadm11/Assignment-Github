import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { jwtDecode } from 'jwt-decode'; // Import jwt-decode for decoding JWT tokens

@Component({
  selector: 'app-create-booking',
  standalone: true,
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.css'],
  imports: [NgFor, FormsModule],
})
export class CreateBookingComponent {
  books: any[] = [];
  selectedBookId: number | null = null;
  loanDate: string = '';
  dueDate: string = '';
  returnDate: string = '';
  userId: string = '';

  private http = inject(HttpClient);
  public router = inject(Router);

  constructor() {
    this.getUserIdFromToken(); // ✅ Calling function correctly
    this.fetchBooks();
  }

  /** 🔹 Extract userId from JWT Token */
  getUserIdFromToken() {
    const token = localStorage.getItem('token');
    if (!token) {
      alert('User not authenticated. Redirecting to login.');
      this.router.navigate(['/login']);
      return;
    }

    try {
      const decodedToken: any = jwtDecode(token);
      this.userId = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

      if (!this.userId) {
        alert('User ID not found in token! Redirecting to login.');
        this.router.navigate(['/login']);
      }
      console.log('Extracted userId:', this.userId);
    } catch (error) {
      console.error('Error decoding token:', error);
      alert('Invalid token! Redirecting to login.');
      this.router.navigate(['/login']);
    }
  }

  /** 🔹 Fetch books from API */
  fetchBooks() {
    const token = localStorage.getItem('token');
    if (!token) {
      alert('User not authenticated. Redirecting to login.');
      this.router.navigate(['/login']);
      return;
    }

    const headers = { Authorization: `Bearer ${token}` };

    this.http.get<any[]>('https://localhost:7160/api/books/getallbooks', { headers }).subscribe(
      (response) => {
        console.log("Books fetched from API:", response);
        this.books = response;
      },
      (error) => {
        console.error('Error fetching books:', error);
        alert('Failed to fetch books.');
      }
    );
  }

  /** 🔹 Create Booking */
  createBooking() {
    if (!this.selectedBookId || !this.loanDate || !this.dueDate || !this.userId) {
      alert('Please fill all required fields.');
      return;
    }

    // Determine status
    let status = 'Borrowed';
    if (this.returnDate && new Date(this.returnDate) < new Date(this.loanDate)) {
      status = 'Returned';
    }

    const booking = {
      userId: this.userId,
      bookId: this.selectedBookId,
      loanDate: new Date(this.loanDate).toISOString(),
      dueDate: new Date(this.dueDate).toISOString(),
      returnDate: this.returnDate ? new Date(this.returnDate).toISOString() : null,
      status: status
    };

    const token = localStorage.getItem('token');
    const headers = { Authorization: `Bearer ${token}` };

    this.http.post('https://localhost:7160/api/loans', booking, { headers }).subscribe(
      () => {
        alert('Booking created successfully!');
        this.router.navigate(['/user-dashboard']);
      },
      (error) => {
        console.error('Error creating booking:', error);
        alert('Error creating booking. Please try again.');
      }
    );
  }
}
