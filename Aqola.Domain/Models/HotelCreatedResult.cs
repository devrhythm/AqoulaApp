using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class HotelCreatedResult : ResultBase
    {
        public Hotel Hotel { get; private set; }

        public HotelCreatedResult(string message, Hotel hotel) : base(message)
        {
            Hotel = hotel;
        }
    }
}
