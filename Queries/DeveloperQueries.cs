using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Repositories;
using VacationManager.Models;

namespace VacationManager.Queries
{
    public class DeveloperQueries
    {
        private readonly VacationManagerDbContext dbContext;
        
        public DeveloperQueries(VacationManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
