using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Model;

namespace Test.Service
{
    public class DataService : IService<User>
    {
        public DataService(MyContext context)
        {
            _context = context;
        }

        public MyContext _context { get; }

        public User Add(User model)
        {
            _context.User.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(int id)
        {
            var user = _context.User.Find(id);
            return user;
        }
    }
}
