using ClayBackendCase.API.Core.Entities;
using ClayBackendCase.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClayBackendCase.API.Infrastructure.Data
{
    public class EventRepository : EfRepository<Event>, IEventRepository
    {
        public EventRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
