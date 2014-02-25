using System.Collections.Generic;
using System.Linq;

namespace GeekPaging.Model
{
    public class SpellingAlphabet
    {
        /// <summary>
        /// Samling av bokstäver och dess bokstavering (fejkar tabell med data i en databas).
        /// </summary>
        private static readonly List<SpellingLetter> _spellingLetters;

        /// <summary>
        /// Initierar bokstaveringarna.
        /// </summary>
        static SpellingAlphabet()
        {
            _spellingLetters = new List<SpellingLetter>
            {
                new SpellingLetter{ Letter = 'A', Swedish = "Adam"},    new SpellingLetter{ Letter = 'B', Swedish = "Bertil"}, 
                new SpellingLetter{ Letter = 'C', Swedish = "Cesar"},   new SpellingLetter{ Letter = 'D', Swedish = "David"}, 
                new SpellingLetter{ Letter = 'E', Swedish = "Erik"},    new SpellingLetter{ Letter = 'F', Swedish = "Filip"}, 
                new SpellingLetter{ Letter = 'G', Swedish = "Gustav"},  new SpellingLetter{ Letter = 'H', Swedish = "Helge"},
                new SpellingLetter{ Letter = 'I', Swedish = "Ivar"},    new SpellingLetter{ Letter = 'J', Swedish = "Johan"}, 
                new SpellingLetter{ Letter = 'K', Swedish = "Kalle"},   new SpellingLetter{ Letter = 'L', Swedish = "Ludvig"}, 
                new SpellingLetter{ Letter = 'M', Swedish = "Martin"},  new SpellingLetter{ Letter = 'N', Swedish = "Niklas"}, 
                new SpellingLetter{ Letter = 'O', Swedish = "Olof"},    new SpellingLetter{ Letter = 'P', Swedish = "Petter"}, 
                new SpellingLetter{ Letter = 'Q', Swedish = "Qvintus"}, new SpellingLetter{ Letter = 'R', Swedish = "Rudolf"},
                new SpellingLetter{ Letter = 'S', Swedish = "Sigurd"},  new SpellingLetter{ Letter = 'T', Swedish = "Tore"}, 
                new SpellingLetter{ Letter = 'U', Swedish = "Urban"},   new SpellingLetter{ Letter = 'V', Swedish = "Viktor"}, 
                new SpellingLetter{ Letter = 'W', Swedish = "Wilhelm"}, new SpellingLetter{ Letter = 'X', Swedish = "Xerxes"},
                new SpellingLetter{ Letter = 'Y', Swedish = "Yngve"},   new SpellingLetter{ Letter = 'Z', Swedish = "Zäta"}, 
                new SpellingLetter{ Letter = 'Å', Swedish = "Åke"},     new SpellingLetter{ Letter = 'Ä', Swedish = "Ärlig"}, 
                new SpellingLetter{ Letter = 'Ö', Swedish = "Östen"}
            };
        }

        /// <summary>
        /// Hämtar sida med bokstaveringar.
        /// </summary>
        /// <param name="maximumRows">Maximala antalet rader en sida kan innehålla.</param>
        /// <param name="startRowIndex">Startindex för efterfrågad sida.</param>
        /// <param name="totalRowCount">Totala antalet rader.</param>
        /// <returns>Lista med referenser till bokstaveringar.</returns>
        public IEnumerable<SpellingLetter> GetPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            totalRowCount = _spellingLetters.Count;

            return _spellingLetters.Skip(startRowIndex).Take(maximumRows);
        }

        /// <summary>
        /// Tar bort en bokstavering.
        /// </summary>
        /// <param name="letter">Bokstav som identifierar den bokstavering som ska tas bort.</param>
        public void Remove(char letter)
        {
            // Hittar index för data att ta bort och...
            var index = _spellingLetters.FindIndex(sl => sl.Letter == letter);

            // ...tar bort det ur samlingen med bokstaveringar.
            _spellingLetters.RemoveAt(index);
        }
    }
}