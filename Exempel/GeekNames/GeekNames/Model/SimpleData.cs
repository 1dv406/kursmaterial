using System.Collections.Generic;

namespace GeekNames.Model
{
    /// <summary>
    /// Summary description for SimpleData
    /// </summary>
    public class SimpleData
    {
        public static IEnumerable<string> GetPopularGrilNames()
        {
            return new string[] { "Wilma", "Maja", "Ella", "Emma", "Julia", 
            "Alice", "Alva", "Linnea", "Ida", "Ebba" };
        }
    }
}