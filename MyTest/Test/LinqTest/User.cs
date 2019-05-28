using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTest
{
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }

        public int Age { get; set; }
        public int SchID { get; set; }
    }
    internal class School
    {
        public int SchID { get; set; }
        public string SchName { get; set; }
        public School() { }
        public School(int id, string name)
        {
            SchID = id;
            SchName = name;
        }
    }
    internal class Company
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Company() { }
        public Company(string name, List<User> list)
        {
            Name = name;
            Users = list;
        }
    }
}
