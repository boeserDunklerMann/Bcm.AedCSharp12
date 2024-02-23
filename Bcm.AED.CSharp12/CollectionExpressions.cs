using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcm.AED.CSharp12
{
    /// <summary>
    /// Sammlungsausdrücke (Collection expressions) - siehe Konstruktor
    /// Mir ist nicht klar, wofür man sowas braucht...
    /// </summary>
	internal class CollectionExpressions
	{
        public CollectionExpressions()
        {
            // create array
            int[] intArray = [1, 2, 3, 4, 5, 6];

            // create list
            List<string> stringList = ["André", "Vito", "Mary"];

            // create span
            Span<char> charSpan = ['a', 'b', 'c'];

            // create 2D array
            int[][] twoDee = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

            // use spread operator ..
            int[] test = [.. intArray, .. twoDee[1]];

        }
    }
}
