using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHouseApi.Exceptions
{
    public class ValidationError : Exception
    {
        public ValidationError(string message) : base(message)
        {

        }
    }
}