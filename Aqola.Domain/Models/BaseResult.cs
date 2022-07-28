using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public abstract class ResultBase
    {
        public string Message { get; set; } = "";

        public ResultBase(string message)
        {
            Message = message;
        }
    }
}
