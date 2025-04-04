
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { AppComponent } from './app/app.component';
import { LoginComponent } from './app/Components/auth/login/login.component';
import { RegisterComponent } from './app/Components/auth/register/register.component';
import { UserDashboardComponent } from './app/Components/user-dashboard/user-dashboard.component';
import { AdminDashboardComponent } from './app/Components/admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './app/Guards/auth.guard';
import { AddBookComponent } from './app/Components/add-book/add-book.component';
import { CreateBookingComponent } from './app/Components/create-booking/create-booking.component';
import { UserLoansComponent } from './app/Components/user-loans/user-loans.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'user-dashboard', component: UserDashboardComponent, canActivate: [AuthGuard] },
  { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard] },
  { path: 'add-book', component: AddBookComponent },
  { 
    path: 'update-book/:id', 
    loadComponent: () => import('./app/Components/update-book/update-book.component')
      .then(m => m.UpdateBookComponent) 
  },
  { path: 'create-booking', component: CreateBookingComponent },
  { path: 'user-loans', component: UserLoansComponent },
  { 
    path: 'update-user/:id', 
    loadComponent: () => import('./app/Components/update-user/update-user.component')
      .then(m => m.UpdateUserComponent) 
  },
  
  { path: '**', redirectTo: '/login' }
];

bootstrapApplication(AppComponent, {
  providers: [provideRouter(routes), provideHttpClient()]
})
  .catch(err => console.error(err));
