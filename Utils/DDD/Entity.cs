using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.DDD
{
    public interface IEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt { get; set; }

        IList<IDomainEvent> Events { get; }
    }

    [Serializable]
    public abstract class Entity : IEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        private IList<IDomainEvent> _events;

        public IList<IDomainEvent> Events
        {
            get
            {
                if (_events == null)
                    _events = new List<IDomainEvent>();

                return _events;
            }

        }
    }


    public static class EntityQueries
    {
        public static IQueryable<T> UpdatedSince<T>(this IQueryable<T> list, DateTimeOffset? date) where T : Entity
        {
            if (date.HasValue)
                list = list
                    .Where(e =>
                        (e.UpdatedAt != null && e.UpdatedAt >= date) ||
                        (e.UpdatedAt == null && e.CreatedAt >= date)
                    );

            return list;
        }

        public static IQueryable<T> CreatedAfter<T>(this IQueryable<T> list, DateTimeOffset? date) where T : Entity
        {
            if (date.HasValue)
                list = list.Where(e => e.CreatedAt >= date);

            return list;
        }

        public static IQueryable<T> CreatedBefore<T>(this IQueryable<T> list, DateTimeOffset? date) where T : Entity
        {
            if (date.HasValue)
                list = list.Where(e => e.CreatedAt <= date);

            return list;
        }
    }
}

