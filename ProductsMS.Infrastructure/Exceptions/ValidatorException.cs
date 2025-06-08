using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMS.Infrastructure.Exceptions
{
    public class ValidatorException : Exception
    {
        public ValidatorException(IEnumerable<ValidationFailure> errors)
            : base("Validation failed")
        {
        }

        public ValidatorException(string message)
            : base(message)
        {
        }

        public ValidatorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
