using System.Collections.Generic;
using System.Linq;

namespace GeekNames.Model
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    public class Service
    {
        public IEnumerable<string> GetPopularGirlNames()
        {
            return SimpleData.GetPopularGrilNames();
        }

        public IEnumerable<string> GetPopularGirlNamesOrderedByName()
        {
            return (from name in SimpleData.GetPopularGrilNames()
                    orderby name
                    select name).ToArray();
        }

        public IEnumerable<string> GetPopularGirlNamesOrderedByLength()
        {
            return (from name in SimpleData.GetPopularGrilNames()
                    orderby name.Length, name
                    select name).ToArray();
        }

        public IEnumerable<BabyGirlName> GetPopularBabyGirlNames()
        {
            return BabyGirlName.GetPopularGirlNames();
        }

        public IEnumerable<BabyName> GetPopularBabyNames()
        {
            return BabyName.GetBabyNames();
        }
    }
}