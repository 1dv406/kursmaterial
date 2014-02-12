using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekNames.Model
{
    public enum Gender { Female, Male };

    /// <summary>
    /// Summary description for BabyName
    /// </summary>
    public class BabyName : IComparable<BabyName>
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Number { get; set; }

        public BabyName(string name, Gender gender, int number)
        {
            Name = name;
            Gender = gender;
            Number = number;
        }

        public static IEnumerable<BabyName> GetBabyNames()
        {
            List<BabyName> names = new List<BabyName>(20);

            names.Add(new BabyName("Wilma", Gender.Female, 922));
            names.Add(new BabyName("Maja", Gender.Female, 907));
            names.Add(new BabyName("Ella", Gender.Female, 860));
            names.Add(new BabyName("Emma", Gender.Female, 835));
            names.Add(new BabyName("Julia", Gender.Female, 816));
            names.Add(new BabyName("Alice", Gender.Female, 806));
            names.Add(new BabyName("Alva", Gender.Female, 781));
            names.Add(new BabyName("Linnea", Gender.Female, 778));
            names.Add(new BabyName("Ida", Gender.Female, 763));
            names.Add(new BabyName("Ebba", Gender.Female, 758));
            names.Add(new BabyName("William", Gender.Male, 1166));
            names.Add(new BabyName("Lucas", Gender.Male, 1065));
            names.Add(new BabyName("Elias", Gender.Male, 1047));
            names.Add(new BabyName("Oscar", Gender.Male, 996));
            names.Add(new BabyName("Hugo", Gender.Male, 964));
            names.Add(new BabyName("Viktor", Gender.Male, 892));
            names.Add(new BabyName("Filip", Gender.Male, 868));
            names.Add(new BabyName("Erik", Gender.Male, 857));
            names.Add(new BabyName("Emil", Gender.Male, 840));
            names.Add(new BabyName("Isak", Gender.Male, 838));

            // Sortering med IComparable.
            names.Sort();
            return names;

            // Sortering med LINQ.
            //return names.OrderByDescending(n => n.Number).ThenBy(n => n.Name).AsEnumerable();
        }

        #region IComparable<BabyName> Members

        public int CompareTo(BabyName other)
        {
            if (other == null)
            {
                return 1;
            }

            int retValue = other.Number - this.Number;
            if (retValue == 0)
            {
                retValue = this.Name.CompareTo(other.Name);
            }
            return retValue;
        }

        #endregion

    }
}