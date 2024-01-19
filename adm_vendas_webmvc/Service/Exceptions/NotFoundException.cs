using System;

namespace adm_vendas_webmvc.Service.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
