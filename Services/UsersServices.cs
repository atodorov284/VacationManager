using System.Linq;
using VacationManager.Models;
using VacationManager.Repositories;
using VacationManager.ViewModels.Users;

namespace VacationManager.Services
{
    public class UsersServices
    {
        private VacationManagerDbContext context;
        private UsersRepository repository;

        public UsersServices(VacationManagerDbContext context, UsersRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }
        public int EditUser(EditUsersVM model)
        {
            User takenUser = context.Users.FirstOrDefault(u => u.UserId == model.Id);

            bool takenInfo = context.Users.FirstOrDefault(x => x.Username == model.Username) != null;

            if (!(takenUser.Username == model.Username))
            {
                if (takenInfo)
                {
                    return -1;
                }
                else if (model.Role != "CEO" && model.Role != "Team Lead" && model.Role != "Developer" && model.Role != "Unassigned")
                {
                    return -2;
                }
            }

            takenUser.Username = model.Username;
            takenUser.FirstName = model.FirstName;
            takenUser.LastName = model.LastName;
            takenUser.Password = model.Password;
            takenUser.Role = model.Role;

            if (takenUser.Role == "Developer" || takenUser.Role == "Unassigned")
            {
                takenUser.PermissionLevel = 0;
            }
            else if (takenUser.Role == "Team Lead")
            {
                takenUser.PermissionLevel = 1;
            }
            else
            {
                takenUser.PermissionLevel = 2;
            }

            repository.Update(takenUser);

            return takenUser.UserId;
        }

        public void DeleteUser(int id)
        {
            User user = context.Users.FirstOrDefault(u => u.UserId == id);

            if (user.TeamId != null)
            {
                Team team = context.Teams.FirstOrDefault(t => t.TeamId == user.TeamId);
                team.Developers.Remove(user);
                context.Teams.Update(team);
            }

            context.Users.Remove(user);
            context.SaveChanges();
        }

        public int Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                return user.UserId;
            }
            return -1;
        }

        public User ViewUser(int id)
        {
            var users = context.Users.Select(u => new User()
            {
                UserId = u.UserId,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                TeamId = u.TeamId,
                Team = u.Team,
                Role = u.Role,
            });

            return users.FirstOrDefault(u => u.UserId == id);
        }

        public void AddUserToTeam(int loggedUserId, int userToBeAddedId)
        {
            User loggedUser = context.Users.FirstOrDefault(u => u.UserId == loggedUserId);

            Team team = context.Teams.FirstOrDefault(t => t.TeamId == loggedUser.TeamId);

            User userToBeAdded = context.Users.FirstOrDefault(u => u.UserId == userToBeAddedId);

            team.Developers.Add(userToBeAdded);
            context.Users.Update(userToBeAdded);
            context.Teams.Update(team);
            context.SaveChanges();
        }

        public AllUsersVM GetAllUsers()
        {

            var users = context.Users.Select(u => new User()
            {
                UserId = u.UserId,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
            });

            var model = new AllUsersVM() { Users = users };

            return model;
        }
    }
}
