using System;

namespace DIO.AppSeries.Entities
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base (message)
        {
            
        }

    }
}