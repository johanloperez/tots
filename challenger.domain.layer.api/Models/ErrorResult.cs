using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace challenge.domain.layer.Models
{
    public class ErrorResult
    {
        public bool ErrorMostrable { get; set; }
        public string MensajeError { get; set; }

        public ErrorResult()
        {
            MensajeError = string.Empty;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
