import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { BookService } from '../../Services/book.service';
import { Book } from '../../Models/book.model';

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {
  updateBookForm!: FormGroup;
  bookId!: number;

  constructor(
    public router: Router,
    private fb: FormBuilder,
    private bookService: BookService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (!idParam) {
      console.error("Book ID not found in route!");
      return;
    }
  
    this.bookId = Number(idParam);
    if (isNaN(this.bookId) || this.bookId <= 0) {
      console.error("Invalid Book ID:", this.bookId);
      return;
    }
  
    this.updateBookForm = this.fb.group({
      id: [this.bookId, Validators.required], 
      title: ['', Validators.required],
      author: ['', Validators.required],
      isbn: ['', Validators.required],
      categoryId: [null, Validators.required],
      publishedYear: [null, Validators.required],
      copiesAvailable: [null, Validators.required]
    });
  
    this.loadBookData();
  }
  

  loadBookData() {
    if (this.bookId) {
      this.bookService.getBookById(this.bookId).subscribe({
        next: (book: Book) => this.updateBookForm.patchValue(book),
        error: (err) => console.error('Error fetching book:', err),
      });
    }
  }

  onSubmit() {
    if (this.updateBookForm.valid) {
      this.bookService.updateBook(this.updateBookForm.value).subscribe({
        next: () => {
          alert('Book updated successfully!');
          this.router.navigate(['/admin-dashboard']);
        },
        error: (err) => console.error('Error updating book:', err),
      });
    }
  }
}
