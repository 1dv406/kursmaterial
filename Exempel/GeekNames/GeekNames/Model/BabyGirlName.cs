using System.Collections.Generic;

namespace GeekNames.Model
{
    /// <summary>
    /// Summary description for BabyGirlName
    /// </summary>
    public class BabyGirlName
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public static IEnumerable<BabyGirlName> GetPopularGirlNames()
        {
            List<BabyGirlName> names = new List<BabyGirlName>(10);

            names.Add(new BabyGirlName { Name = "Wilma", Rank = 1, Number = 922 });
            names.Add(new BabyGirlName { Name = "Maja", Rank = 2, Number = 907 });
            names.Add(new BabyGirlName { Name = "Ella", Rank = 3, Number = 860 });
            names.Add(new BabyGirlName { Name = "Emma", Rank = 4, Number = 835 });
            names.Add(new BabyGirlName { Name = "Julia", Rank = 5, Number = 816 });
            names.Add(new BabyGirlName { Name = "Alice", Rank = 6, Number = 806 });
            names.Add(new BabyGirlName { Name = "Alva", Rank = 7, Number = 781 });
            names.Add(new BabyGirlName { Name = "Linnea", Rank = 8, Number = 778 });
            names.Add(new BabyGirlName { Name = "Ida", Rank = 9, Number = 763 });
            names.Add(new BabyGirlName { Name = "Ebba", Rank = 10, Number = 758 });

            return names;
        }
    }
}