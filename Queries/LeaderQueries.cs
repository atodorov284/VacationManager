using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Repositories;
using VacationManager.Models;

namespace VacationManager.Queries
{
    public class LeaderQueries
    {
        private readonly VacationManagerDbContext dbContext;
        
        public LeaderQueries(VacationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
