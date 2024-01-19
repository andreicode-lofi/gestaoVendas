using System;

namespace adm_vendas_webmvc.Service.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
            
        }
    }
}
