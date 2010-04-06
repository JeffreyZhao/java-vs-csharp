using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace V3.Expressions
{
    public class User
    {
        public int UserID { get; set; }

        public int Name { get; set; }

        public int Age { get; set; }

        public Group Group { get; set; }
    }

    public class Group { }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.UserID);
            Map(u => u.Name);
            Map(u => u.Age);
            References(u => u.Group);
        }
    }
}
