import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { BookService } from '../../Services/book.service';
import { jwtDecode } from 'jwt-decode';
import { Book } from '../../Models/book.model';
import { Member } from '../../Models/member.model';
import { MemberService } from '../../Services/member.service';
import { Loan } from '../../Models/loan.model';
import { LoanService } from '../../Services/loan.service';
@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  adminEmail: string | null = '';
  adminRole: string | null = '';
  books: Book[] = [];
  members: Member[] = [];
  loans: Loan[] = [];

  constructor(private authService: AuthService, private bookService: BookService, public router: Router,private memberService: MemberService,private loanService: LoanService,) { }

  ngOnInit(): void {
    this.loadAdminData();
    this.loadBooks();
    this.loadMembers();
    this.loadLoans();
  }

  loadLoans() {
    this.loanService.getAllLoans().subscribe({
      next: (data) => {
        this.loans = data;
      },
      error: (err) => console.error('Error fetching loans:', err)
    });
  }

  loadAdminData() {
    const token = this.authService.getToken();
    if (token) {
      try {
        const decodedToken: any = jwtDecode(token);
        this.adminEmail = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        this.adminRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      } catch (error) {
        console.error('Invalid Token', error);
      }
    }
  }

  
  
  
  loadBooks() {
    this.bookService.getAllBooks().subscribe({
      next: (data) => {
        this.books = data;
      },
      error: (err) => console.error('Error fetching books:', err)
    });
  }
  
  deleteBook(bookId: number | undefined) {
    if (!bookId) {
      alert('Invalid Book ID');
      return;
    }
  
    if (confirm('Are you sure you want to delete this book?')) {
      this.bookService.deleteBook(bookId).subscribe({
        next: () => {
          alert('Book deleted successfully!');
          this.loadBooks(); // Refresh book list
        },
        error: (err) => {
          console.error('Error deleting book:', err);
          alert('Failed to delete book.');
        },
      });
    }
  }
  
  loadMembers() {
    this.memberService.getAllMembers().subscribe({
      next: (data) => {
        this.members = data;
      },
      error: (err) => console.error('Error fetching members:', err)
    });
  }




  navigateToUpdateUser(userId: string): void {
    this.router.navigate(['/update-user', userId]);
  }


  deleteMember(userId: string): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.memberService.deleteMember(userId).subscribe({
        next: () => {
          alert('User deleted successfully!');
          this.loadMembers(); // Reload list after delete
        },
        error: (err) => console.error('Error deleting user:', err),
      });
    }
  }
  

  

  navigateToAddUser() {
    this.router.navigate(['/register']);
  }
  
  navigateToAddBook() {
    this.router.navigate(['/add-book']);
  }

  navigateToUpdateBook(bookId: number) {
    this.router.navigate(['/update-book', bookId]);
  }
  
  
  


  logout() {
    this.authService.logout();
  }
}
