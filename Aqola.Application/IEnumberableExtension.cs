using Aqola.Domain.Models;

namespace Aqola.Application
{
    internal static class IEnumberableExtension
    {
        internal static IEnumerable<Guest> FilterByOperand(this IEnumerable<Guest> guests, object filterStart, object filterEnd)
        {
            if (filterStart == null || filterEnd == null)
            {
                return guests;
            }

            if (filterStart is int && filterEnd is int)
                return guests.Where(g => g.Age >= (int)filterStart && g.Age <= (int)filterEnd).AsEnumerable();

            switch (filterStart.ToString())
            {
                case ">":
                    return guests.Where(g => g.Age > (int)filterEnd).AsEnumerable();
                case "<":
                    return guests.Where(g => g.Age < (int)filterEnd).AsEnumerable();
                default:
                    throw new NotImplementedException();
            }
        }

        internal static string JoinCommaWithSpace<T>(this IEnumerable<T> enumberable)
        {
            return string.Join(", ", enumberable);
        }
    }
}
