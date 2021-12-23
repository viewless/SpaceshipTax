using System;

namespace SpaceshipTax.Services.ExceptionHandling
{
    public class ValidationException : Exception
    {
        public ValidationException() : base() { }

        public ValidationException(string message) : base(message) { }

    }
}
