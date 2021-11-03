using System;
using System.Net;

namespace Hdn.Onboarding.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }

        public string ErrorMessage { get; set; }

        public ApiException()
        {

        }

        public ApiException(HttpStatusCode status)
        {
            Status = (int)status;
        }

        public ApiException(HttpStatusCode status, string message)
        {
            Status = (int)status;
            this.ErrorMessage = message;
        }

        public ApiException(int status)
        {
            Status = status;
        }
    }
}
