import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  template: `
    <div class="container mt-5">
      <div class="card shadow-lg">
        <div class="card-body text-center">
          <h2 class="card-title">Welcome, {{ userName }}!</h2>
          <p class="card-text">You can create a new booking below:</p>
          <button class="btn btn-primary w-100 mb-2" (click)="createBooking()">Create Booking</button>
          <button class="btn btn-danger w-100" (click)="logout()">Logout</button>
        </div>
      </div>
    </div>
  `,
  styles: []
})
export class UserDashboardComponent {
  userName = localStorage.getItem('userName') || 'User';

  constructor(private router: Router) {}

  createBooking() {
    this.router.navigate(['/create-booking']);
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
