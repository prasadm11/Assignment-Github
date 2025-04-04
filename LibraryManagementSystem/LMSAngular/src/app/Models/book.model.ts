export class Book {
    id?: number;  
    title?: string;
    author?: string;
    isbn?: string;
    categoryId?: number | null;
    publishedYear?: number | null;
    copiesAvailable?: number | null;
}