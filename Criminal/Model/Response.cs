using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Model
{
    public class Response
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
    }
}
