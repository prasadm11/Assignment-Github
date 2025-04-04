import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  userEmail: string | null = '';
  userRole: string | null = '';

  constructor(private authService: AuthService, private router: Router) {
    this.loadUserData();
  }

  loadUserData() {
    const user = this.authService.getUserDetails();
    if (user) {
      this.userEmail = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
      this.userRole = user["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    }
  }

  logout() {
    this.authService.logout();
  }
}
