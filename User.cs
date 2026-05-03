using System;

namespace Calendar
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public User(int id, string name)
        {
            UserId = id;
            UserName = name;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}