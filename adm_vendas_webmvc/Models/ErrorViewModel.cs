using System;

namespace adm_vendas_webmvc.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string Message { get; set; }// atributo para enviar uma msg de erro
                                           // customizad 
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
