import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookService } from '../../Services/book.service';
import { Router } from '@angular/router';
import { Book } from '../../Models/book.model'; 
import { Category } from '../../Models/category.model';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {
  book: Book = {
    title: '',
    author: '',
    isbn: '',
    categoryId: null,
    publishedYear: null,
    copiesAvailable: null
  };

  categories: Category[] = [];

  constructor(private bookService: BookService, private router: Router) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.bookService.getCategories().subscribe({
      next: (data) => {
        console.log('Categories received:', data);
        const categoryIds = data.map((category: any) => category.id);
        console.log('Extracted Category IDs:', categoryIds); 
  
        this.categories = data;
      },
      error: (err: any) => console.error('Error fetching categories:', err)
    });
  }
  
  
  
  addBook() {
    this.bookService.addBook(this.book).subscribe({
      next: () => {
        alert('Book added successfully!');
        this.router.navigate(['/admin-dashboard']);
      },
      error: (err: any) => console.error('Error adding book:', err)
    });
  }
}
