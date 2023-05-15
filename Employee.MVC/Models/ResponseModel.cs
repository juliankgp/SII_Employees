using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Logistica.Models.Models
{
    public class ResponseModel<T>
    {
        public bool Successfully { get; set; }
        public string? Description { get; set; }
        public T? Result { get; set; }
    }
}
