using System;

namespace TemperatureDifference.Model
{
    public class TemperatureCalculator
    {
        public int Min { get; set; }
        public int Max { get; set; }

        // Inte kanske den bästa implementationen - men ett undantag kastas i alla fall
        // vilket är det viktigaste för att demonstrera fel i affärslogiklagret.
        public int Difference 
        {
            get
            {
                if (Max < Min)
                {
                    throw new ApplicationException("Mintemperaturen kan inte vara högre än maxtemperaturen.");
                }

                return Max - Min;
            }
        }
    }
}