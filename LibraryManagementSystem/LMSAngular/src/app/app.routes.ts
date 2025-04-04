import { Routes } from '@angular/router';
import { LoginComponent } from './Components/auth/login/login.component';
import { RegisterComponent } from './Components/auth/register/register.component';
import { UserDashboardComponent } from './Components/user-dashboard/user-dashboard.component';
import { AdminDashboardComponent } from './Components/admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './Guards/auth.guard';
import { AddBookComponent } from './Components/add-book/add-book.component';
import { UpdateBookComponent } from './Components/update-book/update-book.component';
import { UpdateUserComponent } from './Components/update-user/update-user.component';

// import { UserLoansComponent } from './Components/user-loans/user-loans.component';



export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'user-dashboard', component: UserDashboardComponent, canActivate: [AuthGuard] },
  { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard] },
  { path: 'add-book', component: AddBookComponent },
  { path: 'update-book/:id', component: UpdateBookComponent },
  { path: 'update-user/:id', component: UpdateUserComponent },
  // { path: 'user-loans', component: UserLoansComponent },

  // { path: '**', redirectTo: '/login' }
];
