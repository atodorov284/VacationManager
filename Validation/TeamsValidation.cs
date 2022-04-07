using VacationManager.Repositories;

namespace VacationManager.Validation
{
    public class TeamsValidation
    {
        private VacationManagerDbContext _context;

        public TeamsValidation(VacationManagerDbContext context)
        {
            this._context = context;
        }



        private int ValidateData(bool takenProjectInfo, bool takenUserFirstNameInfo, bool takenUserLastNameInfo, bool takenTemaInfo)
        {
            if (takenTemaInfo)
            {
                return 0;
            }
            if (takenProjectInfo && takenUserFirstNameInfo && takenUserLastNameInfo)
            {
                return -1;
            }
            else if (takenProjectInfo && takenUserFirstNameInfo)
            {
                return -2;
            }
            else if (takenProjectInfo && takenUserLastNameInfo)
            {
                return -3;
            }
            else if (takenProjectInfo)
            {
                return -4;
            }
            else if (takenUserFirstNameInfo && takenUserLastNameInfo)
            {
                return -5;
            }
            else if (takenUserFirstNameInfo)
            {
                return -6;
            }
            else if (takenUserLastNameInfo)
            {
                return -7;
            }
            else
            {
                return 1;
            }
        }
    }
}
