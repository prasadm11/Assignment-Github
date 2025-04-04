using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarymanagement.Application.Exceptions
{
    public class LoanProcessingException : Exception  
    {
        public LoanProcessingException(string message) : base(message) { }
    }
}
