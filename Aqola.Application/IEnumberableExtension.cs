using Aqola.Domain.Models;

namespace Aqola.Application
{
    internal static class IEnumberableExtension
    {
        internal static IQueryable<Guest> FilterByOperand(this IEnumerable<Guest> guests, object filterStart, object filterEnd)
        {
            if (filterStart == null || filterEnd == null)
            {
                return guests.AsQueryable();
            }

            if (filterStart is int && filterEnd is int)
                return guests.Where(g => g.Age >= filterStart.ToInt() && g.Age <= filterEnd.ToInt()).AsQueryable();


            switch (filterStart.ToString())
            {
                case ">":
                    return guests.Where(g => g.Age > filterEnd.ToInt()).AsQueryable();
                case "<":
                    return guests.Where(g => g.Age < filterEnd.ToInt()).AsQueryable();
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
