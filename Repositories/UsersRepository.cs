using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using VacationManager.Models;

namespace VacationManager.Repositories
{
    public class UsersRepository
    {
        private readonly VacationManagerDbContext context;

        public UsersRepository(VacationManagerDbContext context)
        {
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.context.Users.AsQueryable();
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.Where(predicate).AsQueryable();
        }

        public User GetOne(int id)
        {
            return this.context.Users.Find(id);
        }

        public User GetOne(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.FirstOrDefault(predicate);
        }

        public void Add(User entity)
        {
            this.context.Users.Add(entity);
            this.context.SaveChanges();
        }

        public void Update(User entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Remove(User entity)
        {
            this.context.Users.Remove(entity);
            this.context.SaveChanges();
        }

        public int Count()
        {
            return this.context.Users.Count();
        }

        public int Count(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.Count(predicate);
        }
    }
}
