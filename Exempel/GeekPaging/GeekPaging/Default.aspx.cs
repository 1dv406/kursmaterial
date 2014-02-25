using System;
using System.Collections.Generic;
using GeekPaging.Model;

namespace GeekPaging
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Bokstaveringar.
        /// </summary>
        private SpellingAlphabet _spellingAlphabet;
        private SpellingAlphabet SpellingAlphabet
        {
            get { return _spellingAlphabet ?? (_spellingAlphabet = new SpellingAlphabet()); }
        }

        /// <summary>
        /// Returnerar efterfråga sida med bokstaveringar.
        /// </summary>
        /// <param name="maximumRows">Det maximala antalet rader på en sida.</param>
        /// <param name="startRowIndex">Startindex för efterfrågad sida.</param>
        /// <param name="totalRowCount">Totala antalet rader.</param>
        /// <returns></returns>
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression (implementerar inte sortering varför denna parameter inte används)
        //                              ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        public IEnumerable<SpellingLetter> SpellingAlphabetListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return SpellingAlphabet.GetPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        /// <summary>
        /// Raderar angiven bokstavering.
        /// </summary>
        /// <param name="letter"></param>
        // The id parameter name should match the DataKeyNames value set on the control
        public void SpellingAlphabetListView_DeleteItem(char letter)
        {
            SpellingAlphabet.Remove(letter);
        }
    }
}