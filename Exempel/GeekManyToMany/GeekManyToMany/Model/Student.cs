using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekManyToMany.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }

        public string FullName
        {
            get { return String.Format("{0}, {1}", LastName, FirstName); }
        }
    }
}