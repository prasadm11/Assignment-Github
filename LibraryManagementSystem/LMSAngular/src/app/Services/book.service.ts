import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../Models/book.model';


@Injectable({
    providedIn: 'root',
})
export class BookService {
    private apiUrl = 'https://localhost:7160/api';

    constructor(private http: HttpClient) { }

    private getHeaders() {
        const token = localStorage.getItem('token');
        return {
          headers: new HttpHeaders({
            Authorization: `Bearer ${token}`,
            'Content-Type': 'application/json',
          }),
        };
      }

    getAllBooks(): Observable<Book[]> {
        const token = localStorage.getItem('token');
        const headers = new HttpHeaders({
            Authorization: `Bearer ${token}`,
        });

        return this.http.get<Book[]>(`${this.apiUrl}/books/GetAllBooks`, { headers });
    }



    getBookById(id: number): Observable<Book> {  
        const token = localStorage.getItem('token'); // Retrieve token from local storage
        const headers = new HttpHeaders({
          Authorization: `Bearer ${token}`,
        });
      
        return this.http.get<Book>(`${this.apiUrl}/books/${id}`, { headers });
      }
      


    updateBook(book: Book): Observable<Book> {
        const token = localStorage.getItem('token');
        const headers = new HttpHeaders({
            Authorization: `Bearer ${token}`,
            'Content-Type': 'application/json'  
        });

        return this.http.put<Book>(`${this.apiUrl}/books/${book.id}`, book, { headers });
    }



    deleteBook(bookId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/books/${bookId}`, this.getHeaders()); 
    }



    getCategories(): Observable<any> {
        const token = localStorage.getItem('token');
        const headers = new HttpHeaders({
            Authorization: `Bearer ${token}`,
        });

        return this.http.get(`${this.apiUrl}/categories`, { headers });
    }


    addBook(book: any): Observable<any> {
        const token = localStorage.getItem('token');
        const headers = new HttpHeaders({
            Authorization: `Bearer ${token}`,
            'Content-Type': 'application/json'
        });


        return this.http.post(`${this.apiUrl}/books/AddBook`, book, { headers });
    }



}
