using NoteProject.DAL.Context;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Repositories
{
    public class UserRepository
    {
        public UserRepository()
        {
            db = new AppDbContext();
        }
        AppDbContext db;

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
        public void Delete(int userId)
        {
            User user = db.Users.Find(userId);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User GetById(int userId)
        {
            User user = db.Users.Find(userId);
            return user;
        }

        public User GetByUserName(string userName)
        {
            User user = db.Users.FirstOrDefault(x => x.UserName == userName);
            return user;
        }

        public List<User> GetStandartUsers()
        {
            List<User> users = db.Users.Where(x => x.UserType == Domain.Enums.UserType.Standart).ToList();
            return users;
        }
    }
}
