using LibraryManagement.Application.Interfaces;
using LibraryManagement.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

        public LoansController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        // GET: api/loans
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _loanRepository.GetAllAsync();
            return Ok(loans);
        }

        // GET: api/loans/{id}
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan == null)
                return NotFound($"Loan with ID {id} not found.");

            return Ok(loan);
        }

        // POST: api/loans
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddLoan([FromBody] Loan loan)
        {
            if (loan == null)
                return BadRequest("Invalid loan data.");

            await _loanRepository.AddAsync(loan);
            return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
        }

        // PUT: api/loans/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, [FromBody] Loan loan)
        {
            if (loan == null || id != loan.Id)
                return BadRequest("Invalid loan data.");

            var existingLoan = await _loanRepository.GetByIdAsync(id);
            if (existingLoan == null)
                return NotFound($"Loan with ID {id} not found.");

            await _loanRepository.UpdateAsync(loan);
            return NoContent();
        }

        // DELETE: api/loans/{id}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var existingLoan = await _loanRepository.GetByIdAsync(id);
            if (existingLoan == null)
                return NotFound($"Loan with ID {id} not found.");

            await _loanRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
