using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekManyToMany.Model
{
    public class Service
    {
        // CoursDate -[ Participant ]- Student

        private static readonly List<CourseDate> _courseDates;
        private static readonly List<Participant> _participants;
        private static readonly List<Student> _students;

        static Service()
        {
            _courseDates = new List<CourseDate>
            {
                new CourseDate { Id = 1, Name = "Kursen A" },
                new CourseDate { Id = 2, Name = "Kursen B" }
            };

            _students = new List<Student>
            {
                new Student { Id = 100, FirstName = "Adam", LastName = "Bertilsson" },
                new Student { Id = 101, FirstName = "Bertil", LastName = "Cesarsson" },
                new Student { Id = 102, FirstName = "Cesar", LastName = "Davidsson" },
                new Student { Id = 103, FirstName = "David", LastName = "Eriksson" },
                new Student { Id = 104, FirstName = "Erik", LastName = "Filipsson" }
            };

            _participants = new List<Participant>
                {
                    new Participant{ Id= 1, CourseDateId = 1, StudentId = 100 },
                    new Participant{ Id= 2, CourseDateId = 1, StudentId = 101 },
                    new Participant{ Id= 3, CourseDateId = 1, StudentId = 102 }
                };
        }

        #region CourseDate (CRUD)

        public IEnumerable<CourseDate> GetCourseDates()
        {
            return _courseDates;
        }

        public CourseDate GetCourseDate(int id)
        {
            return _courseDates.SingleOrDefault(cd => cd.Id == id);
        }

        public void SaveCourseDate(CourseDate courseDate)
        {
            if (courseDate.Id == 0)
            {
                courseDate.Id = _courseDates.Select(cd => cd.Id).Max() + 1; // fake primary key
                _courseDates.Add(courseDate);
            }
            else
            {
                int index = _courseDates.FindIndex(cd => cd.Id == courseDate.Id);
                _courseDates[index] = courseDate;
            }
        }

        public void DeleteCourseDate(int id)
        {
            // Remove course participants...
            foreach (var p in _participants.Where(p => p.CourseDateId == id))
            {
                _participants.Remove(p);
            }

            // ...before we remove the course date (cascade delete - kind of)
            _courseDates.RemoveAt(_courseDates.FindIndex(cd => cd.Id == id));
        }

        #endregion

        #region Participants (CR D)

        public IEnumerable<Participant> GetParticipantsOfCourseDate(int id)
        {
            return _participants.Where(p => p.CourseDateId == id);
        }

        public Participant GetParticipant(int id)
        {
            return _participants.SingleOrDefault(p => p.Id == id);
        }

        public void DeleteParticipant(int id)
        {
            _participants.RemoveAt(_participants.FindIndex(p => p.Id == id));
        }

        public void SaveParticipant(Participant participant)
        {
            if (participant.Id == 0)
            {
                participant.Id = _participants.Select(p => p.Id).Max() + 1; // fake primary key
                _participants.Add(participant);
            }
            else
            {
                throw new ArgumentException("Cannot update a relation object.");
            }
        }

        #endregion

        #region Student ( R  )

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.SingleOrDefault(s => s.Id == id);
        }

        #endregion
    }
}