using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekManyToMany.Model
{
    public class Participant
    {
        public int Id { get; set; }
        public int CourseDateId { get; set; }
        public int StudentId { get; set; }
    }
}