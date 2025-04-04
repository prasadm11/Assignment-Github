export interface Loan {
    id: number;
    userId: string;
    bookId: number;
    loanDate: string;
    dueDate: string;
    returnDate?: string | null;
    status: string;
    member?: any; // Can be null, so using `any`
    book?: any;   // Can be null, so using `any`
  }
  