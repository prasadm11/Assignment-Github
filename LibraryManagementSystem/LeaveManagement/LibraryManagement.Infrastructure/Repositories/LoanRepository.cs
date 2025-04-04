using Librarymanagement.Application.Exceptions;
using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain;
using LibraryManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {

            //return await _context.Loans.FindAsync(id);

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                throw new LoanProcessingException($"Loan with ID {id} not found.");
            }
            return loan;
        }

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }       

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Loan>> GetLoansByUserIdAsync(string userId)
        {
            return await _context.Loans.Where(l => l.UserId == userId).ToListAsync();
        }

    }
}
