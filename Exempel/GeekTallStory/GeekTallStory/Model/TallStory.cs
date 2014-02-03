
namespace GeekTallStory.Model
{
    /// <summary>
    /// Klassen avspeglar tabellen TallStory i databasen. En instans
    /// av klassen motsvarar en post i tabellen. Tabellens namn och fält
    /// tjänar som "mall" för klassens och egenskapernas namn.
    /// </summary>
    public class TallStory
    {
        // Varje egenskap har sin motsvarighet beträffande namn och typ
        // i tabellen TallStory i databasen.

        public int TallStoryId { get; set; }
        public string Header { get; set; }
        public string Phrase { get; set; }
    }
}