using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPractice
{
    internal class Program
    {
        static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                {')', '('},
                {']', '['},
                {'}', '{'}
            };

            foreach (char c in s)
            {
                if (pairs.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (pairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                        return false;
                }
            }

            return stack.Count == 0;
        }

        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(IsBalanced(input) ? "Balanced" : "Not Balanced");
        }
    }
}

/*input
Input:
- A string containing only brackets: ()[]{}
- Example: "({[]})" or "([)]"
Output:
- "Balanced" if brackets are properly matched and nested
- "Not Balanced" if mismatched, extra, or improperly ordered
Constraints:
- 1 ≤ input length ≤ 10⁶
- Only bracket characters allowed
- Must match pairs and maintain nesting order
Edge Cases:
- Empty string → Balanced
- Single bracket → Not Balanced
- Mismatched pairs → ([)] → Not Balanced
- Extra opening or closing brackets → Not Balanced
- Wrong order → {[}] → Not Balanced
- Deep nesting → "(((((())))))" → Balanced if matched
*/